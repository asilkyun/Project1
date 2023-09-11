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
    public partial class frmMain : Form
    {
        private string loaitk;
        private string tendangnhap;
        public frmMain(string loaitk, string tendangnhap)
        {
            InitializeComponent();
            this.loaitk = loaitk;
            this.tendangnhap = tendangnhap;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbTaiKhoan.Text="Tài khoản: " +tendangnhap;
            if (loaitk.Equals("admin"))
            {
                thongTinSinhVienToolStripMenuItem.Visible = false;
                thongTinGiaoVienToolStripMenuItem.Visible=false;
                chucNangToolStripMenuItem.Visible = false;
                quanLyLopToolStripMenuItem.Visible = false;
            }
            else
            {
                quanLyToolStripMenuItem.Visible = false;
                if (loaitk.Equals("gv"))
                {
                    thongTinSinhVienToolStripMenuItem.Visible = false;
                    chucNangToolStripMenuItem.Visible=false;
                }
                else
                {
                    thongTinGiaoVienToolStripMenuItem.Visible = false;
                    quanLyLopToolStripMenuItem.Visible=false;
                }
            }
        }
        private void AddForm(Form f)
        {
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panel1.Controls.Add(f);
            f.Show();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddForm(f);
        }

        private void giaoVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSGV f = new frmDSGV();
            AddForm(f);
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSMH f = new frmDSMH();
            AddForm(f);
        }

        private void lopHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSLH f = new frmDSLH();
            AddForm(f);
        }

        private void dangKyMonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDKMH f = new frmDKMH(tendangnhap);
            AddForm(f);
        }

        private void quanLyLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLyLop f = new frmQLyLop(tendangnhap);
            AddForm(f);
        }

        private void traCuuDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKQHT f = new frmKQHT(tendangnhap);
            AddForm(f);
        }

        private void thongTinSinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTSV f = new frmTTSV(tendangnhap);
            AddForm(f);
        }

        private void thongTinGiaoVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTTGV f = new frmTTGV(tendangnhap);
            AddForm(f);
        }

        private void ketQuaDangKyMonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSMHDaDKy f = new frmDSMHDaDKy(tendangnhap);
            AddForm(f);
        }
    }
}
