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
    public partial class frmDSMHDaDKy : Form
    {
        private string masv;
        public frmDSMHDaDKy(string masv)
        {
            InitializeComponent();
            this.masv = masv;
        }

        private void frmDSMHDaDKy_Load(object sender, EventArgs e)
        {
            LoadMonDky();
            dgvDSMHDaDKy.Columns["malophoc"].HeaderText = "Mã lớp học";
            dgvDSMHDaDKy.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSMHDaDKy.Columns["hoten"].HeaderText = "Giáo viên";
            dgvDSMHDaDKy.Columns["sotc"].HeaderText = "Số TC";
        }
        private void LoadMonDky()
        {
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@masinhvien",
                    value = masv
                }
            };
            dgvDSMHDaDKy.DataSource = new Database().SelectData("MonDaDKi", lst);
        }
    }
}
