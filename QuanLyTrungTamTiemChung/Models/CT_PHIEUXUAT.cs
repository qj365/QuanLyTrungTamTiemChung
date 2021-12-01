namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUXUAT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUXUAT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAVX { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIAXUAT { get; set; }

        public decimal? THANHTIEN { get; set; }

        public virtual PHIEUXUAT PHIEUXUAT { get; set; }

        public virtual VACXIN VACXIN { get; set; }
    }
}
