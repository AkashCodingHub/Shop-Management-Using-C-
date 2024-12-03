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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser objUser = new frmUser();
            objUser.Show();
            objUser.MdiParent = this;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin objLogin = new frmLogin();
            objLogin.Show();
            objLogin.MdiParent = this;
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct objProduct = new frmProduct();
            objProduct.Show();
            objProduct.MdiParent = this;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmType objType = new frmType();       
             objType.Show();
             objType.MdiParent = this;
        }

        private void addSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frmSize objSize = new frmSize();    
                objSize.Show();
                objSize.MdiParent = this;
        }
    }
}
