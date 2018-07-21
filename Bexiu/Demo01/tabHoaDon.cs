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
        private void loadHoaDon()
        {
            var hdlist = (from s in db.HoaDons
                          join p in db.LoaiHoaDons on s.LoaiHoaDon equals p.MaLoaiHoaDon
                          select new
                          {
                              s.MaHoaDon,
                              s.LoaiHoaDon,
                              p.TenLoaiHoaDon,
                              s.NgayLapHoaDon
                          }).ToList();

            gvHoaDon.DataSource = null;
            gvHoaDon.DataSource = hdlist;
            gvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            gvHoaDon.Columns[1].HeaderText = "Loại hóa đơn";
            gvHoaDon.Columns[2].HeaderText = "Loại hóa đơn";
            gvHoaDon.Columns[3].HeaderText = "Ngày lập hóa đơn";
            gvHoaDon.Columns[0].Width = 90;
            gvHoaDon.Columns[3].Width = 120;
            gvHoaDon.Columns[1].Visible = false;

            //gvHoaDon.DataSource = null;
            //gvHoaDon.DataSource = db.HoaDons.Local.ToBindingList();
        }

        private void loadComboBoxLoaiHoaDon()
        {
            cboLoaiHoaDon.DataSource = db.LoaiHoaDons.Local.ToBindingList();
            cboLoaiHoaDon.DisplayMember = "TenLoaiHoaDon";
            cboLoaiHoaDon.ValueMember = "MaLoaiHoaDon";
        }

        private void loadHoaDonChiTiet(int maHoaDon)
        {
            var hdct = (from s in db.HoaDons
                        join p in db.HoaDonChiTiets on s.MaHoaDon equals p.MaHoaDon
                        join k in db.SanPhams on p.MaSanPham equals k.MaSP
                        select new
                        {
                            p.MaChiTiet,
                            p.MaHoaDon,
                            p.MaSanPham,
                            p.SoLuong,
                            p.DonGia,
                            p.MaDonVi,
                            p.MaCuaHang,
                            k.TenSP
                        }).ToList();
            var hdct1 = hdct.Where(u => u.MaHoaDon == maHoaDon).ToList();

            gvHoaDonChiTiet.DataSource = hdct1;
            gvHoaDonChiTiet.Columns[0].HeaderText = "Mã chi tiết";
            gvHoaDonChiTiet.Columns[1].HeaderText = "Mã hóa đơn";
            gvHoaDonChiTiet.Columns[2].HeaderText = "Mã sản phẩm";
            gvHoaDonChiTiet.Columns[3].HeaderText = "Số lượng";
            gvHoaDonChiTiet.Columns[4].HeaderText = "Đơn giá";
            gvHoaDonChiTiet.Columns[5].HeaderText = "Mã đơn vị";
            gvHoaDonChiTiet.Columns[6].HeaderText = "Mã cửa hàng";
            gvHoaDonChiTiet.Columns[7].HeaderText = "Tên sản phẩm";

            gvHoaDonChiTiet.Columns[0].Visible = false;
            gvHoaDonChiTiet.Columns[1].Visible = false;
            gvHoaDonChiTiet.Columns[2].Visible = false;
            gvHoaDonChiTiet.Columns[5].Visible = false;
            gvHoaDonChiTiet.Columns[6].Visible = false;

            gvHoaDonChiTiet.Columns[7].DisplayIndex = 0;
            gvHoaDonChiTiet.Columns[3].DisplayIndex = 1;
            gvHoaDonChiTiet.Columns[4].DisplayIndex = 2;

            //var id = int.Parse(txtMaHoaDon.Text);
            //var chitiet = db.HoaDonChiTiets.Where(u => u.MaHoaDon == id).ToList();
            //gvHoaDonChiTiet.DataSource = chitiet;

            double total = 0;

            for (int i = 0; i < gvHoaDonChiTiet.RowCount; i++)
            {
                var masp = int.Parse(gvHoaDonChiTiet.Rows[i].Cells[2].Value.ToString());
                var soluong = int.Parse(gvHoaDonChiTiet.Rows[i].Cells[3].Value.ToString());
                var dongia = int.Parse(gvHoaDonChiTiet.Rows[i].Cells[4].Value.ToString());

                var sp = db.SanPhams.Find(masp);
                total += (double)(dongia * soluong);
            }
            lblTotal.Text = total.ToString();
        }

        private void loadComboBoxLoaiSP_HoaDon()
        {
            cboLoaiSP_HoaDon.DataSource = db.LoaiSanPhams.Local.ToBindingList();
            cboLoaiSP_HoaDon.DisplayMember = "TenLoaiSP";
            cboLoaiSP_HoaDon.ValueMember = "MaLoaiSP";
        }

        private void getSanPhamFromLoaiSP()
        {
            if (string.IsNullOrEmpty(txtSearchSP.Text))
            {
                int maloaisp = int.Parse(cboLoaiSP_HoaDon.SelectedValue.ToString());
                var sp = db.SanPhams.Where(u => u.LoaiSP == maloaisp).ToList();

                gvSearchSP.DataSource = sp;
            }
            else if (txtSearchSP.Text != null)
            {
                int maloaisp = int.Parse(cboLoaiSP_HoaDon.SelectedValue.ToString());
                var sp = db.SanPhams.Where(u => u.LoaiSP == maloaisp && u.TenSP.Contains(txtSearchSP.Text)).ToList();

                gvSearchSP.DataSource = sp;
            }
            gvSearchSP.Columns[0].HeaderText = "Mã sản phẩm";
            gvSearchSP.Columns[1].HeaderText = "Tên sản phẩm";
            gvSearchSP.Columns[2].HeaderText = "Loại sản phẩm";
            gvSearchSP.Columns[3].HeaderText = "Số lượng còn lại";
            gvSearchSP.Columns[0].Visible = false;
            gvSearchSP.Columns[2].Visible = false;
            gvSearchSP.Columns[3].Width = 120;
        }

        private void gvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (gvHoaDon.CurrentRow != null)
            {
                var row = gvHoaDon.CurrentRow.Index;
                if (row != -1)
                {
                    txtMaHoaDon.Text = gvHoaDon.Rows[row].Cells[0].Value.ToString();
                    txtNgayLapHoaDon.Text = gvHoaDon.Rows[row].Cells[3].Value.ToString();
                    cboLoaiHoaDon.SelectedValue = gvHoaDon.Rows[row].Cells[1].Value;

                    loadHoaDonChiTiet(int.Parse(txtMaHoaDon.Text));
                }
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            var newhoadon = new HoaDon()
            {
                NgayLapHoaDon = DateTime.Now,
                LoaiHoaDon = int.Parse(cboLoaiHoaDon.SelectedValue.ToString())
            };
            db.HoaDons.Add(newhoadon);
            db.SaveChanges();
            MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadHoaDon();
        }

        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtMaHoaDon.Text);
            var hoadon = db.HoaDons.Find(id);
            if (hoadon != null)
            {
                hoadon.NgayLapHoaDon = DateTime.Now;
                hoadon.LoaiHoaDon = int.Parse(cboLoaiHoaDon.SelectedValue.ToString());
            }
            db.SaveChanges();
            MessageBox.Show("Sửa hóa đơn thành công");
            loadHoaDon();
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (gvHoaDon.CurrentRow != null)
            {
                var confirm = MessageBox.Show("Xác nhận xóa hóa đơn này ?", "Xóa hóa đơn", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (confirm == DialogResult.OK)
                {
                    var id = int.Parse(txtMaHoaDon.Text);
                    var hoadon = db.HoaDons.Find(id);
                    if (hoadon != null)
                    {
                        var chitiet = db.HoaDonChiTiets.Where(u => u.MaHoaDon == id).ToList();
                        if (chitiet != null)
                        {
                            foreach (var item in chitiet)
                            {
                                var sp = db.SanPhams.Find(item.MaSanPham);
                                if (sp != null)
                                {
                                    if (hoadon.LoaiHoaDon == 1) //Đầu vào
                                    {
                                        sp.SoLuong -= item.SoLuong;
                                    }
                                    if (hoadon.LoaiHoaDon == 2) //Đầu ra
                                    {
                                        sp.SoLuong += item.SoLuong;
                                    }
                                }
                            }
                            db.HoaDonChiTiets.RemoveRange(chitiet);
                            db.SaveChanges();
                        }
                        db.HoaDons.Remove(hoadon);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadHoaDon();
                    loadSanPham();
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvHoaDonChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            //if (gvHoaDonChiTiet.CurrentRow != null)
            //{
            //    var row = gvHoaDonChiTiet.CurrentRow.Index;
            //    if (row != -1)
            //    {
            //        txtMaChiTiet.Text = gvHoaDonChiTiet.Rows[row].Cells[0].Value.ToString();
            //        //Lấy mã sản phẩm
            //        var masp = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[2].Value.ToString());
            //        //Tìm sản phẩm trong database
            //        var sp = db.SanPhams.Find(masp);
            //        if (sp != null)
            //        {
            //            //Chọn loại sản phẩm trên combo box
            //            cboLoaiSP_HoaDon.SelectedValue = sp.LoaiSP;
            //            //Load lại combo box sản phẩm
            //            getSanPhamFromLoaiSP();
            //            //Chọn sản phẩm
            //            //cboSanPham_HoaDon.SelectedValue = sp.MaSP;
            //        }

            //        txtSoLuongSP_HoaDon.Value = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[3].Value.ToString());
            //    }
            //}
        }

        private void btnThemSP_HoaDon_Click(object sender, EventArgs e)
        {
            if (gvHoaDon.CurrentRow != null)
            {
                if (gvSearchSP.CurrentRow != null)
                {
                    var row = gvSearchSP.CurrentRow.Index;
                    if (row != -1)
                    {
                        var mahoadon = int.Parse(txtMaHoaDon.Text);
                        var masp = int.Parse(gvSearchSP.Rows[row].Cells[0].Value.ToString());
                        var tsp = new ThemSanPhamVaoHoaDon(mahoadon, masp);
                        tsp.ShowDialog();
                    }
                    loadHoaDonChiTiet(int.Parse(txtMaHoaDon.Text));
                    loadSanPham();
                }
                else
                {
                    MessageBox.Show("Chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaSP_HoaDon_Click(object sender, EventArgs e)
        {
            if (gvHoaDonChiTiet.CurrentRow != null)
            {
                var row = gvHoaDonChiTiet.CurrentRow.Index;
                if (row != -1)
                {
                    var machitiet = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[0].Value.ToString());
                    var mahoadon = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[1].Value.ToString());
                    var masp = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[2].Value.ToString());
                    var tsp = new SuaSanPhamVaoHoaDon(machitiet, mahoadon, masp);
                    tsp.ShowDialog();
                }
                loadHoaDonChiTiet(int.Parse(txtMaHoaDon.Text));
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm");
            }

            //var maChiTiet = int.Parse(txtMaChiTiet.Text);
            //var chitiet = db.HoaDonChiTiets.Find(maChiTiet);
            //if (chitiet != null)
            //{
            //    //chitiet.MaSanPham = int.Parse(cboSanPham_HoaDon.SelectedValue.ToString());
            //    chitiet.SoLuong = int.Parse(txtSoLuongSP_HoaDon.Text);
            //}

            //db.SaveChanges();
            //MessageBox.Show("Sửa sản phẩm trong hóa đơn thành công");
            //loadHoaDonChiTiet(int.Parse(txtMaHoaDon.Text));
        }

        private void btnXoaSP_HoaDon_Click(object sender, EventArgs e)
        {
            if (gvHoaDonChiTiet.CurrentRow != null)
            {
                var confirm = MessageBox.Show("Xác nhận xóa sản phẩm này ?", "Xóa sản phẩm trong hóa đơn", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (confirm == DialogResult.OK)
                {
                    var row = gvHoaDonChiTiet.CurrentRow.Index;
                    if (row != -1)
                    {
                        var maChiTiet = int.Parse(gvHoaDonChiTiet.Rows[row].Cells[0].Value.ToString());
                        var chitiet = db.HoaDonChiTiets.Find(maChiTiet);
                        if (chitiet != null)
                        {
                            //Tăng, giảm số lượng sản phẩm
                            var soluong = chitiet.SoLuong;
                            var hoadon = db.HoaDons.Find(chitiet.MaHoaDon);
                            var sp = db.SanPhams.Find(chitiet.MaSanPham);
                            if (hoadon != null && sp != null)
                            {
                                if (hoadon.LoaiHoaDon == 1) // đầu vào
                                {
                                    sp.SoLuong -= soluong;
                                }
                                else if (hoadon.LoaiHoaDon == 2) // đầu ra
                                {
                                    sp.SoLuong += soluong;
                                }
                            }
                            db.HoaDonChiTiets.Remove(chitiet);
                        }

                        db.SaveChanges();
                        MessageBox.Show("Xóa sản phẩm trong hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadHoaDonChiTiet(int.Parse(txtMaHoaDon.Text));
                        loadSanPham();
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getSanPhamFromLoaiSP();
        }
    }
}