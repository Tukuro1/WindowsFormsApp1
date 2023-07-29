using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tentk = txtTaikhoan.Text;
            string mk = txtMatkhau.Text;
            if(tentk.Trim() == "")
            {
                MessageBox.Show("Bạn cần điền tài khoản", "Tài khoản");
            }
            else if(mk.Trim() == "")
            {
                MessageBox.Show("Bạn cần điền mật khẩu", "Mật khẩu");
            }
            else
            {
                string query = "Select * from Taikhoan where TaiKhoan = '"+tentk+"' and MatKhau = '"+mk+"'";
                if(modify.TaiKhoans(query).Count > 0)
                {
                    this.Hide();
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
