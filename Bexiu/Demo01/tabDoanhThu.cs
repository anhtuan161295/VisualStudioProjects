using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo01
{
    public partial class Form1
    {
        private void loadComboboxThang()
        {
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Add(i);
            }
            cboThang.SelectedItem = DateTime.Now.Month;
        }

        private void loadComboboxNam()
        {
            for (int i = DateTime.Now.Year - 20; i < DateTime.Now.Year + 20; i++)
            {
                cboNam.Items.Add(i);
                cboNam2.Items.Add(i);
            }
            cboNam.SelectedItem = DateTime.Now.Year;
            cboNam2.SelectedItem = DateTime.Now.Year;
        }

        private void dtpNgay_CloseUp(object sender, EventArgs e)
        {
            tinhDoanhThuTheoNgay();
        }

        private void cboThang_DropDownClosed(object sender, EventArgs e)
        {
            tinhDoanhThuTheoThang();
        }

        private void cboNam_DropDownClosed(object sender, EventArgs e)
        {
            tinhDoanhThuTheoThang();
        }

        private void cboNam2_DropDownClosed(object sender, EventArgs e)
        {
            tinhDoanhThuTheoNam();
        }

        private void tinhDoanhThuTheoNgay()
        {
            var ngay = dtpNgay.Value;
            //MessageBox.Show(ngay.ToString());
            double doanhthu = 0;
            double dauvao = 0;
            double daura = 0;
            // Tìm chi tiết hóa đơn dựa theo đầu vào 1 hoặc đầu ra 2
            var dsDauVao = (from t1 in db.HoaDons
                            join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                            where t1.LoaiHoaDon.Equals(1)
                            select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();
            var dsDauRa = (from t1 in db.HoaDons
                           join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                           where t1.LoaiHoaDon.Equals(2)
                           select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();

            // Lọc theo giá trị ngày tháng năm của date time picker
            var dsDauVao2 =
                dsDauVao.Where(u => u.NgayLapHoaDon.Value.ToString("yy-MM-dd").Equals(ngay.ToString("yy-MM-dd")))
                    .ToList();
            var dsDauRa2 =
                dsDauRa.Where(u => u.NgayLapHoaDon.Value.ToString("yy-MM-dd").Equals(ngay.ToString("yy-MM-dd")))
                    .ToList();
            // Tính đầu vào, đầu ra
            foreach (var item in dsDauVao2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                dauvao += (double)(item.DonGia * item.SoLuong);
            }
            foreach (var item in dsDauRa2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                daura += (double)(item.DonGia * item.SoLuong);
            }
            //Doanh thu ngày = đầu ra - đầu vào
            doanhthu = dauvao - daura;
            lblDoanhThuNgay.Text = "Doanh thu ngày " + ngay.ToString("dd/MM/yyyy") + " : " + doanhthu.ToString();
        }

        private void tinhDoanhThuTheoThang()
        {
            var date = new DateTime(int.Parse(cboNam.SelectedItem.ToString()), int.Parse(cboThang.SelectedItem.ToString()), 1);

            var thang = date;

            //MessageBox.Show(ngay.ToString());
            double doanhthu = 0;
            double dauvao = 0;
            double daura = 0;
            // Tìm chi tiết hóa đơn dựa theo đầu vào 1 hoặc đầu ra 2
            var dsDauVao = (from t1 in db.HoaDons
                            join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                            where t1.LoaiHoaDon.Equals(1)
                            select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();
            var dsDauRa = (from t1 in db.HoaDons
                           join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                           where t1.LoaiHoaDon.Equals(2)
                           select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();

            // Lọc theo giá trị ngày tháng năm của date time picker
            var dsDauVao2 =
                dsDauVao.Where(u => u.NgayLapHoaDon.Value.ToString("MM-yyyy").Equals(thang.ToString("MM-yyyy")))
                    .ToList();
            var dsDauRa2 =
                dsDauRa.Where(u => u.NgayLapHoaDon.Value.ToString("MM-yyyy").Equals(thang.ToString("MM-yyyy")))
                    .ToList();
            // Tính đầu vào, đầu ra
            foreach (var item in dsDauVao2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                dauvao += (double)(item.DonGia * item.SoLuong);
            }
            foreach (var item in dsDauRa2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                daura += (double)(item.DonGia * item.SoLuong);
            }
            //Doanh thu ngày = đầu ra - đầu vào
            doanhthu = dauvao - daura;
            lblDoanhThuThang.Text = "Doanh thu tháng " + thang.ToString("MM/yyyy") + " : " + doanhthu.ToString();
        }

        private void tinhDoanhThuTheoNam()
        {
            var date = new DateTime(int.Parse(cboNam2.SelectedItem.ToString()), 1, 1);
            var nam = date;
            //MessageBox.Show(ngay.ToString());
            double doanhthu = 0;
            double dauvao = 0;
            double daura = 0;
            // Tìm chi tiết hóa đơn dựa theo đầu vào 1 hoặc đầu ra 2
            var dsDauVao = (from t1 in db.HoaDons
                            join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                            where t1.LoaiHoaDon.Equals(1)
                            select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();
            var dsDauRa = (from t1 in db.HoaDons
                           join t2 in db.HoaDonChiTiets on t1.MaHoaDon equals t2.MaHoaDon
                           where t1.LoaiHoaDon.Equals(2)
                           select new { t2.MaSanPham, t2.SoLuong, t2.DonGia, t1.NgayLapHoaDon }).ToList();

            // Lọc theo giá trị ngày tháng năm của date time picker
            var dsDauVao2 =
                dsDauVao.Where(u => u.NgayLapHoaDon.Value.ToString("yyyy").Equals(nam.ToString("yyyy")))
                    .ToList();
            var dsDauRa2 =
                dsDauRa.Where(u => u.NgayLapHoaDon.Value.ToString("yyyy").Equals(nam.ToString("yyyy")))
                    .ToList();
            // Tính đầu vào, đầu ra
            foreach (var item in dsDauVao2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                dauvao += (double)(item.DonGia * item.SoLuong);
            }
            foreach (var item in dsDauRa2)
            {
                var sp = db.SanPhams.Find(item.MaSanPham);
                daura += (double)(item.DonGia * item.SoLuong);
            }
            //Doanh thu ngày = đầu ra - đầu vào
            doanhthu = dauvao - daura;
            lblDoanhThuNam.Text = "Doanh thu năm " + nam.ToString("yyyy") + " : " + doanhthu.ToString();
        }
    }
}