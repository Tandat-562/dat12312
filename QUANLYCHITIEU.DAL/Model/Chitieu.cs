using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUANLYCHITIEU.DAL.Model
{
    [Table("Chitieu")]
    public partial class Chitieu
    {
        [Key]
        [Column("Tên mặt hàng", Order = 0)]
        [StringLength(50)]
        public string TenMatHang { get; set; } // Đổi tên thuộc tính để sử dụng kiểu PascalCase

        [Key]
        [Column("Danh mục", Order = 1)]
        [StringLength(50)]
        public string DanhMuc { get; set; } // Đổi tên thuộc tính để sử dụng kiểu PascalCase

        [Key]
        [Column("Số tiền", Order = 2)]
        public decimal SoTien { get; set; } // Đổi tên thuộc tính để sử dụng kiểu PascalCase

        [Key]
        [Column("Ngày chi", Order = 3)]
        public DateTime NgayChi { get; set; } // Đổi tên thuộc tính để sử dụng kiểu PascalCase

        [Key]
        [Column("Ghi chú", Order = 4, TypeName = "ntext")]
        public string GhiChu { get; set; } // Đổi tên thuộc tính để sử dụng kiểu PascalCase

        public override string ToString()
        {
            return $"{TenMatHang} - {DanhMuc} - {SoTien} - {NgayChi.ToShortDateString()} - {GhiChu}";
        }
    }
}
