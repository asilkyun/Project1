using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDT
{
    public partial class frmGV : Form
    {
        private string mgv;
        public frmGV(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }

        private void frmGV_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mgv))
            {
                this.Text = "Thêm mới giáo viên";
            }
            else
            {
                this.Text = "Cập nhật giáo viên";
                var r = new Database().Select("SelectGV '" + mgv + "'");
                txtHoTen.Text = r["hoten"].ToString();
                txtMatKhau.Text = r["matkhau"].ToString();
                if (int.Parse(r["gioitinh"].ToString()) == 1)
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                mtbNgaySinh.Text = r["nsinh"].ToString();
                txtQueQuan.Text = r["quequan"].ToString();
                txtDiaChi.Text = r["diachi"].ToString();
                txtDienThoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập họ tên", "Thông báo");
                txtHoTen.Select();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Chưa nhập email", "Thông báo");
                txtEmail.Select(); return;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại", "Thông báo");
                txtDienThoai.Select(); return;
            }
            DateTime ngaysinh;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaySinh.Select();
                return;
            }

            if (string.IsNullOrEmpty(mgv))
            {
                sql = "ThemGV";
            }
            else
            {
                sql = "UpdateGV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@magiaovien",
                    value = mgv
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@hoten",
                value = txtHoTen.Text
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@matkhau",
                value = txtMatKhau.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = rbtNam.Checked ? "1" : "0"
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quequan",
                value = txtQueQuan.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = txtDiaChi.Text
            });

            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                value = txtDienThoai.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                value = txtEmail.Text
            });
            var rs = new Database().ExeCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mgv))
                {
                    MessageBox.Show("Thêm mới giáo viên thành công","Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật mới giáo viên thành công","Thông báo");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi truy vấn thất bại");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
