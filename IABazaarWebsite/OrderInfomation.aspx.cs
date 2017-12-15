using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IABazaar.Core;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Configuration;

public partial class OrderInfomation : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    Customer custmer;
   
    protected void Page_Load(object sender, EventArgs e)
   {
       if (Session["User"] == null)
       {
           Response.Redirect("login.aspx");
       }

       custmer = (Customer)Session["User"];
       SqlConnection con = new SqlConnection(webcon);
       string qry = "select Email,FirstName,LastName,Phone from Orders where CustomerID = " + custmer.CustomerId.ToString() + "";
       SqlDataAdapter adp = new SqlDataAdapter(qry, con);
       DataSet ds = new DataSet();
       adp.Fill(ds);
       GridView1.DataSource = ds.Tables[0];
       GridView1.DataBind();



        //string MyPageTitle = "MyPageTitle"; // your page title here
        //string myConnectionString = "connectionstring"; //you connectionstring goes here
     
        //SqlConnection con = new SqlConnection(webcon);
        //string qry = " select ShippingPhone,ShippingState,ShippingZip,ShippingCountry,ShippingCity,ShippingAddress1 from Orders where OrderNumber = " + id ;
        //com = new SqlCommand(qry, con);
        //SqlDataReader reader = com.ExecuteReader();
        //reader.Read();
        //lblShippingPhone.Text = reader["ShippingPhone"].ToString();
        //reader.Read();
        //lblShippingState.Text = reader["ShippingState"].ToString();
        //reader.Read();
        //reader.Close();
        //con.Close();
        //con.Open();



        //str = "select * from emp";
        //com = new SqlCommand(str, con);
        //SqlDataReader reader = com.ExecuteReader();
        //reader.Read();
        //lblShippingPhone.Text = reader["Name"].ToString();
        //reader.Read();
        //labelname2.Text = reader["Name"].ToString();
        //reader.Read();
        //labelname3.Text = reader["Name"].ToString();
        //reader.Close();
        //con.Close();
        //con.Open();


        //SqlDataReader reader1 = com.ExecuteReader();
        //reader1.Read();
        //labelage1.Text = reader1["Age"].ToString();
        //reader1.Read();
        //labelage2.Text = reader1["Age"].ToString();
        //reader1.Read();
        //labelage3.Text = reader1["Age"].ToString();
        //reader.Close();
        //con.Close();
        
        //cmd.Connection.Close();





        //custmer = (Customer)Session["User"];
        //SqlConnection con = new SqlConnection(webcon);
        //string qry = "select Email,FirstName,LastName,Phone from Orders where CustomerID = " + custmer.CustomerID + "";
        //SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        //DataSet ds = new DataSet();
        //adp.Fill(ds);
        //gview.DataSource = ds.Tables[0];
        //gview.DataBind();
    }

    //private void FillGrid()
    //{
    //    SqlConnection con = new SqlConnection(webcon);
    //    string qry = "select ShippingPhone,ShippingState,ShippingZip,ShippingCountry,ShippingCity,ShippingAddress1 from Orders";
    //    SqlDataAdapter adp = new SqlDataAdapter(qry, webcon);
    //    DataSet ds = new DataSet();
    //    adp.Fill(ds); //code smith end
    //    dtShopingCart.DataSource = ds.Tables[0];
    //    dtShopingCart.DataBind();


    //}

    //protected void dtShopingCart_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    //{
    //    int id = Convert.ToInt32(e.CommandArgument.ToString());

    //    if (e.CommandName == "Add")
    //    {
    //        System.Web.UI.WebControls.Label lblShippingPhone = e.Item.FindControl("lblShippingPhone") as System.Web.UI.WebControls.Label;
    //        System.Web.UI.WebControls.Label lblShippingState = e.Item.FindControl("lblShippingState") as System.Web.UI.WebControls.Label;
    //        System.Web.UI.WebControls.Label lblShippingZip = e.Item.FindControl("lblShippingZip") as System.Web.UI.WebControls.Label;
    //        System.Web.UI.WebControls.Label lblShippingCountry = e.Item.FindControl("lblShippingCountry") as System.Web.UI.WebControls.Label;
    //        System.Web.UI.WebControls.Label lblShippingCity = e.Item.FindControl("lblShippingCity") as System.Web.UI.WebControls.Label;
    //        System.Web.UI.WebControls.Label lblShippingAddress1 = e.Item.FindControl("lblShippingAddress1") as System.Web.UI.WebControls.Label;

    //    }
    //}
}