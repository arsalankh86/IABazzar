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
using System.Text;

public partial class Admin_Orders : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Admin"] == null)
        {
            Response.Redirect("Default.aspx");
        }


        if (IsPostBack)
            return;


        BindOrders();

        BindOrdersDetail();

        BindCustomerProductSizeDetail();
    }

    private void BindOrders()
    {
        SqlConnection con = new SqlConnection(webcon);
        string qry = "select * from Orders order by 1 desc";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    private void BindCustomerProductSizeDetail()
    {
        SqlConnection con = new SqlConnection(webcon);
        string qry = "select * from CustomerProductSizeDetail order by 1 desc";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);
        GridView3.DataSource = ds.Tables[0];
        GridView3.DataBind();
    }



    private void BindOrdersDetail()
    {
        SqlConnection con = new SqlConnection(webcon);
        string qry = "select * from Orders_ShoppingCart order by 1 desc";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);
        GridView2.DataSource = ds.Tables[0];
        GridView2.DataBind();
    }

}