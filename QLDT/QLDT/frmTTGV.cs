using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDT
{
    public partial class frmTTGV : Form
    {
        private string tendangnhap;
        public frmTTGV(string tendangnhap)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
        }

        private void frmTTGV_Load(object sender, EventArgs e)
        {
            var r = new Database().Select("selectGV '" + tendangnhap + "'");

            txtHoTen.Text = r["hoten"].ToString();
            txtMatKhau.Text = r["matkhau"].ToString();
            mtbNgaySinh.Text = r["nsinh"].ToString();
            if (int.Parse(r["gioitinh"].ToString()) == 1)
            {
                txtGioiTinh.Text = "Nam";
            }
            else
            {
                txtGioiTinh.Text = "Nữ";
            }

            txtQueQuan.Text = r["quequan"].ToString();
            txtDiaChi.Text = r["diachi"].ToString();
            txtDienThoai.Text = r["dienthoai"].ToString();
            txtEmail.Text = r["email"].ToString();

            txtHoTen.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            mtbNgaySinh.ReadOnly = true;
            txtGioiTinh.ReadOnly = true;
            txtQueQuan.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
        }
    }
}
