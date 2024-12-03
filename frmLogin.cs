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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShopMangemnet
{
    public partial class frmLogin : Form
    {
        public string txtName;
        private object a;
        private object b;

        public object Customer { get; private set; }
        public object Admin { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbbxType.Items.Add("Admin");
            cmbbxType.Items.Add("Customer");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxType.SelectedItem = null;
            txtEmail.Clear();
            txtPassword.Clear();
        }

   
        private void btnlogin_Click(object sender, EventArgs e)
        {
          
            clsUser log = new clsUser(cmbbxType.Text, txtEmail.Text, txtPassword.Text);
            SqlDataReader dr = log.LoginData();
          
            if (dr.HasRows) 
            {
                while (dr.Read())
                {
                    String UserName = dr["UserName"].ToString();
                    if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    String UserEmail = dr["UserEmail"].ToString();
                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int UserId = Convert.ToInt32(dr["UserId"].ToString());
                    string a = dr["UserType"].ToString();
            
                    MessageBox.Show("login Successfully");

                    if (a == "Customer")
                    {
                        //this.hide();
                        frmDisplay objDisplay = new frmDisplay(UserName,UserEmail,UserId);
                        objDisplay.Show();
                    }
                   else if (a =="Admin")
                    {
                        this.hide();
                        frmAdmin objAdmin = new frmAdmin();
                        objAdmin.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("login is not valid ");
            }
            }

        private void hide()
        {
          
        }

       
    }
    }
    





        
    

  
       
   

