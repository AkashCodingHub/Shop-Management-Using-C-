using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;

namespace ShopMangemnet
{
    internal class clsUser
    {
        string gend;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=ShopManagment;Integrated Security=True;Encrypt=False");
        private string text1;
        private string text2;
        private string text3;
        private object text;


        public int UserId { get; set; } 

        public string UserType {  get; set; }  

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserGender { get; set; }

        public string UserState { get; set; }

        public string UserPassword { get; set; }
        public string UserId1 { get; internal set; }

        public clsUser(string type,string name, string Email, string gend, string State, string Password)
        {
          //  UserId = id;    
            UserType = type;    
            UserName = name;
            UserEmail = Email;
            UserGender = gend;
            UserState = State;
            UserPassword = Password;
        }

        public clsUser(string text1, object text, string text3)
        {
            this.text1 = text1;
            this.text = text;
            this.text3 = text3;
        }

        public clsUser(string type,  string Email, string Password)
        {
            UserType = type;
           
            UserEmail = Email;
            UserPassword = Password;
        }


        public clsUser(string username,string useremail, int userid )
        {
            UserName = username;    
            UserName = useremail;
            UserId = userid;
        }

        public clsUser(string name,string email)
        {
            UserName = name;

            UserEmail = email;

        }

        public clsUser(int  id)
        {
            UserId = id;
        }


            public clsUser()
        {
        }

        //public clsUser(string text1, string text2, string text3)
        //{
        //    this.text1 = text1;
        //    this.text2 = text2;
        //    this.text3 = text3;
        //}

        public void SaveRegister()
        {
         
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveRegister");
            cmd.Parameters.AddWithValue("@UserType", UserType);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@UserEmail", UserEmail);
            cmd.Parameters.AddWithValue("@UserGender", UserGender);
            cmd.Parameters.AddWithValue("@UserState", UserState);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
            cmd.ExecuteNonQuery(); 
            con.Close();
        }

        public void ShowName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowName");
            
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserName = dr["UserName"].ToString();
                UserEmail = dr["UserEmail"].ToString();
                UserId = Convert.ToInt32(dr["UserId"].ToString());
            }
            con.Close();
        }

        public SqlDataReader LoginData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "LoginData");
            cmd.Parameters.AddWithValue("@UserType",UserType);
            cmd.Parameters.AddWithValue("@UserEmail", UserEmail);
            cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();  
            return dr;
            con.Close();
        }


    }
} 