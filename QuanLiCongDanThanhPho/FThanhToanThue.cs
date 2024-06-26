﻿using QuanLiCongDanThanhPho.Models;

namespace QuanLiCongDanThanhPho
{
    public partial class FThanhToanThue : Form
    {
        private Thue? thue;
        private ThueDAO thueDAO;

        public FThanhToanThue(string? maCCCD)
        {
            InitializeComponent();
            thueDAO = new ThueDAO();
            if (maCCCD != null )
            {
                thue = thueDAO.LayThongTin(maCCCD);
            }
        }

        private void LayThongTinThue()
        {
            if (thue != null )
            {
                lblMaThue.Text = thue.MaThue;
                lblTienNo.Text = $"Số tiền nợ {thue.SoTienCanNop} VNĐ";
                if (thue.HanNop != null)
                    dtpThoiHan.Value = thue.HanNop;
            }
        }

        private bool ThanhToan()
        {
            if (txtDongThue.Text.Length == 0) return false;
            if (KiemTraDuLieuNhap.isTien(txtDongThue.Text))
            {
                try
                {
                    int tienNhap = int.Parse(txtDongThue.Text);
                    if (thue != null && thue.ThanhToan(tienNhap))
                    {
                        thueDAO.CapNhatThue(thue);
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Số tiền quá lớn");
                }
            }
            return false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (ThanhToan())
            {
                MessageBox.Show("Thanh toán thành công");
                LayThongTinThue();
            }
            else
                MessageBox.Show("Thanh toán thất bại");
        }

        private void btnToanBo_Click(object sender, EventArgs e)
        {
            if (thue != null) 
                txtDongThue.Text = thue.SoTienCanNop;
        }

        private void FThanhToanThue_Load(object sender, EventArgs e)
        {
            LayThongTinThue();
        }
    }
}
