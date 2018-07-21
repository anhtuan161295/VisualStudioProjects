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
        private void loadDonVi()
        {
            gvDonVi.DataSource = null;
            gvDonVi.DataSource = db.DonVis.Local.ToBindingList();
            gvDonVi.Columns[0].HeaderText = "Mã đơn vị";
            gvDonVi.Columns[1].HeaderText = "Tên đơn vị";
            gvDonVi.Columns[2].HeaderText = "Địa chỉ";
            gvDonVi.Columns[3].HeaderText = "Số điện thoại";
        }

        private void loadCuaHang()
        {
            gvCuaHang.DataSource = null;
            gvCuaHang.DataSource = db.CuaHangs.Local.ToBindingList();
            gvCuaHang.Columns[0].HeaderText = "Mã cửa hàng";
            gvCuaHang.Columns[1].HeaderText = "Tên cửa hàng";
            gvCuaHang.Columns[2].HeaderText = "Địa chỉ";
            gvCuaHang.Columns[3].HeaderText = "Số điện thoại";
        }

        private void btnThemDonVi_Click(object sender, EventArgs e)
        {
            var newdonvi = new DonVi()
            {
                TenDonVi = txtTenDonVi.Text,
                DiaChi = txtDiaChiDonVi.Text,
                SoDienThoai = txtSDTDonVi.Text
            };
            db.DonVis.Add(newdonvi);
            db.SaveChanges();
            MessageBox.Show("Thêm đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDonVi();
        }

        private void btnSuaDonVi_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaDonVi.Text);
            var donvi = db.DonVis.Find(id);
            if (donvi != null)
            {
                donvi.TenDonVi = txtTenDonVi.Text;
                donvi.DiaChi = txtDiaChiDonVi.Text;
                donvi.SoDienThoai = txtSDTDonVi.Text;
            }
            db.SaveChanges();
            MessageBox.Show("Sửa đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDonVi();
        }

        private void btnXoaDonVi_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaDonVi.Text);
            var donvi = db.DonVis.Find(id);
            if (donvi != null)
            {
                db.DonVis.Remove(donvi);
            }
            db.SaveChanges();
            MessageBox.Show("Xóa đơn vị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDonVi();
        }

        private void btnThemCuaHang_Click(object sender, EventArgs e)
        {
            var newcuahang = new CuaHang()
            {
                TenCuaHang = txtTenCuaHang.Text,
                DiaChi = txtDiaChiCuaHang.Text,
                SoDienThoai = txtSDTCuaHang.Text
            };
            db.CuaHangs.Add(newcuahang);
            db.SaveChanges();
            MessageBox.Show("Thêm cửa hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadCuaHang();
        }

        private void btnSuaCuaHang_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaCuaHang.Text);
            var cuahang = db.CuaHangs.Find(id);
            if (cuahang != null)
            {
                cuahang.TenCuaHang = txtTenCuaHang.Text;
                cuahang.DiaChi = txtDiaChiCuaHang.Text;
                cuahang.SoDienThoai = txtSDTCuaHang.Text;
            }
            db.SaveChanges();
            MessageBox.Show("Sửa cửa hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadCuaHang();
        }

        private void btnXoaCuaHang_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaCuaHang.Text);
            var cuahang = db.CuaHangs.Find(id);
            if (cuahang != null)
            {
                db.CuaHangs.Remove(cuahang);
            }
            db.SaveChanges();
            MessageBox.Show("Xóa cửa hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadCuaHang();
        }

        private void gvDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (gvDonVi.CurrentRow != null)
            {
                var row = gvDonVi.CurrentRow.Index;
                if (row != -1)
                {
                    txtMaDonVi.Text = gvDonVi.Rows[row].Cells[0].Value.ToString();
                    txtTenDonVi.Text = gvDonVi.Rows[row].Cells[1].Value.ToString();
                    txtDiaChiDonVi.Text = gvDonVi.Rows[row].Cells[2].Value.ToString();
                    txtSDTDonVi.Text = gvDonVi.Rows[row].Cells[3].Value.ToString();
                }
            }
        }

        private void gvCuaHang_SelectionChanged(object sender, EventArgs e)
        {
            if (gvCuaHang.CurrentRow != null)
            {
                var row = gvCuaHang.CurrentRow.Index;
                if (row != -1)
                {
                    txtMaCuaHang.Text = gvCuaHang.Rows[row].Cells[0].Value.ToString();
                    txtTenCuaHang.Text = gvCuaHang.Rows[row].Cells[1].Value.ToString();
                    txtDiaChiCuaHang.Text = gvCuaHang.Rows[row].Cells[2].Value.ToString();
                    txtSDTCuaHang.Text = gvCuaHang.Rows[row].Cells[3].Value.ToString();
                }
            }
        }
    }
}