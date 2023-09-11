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
    public partial class frmKQHT : Form
    {
        private string masv;
        public frmKQHT(string masv)
        {
            InitializeComponent();
            this.masv = masv;
        }
        private void LoadKQHT()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTuKhoa.Text
            });
            dgvKQHT.DataSource = new Database().SelectData("TraCuuDiem", lstPara);
        }

        private void frmKQHT_Load(object sender, EventArgs e)
        {
            LoadKQHT();

            dgvKQHT.Columns["mamonhoc"].HeaderText = "Mã môn học";
            dgvKQHT.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvKQHT.Columns["lanhoc"].HeaderText = "Lần học";
            dgvKQHT.Columns["hoten"].HeaderText = "Giáo viên";
            dgvKQHT.Columns["diemlan1"].HeaderText = "Điểm giữa kỳ";
            dgvKQHT.Columns["diemlan2"].HeaderText = "Điểm cuối kỳ";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadKQHT();
        }
    }
}
