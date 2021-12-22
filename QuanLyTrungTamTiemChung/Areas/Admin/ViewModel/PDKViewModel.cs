using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyTrungTamTiemChung.Areas.Admin.ViewModel
{
    public class PDKViewModel
    {
        public PDKViewModel(PHIEUDANGKY pHIEUDANGKY)
        {
            MAPHIEUDK = pHIEUDANGKY.MAPHIEUDK;
            NGAYLAPPHIEU = pHIEUDANGKY.NGAYLAPPHIEU;
            NGAYDANGKYTIEM = pHIEUDANGKY.NGAYDANGKYTIEM;
            MACS = pHIEUDANGKY.MACS;
            MAKH = pHIEUDANGKY.MAKH;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPHIEUDK { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NGAYLAPPHIEU { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? NGAYDANGKYTIEM { get; set; }

        public int? MACS { get; set; }

        public int? MAKH { get; set; }

        public virtual COSO COSO { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual PHIEUKHAM PHIEUKHAM { get; set; }

        public virtual PHIEUTIEM PHIEUTIEM { get; set; }


        public IEnumerable<GOIVACXIN> GOIVACXIN { get; set; }

    }
}
