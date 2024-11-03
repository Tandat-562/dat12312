using DAL.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
[Table("ChiTieu")]
public partial class ChiTieu
{
    public int ChiTieuID { get; set; }

    public int UserId { get; set; } // Bắt buộc, không thể là null

    [Required]
    [StringLength(50)]
    public string LoaiChiTieu { get; set; }

    public int DanhMucID { get; set; }

    public decimal? SoTien { get; set; }

    [Column(TypeName = "date")]
    public DateTime NgayChi { get; set; }

    [StringLength(200)]
    public string MoTa { get; set; }

    public virtual DanhMuc DanhMuc { get; set; }

    public virtual Users Users { get; set; }
}
