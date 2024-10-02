using QLyHieuSach1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QlyHieuSach
{
    public partial class frmNhanVien : Form
    {
        connect ketnoi = new connect();
        public frmNhanVien()
        {
            InitializeComponent();
            duaDLVaoBang();
        }
        void duaDLVaoBang()
        {
            dataGridView1.DataSource = ketnoi.GetDSNhanVien();
        }


        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNv.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn Nhân Viên Cần Sửa Thông Tin ????");
                return;
            }

            if (!ketnoi.tonTaiNV(txtMaNv.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân Viên Không Tồn Tại =)))");
                return;
            }
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaNv.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[i];
                txtMaNv.Text = row.Cells[0].Value.ToString();
                txtHoTenNv.Text = row.Cells[1].Value.ToString();
                dtpNgaySinh.Text = row.Cells[5].Value.ToString();
                string gt = row.Cells[2].Value.ToString();
                if (gt == "Nam") rdbNam.Checked = true;
                else rdbNu.Checked = true;
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                txtDienThoai.Text = row.Cells[4].Value.ToString();
            }
        }
        bool kiemTraRong()
        {
            if (txtMaNv.Text.Trim() == "") return false;
            if (txtHoTenNv.Text.Trim() == "") return false;
            if (dtpNgaySinh.Text.Trim() == "") return false;
            if (txtDiaChi.Text.Trim() == "") return false;
            if (txtDienThoai.Text.Trim() == "") return false;
            return true;
        }

        void clearTexts()
        {
            txtMaNv.Text = "";
            txtHoTenNv.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!kiemTraRong())
            {
                MessageBox.Show("Chưa Nhập đủ thông tin????");
                return;
            }

            string ma = txtMaNv.Text.Trim();
            string ten = txtHoTenNv.Text;
            DateTime ngay = DateTime.Parse(dtpNgaySinh.Text);
            string gt;
            if (rdbNam.Checked)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }

            string dc = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            if (ketnoi.tonTaiNV(ma))
            {
                MessageBox.Show("Mã nhân viên đã tôn tại =)))");
                return;
            }

            ketnoi.themNhanVien(ma, ten, gt, dc, dt, ngay);
            duaDLVaoBang();
            clearTexts();
            txtMaNv.Focus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNv.Text.Trim() != "")
            {
                if (MessageBox.Show("Có chắc chắn dám xóa không =)))))", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ketnoi.XoaNhanVien(txtMaNv.Text.Trim());
                    duaDLVaoBang();
                    clearTexts();
                }
                else
                {
                    MessageBox.Show("Không thể xóa!!!");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!kiemTraRong())
            {
                MessageBox.Show("Chưa nhập đủ thông tin mà đòi lưu???");
                return;
            }
            string ma = txtMaNv.Text.Trim();
            string ten = txtHoTenNv.Text;
            DateTime ngay = DateTime.Parse(dtpNgaySinh.Text);
            string gt;
            if (rdbNam.Checked)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            string dc = txtDiaChi.Text;
            string dt = txtDienThoai.Text;
            ketnoi.capNhatNhanVien(ma, ten, gt, dc, dt, ngay);
            duaDLVaoBang();
            clearTexts();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaNv.Enabled = true;
            MessageBox.Show("Đã sửa thông tin nhân viên có mã " + ma + "=))))))");
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaNv.Enabled = true;
        }


    }
}