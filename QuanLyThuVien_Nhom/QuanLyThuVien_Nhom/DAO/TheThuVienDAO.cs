using QuanLyThuVien_TTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien_TTN.DAO
{
    class TheThuVienDAO
    {

        private static TheThuVienDAO instance; //Ctrl + R + E

        public static TheThuVienDAO Instance
        {
            get { if (instance == null) instance = new TheThuVienDAO(); return TheThuVienDAO.instance; }
            private set { TheThuVienDAO.instance = value; }
        }

        private TheThuVienDAO() { }
        public int ktNgayHetHan(string date)
        {
            return (int)DataProvider.Instance.executeScalar("SELECT DATEDIFF(DAY, '" + date + "', CONVERT(date,GETDATE()))");
        }

        public DateTime getNgayHetHan(string mathe)
        {
            return (DateTime)DataProvider.Instance.executeScalar("SELECT ngayhethan FROM thethuvien where mathe = '" + mathe + "'");
        }
        public int getQuaHan(DateTime today, DateTime ngayhh)
        {
            string to = today.ToString("yyyy-MM-dd");
            string ngay = ngayhh.ToString("yyyy-MM-dd");
            int s = (int)DataProvider.Instance.executeScalar("SELECT DATEDIFF(day, '" + ngay + "', '" + to + "')");
            if (s > 0)
                return 0;
            return s * -1;
        }

        public List<TheThuVien> GetListTheThuVien()

        {
            List<TheThuVien> list = new List<TheThuVien>();
            DataTable data = DataProvider.Instance.executeQuery("select * from THETHUVIEN");
            //List<DocGia> list = new List<DocGia>();
            //DataTable data = DataProvider.Instance.ExecuteQuery("select * from DOCGIA ");

            foreach (DataRow item in data.Rows)
            {
                TheThuVien theThuVien = new TheThuVien(item);
                list.Add(theThuVien);
            }
            return list;
        }


        public bool InsertTheThuVien(string mathe, string ngaybatdau, string ngayhethan)
        {
            string query = string.Format("insert THETHUVIEN ( MATHE, NGAYBATDAU, NGAYHETHAN) values" +
                " ( N'{0}', N'{1}',N'{2}')", mathe, ngaybatdau, ngayhethan);
            int result = DataProvider.Instance.executeNonQuery(query);
            return result > 0;
        }
        public bool UpdateTheThuVien(string mathe, string ngaybatdau, string ngayhethan)
        {
            string query = string.Format(
            "update THETHUVIEN set  NGAYBATDAU= N'{0}', NGAYHETHAN=N'{1}' where MATHE = N'{2}' ", ngaybatdau, ngayhethan, mathe);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteTheThuVien(string mathe)
        {
            string query = string.Format(" delete from THETHUVIEN where MATHE = N'{0}' ", mathe);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }
        public List<TheThuVien> SearchTheByMaThe(string mathe)
        {
            List<TheThuVien> list = new List<TheThuVien>();
            string query = string.Format("select * from THETHUVIEN where [dbo].[GetUnsignString](MATHE) " +
                "like N'%' +[dbo].[GetUnsignString](N'{0}') + '%'", mathe);
            DataTable data = DataProvider.Instance.executeQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TheThuVien theThuVien = new TheThuVien(item);
                list.Add(theThuVien);
            }
            return list;
        }
        public List<TheThuVien> SearchTheByNgayBatDau(string ngaybatdau)
        {
            List<TheThuVien> list = new List<TheThuVien>();
            string query = string.Format("select * from THETHUVIEN where [dbo].[GetUnsignString](NGAYBATDAU) like N'%'" +
                "+[dbo].[GetUnsignString](N'{0}')+'%'", ngaybatdau);
            // '%0%' or '%1%' or '%2%' or '%2%' or '%3%' or '%4%' or '%5%' or '%6%' or '%7%' or '%8%' or '%9%
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TheThuVien theThuVien = new TheThuVien(item);
                list.Add(theThuVien);
            }
            return list;
        }
        public List<TheThuVien> SearchTheByNgayHetHan(string ngayhethan)
        {
            List<TheThuVien> list = new List<TheThuVien>();
            string query = string.Format("select * from THETHUVIEN where [dbo].[GetUnsignString](NGAYHETHAN) like N'%'" +
                "+[dbo].[GetUnsignString](N'{0}')+'%'", ngayhethan);
            // '%0%' or '%1%' or '%2%' or '%2%' or '%3%' or '%4%' or '%5%' or '%6%' or '%7%' or '%8%' or '%9%
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TheThuVien theThuVien = new TheThuVien(item);
                list.Add(theThuVien);
            }
            return list;
        }

    }
}
