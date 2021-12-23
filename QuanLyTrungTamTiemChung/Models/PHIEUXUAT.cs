namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUAT")]
    public partial class PHIEUXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXUAT()
        {
            CT_PHIEUXUAT = new HashSet<CT_PHIEUXUAT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã phiếu xuất")]
        public int MAPHIEUXUAT { get; set; }
        [Display(Name = "Thời gian lập")]
        [Column(TypeName = "date")]
        public DateTime? NGAYLAP { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? TONGTIEN { get; set; }
        [Display(Name = "Kho đích")]
        public int? MAKHODICH { get; set; }
        [Display(Name = "Kho nguồn")]
        public int? MAKHONGUON { get; set; }
        [Display(Name = "Nhân viên")]
        public int? MANV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }
        [Display(Name = "Kho nguồn")]
        public virtual KHO KHO { get; set; }
        [Display(Name = "Kho đích")]
        public virtual KHO KHO1 { get; set; }

        
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
