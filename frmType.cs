using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopMangemnet
{
    public partial class frmType : Form
    {
        public frmType()
        {
            InitializeComponent();
        }

        public frmType(object text)
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsProduct objProduct = new clsProduct(txtType.Text);
            objProduct.SaveData();
            MessageBox.Show("Save Succesfully"); 
       
        }
         
        private void frmType_Load(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
