﻿using QuanLiCongDanThanhPho.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLiCongDanThanhPho
{
    internal static class KiemTraDuLieuNhap
    {
        public static bool KiemTra(string s, string rule)
        {
            return Regex.IsMatch(s, rule);
        }

        public  static bool isDiaChi(string diaChi)
        {
            string rule = @"^([^#$%*+.@!]{1,20})[,]([^#$%*+.@!]{1,20})[,]([^#$%*+.@!]{1,20})[,]([^#$%*+.@!]{1,20})[,]([^#$%*+.@!]{1,20})$";
            return KiemTra(diaChi, rule);
        }

        public static bool isSoDT(string SoDT)
        {
            string rule = @"^\d{9,11}$";
            return KiemTra(SoDT, rule);
        }

        public static bool isCCCD(string CCCD)
        {
            string rule = @"^\d{12}$";
            return KiemTra(CCCD, rule);
        }

        public static bool isTen(string Ten) 
        {
            string rule = @"^[^!@#$%^*()|+*0123456789]{3,30}$";
            return KiemTra(Ten, rule);
        }
        public static bool isMaSo(string MaSo)
        {
            string rule = @"^[0-9a-zA-Z]{5,15}$";
            return KiemTra(MaSo, rule);
        }
        public static bool isGioiTinh(string GioiTinh)
        {
            string rule = @"^[fm]$";
            return KiemTra(GioiTinh, rule);
        }

    }
}