namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vi")]
    public partial class Vi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vi()
        {
            ChiTieu = new HashSet<ChiTieu>();
        }

        [Key]
        [StringLength(50)]
        public string MaVi { get; set; }

        [StringLength(50)]
        public string TenVi { get; set; }

        [StringLength(50)]
        public string MaTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTieu> ChiTieu { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
