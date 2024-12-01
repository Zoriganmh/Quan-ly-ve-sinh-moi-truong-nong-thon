using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KTPMUD
{
    internal class TaiKhoan
    {
        private string Username;
        private string Password;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public string username { get => username; set => username = value; }
        public string password {  get => password; set => password = value; }   
    }
}
