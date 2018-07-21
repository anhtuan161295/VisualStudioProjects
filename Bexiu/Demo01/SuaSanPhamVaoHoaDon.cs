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
    public partial class SuaSanPhamVaoHoaDon : Form
    {
        DataContext db = DataObject.db;
        //DataContext db = new DataContext();

        public SuaSanPhamVaoHoaDon()
        {
            InitializeComponent();

            loadData();
            loadDonVi();
            loadCuaHang();
            radioGroup();
        }

        public SuaSanPhamVaoHoaDon(int machitiet, int mahoadon, int masp)
        {
            InitializeComponent();

            loadData();
            loadDonVi();
            loadCuaHang();
            radioGroup();

            txtMaChiTiet.Text = machitiet.ToString();
            txtMaHoaDon.Text = mahoadon.ToString();
            txtMaSP.Text = masp.ToString();
            loadSanPham();
            loadChiTiet();
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

        private void loadChiTiet()
        {
            var machitiet = int.Parse(txtMaChiTiet.Text);
            var ct = db.HoaDonChiTiets.Find(machitiet);
            if (ct != null)
            {
                txtSoLuong.Value = int.Parse(ct.SoLuong.ToString());
                txtDonGia.Value = int.Parse(ct.DonGia.ToString());
                if (ct.MaDonVi != null)
                {
                    rdDonVi.Checked = true;
                    cboDonVi.Enabled = true;
                    cboDonVi.SelectedValue = ct.MaDonVi;
                    rdCuaHang.Checked = false;
                    cboCuaHang.Enabled = false;
                }
                else if (ct.MaCuaHang != null)
                {
                    rdCuaHang.Checked = true;
                    cboCuaHang.Enabled = true;
                    cboCuaHang.SelectedValue = ct.MaCuaHang;
                    rdDonVi.Checked = false;
                    cboDonVi.Enabled = false;
                }
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            var chitiet = db.HoaDonChiTiets.Find(int.Parse(txtMaChiTiet.Text));
            if (chitiet != null)
            {
                chitiet.SoLuong = int.Parse(txtSoLuong.Value.ToString());
                chitiet.DonGia = double.Parse(txtDonGia.Value.ToString());
                if (rdDonVi.Checked)
                {
                    chitiet.MaDonVi = int.Parse(cboDonVi.SelectedValue.ToString());
                    chitiet.MaCuaHang = null;
                }
                else if (rdCuaHang.Checked)
                {
                    chitiet.MaCuaHang = int.Parse(cboCuaHang.SelectedValue.ToString());
                    chitiet.MaDonVi = null;
                }
                db.SaveChanges();
                MessageBox.Show("Sửa sản phẩm trong hóa đơn thành công");
            }
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