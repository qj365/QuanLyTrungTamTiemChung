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
        [Display(Name = "Mã lô vắc xin")]
        public int MALO { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn 0")]
        public int? SOLUONG { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Vui lòng nhập đơn giá")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn 0")]
        public decimal? DONGIA { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Vui lòng nhập thành tiền")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập giá trị lớn hơn 0")]
        public decimal? THANHTIEN { get; set; }

        [Display(Name = "Phiếu nhập")]
        [Required(ErrorMessage = "Vui lòng chọn phiếu nhập")]
        public int? MAPN { get; set; }
        [ForeignKey("MAPN")]
        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        [Display(Name = "Vắc xin")]
        [Required(ErrorMessage = "Vui lòng chọn vắc xin")]
        public int? MAVX { get; set; }
        [ForeignKey("MAVX")]
        public virtual VACXIN VACXIN { get; set; }
    }
}
