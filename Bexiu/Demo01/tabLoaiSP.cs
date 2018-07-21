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
        private void loadLoaiSP()
        {
            var loaisplist = (from s in db.LoaiSanPhams
                              select s).ToList();
            gvLoaiSP.DataSource = null;
            gvLoaiSP.DataSource = loaisplist;

            gvLoaiSP.Columns[0].HeaderText = "Mã loại sản phẩm";
            gvLoaiSP.Columns[1].HeaderText = "Tên loại sản phẩm";
            gvLoaiSP.Columns[0].Width = 120;
            gvLoaiSP.Columns[1].Width = 120;

            //gvLoaiSP.DataSource = null;
            //gvLoaiSP.DataSource = db.LoaiSanPhams.Local.ToBindingList();
        }

        private void loadComboBoxLoaiSP()
        {
            cboLoaiSP.DataSource = db.LoaiSanPhams.Local.ToBindingList();
            cboLoaiSP.DisplayMember = "TenLoaiSP";
            cboLoaiSP.ValueMember = "MaLoaiSP";
        }

        private void gvLoaiSP_SelectionChanged(object sender, EventArgs e)
        {
            if (gvLoaiSP.CurrentRow != null)
            {
                var row = gvLoaiSP.CurrentRow.Index;
                if (row != -1)
                {
                    txtMaLoaiSP.Text = gvLoaiSP.Rows[row].Cells[0].Value.ToString();
                    txtTenLoaiSP.Text = gvLoaiSP.Rows[row].Cells[1].Value.ToString();
                }
            }
        }

        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            var newloaisp = new LoaiSanPham()
            {
                TenLoaiSP = txtTenLoaiSP.Text,
            };
            db.LoaiSanPhams.Add(newloaisp);
            db.SaveChanges();
            MessageBox.Show("Thêm loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLoaiSP();
        }

        private void btnSuaLoaiSP_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaLoaiSP.Text);
            var loaisp = db.LoaiSanPhams.Find(id);
            if (loaisp != null)
            {
                loaisp.TenLoaiSP = txtTenLoaiSP.Text;
            }
            db.SaveChanges();
            MessageBox.Show("Sửa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLoaiSP();
        }

        private void btnXoaLoaiSP_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaLoaiSP.Text);
            var loaisp = db.LoaiSanPhams.Find(id);
            if (loaisp != null)
            {
                db.LoaiSanPhams.Remove(loaisp);
            }
            db.SaveChanges();
            MessageBox.Show("Xóa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLoaiSP();
        }
    }
}