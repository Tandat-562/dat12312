using DAL.Model;
using System;
using System.Linq;

namespace BUS.Service
{
    public class UserService
    {
        private QLCTContext _context;

        public UserService()
        {
            _context = new QLCTContext();
        }

        public void RegisterUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            // Thêm người dùng vào cơ sở dữ liệu
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Register(string username, string password)
        {
            // Kiểm tra nếu tên đăng nhập đã tồn tại
            if (_context.Users.Any(u => u.Username == username))
                return false;

            var user = new Users
            {
                Username = username,
                Password = HashPassword(password) // Hash mật khẩu trước khi lưu
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public Users GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return string.Concat(bytes.Select(b => b.ToString("x2")));
            }
        }
        public bool ValidateUser(string username, string password, out int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                userId = user.Id;
                return true;
            }
            userId = 0;
            return false;
        }

    }
}
