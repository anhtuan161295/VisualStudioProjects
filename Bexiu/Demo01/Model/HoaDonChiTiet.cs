using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01.Model
{
    [Table("HoaDonChiTiet")]
    class HoaDonChiTiet
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
    }
}