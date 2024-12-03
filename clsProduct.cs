using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangemnet
{
    internal class clsProduct
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=ShopManagment;Integrated Security=True;Encrypt=False");
     

        public int UserId { get; set; }

        public int OrderId { get; set; }

        public int Discount { get; set; }

        public DateTime PurchaseDate {  get; set; }

        public string OrderStatus { get; set; }

        public int SizeId { get; set; }

        public int ProductId { get; set; }

        public string Size { get; set; }

        public int Price { get; set; }

        public int RealPrice { get; set; }

        public int Id { get; set; }

        public string Type { get; set; }

        public int PId { get; set; }

        public int TypeId {  get; set; }

        public string Product { get; set; }

        public int Typeid { get; }


        public clsProduct(int productid, int price, string size, int realprice)
        {
            ProductId = productid;
            Size = size;
            Price = price;
            RealPrice = realprice;
        }

        public clsProduct(string type,string product,int price,string size)
        {
            Type = type;
            Product = product;
            Price = price;
            Size = size;
        }

        //public clsProduct(int userId, int sizeId, DateTime purchaseDate, string orderstatus)
        //{
        //    UserId = userId;
        //    SizeId = sizeId;
        //    PurchaseDate = purchaseDate;
        //    OrderStatus = orderstatus;
        //}

        public clsProduct(int productid, int price, string size)
        {
            ProductId = productid;
            Size = size;
            Price = price;
        }

        public clsProduct(int TypeId, int sizeId)
        {
            TypeId = Typeid;

        }


        public clsProduct(int Typeid ,string product)
        {
            TypeId = Typeid;
            Product = product;
        }

       
        public clsProduct(string text, string b, string c, string size, string userId)
        {
            Type = text;
        }

        public clsProduct(string type)
        {
            Type = type;
        }


        public clsProduct(int orderId)
        {
        }

        public clsProduct()
        {
        }

        public void ProductRegister()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ProductRegister");
            cmd.Parameters.AddWithValue("@SizeId", SizeId);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@RealPrice", RealPrice);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DisplayOrder()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayOrder");
            cmd.Parameters.AddWithValue("@SizeId", SizeId);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void SaveData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveData");
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ProductData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ProductData");
            cmd.Parameters.AddWithValue("@TypeId", TypeId);
            cmd.Parameters.AddWithValue("@Product", Product);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ShowType()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowType");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable GridDataDisplay(int tt)
        {
            ProductId = tt;
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GridDataDisplay");
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public SqlDataReader GridPriceDisplay(string aa)
        {
            Size = aa;
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GridPriceDisplay");
            cmd.Parameters.AddWithValue("@Size", Size);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                RealPrice = Convert.ToInt32(dr["Price"].ToString());
            }
            return dr;
            con.Close();
        }


        public DataTable ShowProduct(int tem)
        {
            TypeId = tem;
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowProduct");
            cmd.Parameters.AddWithValue("@TypeId",TypeId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable ShowDisplay(int tem1)
        {
            TypeId = tem1;
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowDisplay");
            cmd.Parameters.AddWithValue("@TypeId", TypeId);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable GridProducts()
        {
            con.Open(); 
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag","GridProducts"); 
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable GridOrderProducts()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag","GridOrderProducts");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable UnorderedProduct()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UnorderedProduct");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }

        public DataTable UnorderedUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UnorderedUser");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
            con.Close();
        }


        public void AddOrder(int userId, int sizeId)
        {
            UserId = userId;
            SizeId = sizeId;
            DateTime PurchaseDate = DateTime.Now;
            string OrderStatus = "Confirmed";
                con.Open();
                SqlCommand cmd = new SqlCommand("ShopManagment", con); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "AddOrder");
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@SizeId", SizeId);
                cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                cmd.ExecuteNonQuery();
            con.Close();
            }


        public void UpdateDiscount(int discount,int orderId)
        {
            Discount = discount;
            OrderId = orderId;
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateDiscount");
            cmd.Parameters.AddWithValue("@Discount", Discount);
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void IsDelete(int OrderId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("ShopManagment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "IsDelete");  
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        internal SqlDataReader AllProducts(string tem)
        {
            //throw new NotImplementedException();
        }
    }
    }



