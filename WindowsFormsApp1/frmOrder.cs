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
using WindowsFormsApp1.Business;

namespace WindowsFormsApp1
{
    public partial class frmOrder : Form
    {
        private ImageList imgListCategory;
        private Table currentTable;
        public frmOrder()
        {
            InitializeComponent();
            OrderBU.LoadMasterData();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            txtNgay.Text = DateTime.Now.ToString(": dd/MM/yyyy");
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

            dgvDetail.Columns[0].ReadOnly = true;
            dgvDetail.Columns[1].ReadOnly = true;
            dgvDetail.Columns[2].ReadOnly = true;

            btnThemMoi.Enabled = false;
            btnChot.Enabled = false;
            btnThanhToan.Enabled = false;
            btnSua.Enabled = false;
        }
        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedIndices.Count == 0 || lvCategory.SelectedIndices[0] < 0)
                return;
            var selectedCategory = (Category)lvCategory.Items[lvCategory.SelectedIndices[0]].Tag;
            SavePendingOrderItems();
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].Tag = null;
            }
            dgvDetail.Rows.Clear();
            foreach (var dish in Global.Dishes.Where(x => x.CategoryNo == selectedCategory.CategoryNo))
            {
                int rowIndex = dgvDetail.Rows.Add();
                var orderItem = currentTable.OrderItems.Where(x => x.DishNo == dish.DishNo).FirstOrDefault();
                if (orderItem == null)
                {
                    orderItem = new OrderItem();
                    orderItem.DishNo = dish.DishNo;
                    orderItem.Quantity = 0;
                    currentTable.OrderItems.Add(orderItem);
                }
                int? quantity = orderItem.Quantity;
                var img = Image.FromFile("./Images/Dish/" + dish.Image);
                img = new Bitmap(img, new Size(60, 60));
                dgvDetail.Rows[rowIndex].Cells[0].Value = img;
                dgvDetail.Rows[rowIndex].Cells[1].Value = dish.DishName;
                dgvDetail.Rows[rowIndex].Cells[2].Value = dish.Price;
                dgvDetail.Rows[rowIndex].Cells[3].Value = quantity;
                dgvDetail.Rows[rowIndex].Tag = orderItem;
            }
        }

        private void SavePendingOrderItems()
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                OrderItem orderItem = null;
                if (dgvDetail.Rows[i].Tag != null)
                {
                    orderItem = (OrderItem)dgvDetail.Rows[i].Tag;
                    orderItem.Quantity = Convert.ToInt32(dgvDetail.Rows[i].Cells[3].Value);
                }
            }
        }

        private void cmbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavePendingOrderItems();
            if (cmbBan.SelectedIndex >= 0)
            {
                currentTable = Global.Tables[cmbBan.SelectedIndex];
                txtTrangThai.Text = currentTable.Status.GetDisplayName();
                SetTableStatus(currentTable.Status);
                lvCategory.Items.Clear();
                if (currentTable.Status != TableStatus.Empty)
                {
                    foreach (var category in Global.Categories)
                    {
                        var item = lvCategory.Items.Add(category.CategoryName, category.Image);
                        item.Tag = category;
                    }
                }
            }
        }

        private void btnChot_Click(object sender, EventArgs e)
        {
            SavePendingOrderItems();
            currentTable.Status = TableStatus.Confirm;
            SetTableStatus(currentTable.Status);
            var total = OrderBU.CalculateTotal(currentTable);
            txtTotal.Text = string.Format("{0:n}", total); ;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            currentTable.Status = TableStatus.New;
            currentTable.Order = new Order();
            currentTable.OrderItems = new List<OrderItem>();
            cmbBan_SelectedIndexChanged(cmbBan, null);
            SetTableStatus(currentTable.Status);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            currentTable.Status = TableStatus.Edit;
            SetTableStatus(currentTable.Status);
        }

        private void SetTableStatus(TableStatus status)
        {
            txtTrangThai.Text = status.GetDisplayName();
            switch (status)
            {
                case TableStatus.Empty:
                    btnThemMoi.Enabled = true;
                    btnChot.Enabled = false;
                    btnThanhToan.Enabled = false;
                    btnSua.Enabled = false;
                    break;
                case TableStatus.New:
                    btnThemMoi.Enabled = false;
                    btnChot.Enabled = true;
                    btnThanhToan.Enabled = false;
                    btnSua.Enabled = false;
                    dgvDetail.Columns[3].ReadOnly = false;
                    txtTotal.Text = "";
                    dgvDetail.Rows.Clear();
                    break;
                case TableStatus.Confirm:
                    btnThemMoi.Enabled = false;
                    btnChot.Enabled = false;
                    btnThanhToan.Enabled = true;
                    btnSua.Enabled = true;
                    dgvDetail.Columns[3].ReadOnly = true;
                    break;
                case TableStatus.Edit:
                    btnThemMoi.Enabled = false;
                    btnChot.Enabled = true;
                    btnThanhToan.Enabled = false;
                    btnSua.Enabled = false;
                    dgvDetail.Columns[3].ReadOnly = false;
                    break;
                case TableStatus.Paid:
                    btnThemMoi.Enabled = true;
                    btnChot.Enabled = false;
                    btnThanhToan.Enabled = false;
                    btnSua.Enabled = false;
                    dgvDetail.Columns[3].ReadOnly = true;
                    break;
                default:
                    return;
            }
        }

        private void dgvDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            currentTable.Status = TableStatus.Paid;
            SetTableStatus(currentTable.Status);
            currentTable.Order.OrderDate = DateTime.Now;
            currentTable.Order.StaffNo = (int)cmbStaff.SelectedValue;
            currentTable.Order.TableNo = byte.Parse((string)cmbBan.Items[cmbBan.SelectedIndex]);
            OrderBU.Paid(currentTable);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }
    }   
}
