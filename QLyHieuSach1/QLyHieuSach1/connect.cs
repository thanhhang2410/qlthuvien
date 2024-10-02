using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLyHieuSach1
{
    internal class connect
    {
        SqlConnection conn;
        public void MoKetNoi()
        {
            string sql = @"Data Source=ZODYYY\ZODYYY;Initial Catalog=qlyhieusach;Integrated Security=True;";
            conn = new SqlConnection(sql);
            conn.Open();
        }
        public void dongKetNoi()
        {
            conn.Close();
        }
        public DataTable GetDSNhanVien()
        {
            MoKetNoi();
            string sql = "select * from NhanVien";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bang = new DataTable();
            bang.Load(dr);
            dongKetNoi();
            return bang;
        }

        public void themNhanVien(string ma, string ten, string gt, string dc, string dt, DateTime ngay)
        {
            MoKetNoi();
            string sql = "insert into NhanVien values (@MaNV,@TenNV,@GioiTinhNV,@DienThoaiNV,@NgaySinhNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaNv", ma);
            cmd.Parameters.AddWithValue("TenNv", ten);
            cmd.Parameters.AddWithValue("GioiTinhNv", gt);
            cmd.Parameters.AddWithValue("DiaChiNv", gt);
            cmd.Parameters.AddWithValue("DienThoaiNv", dt);
            cmd.Parameters.AddWithValue("NgaySinhNv", ngay);
            cmd.ExecuteNonQuery();
            dongKetNoi();
        }
        public bool tonTaiNV(string ma)
        {
            bool kt = false;
            MoKetNoi();
            string sql = "select * from NhanVien where MaNv = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaNV", ma);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                kt = true;
            }
            dongKetNoi();
            return kt;
        }
        //public void xoaNhanVien(string ma)
        //{
        //    MoKetNoi();
        //    string sql = "delete NhanVien where MaNv = '@MaVv'";
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("MaNV", ma);
        //    cmd.ExecuteNonQuery();
        //    dongKetNoi();
        //}
        public bool XoaNhanVien(string ma)
        {
            bool kt = false;
            MoKetNoi();
            string sql = "delete tblNhanVien where MaNV = @manv";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaNv",ma);
            try
            {
                cmd.ExecuteNonQuery();
                kt = true;

            }catch(Exception e) {}
                dongKetNoi();
                return kt;
        }

        public void capNhatNhanVien(string ma, string ten, string gt, string dc, string dt, DateTime ngay)
        {
            MoKetNoi();
            string sql = "update NhanVien set TenNV = @TenNv, GioiTinh = @GioiTinh, DiaChiNV = @DiaChiNv, DienThoaiNV = @DienThoaiNv, NgaySinhNV = @NgaySinhNv where MaNv = @MaNv";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("MaNV", ma);
            cmd.Parameters.AddWithValue("TenNv", ten);
            cmd.Parameters.AddWithValue("GioiTinh", gt);
            cmd.Parameters.AddWithValue("DiaChiNv", dc);
            cmd.Parameters.AddWithValue("DienThoaiNv", dt); 
            cmd.Parameters.AddWithValue("NgaySinhNv", ngay);
            cmd.ExecuteNonQuery();
            dongKetNoi();
        }

        public DataTable timNVTheoTen(string ten)
        {
            MoKetNoi();
            string sql = "select * from NhanVien where TenNV like N'%" + ten + "%'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable bang = new DataTable();
            bang.Load(dr);
            dongKetNoi();
            return bang;
        }
    }
}
        

