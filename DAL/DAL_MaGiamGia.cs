using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_MaGiamGia : QuanLyKetNoi
    {
        public void GhiThongTinMaGiamGia(MaGiamGiaDTO maGiamGia)
        {
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string insertString = string.Format("INSERT INTO MaGiamGia(Ma, MoTa, SoTien) VALUES(N'{0}',N'{1}',{2})",
                maGiamGia.Ma,
                maGiamGia.MoTa,
                maGiamGia.SoTien
                );
            SqlCommand cmd = new SqlCommand(insertString, DAL_MaGiamGia.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DAL_MaGiamGia.Close();

        }

        public DataTable DanhSachMaGiamGia()
        {
            DataTable ds = new DataTable();
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string selectString = "SELECT Id, Ma, MoTa, SoTien FROM MaGiamGia";
            SqlCommand cmd = new SqlCommand(selectString, DAL_MaGiamGia.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ds.Load(reader);
            DAL_MaGiamGia.Close();
            return ds;
        }

        public bool TrungMaDangSua(int id, string ma)
        {
             DataTable ds = new DataTable();
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string selectString = string.Format("SELECT Id, Ma FROM MaGiamGia WHERE LOWER(Ma) LIKE '{0}' AND Id != {1}", ma.ToLower(), id);
            SqlCommand cmd = new SqlCommand(selectString, DAL_MaGiamGia.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool result = reader.HasRows;
            cmd.Dispose();
            DAL_MaGiamGia.Close();
            return result;
        }

        public bool TonTaiMaGiamGia(string ma)
        {
            DataTable ds = new DataTable();
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string selectString = string.Format("SELECT Id, Ma FROM MaGiamGia WHERE LOWER(Ma) LIKE '{0}'", ma.ToLower());
            SqlCommand cmd = new SqlCommand(selectString, DAL_MaGiamGia.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool result = reader.HasRows;
            cmd.Dispose();
            DAL_MaGiamGia.Close();
            return result;
        }

        public decimal LaySoTienGiamGia(string ma)
        {
            DataTable ds = new DataTable();
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string selectString = string.Format("SELECT SoTien FROM MaGiamGia WHERE Ma LIKE '{0}'", ma);
            SqlCommand cmd = new SqlCommand(selectString, DAL_MaGiamGia.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            decimal result = 0;
            if (reader.HasRows)
            {
                reader.Read();
                result = reader.GetDecimal(0);
            }
            cmd.Dispose();
            DAL_MaGiamGia.Close();
            return result;
        }

        public MaGiamGiaDTO LayThongTinMaGiamGia(int Id)
        {
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string qry = "select Id, Ma, MoTa, SoTien from MaGiamGia where Id = " + Id;
            SqlCommand cmd = new SqlCommand(qry, DAL_MaGiamGia.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            MaGiamGiaDTO MaGiamGia = new MaGiamGiaDTO();
            if (reader.HasRows)
            {
                reader.Read();
                MaGiamGia.Id = reader.GetInt32(0);
                MaGiamGia.Ma = reader.GetString(1);
                MaGiamGia.MoTa = reader.GetString(2);
                MaGiamGia.SoTien = reader.GetDecimal(3);
            }
            reader.Dispose();
            cmd.Dispose();
            DAL_MaGiamGia.Close();

            return MaGiamGia;
        }

        public void XoaMaGiamGia(int Id)
        {
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string deleteString = "delete from MaGiamGia where Id =" + Id;
            SqlCommand cmd = new SqlCommand(deleteString, DAL_MaGiamGia.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DAL_MaGiamGia.Close();
        }

        public void SuaMaGiamGia(MaGiamGiaDTO maGiamGia)
        {
            DAL_MaGiamGia DAL_MaGiamGia = new DAL_MaGiamGia();
            DAL_MaGiamGia.Open();
            string insertString = string.Format("UPDATE MaGiamGia SET Ma = N'{0}', MoTa = N'{1}', SoTien = {2} WHERE Id = {3}",
                maGiamGia.Ma,
                maGiamGia.MoTa,
                maGiamGia.SoTien,
                maGiamGia.Id
                );
            SqlCommand cmd = new SqlCommand(insertString, DAL_MaGiamGia.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DAL_MaGiamGia.Close();
        }
    }
}
