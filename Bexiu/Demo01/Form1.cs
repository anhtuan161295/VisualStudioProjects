using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo01
{
    public partial class Form1 : Form
    {
        DataContext db = DataObject.db;
        //public static DataContext db = new DataContext();

        public Form1()
        {
            InitializeComponent();

            loadData();
            loadSanPham();
            loadLoaiSP();
            loadComboBoxLoaiSP();
            loadDonVi();
            loadCuaHang();
            loadHoaDon();
            loadComboBoxLoaiHoaDon();

            loadComboBoxLoaiSP_HoaDon();

            loadComboboxThang();
            loadComboboxNam();

            tinhDoanhThuTheoNgay();
            tinhDoanhThuTheoThang();
            tinhDoanhThuTheoNam();
        }

        // Tải dữ liệu từ database lên bộ nhớ
        private void loadData()
        {
            db.LoaiSanPhams.Load();
            db.SanPhams.Load();
            db.DonVis.Load();
            db.CuaHangs.Load();
            db.HoaDons.Load();
            db.LoaiHoaDons.Load();
            db.HoaDonChiTiets.Load();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            tinhDoanhThuTheoNgay();
            tinhDoanhThuTheoThang();
            tinhDoanhThuTheoNam();
        }
    }
}