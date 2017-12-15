using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Contactus : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

        string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        SqlConnection conw = new SqlConnection(webcon);
        string qry = "insert into ContactUs(Name,Phone,Email,Description,CreatedDate,UpdatedIP) values('" + name.Value.Replace("'", " ") + "','" + phone.Value.Replace("'", " ") + "','" + email.Value.Replace("'", " ") + "','" + enquiry.Value.Replace("'", " ") + "','" + DateTime.Now.ToString() + "','" + ipAddress + "')";
        SqlCommand cmd = new SqlCommand(qry, conw);

        conw.Open();
        cmd.ExecuteNonQuery();
        conw.Close();
    }
}