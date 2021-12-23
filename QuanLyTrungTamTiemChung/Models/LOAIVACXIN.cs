namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIVACXIN")]
    public partial class LOAIVACXIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIVACXIN()
        {
            VACXIN = new HashSet<VACXIN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã loại")]
        public int MALOAI { get; set; }
        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string TENLOAI { get; set; }
        [Display(Name = "Kho")]
        public int? MAKHO { get; set; }

        public virtual KHO KHO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VACXIN> VACXIN { get; set; }
    }
}
