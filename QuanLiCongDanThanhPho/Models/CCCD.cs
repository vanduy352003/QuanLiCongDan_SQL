﻿
namespace QuanLiCongDanThanhPho.Models
{
    internal class CCCD
    {
        string maCCCD;
        DateTime ngayCap;
        string dacDiem;

        public CCCD() 
        {
            ngayCap = DateTime.Now;
            dacDiem = "unknow";
        }

        public CCCD(string maCCCD, DateTime ngayCap, string dacDiem)
        {
            this.maCCCD = maCCCD;
            this.ngayCap = ngayCap;
            this.dacDiem = dacDiem;
        }

        public CCCD(string maCCCD) 
        {
            this.maCCCD = maCCCD;
            ngayCap = DateTime.Now;
            dacDiem = "unknow";
        }

        public string MaCCCD { get => maCCCD; set => maCCCD = value; }
        public DateTime NgayCap { get => ngayCap; set => ngayCap = value; }
        public string DacDiem { get => dacDiem; set => dacDiem = value; }
    }
}
