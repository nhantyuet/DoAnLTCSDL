using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanLeVLXD.ChucNangNhanVien
{
    public partial class ucThanhToanCongNo : UserControl
    {
        public string tenNhanVien;
        public string maNhanVien;
        private ucThanhToanCongNoBL uc_ThanhToanCongNoBL;
        public ucThanhToanCongNo()
        {
            InitializeComponent();
        }
        private void ucThanhToanCongNo_Load(object sender, EventArgs e)
        {
            lbMaNhanVien.Text = maNhanVien;
            lbTenNhanVien.Text = tenNhanVien;
            dateTimePicker1.Value = DateTime.Today; // Gán ngày hiện tại
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            uc_ThanhToanCongNoBL = new ucThanhToanCongNoBL();
            if (tbSdtKh.Text == "")
            {
                MessageBox.Show("Vui Long Nhap SDT_Khach_Hang", MessageBoxButtons.OK.ToString());
            }
            else
            {
                try
                {
                    KhachHang khachHang = uc_ThanhToanCongNoBL.timKiemKhachHangBL(tbSdtKh.Text.Trim());
                    tbTenKhachHang.Text = khachHang.TenKH;
                    lbCongNo.Text = khachHang.CongNo.ToString();
                }
                catch (SqlException ex) // chỗ này nó hơi vô lý ch test lại
                {
                    MessageBox.Show(ex.Message, "Không Tìm thấy khách hàng ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tongTien = lbCongNo.Text;
            int len = lbCongNo.Text.Length;
            tbTienDua.Text = lbCongNo.Text;
        }

        private void tbTienDua_TextChanged(object sender, EventArgs e)
        {
            int tienThoi;
            int len = lbCongNo.Text.Length;
            string tongTien = lbCongNo.Text;
            if (tbTienDua.Text == "")
            {
                tbTienDua.Text = "0";
            }
            else if (int.Parse(tbTienDua.Text) > int.Parse(tongTien))
            {
                tbTienDua.Text = lbCongNo.Text;
            }
            tienThoi = int.Parse(tongTien) - int.Parse(tbTienDua.Text);
            lbTienThoi.Text = tienThoi.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uc_ThanhToanCongNoBL = new ucThanhToanCongNoBL();
            if (tbTienDua.Text == "" || tbTienDua.Text == "" || tbTenKhachHang.Text == "" || tbSdtKh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thực hiện trả nợ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                LichSuCongNo lichSuCongNo = new LichSuCongNo(Int32.Parse(uc_ThanhToanCongNoBL.getMaKHBL(tbSdtKh.Text)), Int32.Parse(uc_ThanhToanCongNoBL.getMaNVBL(lbTenNhanVien.Text)), Int32.Parse(tbTienDua.Text) * (-1),dateTimePicker1.Value);
                uc_ThanhToanCongNoBL.InsertLichSuCongNoBL(lichSuCongNo);
                uc_ThanhToanCongNoBL.UpdateCongNoKhachHangBL(tbSdtKh.Text, Int32.Parse(tbTienDua.Text));
                MessageBox.Show("Thực hiện thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
