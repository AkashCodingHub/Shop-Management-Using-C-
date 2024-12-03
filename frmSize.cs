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
using static System.Net.Mime.MediaTypeNames;

namespace ShopMangemnet
{
    public partial class frmSize : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=ShopManagment;Integrated Security=True;Encrypt=False");
        public frmSize()
        {
            InitializeComponent();
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ProID = Convert.ToInt32(cmbbxProduct.SelectedValue.ToString());
            if (string.IsNullOrEmpty(txtSize.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int MRP = Convert.ToInt32(txtMRP.Text.ToString());
            if (string.IsNullOrEmpty(txtMRP.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int RealPrice = Convert.ToInt32(txtRealPrice.Text.ToString());
            if (string.IsNullOrEmpty(txtRealPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsProduct objUser = new clsProduct(ProID,MRP, txtSize.Text,RealPrice);
            objUser.ProductRegister();
            MessageBox.Show("Save Successfully");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxType.SelectedItem = null;
            cmbbxProduct.SelectedItem = null;
            txtSize.Clear();
            txtMRP.Clear();
            txtRealPrice.Clear();
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.ShowType();
            cmbbxType.DisplayMember = "Type";
            cmbbxType.ValueMember = "Id";
            cmbbxType.DataSource = dt;
        }

        private void cmbbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tem = Convert.ToInt32(cmbbxType.SelectedValue.ToString());
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.ShowProduct(tem);
            cmbbxProduct.DisplayMember = "Product";
            cmbbxProduct.ValueMember = "ProductId"; 
            cmbbxProduct.DataSource = dt;
        }

        private void cmbbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
    }

