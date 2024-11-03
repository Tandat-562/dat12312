namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuNhap")]
    public partial class ThuNhap
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }

        public decimal? SoTien { get; set; }

        public DateTime NgayThu { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual Users Users { get; set; }
    }
}
