using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_SanPham : QuanLyKetNoi
    {

        public DataTable LoadSPChuDe(int ChuDe)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select * from SanPham where chude = "+ChuDe;
            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return dt;
        }
        public DataTable LoadSPTheoLoai(int LoaiSP, int Gioitinh)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select *  from SanPham  where LoaiSP = " + LoaiSP + "and GioiTinh =" + Gioitinh;
            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return dt;
        }

        public void XoaSPTheoKichThuoc(int maSP, string size)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            String deleteString = string.Format("DELETE FROM SanPham_Size WHERE MaSP = {0} AND MaSize IN (SELECT MaSize FROM Size WHERE Size LIKE '{1}')",
                maSP,
                size
                );
            SqlCommand cmd = new SqlCommand(deleteString, dal_SanPham.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_SanPham.Close();
        }

        public DataTable LoadSPTheoLoaiAdmin(int LoaiSP,int Gioitinh)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select s.MaSP as MaSP,TenSP , GiaBan , NgayNhapHang,size.MaSize,Size,SoLuong,HinhAnh  from SanPham s, sanpham_size si , Size size where s.MaSP = si.MaSP and size.MaSize = si.MaSize  and LoaiSP = " + LoaiSP + "and GioiTinh =" + Gioitinh;
            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return dt;
        }
        public SanPham LayThongTinSanPham(int ID, string size)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select s.MaSP as MaSP,TenSP , GiaBan ,GiaMua, NgayNhapHang,GioiTinh,HinhAnh,si.MaSize as MaSize,SoLuong,LoaiSP,ChuDe,ThongTin  from SanPham s, sanpham_size si , Size size where s.MaSP = si.MaSP and size.MaSize = si.MaSize and s.MaSP = " + ID;

            if (!string.IsNullOrEmpty(size))
            {
                selectString += " AND LOWER(size.Size) LIKE '" + size.ToLower() + "'";
            }

            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            SanPham sp = new SanPham();
            sp.MaSP = ID;
            sp.TenSP = reader.GetString(1);
            sp.GiaBan = int.Parse(reader["GiaBan"].ToString());
            sp.GiaMua = int.Parse(reader["GiaMua"].ToString());
            sp.LoaiSP = int.Parse(reader["LoaiSP"].ToString());
            sp.ChuDe = int.Parse(reader["ChuDe"].ToString());
            sp.ThongTin = reader["ThongTin"].ToString();
            sp.GioiTinh = int.Parse(reader["GioiTinh"].ToString());
            sp.NgayNhap = DateTime.Parse(reader["NgayNhapHang"].ToString());
            sp.HinhAnh = reader["HinhAnh"].ToString();
            sp.MASIZE = int.Parse(reader["MaSize"].ToString());
            sp.SoLuong = int.Parse(reader["SoLuong"].ToString());
            return sp;
        }
        public DataTable TimKiemSanPham(string TenSP)
        {
            DataTable dt = new DataTable();

            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "SELECT * FROM SANPHAM WHERE TENSP LIKE '%" + TenSP + "%'";
            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return dt;
        }
        public DataTable LayKichThuocSanPham(int ID)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            String selectString = "SELECT A.SIZE,A.MASIZE FROM  SIZE A, SANPHAM_SIZE B WHERE  A.MASIZE = B.MASIZE AND B.SOLUONG > 0  AND B.MASP = "+ID;
            SqlCommand cmd = new SqlCommand(selectString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return dt;
        }
        public void XoaSP(int MaSP)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string deleteString = "delete from SanPham where MaSP=" + MaSP;
            SqlCommand cmd = new SqlCommand(deleteString, dal_SanPham.conn);
            /*cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = MaSP;*/
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_SanPham.Close();
        }
        public void ThemSP(SanPham sp)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string insertString = "insert into SanPham(MaSP,TenSP,GiaMua,GiaBan,LoaiSP,ChuDe,ThongTin,GioiTinh,NgayNhapHang,HinhAnh) values("+sp.MaSP +",'" + sp.TenSP + "'," + sp.GiaMua + "," + sp.GiaBan + "," + sp.LoaiSP + "," + sp.ChuDe + ",'" + sp.ThongTin + "'," + sp.GioiTinh + ",'" + sp.NgayNhap + "','" + sp.HinhAnh + "')";
            SqlCommand cmd = new SqlCommand(insertString, dal_SanPham.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_SanPham.Close();
        }
        public void ThemSoLuongSanPham(SanPham sp)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string insertString = "insert into SanPham_Size(MaSP,MaSize,SoLuong) values("+ sp.MaSP +","+sp.MASIZE+","+sp.SoLuong+")" ;
            SqlCommand cmd = new SqlCommand(insertString, dal_SanPham.conn);
            cmd.ExecuteNonQuery();
            dal_SanPham.Close();
        }
        public void CapNhatSP(SanPham sp)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string updateSanPham = string.Format("UPDATE SanPham SET TenSP = N'{0}', GiaMua = {1}, GiaBan = {2}, LoaiSP = {3}, ChuDe = {4}, ThongTin = N'{5}', GioiTinh = {6}, NgayNhapHang = '{7}', HinhAnh = N'{8}' WHERE MaSP = {9}",
                sp.TenSP,
                sp.GiaMua,
                sp.GiaBan,
                sp.LoaiSP,
                sp.ChuDe,
                sp.ThongTin,
                sp.GioiTinh,
                sp.NgayNhap,
                sp.HinhAnh,
                sp.MaSP);
            SqlCommand cmd = new SqlCommand(updateSanPham, dal_SanPham.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            string updateSanPhamSize = string.Format("UPDATE SanPham_Size SET SoLuong = {0}, SoLuongTam = {1} WHERE MaSP = {2} AND MaSize = {3}",
                sp.SoLuong,
                sp.SoLuong,
                sp.MaSP,
                sp.MASIZE
                );
            cmd = new SqlCommand(updateSanPhamSize, dal_SanPham.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_SanPham.Close();
        }
        public int LayMaSP()
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select top 1 MaSP from SanPham order by MaSP desc";
            SqlCommand cmd = new SqlCommand(selectString,dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int Masp = reader.GetInt32(0);
            reader.Dispose();
            dal_SanPham.Close();
            return Masp+1;
        }
        public DataTable TopSanPham(int num)
        {
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string seleteString = "select top " + num + " with ties B.TenSP , B.GiaMua,B.GiaBan,SUM(SoLuong)as SoLuongBan from ChiTiet_HoaDon as A , SanPham B where A.MaSP = B.MaSP group by A.MaSP ,B.TenSP, B.GiaMua,B.GiaBan order by SUM(SoLuong) desc";
            SqlCommand cmd = new SqlCommand(seleteString, dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Dispose();
            cmd.Dispose();
            dal_SanPham.Close();
            return dt;
        }
        public int LaTrungMaSP(int MaSP)
        {
            int flag = 0;
            DAL_SanPham dal_SanPham = new DAL_SanPham();
            dal_SanPham.Open();
            string selectString = "select * from SanPham where MaSP = " + MaSP;
            SqlCommand cmd = new SqlCommand(selectString,dal_SanPham.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                flag = 1;
            }
            cmd.Dispose();
            reader.Dispose();
            dal_SanPham.Close();
            return flag;
        }



    }

}
