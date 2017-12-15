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

public partial class My_Account_Wish_List : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        //string ID = Request.QueryString["pid"].ToString();
        Customer cus = new Customer();
        int idutharahahoo = cus.CustomerId;
        Session["Customer"] = cus;
         
             //  

        Customer custmer = (Customer)Session["Customer"];
        SqlConnection con = new SqlConnection(webcon);
        string qry = "select Customer_ID,Product_ID from WishList where Customer_ID = " + cus.CustomerId + "";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GView.DataSource = ds;
        GView.DataBind();
    }
}