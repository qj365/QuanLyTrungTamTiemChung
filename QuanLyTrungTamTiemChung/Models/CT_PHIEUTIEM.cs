namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUTIEM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUTIEM { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAVX { get; set; }

        public decimal? LIEULUONG { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }

        public decimal? THANHTIEN { get; set; }

        public virtual PHIEUTIEM PHIEUTIEM { get; set; }

        public virtual VACXIN VACXIN { get; set; }
    }
}
