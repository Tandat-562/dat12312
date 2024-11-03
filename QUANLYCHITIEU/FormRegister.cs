using System;
using System.Windows.Forms;
using BUS.Service;
using DAL.Model;

namespace QUANLYCHITIEU
{
    public partial class FormRegister : Form
    {
        private UserService _userService;

        public FormRegister()
        {
            InitializeComponent();
            _userService = new UserService(); // Khởi tạo UserService
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string confirmPassword = txtXacNhanMatKhau.Text.Trim();

            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền tất cả các trường!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu không khớp!");
                return;
            }

            // Kiểm tra tên đăng nhập thông qua UserService
            if (_userService.GetUserByUsername(username) != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên khác.");
                return;
            }

            // Tạo người dùng mới
            var user = new Users
            {
                Username = username,
                Password = password // Thực tế nên hash mật khẩu trước khi lưu
            };

            // Gọi phương thức UserService để lưu vào cơ sở dữ liệu
            _userService.RegisterUser(user);

            // Hiển thị thông báo thành công và chuyển đến Form đăng nhập
            MessageBox.Show("Đăng ký thành công!");
            this.Close();

            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Hide();
        }
    }
}
