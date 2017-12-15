using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_Product.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add_Category.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Visitor_rpt.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Orders.aspx");
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();        
        Session["Admin"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void lnkContactUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs_rpt.aspx");
    }
    protected void lnkContactUs_Click1(object sender, EventArgs e)
    {
        Response.Redirect("ContactUs_rpt.aspx");
    }
}