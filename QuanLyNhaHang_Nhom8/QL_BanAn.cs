using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.IO;

namespace QuanLyNhaHang_Nhom8
{
    public partial class QL_BanAn : Form
    {
        CN_QLBanAn a = new CN_QLBanAn();
        string conStr = Properties.Settings.Default.ConStr;
        public QL_BanAn()
        {
            //txt_soluong.TextChanged += NumericOnly_TextChanged;
            InitializeComponent();
        }
        private void NumericOnly_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            // Loại bỏ các kí tự không phải số
            string numericText = new string(text.Where(char.IsDigit).ToArray());

            // Cập nhật nội dung của TextBox chỉ chứa số
            textBox.Text = numericText;
            // Di chuyển con trỏ về cuối TextBox
            textBox.SelectionStart = textBox.Text.Length;
        }
        private void QL_BanAn_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 800);
            flp_table.Controls.Clear();
            flp_menu.Controls.Clear();
            CreateTableList(a.DanhSachBan());
            Create_Menu(a.ThucDon());
        }
        public void Load_Ban()
        {
            flp_table.Controls.Clear();
            CreateTableList(a.DanhSachBan());
        }
        public void Load_Menu()
        {
             flp_menu.Controls.Clear();
             Create_Menu(a.ThucDon());
        }
        //class radius
        public class RoundPanel : Panel
        {
            public RoundPanel()
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (var path = new GraphicsPath())
                {
                    int radius = 7; // Độ cong của góc
                    int width = Width;
                    int height = Height;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(width - (radius * 2), height - (radius * 2), radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, height - (radius * 2), radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    Region = new Region(path);
                }
            }
        }
        //end class
        //class radius pt
        public class RoundPictureBox : PictureBox
        {
            public RoundPictureBox()
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);

                using (var path = new GraphicsPath())
                {
                    int radius = 4; // Độ cong của góc
                    int width = Width;
                    int height = Height;
                    path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                    path.AddArc(width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                    path.AddArc(width - (radius * 2), height - (radius * 2), radius * 2, radius * 2, 0, 90);
                    path.AddArc(0, height - (radius * 2), radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    Region = new Region(path);
                }

                this.SizeMode = PictureBoxSizeMode.StretchImage; // Đặt PictureBox để ảnh lấp đầy kích thước PictureBox
            }
        }
        //end
        private void ProcessTableClick(DataRow row)
        {
            string maBan = row["MaBan"].ToString();
            string trangThai = row["TrangThai"].ToString();

            if (trangThai.Equals("Trong"))
            {
                ShowConfirmationDialog("Bạn Có Muốn Vào Bàn?", () =>
                {
                    listView1.Items.Clear();
                    a.Update_Ban(maBan, "Co");
                    HandleClickEvent(row);
                    Load_Ban();
                });
            }
            else if (trangThai.Equals("Co"))
            {
                ShowConfirmationDialog("Bạn Có Muốn Order Thêm Món?", () =>
                {
                    listView1.Items.Clear();
                    txtMaBan.Text = maBan;
                    HienThiDanhSachMon(txtMaBan.Text);
                });
            }
        }
        private void HienThiDanhSachMon(string maBan)
        {
            string query = "SELECT ChiTietDatMon.MaMonAn, ThucDon.TenMonAn, ChiTietDatMon.SoLuong, ThucDon.GiaBan, ChiTietDatMon.GhiChu FROM ChiTietDatMon INNER JOIN DatMon ON ChiTietDatMon.MaDatMon = DatMon.MaDatMon INNER JOIN ThucDon ON ChiTietDatMon.MaMonAn = ThucDon.MaMonAn WHERE DatMon.MaBan = '" + maBan + "' AND ChiTietDatMon.TrangThai <> N'Đã thanh toán'";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        listView1.Items.Clear();

                        while (reader.Read())
                        {
                            string maMonAn = reader.GetString(0);
                            string tenMonAn = reader.GetString(1);
                            int soLuong = reader.GetInt32(2);
                            decimal giaBan = reader.GetDecimal(3);
                            string ghiChu = reader.IsDBNull(4) ? "" : reader.GetString(4);

                            // Tạo ListViewItem và thêm vào ListView
                            ListViewItem item = new ListViewItem(new string[] { maMonAn, tenMonAn, soLuong.ToString(), giaBan.ToString(), ghiChu });
                            listView1.Items.Add(item);

                            txt_tongtien.Text = CalculateTotalPrice().ToString();
                        }
                    }
                }
            }
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                int soLuong = int.Parse(item.SubItems[2].Text);
                decimal giaBan = decimal.Parse(item.SubItems[3].Text);
                totalPrice += soLuong * giaBan;
            }

            return totalPrice;
        }
        private void ShowConfirmationDialog(string message, Action action)
        {
            DialogResult result = MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                action.Invoke();
            }
        }
        private void HandleClickEvent(DataRow row)
        {
            string maBan = row["MaBan"].ToString();
            string trangThai = row["TrangThai"].ToString();
            txtMaBan.Text = maBan;
        }

        private void HandleTableClickEvents(RoundPictureBox pictureBox, Label labelMaBan, Label labelTrangThai, DataRow row)
        {
            pictureBox.Click += (sender, e) => ProcessTableClick(row);
            labelMaBan.Click += (sender, e) => ProcessTableClick(row);
            labelTrangThai.Click += (sender, e) => ProcessTableClick(row);
        }

        //ds bàn
        public void CreateTableList(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                RoundPanel panel = new RoundPanel();
                panel.Width = 90;
                panel.Height = 105;

                RoundPictureBox pictureBox = new RoundPictureBox();
                pictureBox.Image = Image.FromFile("..\\..\\Images\\ban_an.jpg");
                pictureBox.Width = panel.Width;
                pictureBox.Height = 50;
                pictureBox.Dock = DockStyle.Top;

                Label labelMaBan = new Label();
                labelMaBan.Text ="  "+row["MaBan"].ToString().ToUpper();
                labelMaBan.Font = new Font(labelMaBan.Font.FontFamily, 7, labelMaBan.Font.Style | FontStyle.Bold);
                labelMaBan.TextAlign = ContentAlignment.MiddleCenter;
                labelMaBan.Dock = DockStyle.Top;

                Label labelTrangThai = new Label();
                labelTrangThai.Text =""+row["TrangThai"].ToString().ToUpper();
                labelTrangThai.Font = new Font(labelTrangThai.Font.FontFamily, 7, labelTrangThai.Font.Style | FontStyle.Bold);
                labelTrangThai.TextAlign = ContentAlignment.MiddleCenter;
                labelTrangThai.Dock = DockStyle.Top;
                labelTrangThai.Margin = new Padding(0, 0, 0, 5);

                pictureBox.Click += (sender, e) =>
                {
                    ProcessTableClick(row);

                };
                labelMaBan.Click += (sender, e) => ProcessTableClick(row);
                labelTrangThai.Click += (sender, e) => ProcessTableClick(row);

                panel.Controls.Add(labelMaBan);
                panel.Controls.Add(labelTrangThai);
                panel.Controls.Add(pictureBox);
                panel.Padding = new Padding(10);

                if (row["TrangThai"].ToString().Equals("Co"))
                {
                    panel.BackColor = Color.Blue;
                    labelMaBan.ForeColor = Color.White;
                    labelTrangThai.ForeColor = Color.White;
                }
                else
                {
                    panel.BackColor = Color.FromArgb(180, 92, 5);
                    labelMaBan.ForeColor = Color.White;
                    labelTrangThai.ForeColor = Color.White;
                }

                flp_table.Controls.Add(panel);
            }
        }
        //menu
        public void Create_Menu(DataTable dttb)
        {
            DataTable dt = new DataTable();
            dt = dttb;
            foreach (DataRow row in dt.Rows)
            {
                RoundPanel panel = new RoundPanel();
                panel.Width = 150;
                panel.Height = 170;

                RoundPictureBox pictureBox = new RoundPictureBox();

                string imagePath = "..\\..\\Images\\" + row["DuongDanAnh"].ToString();
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox.Image = Image.FromFile("..\\..\\Images\\chiengamatong.jpg");
                }

                pictureBox.Width = panel.Width;
                pictureBox.Height = 110;
                pictureBox.Dock = DockStyle.Top;

                Label labelGiaBan = new Label();
                labelGiaBan.Text = "Giá: " + row["GiaBan"].ToString() + " VNĐ";
                labelGiaBan.Font = new Font(labelGiaBan.Font, FontStyle.Bold);
                labelGiaBan.TextAlign = ContentAlignment.MiddleCenter;
                labelGiaBan.Dock = DockStyle.Top;

                Label labelTenMon = new Label();
                labelTenMon.Text = row["TenMonAn"].ToString();
                labelTenMon.Text = row["TenMonAn"].ToString().ToUpper();
                labelTenMon.Font = new Font(labelTenMon.Font, FontStyle.Bold);
                labelTenMon.TextAlign = ContentAlignment.MiddleCenter;
                labelTenMon.Dock = DockStyle.Top;
                labelTenMon.Margin = new Padding(0, 0, 0, 10);

                panel.Controls.Add(labelGiaBan);
                panel.Controls.Add(labelTenMon);
                panel.Controls.Add(pictureBox);
                panel.Padding = new Padding(10);
                panel.BackColor = Color.FromArgb(180, 92, 5);
                labelTenMon.ForeColor = Color.White;
                labelGiaBan.ForeColor = Color.White;

                flp_menu.Controls.Add(panel);

                // Gắn sự kiện Click cho RoundPanel, RoundPictureBox, và Label
                panel.Click += (sender, e) =>
                {
                    AddToListView(row);
                };
                pictureBox.Click += (sender, e) =>
                {
                    AddToListView(row);
                };
                labelTenMon.Click += (sender, e) =>
                {
                    AddToListView(row);
                };
                labelGiaBan.Click += (sender, e) =>
                {
                    AddToListView(row);
                };
            }
        }

        private void AddToListView(DataRow row)
        {
            string quantityText = txt_soluong.Text;
            int additionalQuantity = 0;

            if (!string.IsNullOrEmpty(quantityText))
            {
                additionalQuantity = int.Parse(quantityText);
            }

            // Thêm một món mới vào danh sách
            int quantityToAdd = (additionalQuantity != 0) ? additionalQuantity : 1;

            ListViewItem newItem = new ListViewItem(row["MaMonAn"].ToString());
            newItem.SubItems.Add(row["TenMonAn"].ToString());
            newItem.SubItems.Add(quantityToAdd.ToString());
            newItem.SubItems.Add(row["GiaBan"].ToString());
            newItem.SubItems.Add(txt_note.Text);
            listView1.Items.Add(newItem);
            txt_note.Text = "";

            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                int quantity = int.Parse(item.SubItems[2].Text);
                decimal unitPrice = decimal.Parse(item.SubItems[3].Text);
                decimal itemTotal = quantity * unitPrice;
                totalPrice += itemTotal;
            }

            // Hiển thị tổng tiền ở đây, ví dụ đặt vào một Label
            txt_tongtien.Text = totalPrice.ToString();
        }

        //btn table
        private void btn_all_Click(object sender, EventArgs e)
        {
            flp_table.Controls.Clear();
            CreateTableList(a.DanhSachBan());
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            flp_table.Controls.Clear();
            CreateTableList(a.DanhSachBan_use("Co"));
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            flp_table.Controls.Clear();
            CreateTableList(a.DanhSachBan_use("Trong"));
        }
        //btn menu
        private void btn_allmenu_Click(object sender, EventArgs e)
        {
            flp_menu.Controls.Clear();
            Create_Menu(a.ThucDon());
        }

        private void btn_rice_Click(object sender, EventArgs e)
        {
            flp_menu.Controls.Clear();
            Create_Menu(a.ThucDon_use(btn_rice.Text));
        }

        private void btn_noodle_Click(object sender, EventArgs e)
        {
            flp_menu.Controls.Clear();
            Create_Menu(a.ThucDon_use(btn_noodle.Text));
        }

        private void btn_special_Click(object sender, EventArgs e)
        {
            flp_menu.Controls.Clear();
            Create_Menu(a.ThucDon_use(btn_special.Text));
        }

        private void btn_drink_Click(object sender, EventArgs e)
        {
            flp_menu.Controls.Clear();
            Create_Menu(a.ThucDon_use(btn_drink.Text));
        }

        private void txt_soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
                txt_soluong.Text = string.Empty;
            }
        }

        //control order
        private void ModifyQuantity(bool increase)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int soLuong = int.Parse(selectedItem.SubItems[2].Text);

                if (increase)
                {
                    // Tăng số lượng
                    soLuong++;
                }
                else
                {
                    // Giảm số lượng
                    if (soLuong > 1)
                    {
                        soLuong--;
                    }
                    else
                    {
                        // Nếu số lượng giảm xuống 0, xóa món khỏi ListView
                        listView1.Items.Remove(selectedItem);
                        UpdateTotalPrice();
                        return; // Thoát khỏi hàm nếu đã xóa món
                    }
                }

                selectedItem.SubItems[2].Text = soLuong.ToString();
                UpdateTotalPrice();
            }
        }

        private void btn_them1_Click(object sender, EventArgs e)
        {
            ModifyQuantity(true);
        }

        private void btn_giam1_Click(object sender, EventArgs e)
        {
            ModifyQuantity(false);
        }

        private void btn_xoamon_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                listView1.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món để xóa.");
            }
        }

        private void ThemGhiChuVaoListView()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string ghiChu = txt_note.Text;

                if (selectedItem.SubItems.Count >= 5)
                {
                    selectedItem.SubItems[4].Text = ghiChu;
                }
                else
                {
                    selectedItem.SubItems.Add(ghiChu);
                }

                txt_note.Text = "";
            }
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            ThemGhiChuVaoListView();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi đặt món!", "Thông Báo");
                return;
            }

            // Kiểm tra xem có món ăn trong ListView không
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Không có món ăn để đặt!", "Thông Báo");
                return;
            }

            string maDatMon = a.GenerateMaDatMon();
            if (string.IsNullOrEmpty(maDatMon))
            {
                MessageBox.Show("Không thể tạo mã đặt món!", "Lỗi");
                return;
            }
            string tendn = "di";
            if (Properties.Settings.Default.taikhoanchung != null || Properties.Settings.Default.taikhoanchung != "")
            {
                tendn = Properties.Settings.Default.taikhoanchung;
            }
            else
            {
                tendn = "di";
            }
            a.ThemDatMon(maDatMon, txtMaBan.Text, tendn);

            foreach (ListViewItem item in listView1.Items)
            {
                string maMonAn = item.SubItems[0].Text;
                if (string.IsNullOrEmpty(maMonAn))
                {
                    MessageBox.Show("Mã món ăn không hợp lệ!", "Lỗi");
                    return;
                }

                int soLuong;
                if (!int.TryParse(item.SubItems[2].Text, out soLuong))
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi");
                    return;
                }

                string ghiChu = item.SubItems[4].Text;

                // Kiểm tra xem món đã tồn tại trong cơ sở dữ liệu hay chưa
                if (a.MonAnExists(txtMaBan.Text, maMonAn))
                {
                    // Món đã tồn tại, cập nhật số lượng
                    a.CapNhatSoLuongMonAn(txtMaBan.Text, maMonAn, soLuong);
                }
                else
                {
                    // Món chưa tồn tại, thêm mới món vào cơ sở dữ liệu
                    string maCTDatMon = a.GenerateMaCTDatMon();
                    if (string.IsNullOrEmpty(maCTDatMon))
                    {
                        MessageBox.Show("Không thể tạo mã chi tiết đặt món!", "Lỗi");
                        return;
                    }

                    a.ThemChiTietDatMon(maCTDatMon, maDatMon, maMonAn, soLuong, ghiChu, "Chưa xử lý");
                }
            }

            MessageBox.Show("Order thành công!", "Thông Báo");
        }


        private void btn_themmnmoi_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void btn_chuyenban_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi chuyển!", "Thông Báo");
                return;
            }

            using (frm_ChonBan chonBanForm = new frm_ChonBan())
            {
                if (chonBanForm.ShowDialog() == DialogResult.OK)
                {
                    string maBanDich = chonBanForm.MaBanDich;

                    if (string.IsNullOrEmpty(maBanDich))
                    {
                        MessageBox.Show("Mã bàn đích không hợp lệ!", "Lỗi");
                        return;
                    }

                    if (maBanDich == txtMaBan.Text)
                    {
                        MessageBox.Show("Bàn đích không thể trùng với bàn nguồn!", "Lỗi");
                        return;
                    }
                    a.Update_Ban(maBanDich, "Co");
                    a.Update_Ban(txtMaBan.Text, "Trong");

                    a.ChuyenMonAn(txtMaBan.Text, maBanDich);

                    txtMaBan.Text = maBanDich;
                    listView1.Items.Clear();
                    Load_Ban();
                    HienThiDanhSachMon(maBanDich);

                    MessageBox.Show("Chuyển bàn thành công!", "Thông Báo");
                }
            }
        }


        private void btn_guiorder_Click(object sender, EventArgs e)
        {
            if (txtMaBan.Text == "")
            {
                MessageBox.Show("Chọn Bàn Để Gửi Lại", "Thông Báo");

            }
            else
            {
                string maBan = txtMaBan.Text;
                a.XoaMonCu(maBan);
                //Món mới
                string maDatMon = a.GenerateMaDatMon();
                a.ThemDatMon(maDatMon, txtMaBan.Text, "di");

                foreach (ListViewItem item in listView1.Items)
                {
                    string maMonAn = item.SubItems[0].Text;
                    int soLuong = int.Parse(item.SubItems[2].Text);
                    string ghiChu = item.SubItems[4].Text;

                    // Kiểm tra xem món đã tồn tại trong cơ sở dữ liệu hay chưa
                    if (a.MonAnExists(txtMaBan.Text, maMonAn))
                    {
                        // Món đã tồn tại, cập nhật số lượng
                        a.CapNhatSoLuongMonAn(txtMaBan.Text, maMonAn, soLuong);
                    }
                    else
                    {
                        // Món chưa tồn tại, thêm mới món vào cơ sở dữ liệu
                        a.ThemChiTietDatMon(a.GenerateMaCTDatMon(), maDatMon, maMonAn, soLuong, ghiChu, "Gửi Lại Order");
                    }
                }
                MessageBox.Show("Đã Gửi Lại Order", "Thông Báo");
            }
        }

        private void btn_ketthucban_Click(object sender, EventArgs e)
        {
            a.Update_Ban(txtMaBan.Text, "Trong");
            listView1.Items.Clear();
            Load_Ban();
        }

        public DataTable layDSMon_ListView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon", typeof(string));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GiaBan", typeof(decimal));

            foreach (ListViewItem item in listView1.Items)
            {
                DataRow row = dt.NewRow();
                row["MaMon"] = item.SubItems[0].Text; // Giả sử cột 0 là MaMon
                row["TenMon"] = item.SubItems[1].Text; // Giả sử cột 1 là TenMon
                row["SoLuong"] = int.Parse(item.SubItems[2].Text); // Giả sử cột 2 là SoLuong
                row["GiaBan"] = decimal.Parse(item.SubItems[3].Text); // Giả sử cột 3 là GiaBan
               

                dt.Rows.Add(row);
            }
            return dt;

        }
        double giam;
        private void btn_xuatbill_Click(object sender, EventArgs e)
        {

            DataTable dt = layDSMon_ListView();
            rpt_KiemMon baocao = new rpt_KiemMon();
            baocao.SetDataSource(dt);
            frm_InKiemMon f = new frm_InKiemMon();
            f.crystalReportViewer1.ReportSource = baocao;
            f.ShowDialog();

        }

        private void btn_giamgia_Click(object sender, EventArgs e)
        {
            giam = 1;
            using (frm_GiamGia gg = new frm_GiamGia())
            {
                if (gg.ShowDialog() == DialogResult.OK)
                {
                    giam = gg.Giamgia;
                    double tongtien = double.Parse(txt_tongtien.Text) * giam;
                    txt_tongtien.Text =tongtien.ToString();
                    giam = 1;
                }
            }
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (txtMaBan.Text != "")
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string madm = "SELECT DISTINCT DM.MaDatMon FROM DatMon DM WHERE DM.MaBan = '" + txtMaBan.Text + "' AND DM.MaDatMon IN (SELECT CTDM.MaDatMon FROM ChiTietDatMon CTDM WHERE CTDM.TrangThai <> N'Đã Thanh Toán')";
                    SqlCommand cmd = new SqlCommand(madm, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string layma = result.ToString();
                        if (txt_tongtien.Text != "")
                        {
                            string sql = "Update ChiTietDatMon Set TrangThai=N'Đã Thanh Toán' Where MaDatMon='" + layma + "'";
                            SqlCommand cmd1 = new SqlCommand(sql, con);
                            cmd1.ExecuteNonQuery();

                            string pttt = "Tiền mặt";
                            using (frm_ChonThanhToan ctt = new frm_ChonThanhToan())
                            {
                                if (ctt.ShowDialog() == DialogResult.OK)
                                {
                                    pttt = ctt.LoaiThanhToan;
                                }

                                string matt = a.GenerateMaThanhToan();

                                string themthanhtoan = "INSERT INTO ThanhToan (MaThanhToan, NgayThanhToan, TongTien, PhuongThucThanhToan, MaDatMon) VALUES (@MaThanhToan, GETDATE(), @TongTien, @PhuongThucThanhToan,  @MaDatMon)";

                                SqlCommand cmdthanhtoan = new SqlCommand(themthanhtoan, con);
                                cmdthanhtoan.Parameters.AddWithValue("@MaThanhToan", matt);
                                cmdthanhtoan.Parameters.AddWithValue("@TongTien", decimal.Parse(txt_tongtien.Text)); 
                                cmdthanhtoan.Parameters.AddWithValue("@PhuongThucThanhToan", pttt);
                                cmdthanhtoan.Parameters.AddWithValue("@MaDatMon", layma);

                                cmdthanhtoan.ExecuteNonQuery();

                                //in report
                                string inhoadon = "SELECT dm.MaDatMon, dm.NgayDatMon, dm.MaBan,  ctdm.MaChiTietDatMon, td.TenMonAn, ctdm.SoLuong, ctdm.SoLuong * td.GiaBan AS ThanhTien, tt.TongTien, td.GiaBan FROM DatMon dm JOIN ChiTietDatMon ctdm ON dm.MaDatMon = ctdm.MaDatMon JOIN ThucDon td ON ctdm.MaMonAn = td.MaMonAn JOIN ThanhToan tt ON dm.MaDatMon = tt.MaDatMon WHERE dm.MaDatMon = '" + layma + "'";
                                SqlDataAdapter da_ThongTinHD = new SqlDataAdapter(inhoadon, con);
                                DataTable dt = new DataTable();
                                da_ThongTinHD.Fill(dt);
                                rpt_HoaDon baocao = new rpt_HoaDon();
                                baocao.SetDataSource(dt);
                                frm_InHoaDon f = new frm_InHoaDon();
                                f.crystalReportViewer1.ReportSource = baocao;
                                f.ShowDialog();

                                a.Update_Ban(txtMaBan.Text, "Trong");
                                Load_Ban();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Chọn Bàn Thanh Toán!", "Thông Báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có đơn hàng chưa thanh toán cho bàn này.", "Thông Báo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Bàn Thanh Toán!", "Thông Báo");
            }
        }

        private void btn_tralai_Click(object sender, EventArgs e)
        {
            double khachDua;
            double tongTien;

            if (double.TryParse(txt_khachdua.Text, out khachDua) && double.TryParse(txt_tongtien.Text, out tongTien))
            {
                decimal tralai = Convert.ToDecimal(khachDua - tongTien);
                txt_tralai.Text = tralai.ToString("F3");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho Khách Đưa và Tổng Tiền.", "Lỗi Nhập Liệu");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_tralai.Text = "0";
            txt_khachdua.Text = "0";
        }

        private void txt_khachdua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; 
            }

           
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true; 
            }
        }

        private void btn_gopban_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn trước gộp!", "Thông Báo");
                return;
            }

            using (frm_GopBan chonBanForm = new frm_GopBan())
            {
                if (chonBanForm.ShowDialog() == DialogResult.OK)
                {
                    string maBanDich = chonBanForm.MaBanDich;

               

                    string queryUpdateMon = "UPDATE DatMon SET MaBan ='"+maBanDich+"'  WHERE MaBan = '"+txtMaBan.Text+"' AND MaDatMon IN (SELECT MaDatMon FROM ChiTietDatMon WHERE TrangThai <> N'Đã Thanh Toán')";
                    using(SqlConnection con=new SqlConnection(conStr))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(queryUpdateMon, con);
                        cmd.ExecuteNonQuery();
                    }
                    a.Update_Ban(maBanDich, "Co");
                    a.Update_Ban(txtMaBan.Text, "Trong");

                    QL_BanAn_Load(sender,e);
                   

                    MessageBox.Show("Chuyển bàn thành công!", "Thông Báo");
                }
            }
        }
    }
}



        

  

