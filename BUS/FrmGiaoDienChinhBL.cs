using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class FrmGiaoDienChinhBL
    {
        private FrmGiaoDienChinhDL frmGiaoDienChinhDL;
        public FrmGiaoDienChinhBL()
        {
            frmGiaoDienChinhDL = new FrmGiaoDienChinhDL();
        }
        public string tenNhanVienBL(string maNV)
        {
            try
            {
                if (frmGiaoDienChinhDL.tenNhanVienDL(maNV) != null && frmGiaoDienChinhDL.tenNhanVienDL(maNV) != "")
                    return frmGiaoDienChinhDL.tenNhanVienDL(maNV);
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
