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
    public partial class frm_BepBar : Form
    {
        string conStr=Properties.Settings.Default.ConStr;
        public frm_BepBar()
        {
            da_ThongTinB = new SqlDataAdapter();
            ds_ThongTinB = new DataSet();
            //
            da_ThongTinBr = new SqlDataAdapter();
            ds_ThongTinBr = new DataSet();
            InitializeComponent();
        }
        //Bếp
        SqlDataAdapter da_ThongTinB;
        DataSet ds_ThongTinB;
        //Bar
        SqlDataAdapter da_ThongTinBr;
        DataSet ds_ThongTinBr;

        public void Load_Bep()
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select MaChiTietDatMon,TenMonAn,SoLuong,GhiChu From ChiTietDatMon, ThucDon Where ChiTietDatMon.TrangThai<>N'Đã Thanh Toán' AND ChiTietDatMon.TrangThai<>N'Đã Ra Món' AND ChiTietDatMon.MaChiTietDatMon<>N'Gửi Lại Order' AND ChiTietDatMon.MaMonAn=ThucDon.MaMonAn AND ThucDon.MaLoaiMonAn<>'drink'";
                da_ThongTinB = new SqlDataAdapter(sql, con);
                ds_ThongTinB.Tables.Clear();
                da_ThongTinB.Fill(ds_ThongTinB, "ThongTinB");
                dgv_bep.DataSource = ds_ThongTinB.Tables["ThongTinB"];
            }
        }

        public void Load_Bar()
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select MaChiTietDatMon,TenMonAn,SoLuong,GhiChu From ChiTietDatMon, ThucDon Where ChiTietDatMon.TrangThai<>N'Đã Thanh Toán' AND ChiTietDatMon.TrangThai<>N'Đã Ra Món' AND ChiTietDatMon.MaChiTietDatMon<>N'Gửi Lại Order' AND ChiTietDatMon.MaMonAn=ThucDon.MaMonAn AND ThucDon.MaLoaiMonAn='drink'";
                da_ThongTinBr = new SqlDataAdapter(sql, con);
                ds_ThongTinBr.Tables.Clear();
                da_ThongTinBr.Fill(ds_ThongTinBr, "ThongTinBr");
                dgv_bar.DataSource = ds_ThongTinBr.Tables["ThongTinBr"];

            }
        }
        private void frm_BepBar_Load(object sender, EventArgs e)
        {
            Load_Bep();
            Load_Bar();
            dgv_bep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_bar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgv_bep_SelectionChanged(object sender, EventArgs e)
        {

            if (dgv_bep.SelectedRows.Count > 0)
            {
                DataGridViewRow chon = dgv_bep.SelectedRows[0];

            }

        }

        private void btn_ramonbep_Click(object sender, EventArgs e)
        {
            if (dgv_bep.SelectedRows.Count > 0)
            {
                DataGridViewRow chon = dgv_bep.SelectedRows[0];
                string ma = chon.Cells["MaChiTietDatMon1"].Value.ToString();
                string sql = "Update ChiTietDatMon Set TrangThai=N'Đã Ra Món' Where MaChiTietDatMon='" + ma + "'";
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    Load_Bep();
                }

            }else
            {
                MessageBox.Show("Vui Lòng Chọn Món", "Thông Báo");
            }
        }

        private void btn_ramonbar_Click(object sender, EventArgs e)
        {
            if(dgv_bar.SelectedRows.Count>0)
            {
                DataGridViewRow chon = dgv_bar.SelectedRows[0];
                string ma = chon.Cells["MaChiTietDatMon"].Value.ToString();
                string sql = "Update ChiTietDatMon Set TrangThai=N'Đã Ra Món' Where MaChiTietDatMon='" + ma + "'";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    Load_Bar();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Món", "Thông Báo");
            }
        }
        private void btn_veNhanVenorder_Click(object sender, EventArgs e)
        {
            OderNhanVien a = new OderNhanVien();
            this.Close();
            a.Show();
        }
    }
}
