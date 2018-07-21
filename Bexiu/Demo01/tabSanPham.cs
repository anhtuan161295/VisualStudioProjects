using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo01
{
    public partial class Form1
    {
        private void loadSanPham()
        {
            var splist = (from s in db.SanPhams
                          join p in db.LoaiSanPhams on s.LoaiSP equals p.MaLoaiSP
                          select new
                          {
                              s.MaSP,
                              s.TenSP,
                              s.LoaiSP,
                              p.TenLoaiSP,
                              s.SoLuong
                          }).ToList();
            gvSanPham.DataSource = null;
            gvSanPham.DataSource = splist;
            gvSanPham.Columns[2].Visible = false;
            gvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            gvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            gvSanPham.Columns[2].HeaderText = "Loại sản phẩm";
            gvSanPham.Columns[3].HeaderText = "Loại sản phẩm";
            gvSanPham.Columns[4].HeaderText = "Số lượng còn lại";

            gvSanPham.Columns[3].Width = 120;
            gvSanPham.Columns[4].Width = 120;

            //gvSanPham.DataSource = null;
            //gvSanPham.DataSource = db.SanPhams.Local.ToBindingList();
        }

        private void gvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (gvSanPham.CurrentRow != null)
            {
                var row = gvSanPham.CurrentRow.Index;
                if (row != -1)
                {
                    txtMaSP.Text = gvSanPham.Rows[row].Cells[0].Value.ToString();
                    txtTenSP.Text = gvSanPham.Rows[row].Cells[1].Value.ToString();
                    cboLoaiSP.SelectedValue = gvSanPham.Rows[row].Cells[2].Value;
                    txtSoLuongSP.Value = int.Parse(gvSanPham.Rows[row].Cells[4].Value.ToString());
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            var newsp = new SanPham()
            {
                TenSP = txtTenSP.Text,
                LoaiSP = int.Parse(cboLoaiSP.SelectedValue.ToString()),
                SoLuong = int.Parse(txtSoLuongSP.Value.ToString())
            };
            db.SanPhams.Add(newsp);
            db.SaveChanges();
            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadSanPham();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaSP.Text);
            var sp = db.SanPhams.Find(id);
            if (sp != null)
            {
                sp.TenSP = txtTenSP.Text;
                sp.LoaiSP = int.Parse(cboLoaiSP.SelectedValue.ToString());
                sp.SoLuong = int.Parse(txtSoLuongSP.Value.ToString());
            }
            db.SaveChanges();
            MessageBox.Show("Sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadSanPham();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaSP.Text);
            var sp = db.SanPhams.Find(id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
            }
            db.SaveChanges();
            MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadSanPham();
        }
    }
}