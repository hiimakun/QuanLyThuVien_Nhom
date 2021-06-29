using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachHang.DTO
{
    public class Account
    {
        public Account(string username, string hoten, string phanquyen)
        {
            Username = username;
            Hoten = hoten;
            Phanquyen = phanquyen;
        }

        public Account(DataRow row)
        {
            Username = row["username"].ToString();
            Hoten = row["hoten"].ToString();
            Phanquyen = row["phanquyen"].ToString();
        }

        private string username;
        private string hoten;
        private string phanquyen;

        public string Username { get => username; set => username = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Phanquyen { get => phanquyen; set => phanquyen = value; }
    }
}
