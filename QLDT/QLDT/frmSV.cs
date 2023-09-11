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
    public partial class frmSV : Form
    {
        private string msv;

        public frmSV(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }

        private void frmSV_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(msv))
            {
                this.Text = "Thêm mới sinh viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin sinh viên";
                
                var r = new Database().Select("selectSV '" + msv + "'");

                txtHoTen.Text = r["hoten"].ToString();
                txtMatKhau.Text = r["matkhau"].ToString();
                mtbNgaySinh.Text = r["nsinh"].ToString();
                if (int.Parse(r["gioitinh"].ToString()) == 1)
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }

                txtQueQuan.Text = r["quequan"].ToString();
                txtDiaChi.Text = r["diachi"].ToString();
                txtDienThoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            string hoten;
            string email;
            string dienthoai;
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
                txtHoTen.Select();
                return;
            }
            else
            {
                hoten = txtHoTen.Text;
            }
            string matkhau = txtMatKhau.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaySinh.Select();
                return;
            }
       
            string gioitinh = rbtNam.Checked ? "1" : "0";
            string quequan = txtQueQuan.Text;
            string diachi = txtDiaChi.Text;
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
                txtDienThoai.Select();
                return;
            }
            else
            {
                dienthoai = txtDienThoai.Text;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu", "Thông báo");
                txtEmail.Select();
                return;
            }
            else
            {
                email = txtEmail.Text;
            }

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(msv))
            {
                sql = "ThemSV";

            }
            else
            {
                sql = "UpdateSV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@masinhvien",
                    value = msv
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@hoten",
                value = hoten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@matkhau",
                value = matkhau
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = gioitinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quequan",
                value = quequan
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = diachi
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                value = dienthoai
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                value = email
            });


            var rs = new Database().ExeCute(sql, lstPara);
            
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(msv))
                {
                    MessageBox.Show("Thêm mới sinh viên thành công","Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công","Thông báo");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi thất bại", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
