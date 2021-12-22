namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUKHAM")]
    public partial class PHIEUKHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUKHAM()
        {
            PHIEUTIEM = new HashSet<PHIEUTIEM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPHIEUKHAM { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? NGAYKHAM { get; set; }

        [StringLength(50)]
        public string DIUNG { get; set; }

        [StringLength(50)]
        public string NHIETDO { get; set; }

        [StringLength(50)]
        public string HUYETAP { get; set; }

        public int? MAPHIEUDK { get; set; }

        public int? MABS { get; set; }

        public virtual BACSI BACSI { get; set; }

        public virtual PHIEUDANGKY PHIEUDANGKY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTIEM> PHIEUTIEM { get; set; }
    }
}
