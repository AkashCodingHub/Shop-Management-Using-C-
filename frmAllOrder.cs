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
    public partial class frmAllOrder : Form
    {
        private string userName;
        private string userProduct;
        private string userPrice;

        public string UserName { get; private set; }
        public string UserProduct { get; private set; }
        public string UserPrice { get; private set; }
        public int OrderId { get; private set; }

        public frmAllOrder()
        {
            InitializeComponent();
        }

        private void frmAllOrder_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "Action";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            dataGridView.Columns.Add(checkColumn);

        

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            
                btn.HeaderText = "Dis";
                btn.Name = "Discount";
                btn.Text = "Offer";
                btn.UseColumnTextForButtonValue = true;
                this.dataGridView.Columns.Add(btn);
               // this.dataGridView.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            

            clsProduct objProd = new clsProduct();

            DataTable dt = new DataTable();
            dt = objProd.GridOrderProducts();
            dataGridView.DataSource = dt;
            dataGridView.Show();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewColumn)
                {
                    string username = dataGridView.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                    string userproduct = dataGridView.Rows[e.RowIndex].Cells["Product"].Value.ToString();
                    string userprice = dataGridView.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                    int orderId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["OrderId"].Value.ToString());

                    frmdiscount frm1 = new frmdiscount(username, userproduct, userprice, orderId);
                    frm1.Show();
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("UserName like '%{0}'", txtName.Text);
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Product like '%{0}'", txtProduct.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtProduct.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView.RowCount - 1; i >= 0; i--)
            {
                if ((bool)dataGridView.Rows[i].Cells[0].FormattedValue)
                {
                    int OrderId= Convert.ToInt32(dataGridView.Rows[i].Cells[2].Value.ToString());
                    dataGridView.Rows.RemoveAt(i);


                    clsProduct objProd = new clsProduct();
                    objProd.IsDelete(OrderId);
                }
            }
        }
    }
}
