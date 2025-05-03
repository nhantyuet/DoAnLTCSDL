using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class FrmNhanVienBL
    {
        private FrmNhanVienDL frmNhanVienDL;
        public FrmNhanVienBL()
        {
            frmNhanVienDL = new FrmNhanVienDL();    
        } 
        public string tenNhanVienBL(string maNV)
        {
            try
            {
                if (frmNhanVienDL.tenNhanVienDL(maNV) != null && frmNhanVienDL.tenNhanVienDL(maNV) != "")
                    return frmNhanVienDL.tenNhanVienDL(maNV);
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
