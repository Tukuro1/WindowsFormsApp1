using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.DataAdapters;
using System.IO;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class frmOrder : Form
    {
        private ImageList imgListCategory;
        public frmOrder()
        {
            InitializeComponent();
            Global.Staff = OrderDataAdapter.GetAllStaff();
            Global.Categories = OrderDataAdapter.GetAllCategories();
            Global.Dish = OrderDataAdapter.GetAllDish();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString(": dd/MM/yyyy");
            cmbStaff.DataSource = Global.Staff;
            cmbStaff.DisplayMember = "StaffName";
            cmbStaff.ValueMember = "StaffNo";

            imgListCategory = new ImageList();
            imgListCategory.ImageSize = new Size(64, 64);

            foreach (var filePath in Directory.GetFiles("./Images/Category/"))
            {
                imgListCategory.Images.Add(Path.GetFileName(filePath), Image.FromFile(filePath));
            }

            lvCategory.LargeImageList = imgListCategory;
            lvCategory.SmallImageList = imgListCategory;

            foreach (var category in Global.Categories)
            {
                var item = lvCategory.Items.Add(category.CategoryName, category.Image);
                item.Tag = category;
            }

            var imageColumn = new DataGridViewImageColumn();
            dgvDetail.Columns.Add(imageColumn);
            dgvDetail.Columns.Add("Dish", "Món Ăn");
            dgvDetail.Columns.Add("Price", "Đơn Giá");
            dgvDetail.Columns.Add("Quantity", "Số lượng");
            dgvDetail.Columns.Add("DishNo", "DishNo");


        }
        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedIndices.Count == 0 || lvCategory.SelectedIndices[0] < 0)
                return;
            var selectedCategory = (Category)lvCategory.Items[lvCategory.SelectedIndices[0]].Tag;
            dgvDetail.Rows.Clear();
            foreach (var dish in Global.Dish.Where(x => x.CategoryNo == selectedCategory.CategoryNo))
            {
                int rowIndex = dgvDetail.Rows.Add();
                var img = Image.FromFile("./Images/Dish/" + dish.Image);
                img = new Bitmap(img, new Size(60, 60));
                dgvDetail.Rows[rowIndex].Cells[0].Value = img;
                dgvDetail.Rows[rowIndex].Cells[1].Value = dish.DishName;
                dgvDetail.Rows[rowIndex].Cells[2].Value = dish.Price;
                dgvDetail.Rows[rowIndex].Cells[3].Value = 0;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }
    }   
}
