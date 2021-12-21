namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADON = new HashSet<HOADON>();
            PHIEUNHAP = new HashSet<PHIEUNHAP>();
            PHIEUXUAT = new HashSet<PHIEUXUAT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MANV { get; set; }

        [StringLength(50)]
        public string TENNV { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        public decimal? LUONG { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        public int? MACS { get; set; }

        public int? IDTAIKHOAN { get; set; }

        public virtual COSO COSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUAT { get; set; }
    }
}
