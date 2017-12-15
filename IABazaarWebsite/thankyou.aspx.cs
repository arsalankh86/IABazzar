using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string OrderNumber = "0";
        string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
        SqlConnection con = new SqlConnection(constring);
        if (Request.QueryString["ordernumber"] != null)
        {
            OrderNumber = Request.QueryString["ordernumber"].ToString();
        }
        string bsql = "insert into Table_1(Name, object) values('thankyou','" + OrderNumber + "')";
        SqlCommand bcmd = new SqlCommand(bsql, con);
        con.Open();
        bcmd.ExecuteNonQuery();
        con.Close();


        //Start work on Order Number to create Receipt

    }
}