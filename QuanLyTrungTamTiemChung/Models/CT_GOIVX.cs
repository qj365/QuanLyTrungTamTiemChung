namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_GOIVX
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAGOIVX { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAVX { get; set; }

        public int? LIEULUONG { get; set; }

        public int? SOLUONG { get; set; }

        public int? DONGIA { get; set; }

        public int? THANHTIEN { get; set; }

        public virtual GOIVACXIN GOIVACXIN { get; set; }

        public virtual VACXIN VACXIN { get; set; }
    }
}
