using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
namespace DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=NHAN_DEP_TRAI;Initial Catalog=BANDT;User ID=sa;Password=1412";
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }

    }
    public class Data
    {

        public static string CheckLoginDTO (User user)
        {
            string tk = null;
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("DangNhap");
            command.Parameters.AddWithValue("@tk", user.user);
            command.Parameters.AddWithValue("@mk", user.password);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
           
            if (reader.HasRows)
                {
                    while (reader.Read())
                    { 
                        tk = reader.GetString(reader.GetOrdinal("QUYEN"));
                        return tk;
                    }
                    reader.Close();
                    conn.Close();
                }
                else
                {

                    return "Tài khoản hoặc mật khẩu không chính xác";
                }
                return tk;
        }
        public static List<SanPham> loadSanPhamDTO()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SanPham", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable sp = new DataTable();
            adapter.Fill(sp);
            foreach (DataRow item in sp.Rows)
            {
                SanPham sp1 = new SanPham(item);
                listSanPham.Add(sp1);
            }
            conn.Close();
            return listSanPham;
        }
        public static List<SanPham> TimSanPhamDTO(string maloai)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("TimSanPham", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@maloai", SqlDbType.NVarChar).Value = maloai;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable sp = new DataTable();
            adapter.Fill(sp);
            foreach (DataRow item in sp.Rows)
            {
                SanPham sp1 = new SanPham(item);
                listSanPham.Add(sp1);
            }
            conn.Close();
            return listSanPham;
        }
        public static List<SanPham> TimSanPhamTheoTenDTO(string tensp)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("TimSanPhamTheoTen", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@tensp", SqlDbType.NVarChar).Value = tensp;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable sp = new DataTable();
            adapter.Fill(sp);
            foreach (DataRow item in sp.Rows)
            {
                SanPham sp1 = new SanPham(item);
                listSanPham.Add(sp1);
            }
            conn.Close();
            return listSanPham;

        }
        public static void TaoHoaDonDTO(string makh,int manv,int sl,string mamh)
        {
            
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("TaoHoaDon", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@makh", SqlDbType.NVarChar).Value = makh;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = manv;
            command.Parameters.Add("@sl", SqlDbType.NVarChar).Value = sl;
            command.Parameters.Add("@mamh", SqlDbType.NVarChar).Value = mamh;
            command.ExecuteNonQuery();
            conn.Close();
            
        }
        public static KhachHang TimKhachHangDTO(string makh)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("TimKhachHang", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@makh", SqlDbType.NVarChar).Value = makh;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable kh1 = new DataTable();
            adapter.Fill(kh1);
            
            KhachHang kh = new KhachHang();
            if (kh1.Rows.Count > 0)
            {
                DataRow kh2 = kh1.Rows[0];
                kh.makh = (string)kh2.ItemArray[0];
                kh.tenkh = (string)kh2.ItemArray[1];
                kh.dckh = (string)kh2.ItemArray[2];
                kh.sdtkh = (string)kh2.ItemArray[3];
            }
            return kh;
        }
        public static void TaoKhachHangDTO(string makh,string tenkh,string dckh,string sdt)
        {
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("TaoKhachHang", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@makh", SqlDbType.NVarChar).Value = makh;
            command.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = tenkh;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = dckh;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
            command.ExecuteNonQuery();
        }
        public static List<SanPham> SanPhamTangDanDTO()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SanPhamTangDan", conn);
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable SanPham = new DataTable();
            adapter.Fill(SanPham);
            foreach (DataRow item in SanPham.Rows)
            {
                SanPham sp1 = new SanPham(item);
                listSanPham.Add(sp1);
            }
            conn.Close();
            return listSanPham;
        }
        public static List<SanPham> SanPhamGiamDanDTO()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM SanPhamGiamDan", conn);
            
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable SanPham = new DataTable();
            adapter.Fill(SanPham);
            foreach (DataRow item in SanPham.Rows)
            {
                SanPham sp1 = new SanPham(item);
                listSanPham.Add(sp1);
            }
            conn.Close();
            return listSanPham;
        }
    }  
}
