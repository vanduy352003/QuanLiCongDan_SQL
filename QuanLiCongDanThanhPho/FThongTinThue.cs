﻿using QuanLiCongDanThanhPho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCongDanThanhPho
{
    public partial class FThongTinThue : Form
    {
        private string maCCCD;
        ThueDAO thueDAO = new ThueDAO();
        CongDanDAO cdDAO = new CongDanDAO();
        HoKhauDAO hkDAO = new HoKhauDAO();
        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;
        public string MaCCCD
        {
            set { maCCCD = value; }
            get { return maCCCD; }
        }
        public FThongTinThue()
        {
            InitializeComponent();
            StackForm.Add(this);
        }
        public FThongTinThue(string maCCCD)
        {
            MaCCCD = maCCCD;
            InitializeComponent();
            StackForm.Add(this);
        }
        private void FThongTinThue_Load(object sender, EventArgs e)
        {
            if (MaCCCD != null)
            {
                Thue thue = thueDAO.LayThongTin(MaCCCD);
                CongDan cd = cdDAO.LayThongTin(MaCCCD);
                HoKhau hk = hkDAO.LayThongTin(cd.MaHoKhau);
                txtMaSoThue.Text = thue.MaThue;
                txtTen.Text = cd.Ten;
                txtCCCD.Text = cd.CCCD;
                txtSdt.Text = cd.SDT;
                txtDiaChi.Text = hk.DiaChi.toString();
                txtSoTienCanNop.Text = thue.SoTienCanNop;
                txtSoTienDaNop.Text = thue.SoTienDaNop;
                dtpNgayCapMaSoThue.Value = thue.NgayCapMa;
                dtpHanNopThue.Value = thue.HanNop;
            }
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
    }
}
