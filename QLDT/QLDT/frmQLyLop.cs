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
    public partial class frmQLyLop : Form
    {
        private string mgv;
        public frmQLyLop(string mgv)
        {
            InitializeComponent();
            this.mgv = mgv;
        }
        private void LoadDSLH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@magiaovien",
                value = mgv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTuKhoa.Text
            });
            dgvDSLH.DataSource = new Database().SelectData("TraCuuLop", lstPara);
        }
        private void frmQLyLop_Load(object sender, EventArgs e)
        {
            LoadDSLH();
            
            dgvDSLH.Columns["malophoc"].HeaderText = "Mã lớp";
            dgvDSLH.Columns["mamonhoc"].HeaderText = "Mã môn học";
            dgvDSLH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSLH.Columns["sotc"].HeaderText = "Số TC";
            dgvDSLH.Columns["siso"].HeaderText = "Sĩ số";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadDSLH();
        }

        private void dgvDSLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSLH.Rows[e.RowIndex].Index >= 0)
            {
                new frmNhapDiem(dgvDSLH.Rows[e.RowIndex].Cells["malophoc"].Value.ToString(),mgv).ShowDialog();
                LoadDSLH();
            }
        }
    }
}
