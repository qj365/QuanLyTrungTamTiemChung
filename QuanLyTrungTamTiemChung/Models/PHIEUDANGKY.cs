namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDANGKY")]
    public partial class PHIEUDANGKY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDANGKY()
        {
            PHIEUKHAM = new HashSet<PHIEUKHAM>();
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUKHAM> PHIEUKHAM { get; set; }
    }
}
