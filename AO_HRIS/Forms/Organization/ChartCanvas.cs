using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    // Double-buffered, top-to-bottom reporting diagram. No third-party packages.
    internal sealed class ChartCanvas : Control
    {
        internal sealed class Card
        {
            public int Id;
            public int? ParentId;
            public string Name, Position, Department, Number;
        }
        private sealed class Node
        {
            public Card Card;
            public readonly List<Node> Children = new List<Node>();
            public float Width;
            public float Center;
            public int Depth;
            public RectangleF Bounds;
        }
        private const float CardWidth = 208f, CardHeight = 86f, GapX = 24f, GapY = 68f;
        private readonly List<Node> roots = new List<Node>();
        private readonly List<Node> drawn = new List<Node>();
        private HashSet<int> collapsed = new HashSet<int>();
        private float zoom = 1f, offsetX = 30f, offsetY = 30f;
        private float diagramWidth, diagramHeight;
        private Point dragStart;
        private bool dragging;
        private int selectedId = -1;
        public event Action<int> CardSelected;

        public ChartCanvas()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Cursor = Cursors.Hand;
        }
        public void SetCards(IEnumerable<Card> cards, HashSet<int> collapsedIds)
        {
            collapsed = new HashSet<int>(collapsedIds);
            roots.Clear(); drawn.Clear();
            var nodes = cards.ToDictionary(c => c.Id, c => new Node { Card = c });
            foreach (Node node in nodes.Values)
            {
                Node parent;
                if (node.Card.ParentId.HasValue && nodes.TryGetValue(node.Card.ParentId.Value, out parent)
                    && parent != node) parent.Children.Add(node);
                else roots.Add(node);
            }
            Comparison<Node> order = (a, b) => string.Compare(a.Card.Name, b.Card.Name, StringComparison.CurrentCultureIgnoreCase);
            roots.Sort(order);
            foreach (Node node in nodes.Values) node.Children.Sort(order);
            float cursor = 0f;
            foreach (Node root in roots)
            {
                Measure(root, new HashSet<int>());
                Place(root, cursor, 0, new HashSet<int>());
                cursor += root.Width + GapX * 2;
            }
            diagramWidth = Math.Max(0, cursor - GapX * 2);
            diagramHeight = drawn.Count == 0 ? 0 : drawn.Max(n => n.Bounds.Bottom);
            Fit();
        }
        private float Measure(Node node, HashSet<int> path)
        {
            if (!path.Add(node.Card.Id)) return CardWidth;
            float total = 0;
            if (!collapsed.Contains(node.Card.Id))
                foreach (Node child in node.Children)
                    total += Measure(child, path) + GapX;
            path.Remove(node.Card.Id);
            node.Width = Math.Max(CardWidth, total > 0 ? total - GapX : CardWidth);
            return node.Width;
        }
        private void Place(Node node, float left, int depth, HashSet<int> path)
        {
            if (!path.Add(node.Card.Id)) return;
            node.Depth = depth;
            node.Center = left + node.Width / 2;
            node.Bounds = new RectangleF(node.Center - CardWidth / 2, depth * (CardHeight + GapY), CardWidth, CardHeight);
            drawn.Add(node);
            if (!collapsed.Contains(node.Card.Id))
            {
                float childLeft = left;
                foreach (Node child in node.Children)
                {
                    Place(child, childLeft, depth + 1, path);
                    childLeft += child.Width + GapX;
                }
            }
            path.Remove(node.Card.Id);
        }
        public void ZoomBy(float factor)
        {
            float next = Math.Max(.15f, Math.Min(2.5f, zoom * factor));
            float centerX = ClientSize.Width / 2f, centerY = ClientSize.Height / 2f;
            float ratio = next / zoom;
            offsetX = centerX - (centerX - offsetX) * ratio;
            offsetY = centerY - (centerY - offsetY) * ratio;
            zoom = next; Invalidate();
        }
        public void Fit()
        {
            if (diagramWidth <= 0 || diagramHeight <= 0 || Width <= 0 || Height <= 0)
            { zoom = 1; offsetX = 30; offsetY = 30; Invalidate(); return; }
            zoom = Math.Min(1f, Math.Min((Width - 48f) / diagramWidth, (Height - 48f) / diagramHeight));
            zoom = Math.Max(.15f, zoom);
            offsetX = (Width - diagramWidth * zoom) / 2f;
            offsetY = 24;
            Invalidate();
        }
        protected override void OnResize(EventArgs e) { base.OnResize(e); if (drawn.Count > 0) Fit(); }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (drawn.Count == 0)
            {
                using (var brush = new SolidBrush(Color.FromArgb(107,124,144)))
                    g.DrawString("No active employee assignments found.", Font, brush, 24, 24);
                return;
            }
            g.TranslateTransform(offsetX, offsetY); g.ScaleTransform(zoom, zoom);
            using (var pen = new Pen(Color.FromArgb(147,169,194), 2f))
            {
                foreach (Node parent in drawn)
                {
                    if (collapsed.Contains(parent.Card.Id)) continue;
                    foreach (Node child in parent.Children)
                    {
                        if (!drawn.Contains(child)) continue;
                        float x1 = parent.Center, y1 = parent.Bounds.Bottom;
                        float x2 = child.Center, y2 = child.Bounds.Top;
                        float mid = (y1 + y2) / 2;
                        g.DrawLine(pen, x1, y1, x1, mid);
                        g.DrawLine(pen, x1, mid, x2, mid);
                        g.DrawLine(pen, x2, mid, x2, y2);
                    }
                }
            }
            using (var nameFont = new Font("Segoe UI", 10f, FontStyle.Bold))
            using (var bodyFont = new Font("Segoe UI", 8.5f))
            using (var white = new SolidBrush(Color.White))
            using (var dark = new SolidBrush(Color.FromArgb(28,55,91)))
            using (var muted = new SolidBrush(Color.FromArgb(107,124,144)))
            using (var blue = new SolidBrush(Color.FromArgb(35,106,213)))
            using (var border = new Pen(Color.FromArgb(194,210,228)))
            {
                foreach (Node n in drawn)
                {
                    RectangleF r = n.Bounds;
                    bool isRoot = !n.Card.ParentId.HasValue || !drawn.Any(x => x.Card.Id == n.Card.ParentId.Value);
                    bool selected = n.Card.Id == selectedId;
                    using (GraphicsPath path = RoundedRect(r, 9))
                    {
                        g.FillPath(isRoot ? blue : white, path);
                        if (!isRoot) g.DrawPath(selected ? Pens.DodgerBlue : border, path);
                    }
                    Brush titleBrush = isRoot ? white : dark;
                    Brush subBrush = isRoot ? white : muted;
                    using (var fmt = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                    {
                        g.DrawString(n.Card.Name ?? "", nameFont, titleBrush, new RectangleF(r.X+12,r.Y+10,r.Width-24,21), fmt);
                        g.DrawString(n.Card.Position ?? "", bodyFont, subBrush, new RectangleF(r.X+12,r.Y+36,r.Width-24,18), fmt);
                        g.DrawString(n.Card.Department ?? "", bodyFont, subBrush, new RectangleF(r.X+12,r.Y+58,r.Width-24,18), fmt);
                    }
                    if (n.Children.Count > 0)
                    {
                        RectangleF circle = new RectangleF(r.Right - 15, r.Bottom - 13, 22, 22);
                        g.FillEllipse(blue, circle);
                        g.DrawString(collapsed.Contains(n.Card.Id) ? "+" : "−", bodyFont, white, circle.X+6, circle.Y+2);
                    }
                }
            }
        }
        private static GraphicsPath RoundedRect(RectangleF r, float radius)
        {
            float d = radius * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right-d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right-d, r.Bottom-d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom-d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left) { dragStart = e.Location; dragging = false; Capture = true; }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Capture && (Control.MouseButtons & MouseButtons.Left) != 0)
            {
                int dx = e.X - dragStart.X, dy = e.Y - dragStart.Y;
                if (Math.Abs(dx) + Math.Abs(dy) > 2) dragging = true;
                offsetX += dx; offsetY += dy; dragStart = e.Location; Invalidate();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e); Capture = false;
            if (e.Button != MouseButtons.Left || dragging) return;
            PointF point = new PointF((e.X-offsetX)/zoom,(e.Y-offsetY)/zoom);
            Node node = drawn.LastOrDefault(n => n.Bounds.Contains(point));
            if (node == null) return;
            selectedId = node.Card.Id;
            if (CardSelected != null) CardSelected(selectedId);
            if (node.Children.Count > 0)
            {
                if (!collapsed.Add(node.Card.Id)) collapsed.Remove(node.Card.Id);
                // Re-layout the current graph without losing zoom/pan.
                float oldZoom = zoom, oldX = offsetX, oldY = offsetY;
                var cards = AllCards().ToList();
                SetCards(cards, collapsed);
                zoom = oldZoom; offsetX = oldX; offsetY = oldY;
            }
            Invalidate();
        }
        private IEnumerable<Card> AllCards()
        {
            var seen = new HashSet<int>();
            var stack = new Stack<Node>(roots);
            while (stack.Count > 0)
            {
                Node n = stack.Pop();
                if (!seen.Add(n.Card.Id)) continue;
                yield return n.Card;
                foreach (Node c in n.Children) stack.Push(c);
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            ZoomBy(e.Delta > 0 ? 1.1f : 1f/1.1f);
        }
    }
}
