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


public partial class My_Account_Orderhistory : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    Customer custmer;
    protected void Page_Load(object sender, EventArgs e)
    {
        custmer = (Customer)Session["User"];

        SqlConnection con = new SqlConnection(webcon);
        string qry = "select Email,FirstName,LastName,Phone from Orders where CustomerID = " + custmer.CustomerId + "";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        gview.DataSource = ds.Tables[0];
        gview.DataBind();

    }
}