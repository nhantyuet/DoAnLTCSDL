using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace HeThongBanLeVLXD.ChucNangNhanVien
{
    public partial class ucXuatHoaDon : UserControl
    {
        public string tenNhanVien;
        public string maNhanVien;
        private ucXuatHoaDonBL uc_XuatHoaDonBL;
        public ucXuatHoaDon()
        {
            InitializeComponent();
        }

        private void LoadHoaDonDL() //Chua test ten xem co khop voi name hay k
        {
            uc_XuatHoaDonBL = new ucXuatHoaDonBL();
            dataGridView1.Rows.Clear();
            List<HoaDonKH> hoaDonKHs = uc_XuatHoaDonBL.GetHoaDonBL();
            foreach (HoaDonKH hoaDonKH in hoaDonKHs)
            {
                dataGridView1.Rows.Add(hoaDonKH.MaHD, hoaDonKH.MaDH, hoaDonKH.MaKH, hoaDonKH.NgayLap, hoaDonKH.TongTien, hoaDonKH.TrangThaiThanhToan);
            }

        }

        private void ucXuatHoaDon_Load(object sender, EventArgs e)
        {
            lbMaNhanVien.Text = maNhanVien;
            lbTenNhanVien.Text = tenNhanVien;
            LoadHoaDonDL();
            dataGridView2.Rows.Clear();
        }

        private void lbMaNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbTimKiem.Text == "")
            {
                dataGridView1.Rows.Clear();
                LoadHoaDonDL();

            }
            else if (tbTimKiem.Text.Length <= 3)
            {
                dataGridView1.Rows.Clear();
                List<HoaDonKH> hoaDonKHs = uc_XuatHoaDonBL.timKiemHoaDonMaKHBL(Int32.Parse(tbTimKiem.Text));
                foreach (HoaDonKH hoaDonKH in hoaDonKHs)
                {
                    dataGridView1.Rows.Add(hoaDonKH.MaHD, hoaDonKH.MaKH, hoaDonKH.NgayLap, hoaDonKH.TongTien, hoaDonKH.TrangThaiThanhToan);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                List<HoaDonKH> hoaDonKHs = uc_XuatHoaDonBL.timKiemHoaDonSoDienThoaiBL(tbTimKiem.Text);
                foreach (HoaDonKH hoaDonKH in hoaDonKHs)
                {
                    dataGridView1.Rows.Add(hoaDonKH.MaHD, hoaDonKH.MaKH, hoaDonKH.NgayLap, hoaDonKH.TongTien, hoaDonKH.TrangThaiThanhToan);
                }
            }
        }
              private string maHD;
       private string tenKH;
        private string soDienThoai;
       private string diaChiGiaoHang;
        private DateTime ngayLap;
        private int MaDHcaught;


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                dataGridView2.Rows.Clear();
                MaDHcaught = Int32.Parse(row.Cells[1].Value?.ToString());
                int MaKH = Int32.Parse(row.Cells[2].Value?.ToString());
               ngayLap =DateTime.Parse(row.Cells[3].Value.ToString());
                tenKH = uc_XuatHoaDonBL.getTenKhachHangBL(MaKH);
               soDienThoai = uc_XuatHoaDonBL.getSoDienThoaiBL(MaKH);
                diaChiGiaoHang = uc_XuatHoaDonBL.getDiaChiGiaoHangBL(MaDHcaught);
                Console.WriteLine(tenKH);
                Console.WriteLine(soDienThoai);
                  Console.WriteLine(ngayLap);
                Console.WriteLine(diaChiGiaoHang);

                List<ChiTietDonHang> chiTietDonHangs = uc_XuatHoaDonBL.GetChiTietDonHangDL(MaDHcaught);
                foreach (ChiTietDonHang chiTietDonHang in chiTietDonHangs)
                {
                    dataGridView2.Rows.Add(chiTietDonHang.MaCTDH, chiTietDonHang.MaDH, chiTietDonHang.MaVL, chiTietDonHang.TenVL, chiTietDonHang.GiaBan, chiTietDonHang.Soluong, chiTietDonHang.ThanhTien);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Word files|*.docx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string templatePath = "..\\..\\..\\hoaDonBanLe.docx"; // File mẫu //Đường dẫn tương đối
                    Console.WriteLine(templatePath);
                    string outputPath = sfd.FileName;

                    var doc = DocX.Load(templatePath);
                    var placeholderParagraph = doc.Paragraphs.FirstOrDefault(p => p.Text.Contains("{{TablePlaceholder}}"));

                    // 1. Replace text placeholders
                    //doc.ReplaceText("{MaHD}", );
                    doc.ReplaceText("{TenKH}", tenKH);
                    doc.ReplaceText("{SoDienThoai}", soDienThoai);
                    doc.ReplaceText("{DiaChi}", diaChiGiaoHang);
                    //     doc.ReplaceText("{NgayLap}", ngayDatHang);

                    //   doc.ReplaceText("{TongTien}", lblTongTien.Text);

                    // 2. Tạo bảng từ dữ liệu DataGridView
                    int rowCount = dataGridView2.Rows.Count;
                    int colCount = 5; // STT + 4 cột dữ liệu bạn muốn

                    var table = doc.AddTable(rowCount + 1, colCount);
                    table.Alignment = Alignment.center;
                    // Header
                    table.Rows[0].Cells[0].Paragraphs[0].Append("STT");
                    table.Rows[0].Cells[1].Paragraphs[0].Append("Tên vật liệu");
                    table.Rows[0].Cells[2].Paragraphs[0].Append("Số lượng");
                    table.Rows[0].Cells[3].Paragraphs[0].Append("Đơn giá");
                    table.Rows[0].Cells[4].Paragraphs[0].Append("Thành tiền");

                    int thanhTien=0;
                    for (int i = 0; i < rowCount; i++)
                    {
                        var row = dataGridView2.Rows[i];
                        if (!row.IsNewRow)
                        {
                            table.Rows[i + 1].Cells[0].Paragraphs[0].Append((i + 1).ToString()); // STT
                            table.Rows[i + 1].Cells[1].Paragraphs[0].Append(row.Cells["TenVL"].Value?.ToString());
                            table.Rows[i + 1].Cells[2].Paragraphs[0].Append(row.Cells["SoLuong"].Value?.ToString());
                            table.Rows[i + 1].Cells[3].Paragraphs[0].Append(row.Cells["GiaBan"].Value?.ToString());
                            table.Rows[i + 1].Cells[4].Paragraphs[0].Append(row.Cells["ThanhTien1"].Value?.ToString());
                            thanhTien += Int32.Parse(row.Cells["ThanhTien1"].Value?.ToString());
                        }
                    }
                    table.Rows[rowCount].Cells[3].Paragraphs[0].Append("Tổng cộng: ");
                    table.Rows[rowCount].Cells[4].Paragraphs[0].Append(thanhTien.ToString());
                    doc.InsertParagraph("Chi tiết đơn hàng:").FontSize(12).Bold();
                    doc.InsertTable(table);
                    doc.InsertParagraph("\n\t\t\t\t\t\t\tNgày " + ngayLap.Day + " tháng "+ ngayLap.Month+" năm "+ ngayLap.Year).FontSize(12);
                    doc.InsertParagraph("\n KHÁCH HÀNG\t\t\t\t\t\t\tNGƯỜI BÁN HÀNG").FontSize(12).Bold();
                    doc.SaveAs(outputPath);
                    dataGridView2.Rows.Clear();
                    MessageBox.Show("Xuất hóa đơn thành công!");

                }
            }
        }
    }
}



