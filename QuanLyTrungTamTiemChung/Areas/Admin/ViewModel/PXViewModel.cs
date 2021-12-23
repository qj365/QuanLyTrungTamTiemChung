using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace QuanLyTrungTamTiemChung.Areas.Admin.ViewModel
{
    public class PXViewModel
    {
        [Key]
        [Display(Name = "Mã phiếu xuất")]
        public int MAPHIEUXUAT { get; set; }
        [Display(Name = "Vắc xin")]
        public int MAVX { get; set; }
        [Display(Name = "Số lượng")]
        public int? SOLUONG { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? TONGTIEN { get; set; }
        [Display(Name = "Kho đích")]
        public int? MAKHODICH { get; set; }
        [Display(Name = "Kho nguồn")]
        public int? MAKHONGUON { get; set; }



    }
}