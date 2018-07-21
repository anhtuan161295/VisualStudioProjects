namespace Demo01
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [Key]
        public int MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }
    }
}
