using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShopMangemnet
{
    public partial class frmAllProducts : Form
    {
        public frmAllProducts()
        {
            InitializeComponent();
        }

        private void frmAllProducts_Load(object sender, EventArgs e)
        {
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.GridProducts();
            dataGridView.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Product like '%{0}'", txtSearch.Text);
        }
    }
}
