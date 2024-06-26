﻿using System.Data;

namespace QuanLiCongDanThanhPho
{
    public class FormDanhSach : Form
    {
        private dynamic luaChon;
        private Paging listData;
        private DataTable ds;

        public FormDanhSach()
        {
            StackForm.Add(this);
            ds = new DataTable();
        }

        public dynamic LuaChon { get => luaChon; set => luaChon = value; }
        public DataTable Ds { get => ds; set => ds = value; }
        internal Paging ListData { get => listData; set => listData = value; }

        public void Loc_Click(FlowLayoutPanel flpnPhanLoai)
        {
            if (flpnPhanLoai.Width > 50)
                flpnPhanLoai.Width = 45;
            else
                flpnPhanLoai.Width = 1000;
        }

        internal virtual void HeaderText()
        {

        }

        internal void LoadDanhSach(DataGridView gvDanhSach)
        {
            gvDanhSach.DataSource = ListData.NgatTrang(ds);
            if (gvDanhSach.ColumnCount == 0)
            {
                gvDanhSach.Columns.Clear();
            }
            else
                HeaderText();
        }

        internal string DayFormat()
        {
            return "dd/MM/yyyy";
        }

    }
}
