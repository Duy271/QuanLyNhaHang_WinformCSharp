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
    public partial class frm_VIP : Form
    {
        string conStr = Properties.Settings.Default.ConStr;

        double giamgia;

        public double Giamgia
        {
            get { return giamgia; }
            set { giamgia = value; }
        }
        private void frm_VIP_Load(object sender, EventArgs e)
        {
            
        }

        public string loaiKhach(string sdt)
        {
            
            using(SqlConnection con=new SqlConnection(conStr))
            {
                
                con.Open();
                string sql = "Select Count(*) From KhachHang, Nguoi Where KhachHang.MaKhachHang=Nguoi.MaNguoi AND SoDienThoai='" + sdt + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int t = (int)cmd.ExecuteScalar();
                if(t!=0)
                {
                    string sql1 = "Select KhachHang.MaKhachHang From KhachHang,Nguoi Where KhachHang.MaKhachHang=Nguoi.MaNguoi AND SoDienThoai='" + sdt + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    string s = cmd1.ExecuteScalar().ToString();
                    if(s==null)
                    {
                        MessageBox.Show("Khách Hàng Không Tồn Tại!", "Thông Báo");
                        this.Close();

                    }else
                    {
                        if(s=="VIP")
                        {
                            return "VIP";
                            
                        }else
                        {
                            return "NORMAL";
                        }
                    }
                }
                return "";
            }
        }

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            if(txt_sdt.Text!="")
            {
                string s = loaiKhach(txt_sdt.Text);
                if(s!="")
                {
                    lb_tb.Text = "Số Điện Thoại Tồn Tại";
                }else
                {
                    lb_tb.Text = "Số Điện Thoại Sai!";
                }
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (txt_sdt.Text != "")
            {
                string s = loaiKhach(txt_sdt.Text);
                if (s != "")
                {
                    using(SqlConnection con=new SqlConnection(conStr))
                    {
                        con.Open();
                        string sql = "Select KhachHang.MaKhachHang From KhachHang,Nguoi Where KhachHang.MaKhachHang=Nguoi.MaNguoi AND SoDienThoai='" + txt_sdt.Text + "'";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        string loaing = cmd.ExecuteScalar().ToString();
                        string sub = loaing.Substring(0, 2);
                        if(sub=="NV")
                        {
                            giamgia = 0.8;
                        }else if(sub=="KH"&&s=="VIP")
                        {
                            giamgia = 0.9;
                        }else
                        {
                            giamgia = 0.95;
                        }
                    }
                }
                else
                {
                    lb_tb.Text = "Số Điện Thoại Sai!";
                }
            }
            MessageBox.Show("đây:"+giamgia, "Thông Báo");
            Close();
        }
    }
}
