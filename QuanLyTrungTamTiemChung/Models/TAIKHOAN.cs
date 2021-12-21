namespace QuanLyTrungTamTiemChung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            BACSI = new HashSet<BACSI>();
            NHANVIEN = new HashSet<NHANVIEN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTAIKHOAN { get; set; }

        [StringLength(50)]
        public string TENDANGNHAP { get; set; }

        [StringLength(50)]
        public string MATKHAU { get; set; }

        public int? MAQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BACSI> BACSI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIEN { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }
    }
}
