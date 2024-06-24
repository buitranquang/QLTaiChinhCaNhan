namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTieu")]
    public partial class ChiTieu
    {
        [Key]
        public int MaChiTieu { get; set; }

        public int? SoTienChitieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChiTieu { get; set; }

        [StringLength(50)]
        public string MaLoaiCT { get; set; }

        [StringLength(50)]
        public string MaVi { get; set; }

        [StringLength(50)]
        public string MaTK { get; set; }

        public virtual ChiTieu ChiTieu1 { get; set; }

        public virtual ChiTieu ChiTieu2 { get; set; }

        public virtual LoaiCT LoaiCT { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        public virtual Vi Vi { get; set; }
    }
}
