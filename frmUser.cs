using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace ShopMangemnet
{
    public partial class frmUser : Form
    {
        string gend;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=ShopManagment;Integrated Security=True;Encrypt=False");
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) 
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if ( string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rdbtnMale.Checked)
            {
                gend = "Male"; 
            }
            if (rdbtnFemale.Checked)
            {
                gend = "Female";
            }
            clsUser objUser = new clsUser(cmbbxType.Text, txtName.Text, txtEmail.Text, gend, cmbbxState.Text, txtPassword.Text);
            objUser.SaveRegister();
            MessageBox.Show("Registered Successfully");
        }
      
        private void frmUser_Load(object sender, EventArgs e)
        {
            cmbbxType.Items.Add("Admin");
            cmbbxType.Items.Add("Customer");

            cmbbxState.Items.Add("Maharshtra");
            cmbbxState.Items.Add("Goa");
            cmbbxState.Items.Add("Gujrat");
            cmbbxState.Items.Add("Punjab");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxType.SelectedItem = null;
            txtName.Clear();
            txtEmail.Clear();
            rdbtnMale.Checked = false;
            rdbtnFemale.Checked = false;
            cmbbxState.Items.Clear();
            txtPassword.Clear();

        }

        private void cmbbxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}