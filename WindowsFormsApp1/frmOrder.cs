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
namespace WindowsFormsApp1
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Order' table. You can move, or remove it, as needed.
            this.orderTableAdapter.Fill(this.dataSet1.Order);
            // TODO: This line of code loads data into the 'dataSet1.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.dataSet1.Staff);
            lblDate.Text = DateTime.Now.ToString(": dd/MM/yyyy");
        }
        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

    }   
}
