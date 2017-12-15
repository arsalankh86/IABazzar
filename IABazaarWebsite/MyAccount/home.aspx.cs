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

public partial class MyAccount_home : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            Customer custmer = (Customer)Session["User"];

            //txtEmail.Text = custmer.Email;
            //txtFirstname.Text = custmer.FirstName;
            //txtLastname.Text = custmer.LastName;
            hdncustomerid.Value = custmer.CustomerId.ToString();
        }
    }
}