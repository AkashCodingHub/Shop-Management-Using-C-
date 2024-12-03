using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShopMangemnet
{
    public partial class frmDisplay : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=ShopManagment;Integrated Security=True;Encrypt=False");
        private object obj;
        private ListViewItem selectedItem;
        //private object lblUserId;
        //private object lblUserId11;

        public int UserId { get; private set; }
        public object SizeId { get; private set; }
        public int UserIdnew { get;  set; }
        public string Email { get; set; }

        public frmDisplay(string UserName,string UserEmail,int UserId)
        {
            InitializeComponent();
             Name = UserName;
             Email = UserEmail;
             UserIdnew = UserId;
        }


        private void frmDisplay_Load(object sender, EventArgs e)
        {
            clsUser objOrder = new clsUser();
            clsProduct objDisplay = new clsProduct();
            DataTable dt1 = objDisplay.ShowType();
            cmbbxType.DisplayMember = "Type";
            cmbbxType.ValueMember = "Id";
            cmbbxType.DataSource = dt1;

            lblName1.Text = Name;
            lblUser.Text= UserIdnew.ToString();
            lblEmail2.Text = Email;


            listView1.View = View.Details; 
            listView1.Columns.Add("Type");
            listView1.Columns.Add("Product");
            listView1.Columns.Add("Size");
            listView1.Columns.Add("Price");
            listView1.Columns.Add("SizeId");
            listView1.Columns.Add("UserId");

        }

  
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxType.SelectedItem = null;
            cmbbxProduct.SelectedItem = null;
            txtPrice.Clear();
        }

        private void cmbbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tem1 = Convert.ToInt32(cmbbxType.SelectedValue.ToString());
            clsProduct objDisplay = new clsProduct();
            DataTable dt = new DataTable();
            dt = objDisplay.ShowDisplay(tem1);
            cmbbxProduct.DisplayMember = "Product";
            cmbbxProduct.ValueMember = "ProductId";
            cmbbxProduct.DataSource = dt;
        }

        private void cmbbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int aa = Convert.ToInt32(cmbbxProduct.SelectedValue.ToString());
            clsProduct obj = new clsProduct();
            DataTable dt = new DataTable();
            dt = obj.GridDataDisplay(aa);
             grdData.DataSource = dt;
            grdData.Show();
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = grdData.Rows[e.RowIndex].Cells[e.ColumnIndex];

            string tem = cell.Value.ToString();

            clsProduct objUser = new clsProduct();

            SqlDataReader dr;

            dr = objUser.GridPriceDisplay(tem);

            txtPrice.Text = Convert.ToString(objUser.RealPrice);
        }

        private void DoWork(int rowIndex)
        {

        }


        private void btnCart_Click(object sender, EventArgs e)
        {
            String Size = Convert.ToString(grdData.Rows[grdData.CurrentRow.Index].Cells[0].Value);
            String SizeId = Convert.ToString(grdData.Rows[grdData.CurrentRow.Index].Cells[1].Value);
            ListViewItem newitem = new ListViewItem(cmbbxType.Text);
            newitem.SubItems.Add(cmbbxProduct.Text);
            newitem.SubItems.Add(Size);
            newitem.SubItems.Add(txtPrice.Text);
            newitem.SubItems.Add(SizeId);
            newitem.SubItems.Add(lblUser.Text);
            listView1.Items.Add(newitem);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
            }
            decimal total = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                decimal price;
                if (decimal.TryParse(item.SubItems[3].Text, out price))
                    total += price;
            }
            txtTotal.Text = total.ToString();
        }


        private void btnTotal_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                decimal price;
                if (decimal.TryParse(item.SubItems[3].Text, out price))
                {
                    total += price;
                }
                txtTotal.Text = total.ToString();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                int SizeId;
                int UserId;
                if (int.TryParse(item.SubItems[4].Text, out SizeId))
                    SizeId = SizeId;
                if (int.TryParse(item.SubItems[5].Text, out UserId))
                 //  clsProduct obj = new clsProduct();
                   UserId = UserId;
                clsProduct obj = new clsProduct();
                obj.AddOrder(UserId, SizeId);
            }
            

            List<clsProduct> productList = new List<clsProduct>(); 
            foreach (ListViewItem item in listView1.Items)
            {
                string Type = item.SubItems[0].Text;
                string Product = item.SubItems[1].Text;
                string Price = item.SubItems[2].Text;
                string Size = item.SubItems[3].Text;
                string UserId = UserIdnew.ToString();  
                clsProduct objprod = new clsProduct(Type, Product, Price, Size,UserId);
                productList.Add(objprod);
                
            }
            MessageBox.Show("Order Successfully");
        }
    }
}
   



