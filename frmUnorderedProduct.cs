using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopMangemnet
{
    public partial class frmUnorderedProduct : Form
    {
        public frmUnorderedProduct()
        {
            InitializeComponent();
        }

        private void frmUnorderedProduct_Load(object sender, EventArgs e)
        {
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.UnorderedProduct();
            dataGridView.DataSource = dt;
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Product like '%{0}'",txtProductName.Text);
        }

        private void txtProductType_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Type like '%{0}'", txtProductType.Text);
        }
    }
}
