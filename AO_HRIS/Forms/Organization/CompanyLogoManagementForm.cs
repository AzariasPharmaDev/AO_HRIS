using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AO_HRIS.Forms.Organization
{
    public partial class CompanyLogoManagementForm : Form
    {
        private readonly OrganizationRepository _repository = new OrganizationRepository();
        private byte[] _pendingLogo;
        private string _pendingFileName;
        private string _pendingContentType;
        private const int MaxLogoBytes = 2 * 1024 * 1024;

        public CompanyLogoManagementForm()
        {
            InitializeComponent();
        }

        public CompanyLogoManagementForm(int companyId) : this()
        {
            _initialCompanyId = companyId;
        }

        private int? _initialCompanyId;

        private void CompanyLogoManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable companies = _repository.GetCompanies();
                cmbCompany.DisplayMember = "CompanyName";
                cmbCompany.ValueMember = "CompanyId";
                cmbCompany.DataSource = companies;
                cmbCompany.SelectedIndex = -1;
                if (_initialCompanyId.HasValue)
                    cmbCompany.SelectedValue = _initialCompanyId.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Companies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? SelectedCompanyId()
        {
            if (cmbCompany.SelectedValue is int)
                return (int)cmbCompany.SelectedValue;
            return null;
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pendingLogo = null;
            _pendingFileName = null;
            _pendingContentType = null;
            LoadLogo();
        }

        private void LoadLogo()
        {
            ReplacePreview(null);
            lblFileName.Text = "No logo selected";
            int? companyId = SelectedCompanyId();
            btnUpload.Enabled = companyId.HasValue;
            btnSave.Enabled = false;
            btnRemove.Enabled = false;
            if (!companyId.HasValue) return;
            try
            {
                byte[] data = _repository.GetCompanyLogoData(companyId.Value);
                if (data != null && data.Length > 0)
                {
                    ShowPreview(data);
                    lblFileName.Text = "Current company logo";
                    btnRemove.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Logo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReplacePreview(Image image)
        {
            Image old = picLogo.Image;
            picLogo.Image = image;
            if (old != null) old.Dispose();
        }

        private void ShowPreview(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            using (Image image = Image.FromStream(stream, true, true))
            {
                ReplacePreview(new Bitmap(image));
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!SelectedCompanyId().HasValue) return;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose Company Logo";
                dialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    FileInfo info = new FileInfo(dialog.FileName);
                    if (info.Length == 0 || info.Length > MaxLogoBytes)
                    {
                        MessageBox.Show("Choose an image no larger than 2 MB.");
                        return;
                    }

                    byte[] data = File.ReadAllBytes(dialog.FileName);
                    string contentType;
                    using (MemoryStream stream = new MemoryStream(data))
                    using (Image image = Image.FromStream(stream, true, true))
                    {
                        if (image.RawFormat.Guid == ImageFormat.Png.Guid)
                            contentType = "image/png";
                        else if (image.RawFormat.Guid == ImageFormat.Jpeg.Guid)
                            contentType = "image/jpeg";
                        else
                        {
                            MessageBox.Show("Only PNG and JPEG images are supported.");
                            return;
                        }
                        ReplacePreview(new Bitmap(image));
                    }
                    _pendingLogo = data;
                    _pendingFileName = Path.GetFileName(dialog.FileName);
                    _pendingContentType = contentType;
                    lblFileName.Text = _pendingFileName + " (not saved)";
                    btnSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Read Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? companyId = SelectedCompanyId();
            if (!companyId.HasValue || _pendingLogo == null) return;
            try
            {
                btnSave.Enabled = false;
                _repository.SaveCompanyLogo(companyId.Value, _pendingLogo, _pendingFileName, _pendingContentType);
                _pendingLogo = null;
                _pendingFileName = null;
                _pendingContentType = null;
                LoadLogo();
                MessageBox.Show("Company logo saved successfully.", "Company Logo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                MessageBox.Show(ex.Message, "Save Logo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int? companyId = SelectedCompanyId();
            if (!companyId.HasValue) return;
            if (MessageBox.Show("Remove this company's logo?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                _repository.DeleteCompanyLogo(companyId.Value);
                _pendingLogo = null;
                _pendingFileName = null;
                _pendingContentType = null;
                LoadLogo();
                MessageBox.Show("Company logo removed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove Logo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
