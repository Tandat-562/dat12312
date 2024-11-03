using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Service;

namespace QUANLYCHITIEU
{
    public partial class FormDangNhap : Form
    {
        private int _userId;
        public FormDangNhap()
        {
            InitializeComponent();
        }
        public int GetUserId()
        {
            return _userId;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            UserService userService = new UserService();
            int userId; // Biến để lưu userId

            // Kiểm tra thông tin đăng nhập
            if (userService.ValidateUser(username, password, out userId))
            {
                _userId = userId; // Gán userId vào biến _userId

                // Hiển thị Form2 và truyền userId
                Form2 mainForm = new Form2(_userId);
                this.Hide(); // Ẩn form đăng nhập
                mainForm.ShowDialog(); // Hiển thị Form2
                this.Close(); // Đóng form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void link_lblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show(); // Hiển thị form đăng ký
            this.Hide();
        }
    }
}
