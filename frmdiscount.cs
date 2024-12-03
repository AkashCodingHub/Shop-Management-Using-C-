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
    public partial class frmdiscount : Form
    {
        private object numericUpDown2;
        private int orderId;

        public string UserName { get; private set; }
        public string Product { get; private set; }
        public string Price { get; private set; }
   

        public frmdiscount()
        {
            InitializeComponent();
        }
        public frmdiscount(string UserName, string UserProduct, string UserPrice, int OrderId)
        {
            InitializeComponent();
            Name = UserName;
            Product = UserProduct;
            Price = UserPrice;
            orderId = OrderId;
        

        }

        private void frmdiscount_Load(object sender, EventArgs e)
       {
            lblUserName.Text = Name;
            lblProduct.Text = Product;
            lblProductPrice.Text = Price;

        }
       
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "") { }
            else { int DISCOUNT = Convert.ToInt32(txtDiscount.Text);

                int PRICE = Convert.ToInt32(Price);
                int ShowDiscount = (PRICE * DISCOUNT / 100);

                int ShowFinalDiscount = PRICE - ShowDiscount;
                txtPrice.Text = ShowFinalDiscount.ToString();
                
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            clsProduct obj = new clsProduct();
            int DISCOUNT = Convert.ToInt32(txtDiscount.Text);

            obj.UpdateDiscount(DISCOUNT, orderId);
            MessageBox.Show("Updated Successfully");
        }
    }  
    }

