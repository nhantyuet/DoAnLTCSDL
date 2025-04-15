using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DataProvider
    {
        public SqlConnection cn;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        public DataProvider()
        {
            //tren may m se khac cai snStr nen phai doi lai ten connect dc
            string cnStr = "Data Source=DESKTOP-U6OJ5V3\\MAYONHA;Initial Catalog=QuanLyKhoVLXD;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string CheckLogin(Account account)
        {
            try
            {
                Connect();
                string query = "SELECT Role FROM TaiKhoan WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Username", account.Username);
                cmd.Parameters.AddWithValue("@Password", account.Password);

                string roled="";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    roled = result.ToString();
                }
                Disconnect();
                if (roled != "")
                {
                    return roled;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public string tenNhanVien(string maNV)
        {
            try
            {
                Connect();
                string query = "select TenNV\r\nfrom NhanVien join TaiKhoan on NhanVien.MaNV = TaiKhoan.MaNV\r\nwhere Username = '" +maNV + "'" ;
                SqlCommand cmd = new SqlCommand(query, cn);
                string tenNhanVien = "";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    tenNhanVien = result.ToString();
                }
                Disconnect();
                return tenNhanVien;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public KhachHang timKiemKhachHang(string SDT)
        {
            try
            {
                Connect();
                string query = "select * from KhachHang where SoDienThoai = '" + SDT + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Disconnect();
                KhachHang khachHang = new KhachHang();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    khachHang.MaKH = (int)row["MaKH"];
                    khachHang.TenKH= row["TenKH"].ToString();
                    khachHang.DiaChi = row["DiaChi"].ToString();
                    khachHang.SDT = row["SoDienThoai"].ToString() ;
                    return khachHang;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public bool themKhachHang(KhachHang kh)
        {
            try
            {
                Connect();

                string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE SoDienThoai = @SDT";
                SqlCommand checkCmd = new SqlCommand(checkQuery, cn);
                checkCmd.Parameters.AddWithValue("@SDT", kh.SDT);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    // SDT đã tồn tại => không thêm
                    Disconnect();
                    return false;
                }

                string query = "INSERT INTO[dbo].[KhachHang]([TenKH], [DiaChi], [SoDienThoai]) " +
                                "VALUES(@TenKH,@DiaChi,@SDT)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH.ToString());
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi.ToString());
                cmd.Parameters.AddWithValue("@SDT", kh.SDT.ToString());
                int result = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                Disconnect();
                return result>0;

               
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
        public DataSet napDuLieuVaoDanhSachSanPham()
        {
            try
            {
                Connect();
                string sql = "select VatLieu.TenVL , VatLieu.GiaBan, TonKho.SoLuongTon, VatLieu.DonViTinh\r\nfrom VatLieu join TonKho \r\non VatLieu.MaVL = TonKho.MaVL";
                adapter = new SqlDataAdapter(sql, cn);

                dataSet = new DataSet();
                adapter.Fill(dataSet);
           //     dataGridView1.DataSource = dataSet.Tables[0];

                Disconnect();
                return dataSet;
                


            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
        
        public DataSet timKiemSanPham(string tenVL)
        {
            try
            {
                Connect();
                string sql = "select VatLieu.TenVL , VatLieu.GiaBan, TonKho.SoLuongTon, VatLieu.DonViTinh\r\nfrom VatLieu join TonKho \r\non VatLieu.MaVL = TonKho.MaVL " +
                    "WHERE TenVL LIKE N'%" + tenVL + "%'";


                SqlCommand cmd = new SqlCommand(sql, cn);
                adapter = new SqlDataAdapter(sql, cn);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                Disconnect();
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
        public string maVL(string tenVL) //chua test lai voi ham query moi
        {
            try
            {
                Connect();
                string query = "select MaVL from VatLieu where TenVL = @TenVL";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@TenVL", tenVL);


                string maVL = "";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maVL = result.ToString();
                }
                Disconnect();
                if(maVL != "")
                {
                    return maVL;
                }    
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }


        public string maKH(string sdt) //Chưa test
        {
            try
            {
                Connect();
                string query = "select MaKH from KhachHang where SoDienThoai = @sdt";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@sdt", sdt);


                string maKH = "";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maKH = result.ToString();
                }
                Disconnect();
                if (maKH != "")
                {
                    return maKH;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public string maNV(string username) //chua tet
        {
            try
            {
                Connect();
                string query = "select MaNV from TaiKhoan where Username = @username";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@username", username);


                string maNV = "";
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maNV = result.ToString();
                }
                Disconnect();
                if (maNV != "")
                {
                    return maNV;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public int insertDonHang(string MaKH, string MaNV, string NgayDatHang, string NgayGiaoHang, string DiaChi, string SoDienThoai)
        {
            try
            {
                Connect();
                string query = "INSERT INTO[dbo].[DonHang]([MaKH],[MaNV],[NgayDatHang],[NgayGiaoHang],[DiaChi],[SoDienThoai]) " +
                                "VALUES(@MaKH,@MaNV,@NgayDatHang,@NgayGiaoHang,@DiaChi, @SoDienThoai);" +
                                "select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@MaKH", MaKH);
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                cmd.Parameters.AddWithValue("@NgayDatHang", NgayDatHang);
                cmd.Parameters.AddWithValue("@NgayGiaoHang", NgayGiaoHang);
                cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai);

                int maDH = -1;
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maDH = int.Parse(result.ToString());
                }
                Disconnect();
                if (maDH != -1)
                {
                    return maDH;
                }
                return -1;

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }

        }
        public void insertChiTietDonHang(int MaDH, int MaVL,int GiaBan, int SoLuong )
        {
            try
            {
                Connect();
                string query = "INSERT INTO [dbo].[ChiTietDonHang]([MaDH],[MaVL],[GiaBan],[SoLuong]) " +
                    "VALUES(@MaDH, @MaVL, @GiaBan,@SoLuong)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@MaDH", MaDH);
                cmd.Parameters.AddWithValue("@MaVL", MaVL);
                cmd.Parameters.AddWithValue("@GiaBan", GiaBan);
                cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                int result = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                Disconnect();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public void insertHoaDon(int MaDH, string ngayLap,int tongTien,string trangThaiThanhToan)
        {
            try
            {
                Connect();
                string query = "INSERT INTO [dbo].[HoaDon]([MaDH],[NgayLap],[TongTien],[TrangThaiThanhToan])\r\nVALUES(@MaDH,@ngayLap,@tongTien,@trangThaiThanhToan)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@MaDH", MaDH);
                cmd.Parameters.AddWithValue("@ngayLap", ngayLap);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);
                cmd.Parameters.AddWithValue("@trangThaiThanhToan", trangThaiThanhToan);
                int result = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                Disconnect();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }

        public void themCongNo(string SoDienThoai, int TienNo)
        {
            try
            {
                Connect();
                string query = "Update KhachHang set CongNo = CongNo + @TienNo where SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@TienNo", TienNo);
                cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai);
                cmd.ExecuteNonQuery();
                Disconnect();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error: " + ex.Message);
            }
        }
      
        
     



    }
}
