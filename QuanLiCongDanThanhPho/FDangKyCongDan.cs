﻿using QuanLiCongDanThanhPho.Models;

namespace QuanLiCongDanThanhPho
{
    public partial class FDangKyCongDan : FormDangKy
    {
        enum LuaChon
        {
            docThan,
            ketHon,
        }

        public FDangKyCongDan()
        {
            InitializeComponent();
            HinhCongDan = new HinhDaiDien(HinhDaiDien.Type.congDan);
        }

        private bool ThemHoKhau()
        {
            if (HKDAO.LayThongTin(txtHoKhau.Text).MaHoKhau == null)
            {
                HoKhau hK = new HoKhau(txtHoKhau.Text, txtDiaChi.Text, txtCCCD.Text);
                if (KiemTraDuLieuNhap.KiemTraHoKhau(hK) && cboQuanHe.SelectedItem.ToString() == "Chủ hộ")
                {
                    HKDAO.ThemHoKhau(hK);
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            return true;
        }

        internal override void DangKy()
        {
            CongDan cD = new CongDan(txtCCCD.Text, txtTen.Text, txtNgheNghiep.Text, txtSoDT.Text, (string)cboTonGiao.SelectedItem, txtHoKhau.Text, (string)cboQuanHe.SelectedItem, txtDiaChi.Text);
            KhaiSinh kS = new KhaiSinh(txtCCCD.Text, txtTen.Text, rdoNam.Checked.ToString(), (string)cboQuocTich.SelectedItem, (string)cboDanToc.SelectedItem, dtmNgaySinh.Value, dtmDKKhaiSinh.Value, txtNoiSinh.Text, txtQueQuan.Text, txtCCCDCha.Text, txtTenCha.Text, txtCCCDMe.Text, txtTenMe.Text);
            Thue thue = new Thue(txtThue.Text, txtCCCD.Text);

            if (KiemTraDuLieuNhap.KiemTraCongDan(cD) && KiemTraDuLieuNhap.KiemTraKhaiSinh(kS) && KiemTraDuLieuNhap.KiemTraThueDonGian(thue)
            && ptcHinhDaiDien.Image != null && ThemHoKhau() && CDDAO.ThemCongDan(cD) && KSDAO.ThemKhaiSinh(kS))
            {
                HinhCongDan.SaveHinhDaiDien(txtCCCD.Text, ofdHinhDaiDien, ptcHinhDaiDien);

                if (!ThueDAO.ThemThue(thue))
                {
                    MessageBox.Show("Mã số thuế bị trùng. Vui lòng đăng kí thuế sau");
                }

                if (cboTinhTrang.SelectedIndex == (int)LuaChon.ketHon)
                {

                    HonNhan hN = new HonNhan(txtMaHonNhan.Text, txtCCCD.Text, txtTen.Text, txtCCCDVoChong.Text, txtTenVoChong.Text, "u,u,u,u", DateTime.Now, rdoNam.ToString());
                    
                    if (KiemTraDuLieuNhap.KiemTraHonNhan(hN) && HNDAO.ThemHonNhan(hN))
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công. Thêm hôn nhân lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                }
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        internal override void Reset()
        {
            base.Reset();
            dtmDKKhaiSinh.Value = DateTime.Now;
            dtmNgaySinh.Value = DateTime.Now;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy();
        }

        private void cboTinhTrang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTinhTrang.SelectedIndex == (int)LuaChon.ketHon)
            {
                txtTenVoChong.ReadOnly = false;
                txtMaHonNhan.ReadOnly = false;
                txtCCCDVoChong.ReadOnly = false;
                txtCCCDVoChong.BackColor = Color.Gainsboro;
                txtMaHonNhan.BackColor = Color.Gainsboro;
                txtTenVoChong.BackColor = Color.Gainsboro;
            } 
            else
            {
                txtTenVoChong.ReadOnly = true;
                txtMaHonNhan.ReadOnly = true;
                txtCCCDVoChong.ReadOnly = true;
                txtCCCDVoChong.BackColor = Color.WhiteSmoke;
                txtMaHonNhan.BackColor = Color.WhiteSmoke;
                txtTenVoChong.BackColor = Color.WhiteSmoke;
            }    
        }

        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            HinhCongDan.ThemHinhDaiDien(ofdHinhDaiDien, ptcHinhDaiDien);
        }
    }
}
