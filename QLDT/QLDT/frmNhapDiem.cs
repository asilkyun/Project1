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
    public partial class frmNhapDiem : Form
    {
        private string malophoc;
        private string mgv;
        public frmNhapDiem(string malophoc, string mgv)
        {
            InitializeComponent();
            this.malophoc = malophoc;
            this.mgv= mgv;
        }
        private void LoadDSSV()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@malophoc",
                value = malophoc
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTuKhoa.Text
            });

            dgvDSSV.DataSource = new Database().SelectData("DSSV", lstPara);
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            
            LoadDSSV();
            
            dgvDSSV.Columns["masinhvien"].HeaderText = "MSV"; 
            dgvDSSV.Columns["hoten"].HeaderText = "Họ và tên";
            dgvDSSV.Columns["lanhoc"].HeaderText = "Lần học";
            dgvDSSV.Columns["diemlan1"].HeaderText = "Điểm giữa kỳ";
            dgvDSSV.Columns["diemlan2"].HeaderText = "Điểm cuối kỳ";

            
            for (int i = 0; i <= 2; i++)
            {
                dgvDSSV.Columns[i].ReadOnly = true;
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            LoadDSSV();
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn lưu bảng điểm?", "Xác nhận thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                var db = new Database();
                List<CustomParameter> lstPara;

                int chk = 1;
                foreach (DataGridViewRow r in dgvDSSV.Rows)
                {
                    lstPara = new List<CustomParameter>();

                    lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@magiaovien",
                        value = mgv
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@malop",
                        value = malophoc
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@masinhvien",
                        value = r.Cells["masinhvien"].Value.ToString()
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@diemlan1",
                        value = r.Cells["diemlan1"].Value.ToString()
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@diemlan2",
                        value = r.Cells["diemlan2"].Value.ToString()
                    });
                   
                    chk = db.ExeCute("NhapDiem", lstPara);
                    if (chk != 1)
                    {
                        MessageBox.Show("Chấm điểm thất bại", "Thông báo");
                        break;
                    }
                }

                if (chk == 1)
                {
                    MessageBox.Show("Lưu bảng điểm thành công","Thông báo");
                }

            }
        }

        private void btnGuiDiem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn gửi điểm môn học này??", "Xác thực thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                var lstPara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@magiaovien",
                        value=mgv,
                    },
                    new CustomParameter()
                    {
                        key = "@malophoc",
                        value=malophoc,
                    }
                };
                var rs = new Database().ExeCute("GuiDiem", lstPara);
                if (rs == 1)
                {
                    MessageBox.Show("Gửi điểm thành công","Thông báo");
                    this.Dispose();
                }
            }
        }
    }
}
