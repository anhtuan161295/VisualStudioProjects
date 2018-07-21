namespace Demo01
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHoaDon")]
    public partial class LoaiHoaDon
    {
        [Key]
        public int MaLoaiHoaDon { get; set; }

        [StringLength(50)]
        public string TenLoaiHoaDon { get; set; }
    }
}
