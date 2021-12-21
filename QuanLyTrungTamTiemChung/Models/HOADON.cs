namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYLAP { get; set; }

        public decimal? TONGTIEN { get; set; }

        public int? MANV { get; set; }

        public int? MAPHIEUTIEM { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHIEUTIEM PHIEUTIEM { get; set; }
    }
}
