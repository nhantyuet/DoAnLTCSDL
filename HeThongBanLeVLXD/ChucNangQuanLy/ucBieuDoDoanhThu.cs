using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanLeVLXD.ChucNangQuanLy
{
    public partial class ucBieuDoDoanhThu : UserControl
    {
        private ucBieuDoDoanhThuBL uc_BieuDoDoanhThuBL;
        public ucBieuDoDoanhThu()
        {
            InitializeComponent();
            uc_BieuDoDoanhThuBL = new ucBieuDoDoanhThuBL();
        }

        private void ucBieuDoDoanhThu_Load(object sender, EventArgs e)
        {
            Console.WriteLine("alola: " + uc_BieuDoDoanhThuBL.TinhGiaNhapTrungBinhBL(1));
        }
    }
}
