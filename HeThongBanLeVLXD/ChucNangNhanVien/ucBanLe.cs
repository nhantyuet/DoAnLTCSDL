using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;
namespace HeThongBanLeVLXD.ChucNangNhanVien
{

    public partial class ucBanLe : UserControl
    {
     //  private SqlDataAdapter adapter;
      //  private DataSet dataSet;
     //   private SqlConnection cn;
      //  DataProvider dp = new DataProvider();
        public string tenNhanVien;
        public string maNhanVien;
        private int tongTien;
        private ucBanLeBL uc_BanLeBL;
        public ucBanLe()
        {
            InitializeComponent();
            

        }
        private void LoadVatLieuTonKho() //Chua test ten xem co khop voi name hay k
        {
            uc_BanLeBL = new ucBanLeBL();
            dataGridView1.Rows.Clear();
            List<VatLieuTonKho> vatLieuTonKhos = uc_BanLeBL.GetVatLieuTonKhoBL();
            foreach (VatLieuTonKho vatLieuTonKho in vatLieuTonKhos)
            {
                dataGridView1.Rows.Add(vatLieuTonKho.TenVL, vatLieuTonKho.GiaBan, vatLieuTonKho.SoLuongTon, vatLieuTonKho.DonViTinh);
            }
        
        }
        private void ucBanLe_Load(object sender, EventArgs e)
        {

            lbMaNhanVien.Text = maNhanVien;
            lbTenNhanVien.Text = tenNhanVien;
            dateTimePicker1.Value = DateTime.Today; // Gán ngày hiện tại
            LoadVatLieuTonKho();
            dataGridView2.Rows.Clear();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            uc_BanLeBL = new ucBanLeBL();
            if (tbSdtKh.Text == "")
            {
                MessageBox.Show("Vui Long Nhap SDT_Khach_Hang", MessageBoxButtons.OK.ToString());
            }
            else
            {          
                KhachHang khachHang = uc_BanLeBL.timKiemKhachHangBL(tbSdtKh.Text.Trim()); //Gọi ở ucBanLeBL
                if (khachHang.TenKH == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin và số điện thoại phải gồm đúng 10 chữ số.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    tbTenKhachHang.Text = khachHang.TenKH;
                    tbDiaChi.Text = khachHang.DiaChi;
                }
            }
        }
        private bool IsValidPhoneNumber(string sdt)
        {
            return sdt.Length == 10 && sdt.All(char.IsDigit);
        }

        private void btThemKH_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            uc_BanLeBL = new ucBanLeBL();
            int len = tbSdtKh.Text.Length;
            if (string.IsNullOrWhiteSpace(tbTenKhachHang.Text) ||
                    string.IsNullOrWhiteSpace(tbDiaChi.Text) ||
                    !IsValidPhoneNumber(tbSdtKh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và số điện thoại phải gồm đúng 10 chữ số.", "Thông báo", MessageBoxButtons.OK);
                tbTenKhachHang.Text = "";
                tbDiaChi.Text = "";
                tbSdtKh.Text = "";
                return;
            }
            else
            {
                try
                {
                    khachHang.DiaChi = tbDiaChi.Text;
                    khachHang.SDT = tbSdtKh.Text;
                    khachHang.TenKH = tbTenKhachHang.Text;
                    uc_BanLeBL.themKhachHangBL(khachHang);
                    MessageBox.Show("Da Them KH vao DB", "Thông báo", MessageBoxButtons.OK);
                    tbTenKhachHang.Text = "";
                    tbDiaChi.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

     

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(tbTenVl.Text == "")
            {
                dataGridView1.Rows.Clear();
                LoadVatLieuTonKho();
            }
            else
            {
                dataGridView1.Rows.Clear();
                List<VatLieuTonKho> vatLieuTonKhos = uc_BanLeBL.timKiemSanPhamBL(tbTenVl.Text);
                foreach (VatLieuTonKho vatLieuTonKho in vatLieuTonKhos)
                {
                    dataGridView1.Rows.Add(vatLieuTonKho.TenVL, vatLieuTonKho.DonViTinh, vatLieuTonKho.DonViTinh, vatLieuTonKho.GiaBan);
                }
               
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                lbDonViTinh.Text = row.Cells[3].Value?.ToString();
                lbTenVL.Text = row.Cells[0].Value?.ToString(); // nếu là Value thì ==null sẽ bị exception
                lbGiaBan.Text = row.Cells[1].Value?.ToString();
                lbSlTonKho.Text = row.Cells[2].Value?.ToString();
                numSLDH.Value = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(numSLDH.Value > int.Parse(lbSlTonKho.Text) || numSLDH.Value == 0)
            {
                MessageBox.Show("Sth Wrong", "Thông báo", MessageBoxButtons.OK);
                numSLDH.Value = 0;
            }
            else if (tbDiaChi.Text == "" || tbTenKhachHang.Text == "" || tbSdtKh.Text == "")
            {
                MessageBox.Show("Vui Long Dien Thong Tin Truoc Khi Tao Don Hang", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                int giaBan;
                bool daTonTai = false;

                if (!int.TryParse(lbGiaBan.Text, out giaBan))
                {
                    MessageBox.Show("Giá bán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value.ToString() == lbTenVL.Text)
                    {   
                        // Đã tồn tại → Cập nhật số lượng và thành tiền
                        int soLuongCu = int.Parse(row.Cells[3].Value.ToString());
                        int soLuongMoi = soLuongCu + (int)numSLDH.Value;
                        row.Cells[3].Value = soLuongMoi.ToString();

                        giaBan = int.Parse(lbGiaBan.Text);
                        int thanhTienMoi = soLuongMoi * giaBan;
                        row.Cells[4].Value = thanhTienMoi.ToString();

                        daTonTai = true;
                        break;
                    }
                }
                if (!daTonTai)
                {
                    giaBan = int.Parse(lbGiaBan.Text);
                    float thanhTien = (float)numSLDH.Value * giaBan;

                    dataGridView2.Rows.Add(lbTenVL.Text,
                                            lbDonViTinh.Text,
                                            lbGiaBan.Text,
                                            numSLDH.Value.ToString(),
                                            thanhTien.ToString());
                }
                tongTien += (int)numSLDH.Value * giaBan;
                lbTongTien.Text = tongTien.ToString() + " ₫";
            }
        }

        

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Dòng vừa thêm nằm ở cuối
            int lastRow = dataGridView2.Rows.Count - 1;

            if (!dataGridView2.Rows[lastRow].IsNewRow)
            {
                // Lấy giá trị thành tiền (giả sử cột cuối cùng là cột 4, index = 4)
                int thanhTien = int.Parse(dataGridView2.Rows[lastRow].Cells[4].Value.ToString());
                tongTien += thanhTien;
                lbTongTien.Text = tongTien.ToString() + " ₫";
            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            tongTien = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    int thanhTien = int.Parse(row.Cells[4].Value.ToString());
                    tongTien += thanhTien;
                    Console.WriteLine(tongTien.ToString());
                }
            }
            lbTongTien.Text = tongTien.ToString() + " ₫";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count == 0 || dataGridView2.Rows.Count == 1 && dataGridView2.Rows[0].IsNewRow)
            {
                MessageBox.Show("Danh Sach Chi Tiet Don Hang Dang Trong", "Thông báo", MessageBoxButtons.OK);
            }
            else if (dataGridView2.CurrentRow != null && !dataGridView2.CurrentRow.IsNewRow)
            {
                int thanhTien = int.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                tongTien -= thanhTien;
                lbTongTien.Text = tongTien.ToString() + " ₫";

                // Xóa dòng được chọn
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tongTien = lbTongTien.Text;
            int len = lbTongTien.Text.Length;
            tbTienDua.Text = tongTien.Substring(0,len - 2);
            lbTienThoi.Text = "0";
        }

        private void tbTienDua_TextChanged(object sender, EventArgs e)
        {
            int tienThoi;
            int len = lbTongTien.Text.Length;
            string tongTien = lbTongTien.Text;
            tongTien = tongTien.Substring(0,len-2) ;
            if (tbTienDua.Text == "")
            {
                tbTienDua.Text = "0";
            }
            else if(int.Parse(tbTienDua.Text) > int.Parse(tongTien))
            {
                tbTienDua.Text = tongTien.Substring(0, len - 2);
                lbTienThoi.Text = "0";
            }    
            tienThoi = int.Parse(tongTien) - int.Parse(tbTienDua.Text) ;
            

            lbTienThoi.Text = tienThoi.ToString() ;
        }

        private void tbTienDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím control (backspace, delete...)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //------------------------------------------------------------------------------------------------

        private void button4_Click(object sender, EventArgs e)
           {
               //int tienThoi;
               uc_BanLeBL = new ucBanLeBL();
               int len = lbTongTien.Text.Length;
               string tongTien = lbTongTien.Text;
               tongTien = tongTien.Substring(0, len - 2);
            if (tbTienDua.Text == "" || tbDiaChi.Text == "" || tbTenKhachHang.Text == "" || tbSdtKh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để tạo đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (int.Parse(lbTienThoi.Text) == 0) // là trả đủ tiền lun 
            {
                DonHang donHang = new DonHang(Int32.Parse (uc_BanLeBL.getMaKHBL(tbSdtKh.Text.ToString())) , Int32.Parse(uc_BanLeBL.getMaNVBL(lbTenNhanVien.Text)), dateTimePicker1.Value,
               dateTimePicker2.Value, tbDiaChi.Text, tbSdtKh.Text);
                int maDH = uc_BanLeBL.insertDonHangBL(donHang);
                int tongTienHoaDon = 0;

                if (maDH > -1)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // Bỏ qua dòng trống cuối cùng của DataGridView
                        if (row.IsNewRow) continue;

                        int maVL = int.Parse(uc_BanLeBL.getMaVLBL(row.Cells[0].Value.ToString()));
                        int giaBan = int.Parse(row.Cells[2].Value.ToString());
                        int slMua = int.Parse(row.Cells[3].Value.ToString());
                        tongTienHoaDon += giaBan * slMua; // chua can dung toi
                        ChiTietDonHang chiTietDonHang = new ChiTietDonHang(maDH,maVL, giaBan, slMua);
                        uc_BanLeBL.TonKhoBL(maVL, slMua);
                        int maCTDH = uc_BanLeBL.ThemChiTietDonHangBL(chiTietDonHang);
                    }
                    HoaDon hoaDon = new HoaDon(maDH, dateTimePicker1.Value, tongTienHoaDon, "Da Thanh Toan");
                    uc_BanLeBL.insertHoaDonBL(hoaDon);
                    MessageBox.Show("Thêm đơn hàng thành công!");
                    LoadVatLieuTonKho();
                    dataGridView2.Rows.Clear();
                    tbSdtKh.Text = "";
                    tbDiaChi.Text = "";
                    tbTenKhachHang.Text = "";

                }
                else
                {
                    MessageBox.Show("Tạo KHÔNG xong ĐH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                DonHang donHang = new DonHang(Int32.Parse(uc_BanLeBL.getMaKHBL(tbSdtKh.Text.ToString())), Int32.Parse(uc_BanLeBL.getMaNVBL(lbTenNhanVien.Text)), dateTimePicker1.Value,
                    dateTimePicker2.Value, tbDiaChi.Text, tbSdtKh.Text);
                int maDH = uc_BanLeBL.insertDonHangBL(donHang);
                int tongTienHoaDon = 0;
                if (maDH > -1)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        // Bỏ qua dòng trống cuối cùng của DataGridView
                        if (row.IsNewRow) continue;

                        int maVL = int.Parse(uc_BanLeBL.getMaVLBL(row.Cells[0].Value.ToString()));
                        int giaBan = int.Parse(row.Cells[2].Value.ToString());
                        int slMua = int.Parse(row.Cells[3].Value.ToString());
                        tongTienHoaDon += giaBan * slMua; // chua can dung toi
                        ChiTietDonHang chiTietDonHang = new ChiTietDonHang(maDH, maVL, giaBan, slMua);
                        uc_BanLeBL.ThemChiTietDonHangBL(chiTietDonHang);
                    }
                    HoaDon hoaDon = new HoaDon(maDH, dateTimePicker1.Value, tongTienHoaDon, "Chua Thanh Toan Day Du");
                    uc_BanLeBL.insertHoaDonBL(hoaDon);
                    Console.WriteLine(int.Parse(lbTienThoi.Text));
                    
                    uc_BanLeBL.ThemCongNoBL(tbSdtKh.Text.ToString(), int.Parse(lbTienThoi.Text));
                    LichSuCongNo lichSuCongNo = new LichSuCongNo(int.Parse(uc_BanLeBL.getMaKHBL(tbSdtKh.Text.ToString())), int.Parse(uc_BanLeBL.getMaNVBL(lbTenNhanVien.Text)), int.Parse(lbTienThoi.Text), dateTimePicker1.Value);
                    uc_BanLeBL.ThemLichSuCongNoBL(lichSuCongNo);
                    MessageBox.Show("Thêm chi tiết đơn hàng thành công!");
                    this.Controls.Clear();
                    this.InitializeComponent();

                }
                else
                {
                    MessageBox.Show("Tạo KHÔNG xong ĐH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           }
        

    }
}
