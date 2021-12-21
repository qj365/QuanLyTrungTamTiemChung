namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VACXIN")]
    public partial class VACXIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VACXIN()
        {
            CT_GOIVX = new HashSet<CT_GOIVX>();
            CT_PHIEUTIEM = new HashSet<CT_PHIEUTIEM>();
            CT_PHIEUXUAT = new HashSet<CT_PHIEUXUAT>();
            LOVACXIN = new HashSet<LOVACXIN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAVX { get; set; }

        [StringLength(50)]
        public string TENVX { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NSX { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HSD { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }


        public int? MALOAI { get; set; }

        public virtual ICollection<CT_GOIVX> CT_GOIVX { get; set; }

        public virtual ICollection<CT_PHIEUTIEM> CT_PHIEUTIEM { get; set; }

        public virtual ICollection<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }

        public virtual LOAIVACXIN LOAIVACXIN { get; set; }

        public virtual ICollection<LOVACXIN> LOVACXIN { get; set; }
    }
}
