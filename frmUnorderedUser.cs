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
    public partial class frmUnorderedUser : Form
    {
        public frmUnorderedUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmUnorderedUser_Load(object sender, EventArgs e)
        {
            clsProduct objProd = new clsProduct();
            DataTable dt = new DataTable();
            dt = objProd.UnorderedUser();
            dataGridView.DataSource = dt;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("UserEmail like '%{0}'", txtEmail.Text);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("UserName like '%{0}'",txtUserName.Text);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
