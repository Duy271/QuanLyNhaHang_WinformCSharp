using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace QuanLyNhaHang_Nhom8
{
    class CN_DangNhap
    {
        string conStr = Properties.Settings.Default.ConStr;
        //string conStr = @"Data Source=DESKTOP-C8GK90P\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=TrueData Source=DESKTOP-C8GK90P\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        public int Chk_DangNhap(string taikhoan, string matkhau)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                int kt = 0;
                string lenhCheck = "Select Count(*) from DangKiTaiKhoan Where TenDangNhap='" + taikhoan + "'";
                SqlCommand cmd = new SqlCommand(lenhCheck, con);
                kt += (int)cmd.ExecuteScalar();
                if (kt == 1)
                {

                    string sql = "Select Count(*) from DangKiTaiKhoan Where TenDangNhap='" + taikhoan + "' and MatKhau='" + matkhau + "'";
                    SqlCommand cmd1 = new SqlCommand(sql, con);
                    kt += (int)cmd1.ExecuteScalar();
                }
                return kt;
            }
        }

        public string Lay_Role(string TaiKhoan)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select ChucVu from DangKiTaiKhoan Where TenDangNhap='" + TaiKhoan + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                string role = cmd.ExecuteScalar().ToString();
                return role;
            }
        }

        //MD5
        public string CalculateMD5Hash(string mk)
        {
            string input = "!!!@@@###" + mk + "$$$%%%^^^";
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2")); // Format as hexadecimal
                }

                return stringBuilder.ToString();
            }
        }
    }
}
