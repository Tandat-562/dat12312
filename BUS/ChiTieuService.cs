using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS.Service
{
    public class ChiTieuService
    {
        private QLCTContext _context;

        public ChiTieuService()
        {
            _context = new QLCTContext();
        }

        public void AddChiTieu(int userId, string loaiChiTieu, int danhMucId, decimal soTien, DateTime ngayChi, string moTa)
        {
            var totalChiTieu = GetTotalChiTieu(userId) ?? 0; // Lấy tổng chi tiêu hiện tại
            var totalThuNhap = _context.ThuNhap.Where(t => t.UserId == userId).Sum(t => t.SoTien) ?? 0; // Lấy tổng thu nhập
           
            var chiTieu = new ChiTieu
            {
                UserId = userId,
                LoaiChiTieu = loaiChiTieu,
                DanhMucID = danhMucId,
                SoTien = soTien,
                NgayChi = ngayChi,
                MoTa = moTa
            };
            _context.ChiTieu.Add(chiTieu);
            _context.SaveChanges();
        }

        public List<ChiTieu> GetChiTieuByUser(int userId)
        {
            return _context.ChiTieu.Where(c => c.UserId == userId).ToList();
        }
        public List<ChiTieu> GetAllChiTieu()
        {
            return _context.ChiTieu.ToList(); // Lấy tất cả các mục từ bảng ChiTieu
        }
        
        public decimal? GetTotalChiTieu(int userId)
        {
            return _context.ChiTieu.Where(c => c.UserId == userId).Sum(c => c.SoTien);
        }

        public decimal? GetRemainingBalance(int userId)
        {
            var totalThuNhap = _context.ThuNhap.Where(t => t.UserId == userId).Sum(t => t.SoTien);
            var totalChiTieu = _context.ChiTieu.Where(c => c.UserId == userId).Sum(c => c.SoTien);
            return totalThuNhap - totalChiTieu;
        }
        public void UpdateChiTieu(int chiTieuId, int userId, string loaiChiTieu, int danhMucId, decimal soTien, DateTime ngayChi, string moTa)
        {
            var chiTieu = _context.ChiTieu.Find(chiTieuId);
            if (chiTieu != null && chiTieu.UserId == userId) // Kiểm tra xem chi tiêu có tồn tại và thuộc về người dùng không
            {
                var totalChiTieu = GetTotalChiTieu(userId) - chiTieu.SoTien + soTien; // Trừ đi chi tiêu cũ và thêm chi tiêu mới
                var totalThuNhap = _context.ThuNhap.Where(t => t.UserId == userId).Sum(t => t.SoTien) ?? 0; // Lấy tổng thu nhập
               

               
                chiTieu.LoaiChiTieu = loaiChiTieu;
                chiTieu.DanhMucID = danhMucId;
                chiTieu.SoTien = soTien;
                chiTieu.NgayChi = ngayChi;
                chiTieu.MoTa = moTa;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Chi tiêu không tồn tại hoặc không thuộc về người dùng.");
            }
        }
        public void DeleteChiTieu(int chiTieuId, int userId)
        {
            var chiTieu = _context.ChiTieu.Find(chiTieuId);
            if (chiTieu != null && chiTieu.UserId == userId) // Kiểm tra xem chi tiêu có tồn tại và thuộc về người dùng không
            {
                _context.ChiTieu.Remove(chiTieu);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Chi tiêu không tồn tại hoặc không thuộc về người dùng.");
            }
        }
    }
}
    