using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                //luôn luôn sử dụng context để làm việc với các class
                ContextDB context = new ContextDB();
                //lấy tất cả dữ từ bảng
                List<Staff> listStaff = context.Staff.ToList();
                List<Category> listCategory = context.Category.ToList();
                List<Category> listDish = context.Dish.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private class ContextDB
        {
            public object Staff { get; internal set; }
            public object Category { get; internal set; }
            public object Dish { get; internal set; }
        }
    }
}
