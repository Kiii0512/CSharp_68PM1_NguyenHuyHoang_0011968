using System;
using System.Windows.Forms;

namespace AppDangNhap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = txtEmail.Text.Trim();
            string inputMSSV = txtMSSV.Text.Trim();

            string emailDung = "hoang.nh2005@nuce.edu.vn";
            string mssvDung = "20242025";

            bool isEmailValid = string.Equals(inputEmail, emailDung, StringComparison.OrdinalIgnoreCase);
            bool isMSSVValid = (inputMSSV == mssvDung);

            if (isEmailValid && isMSSVValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}