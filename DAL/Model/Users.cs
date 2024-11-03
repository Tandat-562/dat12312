using DAL.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public partial class Users
{
    public Users()
    {
        ChiTieu = new HashSet<ChiTieu>();
        ThuNhap = new HashSet<ThuNhap>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    public virtual ICollection<ChiTieu> ChiTieu { get; set; }

    public virtual ICollection<ThuNhap> ThuNhap { get; set; }
}
