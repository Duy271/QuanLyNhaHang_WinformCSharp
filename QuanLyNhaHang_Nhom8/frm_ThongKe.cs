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
    public partial class frm_ThongKe : Form
    {
        public frm_ThongKe()
        {   
            InitializeComponent();
            con = new SqlConnection(Properties.Settings.Default.ConStr);
            if (con.State == ConnectionState.Closed)
                con.Open();
           
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlConnection con;
        DataColumn[] key = new DataColumn[1];



        private bool IsValidDateInput()
        {
            int day1, month1, year1, day2, month2, year2;

            // Kiểm tra xem các textbox chứa ngày có giá trị hợp lệ hay không
            if (!int.TryParse(textBox1.Text, out day1) || !int.TryParse(textBox2.Text, out month1) || !int.TryParse(textBox3.Text, out year1) ||
                !int.TryParse(textBox4.Text, out day2) || !int.TryParse(textBox5.Text, out month2) || !int.TryParse(textBox6.Text, out year2))
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra xem ngày tháng năm có hợp lệ hay không
            try
            {
                DateTime startDate = new DateTime(year1, month1, day1);
                DateTime endDate = new DateTime(year2, month2, day2);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            if (IsValidDateInput())
            {
                DateTime nt = new DateTime(int.Parse(textBox3.Text), int.Parse(textBox2.Text), int.Parse(textBox1.Text));
                DateTime ns = new DateTime(int.Parse(textBox6.Text), int.Parse(textBox5.Text), int.Parse(textBox4.Text));

                LoadDataBetweenDates(nt, ns);
            }
            else
            {
                MessageBox.Show("Ngày nhập không hợp lệ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDataBetweenDates(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConStr))
            {
                connection.Open();

                string query = "SELECT * FROM ThanhToan WHERE NgayThanhToan >= @StartDate AND NgayThanhToan < @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;

                        // Tính tổng tiền và hiển thị trong TextBox
                        decimal tongTien = 0;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Giả sử cột TongTien trong DataTable là cột chứa tổng tiền của mỗi hóa đơn
                            // Thay đổi tên cột nếu cần thiết
                            if (row["TongTien"] != DBNull.Value)
                            {
                                tongTien += Convert.ToDecimal(row["TongTien"]);
                            }
                        }

                        tb_tongTien.Text = tongTien.ToString("F3"); // Hiển thị tổng tiền dưới dạng tiền tệ
                    }
                }
            }
        }
        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from ThanhToan", con);
            da.Fill(ds, "ThanhToan");

            dataGridView1.DataSource = ds.Tables["ThanhToan"];
            //
            //con.Open();
            string sql = "SELECT SUM(TongTien) AS TongDoanhThu FROM ThanhToan WHERE NgayThanhToan = CAST(GETDATE() AS DATE)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    decimal t = (decimal)result;
                    txt_tongngay.Text = t.ToString("F3");
                }
                else
                {
                    txt_tongngay.Text = "0.000"; // hoặc bạn có thể đặt giá trị mặc định khác tùy thuộc vào yêu cầu của bạn
                }
            }
            //sql
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT TOP 7 NgayThanhToan, SUM(TongTien) AS TongDoanhThu FROM ThanhToan GROUP BY NgayThanhToan ORDER BY NgayThanhToan DESC;", con);
            DataTable dt = new DataTable();
            da1.Fill(dt);

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "D.Thu";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            // Tạo Series nếu chưa tồn tại
            if (chart1.Series.IndexOf("TongDoanhThu") == -1)
            {
                chart1.Series.Add("TongDoanhThu");
                chart1.Series["TongDoanhThu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }

            chart1.Series["TongDoanhThu"].Points.Clear(); // Xóa dữ liệu cũ nếu có

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime ngayThanhToan = Convert.ToDateTime(dt.Rows[i]["NgayThanhToan"]);
                decimal tongDoanhThu = Convert.ToDecimal(dt.Rows[i]["TongDoanhThu"]);
                chart1.Series["TongDoanhThu"].Points.AddXY(ngayThanhToan.ToString("yyyy-MM-dd"), tongDoanhThu);
            }

        }
    }
}
