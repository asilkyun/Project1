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
    public partial class frmDSMH : Form
    {
        private string tukhoa = "";
        public frmDSMH()
        {
            InitializeComponent();
        }

        private void dgvDSMH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mamh = dgvDSMH.Rows[e.RowIndex].Cells["mamonhoc"].Value.ToString();
                new frmMH(mamh,lst).ShowDialog();
                LoadDSMH();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmMH(null,lst).ShowDialog();
            LoadDSMH();
        }
        private void LoadDSMH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSMH.DataSource = new Database().SelectData("SelectAllMonHoc", lstPara);
            ////////////////////////
            string r = "";
            for (int i = 0; i < dgvDSMH.Rows.Count; i++)
            {
                r = dgvDSMH.Rows[i].Cells["tenmonhoc"].Value.ToString();
                lst.Add(r);
            }

        }
        List<string> lst = new List<string>();
        private void frmDSMH_Load(object sender, EventArgs e)
        {
            LoadDSMH();
            dgvDSMH.Columns["mamonhoc"].HeaderText = "Mã MH";
            dgvDSMH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSMH.Columns["sotc"].HeaderText = "Số TC";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTuKhoa.Text;
            LoadDSMH();
        }
    }
}
