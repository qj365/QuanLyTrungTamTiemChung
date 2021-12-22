namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUDANGKY = new HashSet<PHIEUDANGKY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAKH { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(10)]
        public string GIOITINH { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(50)]
        public string TENTHANNHAN { get; set; }

        [StringLength(50)]
        public string MOIQUANHE { get; set; }

        [StringLength(15)]
        public string SDTTHANNHAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANGKY> PHIEUDANGKY { get; set; }
    }
}
