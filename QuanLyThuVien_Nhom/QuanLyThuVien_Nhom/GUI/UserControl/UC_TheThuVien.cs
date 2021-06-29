using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien_TTN.DAO;
using QuanLyThuVien_TTN.DTO;

namespace QuanLyThuVien_TTN
{
    public partial class UC_TheThuVien : UserControl
    {
        BindingSource theList = new BindingSource();
        public UC_TheThuVien()
        {
            InitializeComponent();
        }
        void LoadListTheThuVien()
        {
            dataGridView1.DataSource = DocGiaDAO.Instance.GetListDocGia();
        }
        void Load()

        {
            dataGridView1.DataSource = theList;
            LoadListTheThuVien();
            AddTheThuVienBinding();
        }
        void AddTheThuVienBinding()
        {
            textBoxMaThe.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MATHE", true, DataSourceUpdateMode.Never));
            dateNgayBatDau.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "NGAYBATDAU", true, DataSourceUpdateMode.Never));
            dateNgayHetHan.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "NGAYHETHAN", true, DataSourceUpdateMode.Never));
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            string mathe = textBoxMaThe.Text;
            string ngaybatdau = dateNgayBatDau.Text;
            string ngayhethan = dateNgayHetHan.Text;
            try
            {
                if (TheThuVienDAO.Instance.InsertTheThuVien(mathe, ngaybatdau, ngayhethan))
                {
                    MessageBox.Show("Thêm thành công!");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm sinh viên!");
                }
            }
            catch
            {
                MessageBox.Show("Sai hoặc trùng thông tin khi thêm!");
            }
            LoadListTheThuVien();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            string mathe = textBoxMaThe.Text;
            string ngaybatdau = dateNgayBatDau.Text;
            string ngayhethan = dateNgayHetHan.Text;
            try
            {
                if (TheThuVienDAO.Instance.UpdateTheThuVien(mathe, ngaybatdau, ngayhethan))
                {
                    MessageBox.Show("Sửa thành công!");

                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa thẻ!");
                }
            }
            catch
            {
                MessageBox.Show("Sai hoặc trùng thông tin khi sửa!");
            }
            LoadListTheThuVien();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có thực sự muốn xoá ?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string mathe = textBoxMaThe.Text;
                    if (TheThuVienDAO.Instance.DeleteTheThuVien(mathe))
                    {
                        MessageBox.Show("Xóa thành công!");

                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi Xóa!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sai hoặc trùng thông tin khi Xóa!");
            }
            LoadListTheThuVien();
        }

        private void iconButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadListTheThuVien();
            textBoxMaThe.Clear();
        }
        List<TheThuVien> SearchTheByMaThe(string mathe)
        {
            List<TheThuVien> theList = TheThuVienDAO.Instance.SearchTheByMaThe(mathe);
            return theList;
        }
        List<TheThuVien> SearchTheByNgayBatDau(string ngaybatdau)
        {
            List<TheThuVien> theList = TheThuVienDAO.Instance.SearchTheByNgayBatDau(ngaybatdau);
            return theList;
        }
        List<TheThuVien> SearchTheByNgayHetHan(string ngayhethan)
        {
            List<TheThuVien> theList = TheThuVienDAO.Instance.SearchTheByNgayBatDau(ngayhethan);
            return theList;
        }

        private void iconButtonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxTimKiem.Text == "Mã thẻ")
            {
                if (textBoxTuKhoaTimKiem.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tù khóa tìm kiếm");
                }
                else
                {
                    theList.DataSource = SearchTheByMaThe(textBoxTuKhoaTimKiem.Text);
                }
            }
            if (comboBoxTimKiem.Text == "Ngày bắt đầu")
            {
                if (textBoxTuKhoaTimKiem.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tù khóa tìm kiếm");
                }
                else
                {
                    theList.DataSource = SearchTheByNgayBatDau(textBoxTuKhoaTimKiem.Text);
                }
            }
            if (comboBoxTimKiem.Text == "Ngày hết hạn")
            {
                if (textBoxTuKhoaTimKiem.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tù khóa tìm kiếm");
                }
                else
                {
                    theList.DataSource = SearchTheByNgayHetHan(textBoxTuKhoaTimKiem.Text);
                }
            }
        }
    }
}
