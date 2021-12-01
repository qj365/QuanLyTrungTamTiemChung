namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOVACXIN")]
    public partial class LOVACXIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOVACXIN()
        {
            VACXIN = new HashSet<VACXIN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALO { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }

        public decimal? THANHTIEN { get; set; }

        public int? MAPN { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VACXIN> VACXIN { get; set; }
    }
}
