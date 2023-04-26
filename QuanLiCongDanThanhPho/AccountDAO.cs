﻿using QuanLiCongDanThanhPho.Models;
using System.Data;

namespace QuanLiCongDanThanhPho
{
    internal class AccountDAO
    {
        public AccountDAO() { }
        DBConnection conn = new DBConnection();

        public void XoaTaiKhoan(Account acc)
        {
            string sqlStr = string.Format($"DELETE ACCOUNT WHERE UserName = {acc.UserName}");
        }
        public void CapNhatMatKhau(Account acc)
        {
            string sqlStr = string.Format($"UPDATE ACCOUNT SET StrPassword = '{acc.Password}' WHERE UserName = '{acc.UserName}'");
            conn.ThucThi(sqlStr, "Đổi mật khẩu thành công");
        }
        public void CapNhatDisplayName(Account acc)
        {
            string sqlStr = string.Format($"UPDATE ACCOUNT SET DisplayName = N'{acc.DisplayName}' WHERE UserName = '{acc.UserName}'");
            conn.ThucThi(sqlStr, "Cập nhật tên thành công");
        }
        public Account LayThongTinTaiKhoan(Account acc)
        {
            string sqlStr = string.Format($"SELECT *FROM ACCOUNT WHERE UserName = '{acc.UserName}'");
            return conn.LayThongTinTaiKhoan(sqlStr);
        }
        public bool DangNhap(Account acc)
        {
            string sqlStr = string.Format($"SELECT *FROM ACCOUNT WHERE UserName = '{acc.UserName}' AND StrPassword = '{acc.Password}'");
            DataTable dt = new DataTable();
            dt = conn.LayDanhSach(sqlStr);
            return dt.Rows.Count > 0;
        }
    }
}
