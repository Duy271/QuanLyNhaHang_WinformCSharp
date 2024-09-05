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

namespace QuanLyNhaHang_Nhom8
{
    public partial class frm_GopBan : Form
    {
        public frm_GopBan()
        {
            InitializeComponent();
        }

        private void frm_GopBan_Load(object sender, EventArgs e)
        {
            LoadDanhSachBan();
        }

         private string selectedMaBanDich;

        public string MaBanDich
        {
            get { return selectedMaBanDich; }
        }
     
        
        string conStr = Properties.Settings.Default.ConStr;
        private void LoadDanhSachBan()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Lấy danh sách các bàn từ cơ sở dữ liệu
                string query = "SELECT MaBan, TrangThai FROM Ban Where TrangThai='Co'";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maBan = reader.GetString(0);
                        string trangThai = reader.GetString(1);

                        // Tạo một nút hoặc phần tử giao diện để hiển thị thông tin bàn
                        Button btnBan = new Button();
                        btnBan.Width = 100;
                        btnBan.Height = 40;
                        btnBan.Text = maBan;
                        btnBan.Tag = maBan; // Lưu mã bàn vào Tag để có thể lấy được khi nút được nhấn
                        btnBan.Click += BtnBan_Click;

                        // Thêm nút vào FlowLayoutPanel hoặc Panel (tùy thuộc vào thiết kế của bạn)
                        flowLayoutPanelBan.Controls.Add(btnBan);
                    }
                }
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            selectedMaBanDich = clickedButton.Tag.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
