using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang_Nhom8
{
    public partial class frm_ChonThanhToan : Form
    {
        private string loaiThanhToan = "Tiền mặt";

        public string LoaiThanhToan
        {
            get { return loaiThanhToan; }
            set { loaiThanhToan = value; }
        }

        public frm_ChonThanhToan()
        {
            InitializeComponent();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (rdo_chuyenkhoan.Checked)
            {
                loaiThanhToan = "Thẻ";
            }
            else
            {
                loaiThanhToan = "Tiền mặt";
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
