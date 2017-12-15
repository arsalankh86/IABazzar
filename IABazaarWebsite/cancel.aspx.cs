using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class cancel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
        SqlConnection con = new SqlConnection(constring);
        string bsql = "insert into Table_1(Name, object) values('cancel','xxx')";
        SqlCommand bcmd = new SqlCommand(bsql, con);
        con.Open();
        bcmd.ExecuteNonQuery();
        con.Close();
    }
}