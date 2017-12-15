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

public partial class personalInfor : System.Web.UI.Page
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

        imranfill();

        if (Session["Customer"] == null)
        {
            Customer customer = (Customer)Session["User"];

            txtemail.Value = customer.Email;
            txtfirstname.Value = customer.FirstName;
            txtlastname.Value = customer.LastName;
            txttelephone.Value = customer.Phone;


            //txtEmail.Text = custmer.Email;
            //txtFirstname.Text = custmer.FirstName;
            //txtLastname.Text = custmer.LastName;
            //txtship_Phone.Text = custmer.Phone;
            //hdncustomerid.Value = custmer.CustomerId.ToString();
        }
    }

    private void imranfill()
    {
        if (Session["Customer"] == null)
        {
            Customer customer = (Customer)Session["User"];

            txtemail.Value = customer.Email;
            txtfirstname.Value = customer.FirstName;
            txtlastname.Value = customer.LastName;
            txttelephone.Value = customer.Phone;


            //txtEmail.Text = custmer.Email;
            //txtFirstname.Text = custmer.FirstName;
            //txtLastname.Text = custmer.LastName;
            //txtship_Phone.Text = custmer.Phone;
            //hdncustomerid.Value = custmer.CustomerId.ToString();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Customer customer = (Customer)Session["User"];

            SqlConnection con = new SqlConnection(webcon);
            string qry = "update Customer set FirstName ='" + txtfirstname.Value + "', LastName ='" + txtlastname.Value + "', Phone ='" + txttelephone.Value + "' where CustomerID =" + customer.CustomerId + "";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            CustomerRepository cr=new CustomerRepository();
            Customer c = cr.GetCustomer(customer.CustomerId);

            Session["User"] = c;

            imranfill();

        }
        catch
        {
            Response.Write("<script>alert(' Personal Infomation do net saved ')</script>");
        }




    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyAccount.aspx");
    }
}