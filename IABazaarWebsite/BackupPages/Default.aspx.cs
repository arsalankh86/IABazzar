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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Customer customer = new Customer();
        CustomerRepository r = new CustomerRepository();
        HttpRequest currentRequest = HttpContext.Current.Request;

        customer.Email = "";
        customer.Password = "";
        customer.FirstName = "";
        customer.LastName = "";
        customer.LastIpAddress = currentRequest.ServerVariables["REMOTE_ADDR"];

        
        r.InsertCustomer(customer);

        //DataSet ds = r.GetAllCustomer();

        //GridView1.DataSource = ds;
        //GridView1.DataBind();

       

    }
}