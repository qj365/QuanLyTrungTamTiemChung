namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTIEM")]
    public partial class PHIEUTIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTIEM()
        {
            CT_PHIEUTIEM = new HashSet<CT_PHIEUTIEM>();
            HOADON = new HashSet<HOADON>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPHIEUTIEM { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTIEM { get; set; }

        public int? MAPHIEUKHAM { get; set; }

        public int? MABS { get; set; }

        public int? MAGOIVX { get; set; }

        public virtual BACSI BACSI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUTIEM> CT_PHIEUTIEM { get; set; }

        public virtual GOIVACXIN GOIVACXIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public virtual PHIEUKHAM PHIEUKHAM { get; set; }
    }
}
