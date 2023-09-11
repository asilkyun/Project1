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
    public partial class frmDSGV : Form
    {
        private string tukhoa = "";
        public frmDSGV()
        {
            InitializeComponent();
        }
        private void LoadDSGV()
        {
            string sql = "selectAllGV";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSGV.DataSource = new Database().SelectData(sql, lstPara);

            dgvDSGV.Columns["magiaovien"].HeaderText = "Mã GV";
            dgvDSGV.Columns["hoten"].HeaderText = "Họ tên";
            dgvDSGV.Columns["matkhau"].HeaderText = "Mật khẩu";
            dgvDSGV.Columns["nsinh"].HeaderText = "Ngày sinh";
            dgvDSGV.Columns["gtinh"].HeaderText = "Giới tính";
            dgvDSGV.Columns["quequan"].HeaderText = "Quê quán";
            dgvDSGV.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvDSGV.Columns["email"].HeaderText = "Email";
            dgvDSGV.Columns["dienthoai"].HeaderText = "Điện thoại";
        }
        private void frmDSGV_Load(object sender, EventArgs e)
        {
            LoadDSGV();
        }

        private void dgvDSGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mgv = dgvDSGV.Rows[e.RowIndex].Cells["magiaovien"].Value.ToString();
                new frmGV(mgv).ShowDialog();
                LoadDSGV();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTuKhoa.Text;
            LoadDSGV();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmGV(null).ShowDialog();
            LoadDSGV();
        }
    }
}
