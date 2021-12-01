namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GOIVACXIN")]
    public partial class GOIVACXIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GOIVACXIN()
        {
            CT_GOIVX = new HashSet<CT_GOIVX>();
            PHIEUTIEM = new HashSet<PHIEUTIEM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAGOIVX { get; set; }

        [StringLength(50)]
        public string TENGOIVX { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        public decimal? TONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_GOIVX> CT_GOIVX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTIEM> PHIEUTIEM { get; set; }
    }
}
