namespace QuanLySinhVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;
        private GroupBox groupBox1 = null!;
        private Label lblMa = null!;
        private TextBox txtMaSV = null!;
        private Label lblHoTen = null!;
        private TextBox txtHoTen = null!;
        private Label lblNgaySinh = null!;
        private DateTimePicker dtpNgaySinh = null!;
        private Label lblGioiTinh = null!;
        private RadioButton rbNam = null!;
        private RadioButton rbNu = null!;
        private Label lblEmail = null!;
        private TextBox txtEmail = null!;
        private Label lblDienThoai = null!;
        private TextBox txtDienThoai = null!;
        private Label lblLop = null!;
        private ComboBox cboLop = null!;
        private Label lblDiem = null!;
        private NumericUpDown nudDiem = null!;
        private Label lblTrangThai = null!;
        private ComboBox cboTrangThai = null!;
        private Button btnThem = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private Button btnLamMoi = null!;
        private GroupBox groupBox2 = null!;
        private Label lblTimKiem = null!;
        private TextBox txtTimKiem = null!;
        private Label lblLocLop = null!;
        private ComboBox cboLocLop = null!;
        private Label lblDiemLoc = null!;
        private NumericUpDown nudDiemLoc = null!;
        private Button btnTimKiem = null!;
        private Button btnHienThiTatCa = null!;
        private GroupBox groupBox3 = null!;
        private DataGridView dataGridView1 = null!;
        private Label lblTongSo = null!;
        private ErrorProvider errorProvider1 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            lblMa = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            rbNam = new RadioButton();
            rbNu = new RadioButton();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblDiem = new Label();
            nudDiem = new NumericUpDown();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            groupBox2 = new GroupBox();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            lblLocLop = new Label();
            cboLocLop = new ComboBox();
            lblDiemLoc = new Label();
            nudDiemLoc = new NumericUpDown();
            btnTimKiem = new Button();
            btnHienThiTatCa = new Button();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            lblTongSo = new Label();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemLoc).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.AddRange(new Control[]
            {
                lblMa, txtMaSV, lblHoTen, txtHoTen, lblNgaySinh, dtpNgaySinh,
                lblGioiTinh, rbNam, rbNu, lblEmail, txtEmail, lblDienThoai,
                txtDienThoai, lblLop, cboLop, lblDiem, nudDiem, lblTrangThai,
                cboTrangThai, btnThem, btnSua, btnXoa, btnLamMoi
            });
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1169, 220);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // lblMa, txtMaSV
            // 
            lblMa.AutoSize = true;
            lblMa.Location = new Point(22, 32);
            lblMa.Text = "Mã sinh viên*";
            txtMaSV.Location = new Point(130, 28);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(220, 23);
            txtMaSV.TabIndex = 0;
            txtMaSV.TextChanged += txtMaSV_TextChanged;
            // 
            // lblHoTen, txtHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(380, 32);
            lblHoTen.Text = "Họ và tên*";
            txtHoTen.Location = new Point(480, 28);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(220, 23);
            txtHoTen.TabIndex = 1;
            // 
            // lblLop, cboLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(738, 32);
            lblLop.Text = "Lớp học*";
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(830, 28);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(300, 23);
            cboLop.TabIndex = 2;
            // 
            // lblNgaySinh, dtpNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(22, 70);
            lblNgaySinh.Text = "Ngày sinh";
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(130, 66);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(220, 23);
            dtpNgaySinh.TabIndex = 3;
            // 
            // lblGioiTinh, rbNam, rbNu
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(380, 70);
            lblGioiTinh.Text = "Giới tính";
            rbNam.AutoSize = true;
            rbNam.Location = new Point(480, 68);
            rbNam.Name = "rbNam";
            rbNam.Text = "Nam";
            rbNam.TabIndex = 4;
            rbNu.AutoSize = true;
            rbNu.Location = new Point(555, 68);
            rbNu.Name = "rbNu";
            rbNu.Text = "Nữ";
            rbNu.TabIndex = 5;
            // 
            // lblDiem, nudDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(738, 70);
            lblDiem.Text = "Điểm*";
            nudDiem.DecimalPlaces = 2;
            nudDiem.Increment = 0.25m;
            nudDiem.Location = new Point(830, 66);
            nudDiem.Maximum = 10m;
            nudDiem.Name = "nudDiem";
            nudDiem.Size = new Size(300, 23);
            nudDiem.TabIndex = 6;
            // 
            // lblEmail, txtEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(22, 108);
            lblEmail.Text = "Email*";
            txtEmail.Location = new Point(130, 104);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblDienThoai, txtDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(380, 108);
            lblDienThoai.Text = "Điện thoại*";
            txtDienThoai.Location = new Point(480, 104);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(220, 23);
            txtDienThoai.TabIndex = 8;
            // 
            // lblTrangThai, cboTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(738, 108);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp" });
            cboTrangThai.Location = new Point(830, 104);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(300, 23);
            cboTrangThai.TabIndex = 9;
            // 
            // action buttons
            // 
            btnThem.Location = new Point(130, 155);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 32);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            btnSua.Location = new Point(255, 155);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 32);
            btnSua.Enabled = false;
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            btnXoa.Location = new Point(380, 155);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 32);
            btnXoa.Enabled = false;
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Location = new Point(505, 155);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 32);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.AddRange(new Control[]
            {
                lblTimKiem, txtTimKiem, lblLocLop, cboLocLop, lblDiemLoc, nudDiemLoc,
                btnTimKiem, btnHienThiTatCa
            });
            groupBox2.Location = new Point(12, 238);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1169, 72);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm sinh viên (trên giao diện)";
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(15, 32);
            lblTimKiem.Text = "Từ khóa";
            txtTimKiem.Location = new Point(75, 28);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(220, 23);
            txtTimKiem.TabIndex = 0;
            lblLocLop.AutoSize = true;
            lblLocLop.Location = new Point(305, 32);
            lblLocLop.Text = "Lớp";
            cboLocLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLop.Location = new Point(340, 28);
            cboLocLop.Name = "cboLocLop";
            cboLocLop.Size = new Size(160, 23);
            cboLocLop.TabIndex = 1;
            cboLocLop.SelectedIndexChanged += cboLocLop_SelectedIndexChanged;
            lblDiemLoc.AutoSize = true;
            lblDiemLoc.Location = new Point(515, 32);
            lblDiemLoc.Text = "Điểm từ";
            nudDiemLoc.DecimalPlaces = 1;
            nudDiemLoc.Increment = 0.5m;
            nudDiemLoc.Location = new Point(570, 28);
            nudDiemLoc.Maximum = 10m;
            nudDiemLoc.Name = "nudDiemLoc";
            nudDiemLoc.Size = new Size(75, 23);
            nudDiemLoc.TabIndex = 2;
            nudDiemLoc.ValueChanged += nudDiemLoc_ValueChanged;
            btnTimKiem.Location = new Point(665, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 30);
            btnTimKiem.TabIndex = 3;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            btnHienThiTatCa.Location = new Point(790, 25);
            btnHienThiTatCa.Name = "btnHienThiTatCa";
            btnHienThiTatCa.Size = new Size(140, 30);
            btnHienThiTatCa.TabIndex = 4;
            btnHienThiTatCa.Text = "Hiển thị tất cả";
            btnHienThiTatCa.UseVisualStyleBackColor = true;
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Controls.Add(lblTongSo);
            groupBox3.Location = new Point(12, 316);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1169, 345);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách sinh viên";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 42);
            dataGridView1.Size = new Size(1139, 288);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            lblTongSo.AutoSize = true;
            lblTongSo.Location = new Point(975, 20);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "Tổng số: 0 sinh viên";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 673);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(1000, 700);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên";
            Load += Form1_Load;
            Shown += Form1_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiemLoc).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }
    }
}
