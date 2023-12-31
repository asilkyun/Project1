﻿using System;
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
    public partial class frmDKMH : Form
    {
        private string masv;

        public frmDKMH(string masv)
        {   
            this.masv = masv;
            InitializeComponent();
        }

        private void frmDKMH_Load(object sender, EventArgs e)
        {
            LoadDSLH();
            dgvDSLH.Columns["malophoc"].HeaderText = "Mã lớp";
            dgvDSLH.Columns["tenmonhoc"].HeaderText = "Tên môn học";
            dgvDSLH.Columns["sotc"].HeaderText = "Số TC";
            dgvDSLH.Columns["hoten"].HeaderText = "Giáo viên";
            //////////////////////////////////////////////////////
            dgvDSLH.Columns["mamonhoc"].Visible = false;
        }
        private void LoadDSLH()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@masinhvien",
                value = masv
            });
            dgvDSLH.DataSource = new Database().SelectData("DSLopChuaDKi", lstPara);
        }

        private void dgvDSLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSLH.Rows[e.RowIndex].Index >= 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn đăng ký [" + dgvDSLH.Rows[e.RowIndex].Cells["tenmonhoc"].Value.ToString() + "]?", "Xác nhận đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@masinhvien",
                        value = masv
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@malophoc",
                        value = dgvDSLH.Rows[e.RowIndex].Cells["malophoc"].Value.ToString()
                    });

                    var rs = new Database().ExeCute("DKiHoc", lstPara);
                    if (rs == -1)
                    {
                        MessageBox.Show("Môn học này bạn đã đăng ký", "Thông báo");
                        return;
                    }
                    if (rs == 1)
                    {
                        MessageBox.Show("Đã đăng ký môn học thành công", "Thông báo");
                        LoadDSLH();
                    }
                }
            }
        }
    }
}
