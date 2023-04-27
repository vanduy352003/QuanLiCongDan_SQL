﻿using QuanLiCongDanThanhPho.Models;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Principal;

namespace QuanLiCongDanThanhPho
{
    public static class HinhDaiDien
    {

        private static string GetFolderPath(string path)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = string.Format(System.IO.Path.Combine(sCurrentDirectory, path));
            return folderPath;
        }

        private static void DeleteDirectory(string folderPath, string fileName)
        {
            string fileNamePng = fileName + ".png";
            string fullPathPng = Path.Combine(folderPath, fileNamePng);

            string fileNameJpg = fileName + ".jpg";
            string fullPathJpg = Path.Combine(folderPath, fileNameJpg);

            if (File.Exists(fullPathPng))
            {
                File.Delete(fullPathPng);
            }
            if (File.Exists(fullPathJpg))
            {
                File.Delete(fullPathJpg);
            }

        }

        public static void SaveHinhDaiDien(string name, OpenFileDialog ofdHinhDaiDien, PictureBox ptcHinhDaiDien, string path)
        {
            string fileExtension = Path.GetExtension(ofdHinhDaiDien.FileName).ToLowerInvariant();

            if (fileExtension != ".jpg" && fileExtension != ".png")
            {
                // Thông báo lỗi nếu ko phải file png với jpg
                MessageBox.Show("File ảnh không hợp lệ. Chọn ảnh jpg hoặc png.");
                return;
            }

            string fileName = string.Format($"{name}{fileExtension}");
            string folderPath = GetFolderPath(path);
            string fullPath = Path.Combine(folderPath, fileName);

            DeleteDirectory(folderPath, $"{name}"); // Xóa ảnh cũ

            ptcHinhDaiDien.Image.Save(fullPath, fileExtension == ".jpg" ? ImageFormat.Jpeg : ImageFormat.Png);
        }

        public static bool ThemHinhDaiDien(OpenFileDialog ofdHinhDaiDien, PictureBox ptcHinhDaiDien)
        {
            ofdHinhDaiDien.Filter = "PImage Files (*.jpg, *.png)|*.jpg;*.png";
            try
            {
                if (ofdHinhDaiDien.ShowDialog() == DialogResult.OK)
                {
                    ptcHinhDaiDien.Image = new Bitmap(ofdHinhDaiDien.FileName);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        private static void GanHinh(string filename, PictureBox ptcHinhDaiDien)
        {
            Bitmap bitmap = null;
            bitmap?.Dispose();
            ptcHinhDaiDien.Image?.Dispose();

            using (Bitmap tempImage = new Bitmap(filename, true)) //Giúp k bị lỗi không thể truy cập file đang hoạt động khi xóa
            {
                bitmap = new Bitmap(tempImage);
                ptcHinhDaiDien.Image = bitmap;
            }
        }

        public static void LayHinhDaiDien(string name, PictureBox ptcHinhDaiDien, string path)
        {
            string folderPath = GetFolderPath(path);
            string imagePath = string.Format(@$"{folderPath}\{name}");
            string png = imagePath + ".png";
            string jpg = imagePath + ".jpg";

            if (File.Exists(png))
            {
                GanHinh(png, ptcHinhDaiDien);
            }
            else if (File.Exists(jpg))
            {
                GanHinh(jpg, ptcHinhDaiDien);
            }
        }
    }
}
