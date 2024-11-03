using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS.Service
{
    public class DanhMucService
    {
        private QLCTContext _context;

        public DanhMucService()
        {
            _context = new QLCTContext();
        }


        public List<DanhMuc> GetAllDanhMuc()
        {
            return _context.DanhMuc.ToList();
        }

        public void AddDanhMuc(string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                throw new ArgumentException("Tên danh mục không được để trống.");

            var danhMuc = new DanhMuc
            {
                TenDanhMuc = tenDanhMuc
            };
            _context.DanhMuc.Add(danhMuc);
            _context.SaveChanges();
        }
        public bool DeleteDanhMuc(int danhMucId)
        {
            var danhMuc = _context.DanhMuc.Find(danhMucId);
            if (danhMuc != null)
            {
                _context.DanhMuc.Remove(danhMuc);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}