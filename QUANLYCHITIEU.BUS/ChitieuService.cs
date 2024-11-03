using QUANLYCHITIEU.DAL.Model;
using System.Collections.Generic;

namespace QUANLYCHITIEU.BUS
{
    public class ChiTieuService
    {
        private ApplicationDbContext dbContext; // Giả sử bạn có một DbContext

        public ChiTieuService()
        {
            dbContext = new ApplicationDbContext();
        }

        public List<ChiTieu> LayDanhSachChiTieu()
        {
            return dbContext.Chitieus.ToList(); // Trả về danh sách chi tiêu
        }

        public void ThemChiTieu(ChiTieu chiTieu)
        {
            dbContext.Chitieus.Add(chiTieu);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        public void SuaChiTieu(int index, ChiTieu chiTieuCapNhat)
        {
            var existingChiTieu = dbContext.Chitieus.ToList()[index];
            if (existingChiTieu != null)
            {
                existingChiTieu.Ten = chiTieuCapNhat.Ten;
                existingChiTieu.SoTien = chiTieuCapNhat.SoTien;
                existingChiTieu.NgayChi = chiTieuCapNhat.NgayChi;
                existingChiTieu.DanhMuc = chiTieuCapNhat.DanhMuc;
                existingChiTieu.GhiChu = chiTieuCapNhat.GhiChu;
                dbContext.SaveChanges();
            }
        }

        public void XoaChiTieu(int index)
        {
            var chiTieu = dbContext.Chitieus.ToList()[index];
            if (chiTieu != null)
            {
                dbContext.Chitieus.Remove(chiTieu);
                dbContext.SaveChanges();
            }
        }
    }
}
