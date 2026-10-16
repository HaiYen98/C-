using QuanLySinhVien.Business;
using QuanLySinhVien.Models;

namespace QuanLySinhVien;

public partial class Form1 : Form
{
    private readonly StudentBusiness _studentBusiness = new();
    private readonly StudentClassBusiness _classBusiness = new();
    private bool _updatingControls;
    private bool _isEditing;

    public Form1()
    {
        InitializeComponent();
        ConfigureGrid();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _updatingControls = true;

        var classes = _classBusiness.GetAll().ToList();
        cboLop.DataSource = classes;
        cboLop.DisplayMember = nameof(StudentClass.Name);
        cboLop.ValueMember = nameof(StudentClass.Id);
        cboLop.SelectedIndex = classes.Count > 0 ? 0 : -1;

        var filterClasses = new List<StudentClass>
        {
            new() { Id = string.Empty, Name = "Tất cả lớp" }
        };
        filterClasses.AddRange(classes);
        cboLocLop.DataSource = filterClasses;
        cboLocLop.DisplayMember = nameof(StudentClass.Name);
        cboLocLop.ValueMember = nameof(StudentClass.Id);
        cboLocLop.SelectedIndex = 0;
        cboTrangThai.SelectedIndex = cboTrangThai.Items.Count > 0 ? 0 : -1;

        _updatingControls = false;
        SetNewStudentMode();
        RefreshStudents();
    }

    private void Form1_Shown(object sender, EventArgs e) => txtMaSV.Focus();

    private void ConfigureGrid()
    {
        dataGridView1.AutoGenerateColumns = false;
        AddGridColumn(nameof(Student.Id), "Mã SV");
        AddGridColumn(nameof(Student.FullName), "Họ và tên");
        AddGridColumn(nameof(Student.DateOfBirth), "Ngày sinh", "dd/MM/yyyy");
        AddGridColumn(nameof(Student.Gender), "Giới tính");
        AddGridColumn(nameof(Student.Email), "Email");
        AddGridColumn(nameof(Student.Phone), "Điện thoại");
        AddGridColumn(nameof(Student.Score), "Điểm", "0.##");
        AddGridColumn(nameof(Student.ClassName), "Lớp");
        AddGridColumn(nameof(Student.Status), "Trạng thái");
    }

    private void AddGridColumn(string propertyName, string headerText, string? format = null)
    {
        var column = new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = headerText,
            Name = propertyName,
            SortMode = DataGridViewColumnSortMode.Automatic
        };

        if (format is not null)
        {
            column.DefaultCellStyle.Format = format;
        }

        dataGridView1.Columns.Add(column);
    }

    private void RefreshStudents()
    {
        var classId = cboLocLop.SelectedValue as string;
        IReadOnlyList<Student> students = string.IsNullOrEmpty(classId)
            ? _studentBusiness.GetAll()
            : _studentBusiness.GetByClassId(classId);

        var keyword = txtTimKiem.Text.Trim();
        if (keyword.Length > 0)
        {
            students = students.Where(student =>
                student.Id.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                student.FullName.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                student.Email.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                student.Phone.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                student.ClassName.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        var minimumScore = nudDiemLoc.Value;
        students = students.Where(student => student.Score >= minimumScore).ToList();
        var result = students.ToList();
        dataGridView1.DataSource = result;
        lblTongSo.Text = $"Tổng số: {result.Count} sinh viên";
    }

    private Student ReadStudentForm() => new()
    {
        Id = txtMaSV.Text.Trim(),
        FullName = txtHoTen.Text.Trim(),
        DateOfBirth = dtpNgaySinh.Value.Date,
        Email = txtEmail.Text.Trim(),
        Phone = txtDienThoai.Text.Trim(),
        Gender = rbNam.Checked ? rbNam.Text : rbNu.Checked ? rbNu.Text : string.Empty,
        ClassId = cboLop.SelectedValue as string ?? string.Empty,
        Score = nudDiem.Value,
        Status = cboTrangThai.SelectedItem as string ?? string.Empty
    };

    private void txtMaSV_TextChanged(object sender, EventArgs e)
    {
        if (_updatingControls)
        {
            return;
        }

        ClearErrors();
        var student = _studentBusiness.GetById(txtMaSV.Text.Trim());
        if (student is null)
        {
            ClearStudentFields(clearId: false);
            SetNewStudentMode();
            return;
        }

        FillStudentFields(student);
        SetExistingStudentMode();
    }

    private void FillStudentFields(Student student)
    {
        _updatingControls = true;
        txtMaSV.Text = student.Id;
        txtHoTen.Text = student.FullName;
        dtpNgaySinh.Value = student.DateOfBirth;
        txtEmail.Text = student.Email;
        txtDienThoai.Text = student.Phone;
        rbNam.Checked = student.Gender == rbNam.Text;
        rbNu.Checked = student.Gender == rbNu.Text;
        cboLop.SelectedValue = student.ClassId;
        nudDiem.Value = Math.Clamp(student.Score, nudDiem.Minimum, nudDiem.Maximum);
        cboTrangThai.SelectedItem = student.Status;
        _updatingControls = false;
    }

    private void ClearStudentFields(bool clearId)
    {
        _updatingControls = true;
        if (clearId)
        {
            txtMaSV.Clear();
        }

        txtHoTen.Clear();
        dtpNgaySinh.Value = DateTime.Today;
        txtEmail.Clear();
        txtDienThoai.Clear();
        rbNam.Checked = false;
        rbNu.Checked = false;
        nudDiem.Value = nudDiem.Minimum;
        cboLop.SelectedIndex = -1;
        cboTrangThai.SelectedIndex = -1;
        _updatingControls = false;
        ClearErrors();
        SetNewStudentMode();
    }

    private void SetNewStudentMode()
    {
        _isEditing = false;
        txtMaSV.Enabled = true;
        SetDetailFieldsEnabled(true);
        btnThem.Enabled = true;
        btnSua.Enabled = false;
        btnSua.Text = "Sửa";
        btnXoa.Enabled = false;
    }

    private void SetExistingStudentMode()
    {
        _isEditing = false;
        txtMaSV.Enabled = true;
        SetDetailFieldsEnabled(false);
        btnThem.Enabled = false;
        btnSua.Enabled = true;
        btnSua.Text = "Sửa";
        btnXoa.Enabled = true;
    }

    private void SetDetailFieldsEnabled(bool enabled)
    {
        txtHoTen.Enabled = enabled;
        dtpNgaySinh.Enabled = enabled;
        rbNam.Enabled = enabled;
        rbNu.Enabled = enabled;
        txtEmail.Enabled = enabled;
        txtDienThoai.Enabled = enabled;
        cboLop.Enabled = enabled;
        nudDiem.Enabled = enabled;
        cboTrangThai.Enabled = enabled;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        var student = ReadStudentForm();
        if (!_studentBusiness.Add(student, out var errors))
        {
            ShowErrors(errors);
            return;
        }

        RefreshStudents();
        ClearStudentFields(clearId: true);
        MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        FocusStudentId();
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (!_isEditing)
        {
            _isEditing = true;
            txtMaSV.Enabled = false;
            SetDetailFieldsEnabled(true);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Text = "Lưu sửa";
            txtHoTen.Focus();
            return;
        }

        var student = ReadStudentForm();
        if (!_studentBusiness.Update(student, out var errors))
        {
            ShowErrors(errors);
            return;
        }

        FillStudentFields(student);
        SetExistingStudentMode();
        RefreshStudents();
        MessageBox.Show("Cập nhật sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        var id = txtMaSV.Text.Trim();
        if (string.IsNullOrWhiteSpace(id) || _studentBusiness.GetById(id) is null)
        {
            errorProvider1.SetError(txtMaSV, "Vui lòng nhập mã sinh viên tồn tại.");
            return;
        }

        if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
        {
            return;
        }

        _studentBusiness.Delete(id);
        RefreshStudents();
        ClearStudentFields(clearId: true);
        FocusStudentId();
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        ClearStudentFields(clearId: true);
        FocusStudentId();
    }

    private void btnTimKiem_Click(object sender, EventArgs e) => RefreshStudents();

    private void btnHienThiTatCa_Click(object sender, EventArgs e)
    {
        _updatingControls = true;
        txtTimKiem.Clear();
        cboLocLop.SelectedIndex = 0;
        nudDiemLoc.Value = nudDiemLoc.Minimum;
        _updatingControls = false;
        RefreshStudents();
    }

    private void cboLocLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_updatingControls)
        {
            RefreshStudents();
        }
    }

    private void nudDiemLoc_ValueChanged(object sender, EventArgs e)
    {
        if (!_updatingControls)
        {
            RefreshStudents();
        }
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Student student)
        {
            FillStudentFields(student);
            SetExistingStudentMode();
        }
    }

    private void ShowErrors(Dictionary<string, string> errors)
    {
        ClearErrors();
        foreach (var (field, message) in errors)
        {
            var control = field switch
            {
                nameof(Student.Id) => (Control)txtMaSV,
                nameof(Student.FullName) => txtHoTen,
                nameof(Student.Email) => txtEmail,
                nameof(Student.Phone) => txtDienThoai,
                nameof(Student.ClassId) => cboLop,
                nameof(Student.Score) => nudDiem,
                _ => null
            };

            if (control is not null)
            {
                errorProvider1.SetError(control, message);
            }
        }
    }

    private void ClearErrors()
    {
        foreach (Control control in groupBox1.Controls)
        {
            errorProvider1.SetError(control, string.Empty);
        }
    }

    private void FocusStudentId() => BeginInvoke((Action)(() => txtMaSV.Focus()));
}
