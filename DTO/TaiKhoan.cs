using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO

{
    public class TaiKhoan
    {
        public int MaNV {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public TaiKhoan(int maNV, string username, string password, string role) 
        {
            this.MaNV = maNV;
            this.Username = username;  
            this.Password = password;
            this.Role = role;
        }
        public TaiKhoan(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

    }
}
