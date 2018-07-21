namespace Demo01
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaHoaDon { get; set; }

        public int? MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public int? MaDonVi { get; set; }

        public int? MaCuaHang { get; set; }
    }
}
