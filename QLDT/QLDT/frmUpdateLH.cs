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
    public partial class frmUpdateLH : Form
    {
        private string malophoc;
        private Database db;
        public frmUpdateLH(string malophoc)
        {
            InitializeComponent();
            this.malophoc = malophoc;
        }

        private void frmUpdateLH_Load(object sender, EventArgs e)
        {
            db = new Database();
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value=""
                }
            };

            cbbGiaoVien.DataSource = db.SelectData("SelectAllGV", lst);
            cbbGiaoVien.DisplayMember = "hoten";
            cbbGiaoVien.ValueMember = "magiaovien";
            cbbGiaoVien.SelectedIndex = -1;

            var r = db.Select("SelectLopHoc '" + malophoc + "'");
            txtMonHoc.Text = r["tenmonhoc"].ToString();
            cbbGiaoVien.SelectedValue = r["magiaovien"].ToString();
            txtMonHoc.ReadOnly= true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            List<CustomParameter> lst = new List<CustomParameter>();
            sql = "UpdateLopHoc";
            lst.Add(new CustomParameter()
            {
                key = "@malophoc",
                value = malophoc
            });

            lst.Add(new CustomParameter()
            {
                key = "@magiaovien",
                value = cbbGiaoVien.SelectedValue.ToString()
            });
            var kq = db.ExeCute(sql, lst);
            if (kq == 1)
            {
                MessageBox.Show("Cập nhật lớp học thành công", "Thông báo");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại", "Thông báo");

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
