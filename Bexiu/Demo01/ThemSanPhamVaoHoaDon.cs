using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo01
{
    public partial class ThemSanPhamVaoHoaDon : Form
    {
        DataContext db = DataObject.db;

        //DataContext db = new DataContext();

        public ThemSanPhamVaoHoaDon()
        {
            InitializeComponent();

            loadData();
            loadDonVi();
            loadCuaHang();
            radioGroup();
        }

        public ThemSanPhamVaoHoaDon(int mahoadon, int masp)
        {
            InitializeComponent();

            loadData();
            loadDonVi();
            loadCuaHang();
            radioGroup();

            txtMaHoaDon.Text = mahoadon.ToString();
            txtMaSP.Text = masp.ToString();
            loadSanPham();
        }

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

        private void loadDonVi()
        {
            cboDonVi.DataSource = db.DonVis.Local.ToBindingList();
            cboDonVi.DisplayMember = "TenDonVi";
            cboDonVi.ValueMember = "MaDonVi";
        }

        private void loadCuaHang()
        {
            cboCuaHang.DataSource = db.CuaHangs.Local.ToBindingList();
            cboCuaHang.DisplayMember = "TenCuaHang";
            cboCuaHang.ValueMember = "MaCuaHang";
        }

        private void loadSanPham()
        {
            var masp = int.Parse(txtMaSP.Text);
            var sp = db.SanPhams.Find(masp);
            if (sp != null)
            {
                lblTenSP.Text = sp.TenSP;
                lblSoDuSP.Text = sp.SoLuong.ToString();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            //Thêm sp vào hóa đơn
            var chitiet = new HoaDonChiTiet()
            {
                MaHoaDon = int.Parse(txtMaHoaDon.Text),
                MaSanPham = int.Parse(txtMaSP.Text),
                SoLuong = int.Parse(txtSoLuong.Value.ToString()),
                DonGia = double.Parse(txtDonGia.Value.ToString())
            };
            if (rdDonVi.Checked)
            {
                chitiet.MaDonVi = int.Parse(cboDonVi.SelectedValue.ToString());
            }
            else if (rdCuaHang.Checked)
            {
                chitiet.MaCuaHang = int.Parse(cboCuaHang.SelectedValue.ToString());
            }
            db.HoaDonChiTiets.Add(chitiet);

            //Tăng, giảm số lượng sản phẩm
            int soluong = int.Parse(txtSoLuong.Value.ToString());
            int mahoadon = int.Parse(txtMaHoaDon.Text);
            int masp = int.Parse(txtMaSP.Text);

            var hoadon = db.HoaDons.Find(mahoadon);
            var sp = db.SanPhams.Find(masp);
            if (hoadon != null && sp != null)
            {
                if (hoadon.LoaiHoaDon == 1) // đầu vào
                {
                    sp.SoLuong += soluong;
                }
                else if (hoadon.LoaiHoaDon == 2) // đầu ra
                {
                    sp.SoLuong -= soluong;
                }
            }

            db.SaveChanges();
            MessageBox.Show("Thêm sản phẩm vào hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioGroup()
        {
            if (rdDonVi.Checked)
            {
                cboDonVi.Enabled = true;
                cboCuaHang.Enabled = false;
            }
            else if (rdCuaHang.Checked)
            {
                cboCuaHang.Enabled = true;
                cboDonVi.Enabled = false;
            }
        }

        private void rdDonVi_Click(object sender, EventArgs e)
        {
            radioGroup();
        }

        private void rdCuaHang_Click(object sender, EventArgs e)
        {
            radioGroup();
        }
    }
}