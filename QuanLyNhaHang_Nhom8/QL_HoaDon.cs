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
    public partial class QL_HoaDon : Form
    {
        public QL_HoaDon()
        {
            da_ThongTinHD =new SqlDataAdapter();
            ds_ThongTinHD=new DataSet();
            InitializeComponent();
        }
        string conStr = Properties.Settings.Default.ConStr;
        SqlDataAdapter da_ThongTinHD;
        DataSet ds_ThongTinHD;
        public void Load_HoaDon()
        {
            string sql = "Select*from DatMon ORDER BY MaDatMon DESC";
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                da_ThongTinHD = new SqlDataAdapter(sql, con);
                ds_ThongTinHD.Tables.Clear();
                da_ThongTinHD.Fill(ds_ThongTinHD, "ThongTinHD");
                dgv_hoadon.DataSource = ds_ThongTinHD.Tables["ThongTinHD"];
            }
            
        }
        private void QL_HoaDon_Load(object sender, EventArgs e)
        {
            Load_HoaDon();
            dgv_hoadon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgv_hoadon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_hoadon.SelectedRows.Count > 0)
            { 
                DataGridViewRow chon = dgv_hoadon.SelectedRows[0];
                string ma = chon.Cells["MaDatMon"].Value.ToString();
                Load_DSMon(ma);
            }
        }

        public void Load_DSMon(string ma)
        {
            SqlDataAdapter da_ThongTinM = new SqlDataAdapter();
            DataSet ds_ThongTinM = new DataSet();
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select ChiTietDatMon.MaDatMon,TenMonAn,SoLuong From ChiTietDatMon, ThucDon Where ChiTietDatMon.MaDatMon='" + ma + "' and ChiTietDatMon.MaMonAn=ThucDon.MaMonAn";
                da_ThongTinM = new SqlDataAdapter(sql, con);
                ds_ThongTinM.Tables.Clear();
                da_ThongTinM.Fill(ds_ThongTinM, "ThongTinM");
                dgv_dsmon.DataSource = ds_ThongTinM.Tables["ThongTinM"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (dgv_hoadon.SelectedRows.Count > 0)
            { 
                DataGridViewRow chon = dgv_hoadon.SelectedRows[0];
                string ma = chon.Cells["MaDatMon"].Value.ToString();
            //in report
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string inhoadon = "SELECT dm.MaDatMon, dm.NgayDatMon, dm.MaBan,  ctdm.MaChiTietDatMon, td.TenMonAn, ctdm.SoLuong, ctdm.SoLuong * td.GiaBan AS ThanhTien, tt.TongTien, td.GiaBan FROM DatMon dm JOIN ChiTietDatMon ctdm ON dm.MaDatMon = ctdm.MaDatMon JOIN ThucDon td ON ctdm.MaMonAn = td.MaMonAn JOIN ThanhToan tt ON dm.MaDatMon = tt.MaDatMon WHERE dm.MaDatMon = '" + ma + "'";
                    SqlDataAdapter da_ThongTinHD = new SqlDataAdapter(inhoadon, con);
                    DataTable dt = new DataTable();
                    da_ThongTinHD.Fill(dt);
                    rpt_HoaDon baocao = new rpt_HoaDon();
                    baocao.SetDataSource(dt);
                    frm_InHoaDon f = new frm_InHoaDon();
                    f.crystalReportViewer1.ReportSource = baocao;
                    f.ShowDialog();
                }
            }else
             {
                 MessageBox.Show("Chọn Hóa Đơn Để In", "Thông Báo");
             }

        }
    }
}
