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
        public int MAPHIEUXUAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYLAP { get; set; }

        public decimal? TONGTIEN { get; set; }

        public int? MAKHODICH { get; set; }

        public int? MAKHONGUON { get; set; }

        public int? MANV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }

        public virtual KHO KHO { get; set; }

        public virtual KHO KHO1 { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
