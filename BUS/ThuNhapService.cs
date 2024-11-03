using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS.Service
{
    public class ThuNhapService
    {
        private QLCTContext _context;

        public ThuNhapService()
        {
            _context = new QLCTContext();
        }

        public void AddThuNhap(int userId, decimal soTien, DateTime ngayThu, string ghiChu)
        {
            if (soTien < 0)
                throw new ArgumentException("Số tiền không được âm.");

            var thuNhap = new ThuNhap
            {
                UserId = userId,
                SoTien = soTien,
                NgayThu = ngayThu,
                GhiChu = ghiChu
            };

            _context.ThuNhap.Add(thuNhap);
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        public void DeleteThuNhap(int id)
        {
            var thuNhap = _context.ThuNhap.FirstOrDefault(t => t.Id == id);
            if (thuNhap != null)
            {
                _context.ThuNhap.Remove(thuNhap);
                _context.SaveChanges();
            }
        }
        public List<ThuNhap> GetThuNhapByUser(int userId)
        {
            return _context.ThuNhap.Where(t => t.UserId == userId).ToList();
        }

        public decimal? GetTotalThuNhap(int userId)
        {
            return _context.ThuNhap.Where(t => t.UserId == userId).Sum(c => c.SoTien);

        }

    }
}
