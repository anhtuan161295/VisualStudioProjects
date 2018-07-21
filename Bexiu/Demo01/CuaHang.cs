namespace Demo01
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuaHang")]
    public partial class CuaHang
    {
        [Key]
        public int MaCuaHang { get; set; }

        public string TenCuaHang { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }
    }
}
