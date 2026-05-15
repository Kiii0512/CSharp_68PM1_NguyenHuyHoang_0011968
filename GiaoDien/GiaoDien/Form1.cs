using System;
using System.Drawing;
using System.Windows.Forms;

namespace GiaoDien
{
    public partial class Form1 : Form
    {
        // Khai báo các biến control ở cấp độ class
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuQLSinhVien, mnuQLLopHoc, mnuDangXuat;
        private GroupBox grpThongTin;
        private Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblLop;
        private TextBox txtMaSV, txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboGioiTinh, cboLop;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private Panel pnlRight;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimkiem;
        private DataGridView dgvSinhVien;
        private Panel pnlPhanTrang;
        private Button btnFirst, btnPrev, btnNext, btnLast;
        private Label lblTrang;

        public Form1()
        {
            InitializeComponent(); // Dòng này bắt buộc phải giữ nguyên
            TaoGiaoDien();         // Gọi hàm tạo giao diện thủ công
        }

        private void TaoGiaoDien()
        {
            // Thiết lập Form chính
            this.Text = "Quản Lý Sinh Viên";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = Color.FromArgb(240, 242, 245);

            // 1. MenuStrip
            menuStrip = new MenuStrip();
            menuStrip.BackColor = Color.White;
            mnuQLSinhVien = new ToolStripMenuItem("Quản Lý Sinh Viên") { Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            mnuQLLopHoc = new ToolStripMenuItem("Quản Lý Lớp Học");
            mnuDangXuat = new ToolStripMenuItem("Đăng xuất") { ForeColor = Color.Red };
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuQLSinhVien, mnuQLLopHoc, mnuDangXuat });
            this.Controls.Add(menuStrip);

            // 2. Panel Trái - Thông tin sinh viên
            grpThongTin = new GroupBox();
            grpThongTin.Text = "Thông tin sinh viên";
            grpThongTin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpThongTin.Location = new Point(15, 40);
            grpThongTin.Size = new Size(320, 540);
            grpThongTin.BackColor = Color.White;
            this.Controls.Add(grpThongTin);

            Font regularFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            int yPos = 30;
            int spacing = 55;

            // Mã sinh viên
            lblMaSV = new Label() { Text = "Mã sinh viên:", Location = new Point(15, yPos), Font = regularFont, AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(15, yPos + 20), Size = new Size(290, 25), Font = regularFont };
            grpThongTin.Controls.Add(lblMaSV); grpThongTin.Controls.Add(txtMaSV);

            // Họ và tên
            yPos += spacing;
            lblHoTen = new Label() { Text = "Họ và tên:", Location = new Point(15, yPos), Font = regularFont, AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(15, yPos + 20), Size = new Size(290, 25), Font = regularFont };
            grpThongTin.Controls.Add(lblHoTen); grpThongTin.Controls.Add(txtHoTen);

            // Ngày sinh
            yPos += spacing;
            lblNgaySinh = new Label() { Text = "Ngày sinh:", Location = new Point(15, yPos), Font = regularFont, AutoSize = true };
            dtpNgaySinh = new DateTimePicker() { Location = new Point(15, yPos + 20), Size = new Size(290, 25), Font = regularFont, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            grpThongTin.Controls.Add(lblNgaySinh); grpThongTin.Controls.Add(dtpNgaySinh);

            // Giới tính
            yPos += spacing;
            lblGioiTinh = new Label() { Text = "Giới tính:", Location = new Point(15, yPos), Font = regularFont, AutoSize = true };
            cboGioiTinh = new ComboBox() { Location = new Point(15, yPos + 20), Size = new Size(290, 25), Font = regularFont, DropDownStyle = ComboBoxStyle.DropDownList };
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;
            grpThongTin.Controls.Add(lblGioiTinh); grpThongTin.Controls.Add(cboGioiTinh);

            // Lớp
            yPos += spacing;
            lblLop = new Label() { Text = "Lớp:", Location = new Point(15, yPos), Font = regularFont, AutoSize = true };
            cboLop = new ComboBox() { Location = new Point(15, yPos + 20), Size = new Size(290, 25), Font = regularFont, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLop.Items.Add("68PM1 - Lớp 68PM1");
            cboLop.SelectedIndex = 0;
            grpThongTin.Controls.Add(lblLop); grpThongTin.Controls.Add(cboLop);

            // Các nút chức năng
            yPos += 80;
            int btnWidth = 140;
            int btnHeight = 40;

            btnThem = CreateFlatButton("Thêm", Color.FromArgb(52, 152, 219), Color.White, new Point(15, yPos), new Size(btnWidth, btnHeight));
            btnSua = CreateFlatButton("Sửa", Color.FromArgb(46, 204, 113), Color.White, new Point(165, yPos), new Size(btnWidth, btnHeight));

            yPos += 50;
            btnXoa = CreateFlatButton("Xóa", Color.FromArgb(231, 76, 60), Color.White, new Point(15, yPos), new Size(btnWidth, btnHeight));
            btnLamMoi = CreateFlatButton("Làm mới", Color.FromArgb(149, 165, 166), Color.White, new Point(165, yPos), new Size(btnWidth, btnHeight));

            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);

            // 3. Panel Phải - Tìm kiếm & DataGridView
            pnlRight = new Panel();
            pnlRight.Location = new Point(350, 40);
            pnlRight.Size = new Size(720, 540);
            pnlRight.BackColor = Color.Transparent;
            this.Controls.Add(pnlRight);

            // Tìm kiếm
            lblTimKiem = new Label() { Text = "Tìm kiếm (Tên / Mã SV / Lớp):", Location = new Point(0, 5), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
            txtTimKiem = new TextBox() { Location = new Point(0, 25), Size = new Size(300, 25), Font = regularFont };
            btnTimkiem = CreateFlatButton("Tìm", Color.FromArgb(52, 73, 94), Color.White, new Point(310, 24), new Size(100, 27));

            pnlRight.Controls.Add(lblTimKiem);
            pnlRight.Controls.Add(txtTimKiem);
            pnlRight.Controls.Add(btnTimkiem);

            // DataGridView
            dgvSinhVien = new DataGridView();
            dgvSinhVien.Location = new Point(0, 65);
            dgvSinhVien.Size = new Size(720, 420);
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.ReadOnly = true;

            dgvSinhVien.Columns.Add("MaSV", "Mã SV");
            dgvSinhVien.Columns.Add("HoTen", "Họ và Tên");
            dgvSinhVien.Columns.Add("GioiTinh", "Giới Tính");
            dgvSinhVien.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvSinhVien.Columns.Add("Lop", "Lớp");

            dgvSinhVien.Columns[0].FillWeight = 50;
            dgvSinhVien.Columns[2].FillWeight = 60;

            dgvSinhVien.Rows.Add("1", "hieu", "Nam", "11/03/2026", "68PM1");
            dgvSinhVien.Rows.Add("2", "Nguyễn Văn B", "Nam", "11/03/2026", "68PM2");
            dgvSinhVien.Rows.Add("3", "Trần Văn C", "Nam", "21/03/2026", "68PM2");

            pnlRight.Controls.Add(dgvSinhVien);

            // 4. Phân trang
            pnlPhanTrang = new Panel();
            pnlPhanTrang.Location = new Point(0, 495);
            pnlPhanTrang.Size = new Size(720, 40);
            pnlRight.Controls.Add(pnlPhanTrang);

            int pageBtnWidth = 40;
            int pageBtnHeight = 35;

            btnFirst = CreateFlatButton("<<", Color.White, Color.Black, new Point(0, 0), new Size(pageBtnWidth, pageBtnHeight));
            btnPrev = CreateFlatButton("<", Color.White, Color.Black, new Point(45, 0), new Size(pageBtnWidth, pageBtnHeight));

            btnFirst.FlatAppearance.BorderColor = Color.LightGray;
            btnPrev.FlatAppearance.BorderColor = Color.LightGray;

            lblTrang = new Label();
            lblTrang.Text = "Trang 1/1  |  3 bản ghi";
            lblTrang.AutoSize = false;
            lblTrang.TextAlign = ContentAlignment.MiddleCenter;
            lblTrang.Size = new Size(200, 35);
            lblTrang.Location = new Point(260, 0);

            btnNext = CreateFlatButton(">", Color.White, Color.Black, new Point(590, 0), new Size(pageBtnWidth, pageBtnHeight));
            btnLast = CreateFlatButton(">>", Color.White, Color.Black, new Point(635, 0), new Size(pageBtnWidth, pageBtnHeight));

            btnNext.FlatAppearance.BorderColor = Color.LightGray;
            btnLast.FlatAppearance.BorderColor = Color.LightGray;

            pnlPhanTrang.Controls.Add(btnFirst);
            pnlPhanTrang.Controls.Add(btnPrev);
            pnlPhanTrang.Controls.Add(lblTrang);
            pnlPhanTrang.Controls.Add(btnNext);
            pnlPhanTrang.Controls.Add(btnLast);
        }

        private Button CreateFlatButton(string text, Color backColor, Color foreColor, Point location, Size size)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Location = location;
            btn.Size = size;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = backColor == Color.White ? Color.LightGray : backColor;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            return btn;
        }
    }
}