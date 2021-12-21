namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOVACXIN")]
    public partial class LOVACXIN
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MALO { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }

        public decimal? THANHTIEN { get; set; }

        public int? MAPN { get; set; }
        [ForeignKey("MAPN")]
        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public int? MAVX { get; set; }
        [ForeignKey("MAVX")]
        public virtual VACXIN VACXIN { get; set; }
    }
}
