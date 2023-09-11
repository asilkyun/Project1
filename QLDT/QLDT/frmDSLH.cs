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
    public partial class frmDSLH : Form
    {
        private string tukhoa = "";
        public frmDSLH()
        {
            InitializeComponent();
        }

        private void frmDSLH_Load(object sender, EventArgs e)
        {
            LoadDSLH();
        }
        private void LoadDSLH()
        {
            string sql = "SelectAllLopHoc";
            List<CustomParameter> lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                }
            };
            dgvDSLH.DataSource = new Database().SelectData(sql, lstPara);

            dgvDSLH.Columns["malophoc"].HeaderText = "Mã LH";
            dgvDSLH.Columns["mamonhoc"].HeaderText = "Mã MH";
            dgvDSLH.Columns["tenmonhoc"].HeaderText = "Tên MH";
            dgvDSLH.Columns["sotc"].HeaderText = "Số TC";
            dgvDSLH.Columns["hoten"].HeaderText = "Họ tên giáo viên";
            dgvDSLH.Columns["trangthai"].HeaderText = "Trạng thái";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTuKhoa.Text;
            LoadDSLH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmLH().ShowDialog();
            LoadDSLH();
        }

        private void dgvLopHoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                new frmUpdateLH(dgvDSLH.Rows[e.RowIndex].Cells["malophoc"].Value.ToString()).ShowDialog();
                LoadDSLH();
            }
        }
    }
}
