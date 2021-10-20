using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_KhachHang:QuanLyKetNoi
    {
        public void GhiThongTinKhachHang(KhachHang kh)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string mahoa = MaHoa.EncryptString(kh.MATKHAU, "03DHTH1_CTTeam");
            string insertString = "insert into khachhang(TenDangNhap,MatKhau,HoTen,GioiTinh,DiaChi,Email,SoDienThoai,LaAdmin) values('" + kh.TENDANGNHAP + "','" + mahoa + "',N'" + kh.HOTEN + "'," + kh.GIOITINH + ",N'" + kh.DIACHI + "','" + kh.EMAIL + "','" + kh.SODIENTHOAI + "','False')";
            SqlCommand cmd = new SqlCommand(insertString,dal_KhachHang.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_KhachHang.Close();

        }
        public int LaTrungTenDangNhap(string TenDangNhap)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KHACHHANG WHERE TENDANGNHAP = '" + TenDangNhap+"'";
            SqlCommand cmd = new SqlCommand(selectString,dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return 1;
            }
            return 0;
        }
        public int LaTrungEmail(string Email)
        {
            int flag = 0;
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KHACHHANG WHERE Email = N'" + Email + "'";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                flag =  1;
            }
            cmd.Dispose();
            reader.Dispose();
            dal_KhachHang.Close();
            return flag;
        }

        public bool LaTrungSoDienThoai(string sdt)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KhachHang WHERE SoDienThoai = N'" + sdt + "'";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public bool DaCoHoaDon(int maKH)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM HOADON WHERE MaKH = " + maKH.ToString();
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public bool IsAdmin(int maKH)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KHACHHANG WHERE MaKH = " + maKH.ToString() +" AND LaAdmin = 1";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public int LaDangNhapThanhCong(string Username,string Password)
        {
            int flag = -1;
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KHACHHANG WHERE TENDANGNHAP = '" + Username + "' AND MATKHAU ='" + Password + "'";
            SqlCommand cmd = new SqlCommand(selectString,dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                bool isAdmin = reader.GetBoolean(8);
                if (isAdmin == true)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            cmd.Dispose();
            reader.Dispose();
            dal_KhachHang.Close();
            return flag;
        }
        public int LayMaKH(string username)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT MaKH FROM KHACHHANG WHERE TENDANGNHAP = '" + username + "'";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int makh = int.Parse(reader.GetValue(0).ToString());
                cmd.Dispose();
                reader.Dispose();
                dal_KhachHang.Close();
                return makh;
            }
            else
            {
                cmd.Dispose();
                reader.Dispose();
                dal_KhachHang.Close();
                return -1;
            }
        }
        public KhachHang LayThongTinKhachHang(string username)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string qry = "select * from KhachHang where TenDangNhap = '"+username+"'";
            SqlCommand cmd = new SqlCommand(qry, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            KhachHang kh = new KhachHang();
            if (reader.HasRows)
            {
                reader.Read();
                kh.MAKH = reader.GetInt32(0);
                kh.TENDANGNHAP = username;
                kh.HOTEN = reader.GetValue(3).ToString();
                kh.GIOITINH = reader.GetInt32(4);
                kh.DIACHI = reader.GetValue(5).ToString();
                kh.EMAIL = reader.GetValue(6).ToString();
                kh.SODIENTHOAI = reader.GetValue(7).ToString();
                kh.LAADMIN = (bool)reader.GetValue(8);
            }
            reader.Dispose();
            cmd.Dispose();
            dal_KhachHang.Close();

            return kh;
        }
        public DataTable DanhSachKhachHang()
        {
            DataTable ds = new DataTable();
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "select * from KhachHang";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ds.Load(reader);
            dal_KhachHang.Close();
            return ds;
        }
        public void CapNhatKhachHang(KhachHang kh)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string mahoa = MaHoa.EncryptString(kh.MATKHAU, "03DHTH1_CTTeam");
            string updateString = "Update KhachHang set MatKhau = '"+mahoa+"', HoTen = N'"+kh.HOTEN+"', GioiTinh = "+kh.GIOITINH+
             ", DiaChi = N'"+kh.DIACHI +"', Email = '"+kh.EMAIL +"',SoDienThoai ='"+kh.SODIENTHOAI+"', LaAdmin = '"+kh.LAADMIN+"'" +
             "where MaKH = "+kh.MAKH;
            SqlCommand cmd = new SqlCommand(updateString,dal_KhachHang.conn);
            cmd.ExecuteNonQuery();
            dal_KhachHang.Close();

        }
        public void XoaKhachHang(int MaKH)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string deleteString = "delete from KhachHang where MaKH= "+MaKH;
            SqlCommand cmd = new SqlCommand(deleteString, dal_KhachHang.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_KhachHang.Close();
        }
        public DataTable LoadTopKhachHang(int number)
        {
            DAL_KhachHang daoKH = new DAL_KhachHang();
            daoKH.Open();
            string qry = "select top " + number + " with ties B.HoTen,B.SoDienThoai , SUM(SoLuong*DonGia) as DoanhThu from HoaDon A,KhachHang B,ChiTiet_HoaDon C where A.MaHD = C.MaHD and B.MaKH = A.MaKH group by B.MaKH,B.HoTen,B.SoDienThoai order by SUM(SoLuong*DonGia) desc";
            SqlCommand cmd = new SqlCommand(qry, daoKH.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Dispose();
            cmd.Dispose();
            daoKH.Close();
            return dt;
        }
        public void CapNhatThongTinKH(KhachHang kh)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string updateString = "Update KhachHang set HoTen = N'" + kh.HOTEN + "', GioiTinh = " + kh.GIOITINH +
             ", DiaChi = N'" + kh.DIACHI + "', Email = '" + kh.EMAIL + "',SoDienThoai ='" + kh.SODIENTHOAI + "'" +
             "where MaKH = " + kh.MAKH;
            SqlCommand cmd = new SqlCommand(updateString, dal_KhachHang.conn);
            cmd.ExecuteNonQuery();
            dal_KhachHang.Close();
        }

        public void CapNhatThongTinMatKhau(int maKH, string matKhau)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string updateString = "Update KhachHang set MatKhau = N'" + matKhau + "'" +
             " where MaKH = " + maKH.ToString();
            SqlCommand cmd = new SqlCommand(updateString, dal_KhachHang.conn);
            cmd.ExecuteNonQuery();
            dal_KhachHang.Close();
        }

        public bool MatKhauKhopMatKhauCu(int maKH, string matKhauCu)
        {
            DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
            dal_KhachHang.Open();
            string selectString = "SELECT * FROM KHACHHANG WHERE MaKH = " + maKH.ToString() + " AND MatKhau = N'" + matKhauCu + "'";
            SqlCommand cmd = new SqlCommand(selectString, dal_KhachHang.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }
    }
}
