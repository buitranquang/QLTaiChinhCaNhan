namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoanVay")]
    public partial class KhoanVay
    {
        [Key]
        [StringLength(50)]
        public string MaKV { get; set; }

        public long? SoTienTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHan { get; set; }

        public string TrangThai { get; set; }

        [StringLength(50)]
        public string MaTK { get; set; }

        [StringLength(50)]
        public string TenKV { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
