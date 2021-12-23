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
        [Display(Name = "Mã vắc xin")]
        public int MAVX { get; set; }
        [Display(Name = "Số lượng")]
        public int? SOLUONG { get; set; }
        [Display(Name = "Đơn giá xuất")]
        public decimal? DONGIAXUAT { get; set; }
        [Display(Name = "Thành tiền")]
        public decimal? THANHTIEN { get; set; }

        public virtual PHIEUXUAT PHIEUXUAT { get; set; }

        public virtual VACXIN VACXIN { get; set; }
    }
}
