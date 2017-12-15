using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IABazaar.Core.Entities;
using IABazaar.Repository;


public partial class controls_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;


        DataSet dsShoppingCart = new DataSet();
        DataTable dtcart = new DataTable();
        if (Session["User"] != null)
        {
            Customer customer = (Customer)Session["User"];
            ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
            dsShoppingCart = _ShoppingCartRepository.GetAllShoppingCartAndProductDetailByCustomerID(customer.CustomerId);

            if (dsShoppingCart != null)
            {
                rptcart.DataSource = dsShoppingCart.Tables[0];
                rptcart.DataBind();

                int quantity=0;
                for (int i = 0; i < dsShoppingCart.Tables[0].Rows.Count; i++)
                {
                    quantity += Convert.ToInt32(dsShoppingCart.Tables[0].Rows[i]["Quantity"].ToString());
                }

                lblcart.Text = quantity.ToString() + " item(s)";
            }
        }
        else
        {
            if (Session["Cart"] != null)
            {
                DataTable dtSessionCart = (DataTable)Session["Cart"];

                if (dtSessionCart.Rows.Count > 0)
                {
                    rptcart.DataSource = dtSessionCart;
                    rptcart.DataBind();

                    int quantity = 0;
                    for (int i = 0; i < dtSessionCart.Rows.Count; i++)
                    {
                        quantity += Convert.ToInt32(dtSessionCart.Rows[i]["Quantity"].ToString());
                    }

                    lblcart.Text = quantity.ToString() + " item(s)";
                }

            }
        }




    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SearchResult.aspx?searchvalue=" + filter_name.Value);
    }
}