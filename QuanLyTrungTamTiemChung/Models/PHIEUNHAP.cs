namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            LOVACXIN = new HashSet<LOVACXIN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }

        public decimal? TONGTIEN { get; set; }

        public int? MANSX { get; set; }

        public int? MANV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOVACXIN> LOVACXIN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
