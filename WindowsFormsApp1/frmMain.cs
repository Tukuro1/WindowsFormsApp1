using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataAdapters;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tsmOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOrder frmOrder = new frmOrder();
            frmOrder.ShowDialog();
        }

        private void Thoat_click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo);
            Application.Exit();
        }

        private void Logout_click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn đăng xuất không", "Thông báo", MessageBoxButtons.YesNo);
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void tsmOrderlist_click(object sender, EventArgs e)
        {
            this.Hide();
            frmOrderList frmOrderList = new frmOrderList();
            frmOrderList.ShowDialog();
        }
    }
}
