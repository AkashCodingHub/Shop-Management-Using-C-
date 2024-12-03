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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void allProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllProducts objAdmin = new frmAllProducts();
            objAdmin.Show();
            objAdmin.MdiParent = this;
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllOrder objAllOrder = new frmAllOrder();
            objAllOrder.Show();
            objAllOrder.MdiParent = this;
        }

        //private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmDiscount objDiscount = new frmDiscount();
        //    objDiscount.Show();
        //    objDiscount.MdiParent = this;

        //}

        private void unorderedProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnorderedProduct objAdmin = new frmUnorderedProduct();
            objAdmin.Show();
            objAdmin.MdiParent = this;
        }

        private void unorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnorderedUser objAdmin = new frmUnorderedUser();
            objAdmin.Show();
            objAdmin.MdiParent = this;
        }
    }
}
    
