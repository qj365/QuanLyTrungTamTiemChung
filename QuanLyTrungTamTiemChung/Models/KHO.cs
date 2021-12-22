namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHO")]
    public partial class KHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHO()
        {
            LOAIVACXIN = new HashSet<LOAIVACXIN>();
            PHIEUXUAT = new HashSet<PHIEUXUAT>();
            PHIEUXUAT1 = new HashSet<PHIEUXUAT>();
        }

        public KHO(KHO kho)
        {
            TENKHO = kho.TENKHO;
            SDT = kho.SDT;
            DIACHI = kho.DIACHI;
            MACS = kho.MACS;
            MAKHO = kho.MAKHO;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã kho")]
        public int MAKHO { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên kho")]
        [Required(ErrorMessage = "Vui lòng nhập tên kho")]
        public string TENKHO { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Không phải số điện thoại đúng định dạng")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DIACHI { get; set; }

        [Display(Name = "Cơ sở")]
        [Required(ErrorMessage = "Vui lòng chọn cơ sở")]
        public int? MACS { get; set; }
        [ForeignKey("MACS")]

        public virtual COSO COSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAIVACXIN> LOAIVACXIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUAT1 { get; set; }

        public IEnumerable<COSO> COSOs { get; set; }
    }
}
