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

public partial class Admin_Default : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
         
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
            string Uid, Password1;

            Uid = txtUser_Name.Text.Trim();
            Password1 = txtUser_Password.Text.Trim();

            SqlConnection con = new SqlConnection(webcon);
            string qry = "select * from Admin_Login where User_Name = '" + Uid + "' and User_Password = '" + Password1 + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Session["Admin"] = Uid;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("AdminArea.aspx");
            }

            else
            {
                errormesstr.Visible = true;
                LabelError.Visible = true;
                LabelError.Text = "Error: UserName or Password incorrect!";

            }
        

    }
}