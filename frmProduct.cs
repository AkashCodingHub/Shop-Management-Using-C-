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
    public partial class frmProduct : Form
    {
     
        
        public frmProduct()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            int typeid = Convert.ToInt32(cmbbxType.SelectedValue.ToString());
            clsProduct objProduct = new clsProduct(typeid,txtProduct.Text);
            objProduct.ProductData();
            MessageBox.Show("Product Save Succesfully");
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.ShowType();
            cmbbxType.DisplayMember = "Type";
            cmbbxType.ValueMember = "Id";
            cmbbxType.DataSource = dt;
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
