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


public partial class Wishlist : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (Session["User"] == null)
        {
            Response.Redirect("login.aspx");
        }

        Customer customer = (Customer)Session["User"];

        if (customer != null)
        {

            SqlConnection con = new SqlConnection(webcon);
            string qry = "select p.ProductID, p.Name, p.ImageFilenameOverride, p.Profitpriceindollar from dbo.WishList w, Product p where w.Product_ID =p.ProductID and w.Customer_ID = " + customer.CustomerId.ToString() + "";
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);




            ViewCart.DataSource = ds;
            ViewCart.DataBind();

        }


        //select p.ProductID, p.Name, p.ImageFilenameOverride from dbo.WishList w, Product p where w.Product_ID =p.ProductID  and w.Customer_ID = 1

    }
}