using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IABazaar.Core.Entities;
using IABazaar.Repository;

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
            return;
        
        BindCart();
    }

    private void BindCart()
    {
        
        string productids = string.Empty;

        string shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingformany"].ToString();
        decimal value = 0, shipping = Convert.ToDecimal(shippingvalue), total = 0;
        DataSet dsShoppingCart = new DataSet();
        DataTable dtcart = new DataTable();
        if (Session["User"] != null)
        {
            Customer customer = (Customer)Session["User"];
            ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
            dsShoppingCart = _ShoppingCartRepository.GetAllShoppingCartAndProductDetailByCustomerID(customer.CustomerId);

            if (dsShoppingCart != null)
            {
                foreach (DataRow dr in dsShoppingCart.Tables[0].Rows)
                {
                    value += Convert.ToDecimal(dr[3].ToString());
                }


                int quantity = 0;
                for (int i = 0; i < dsShoppingCart.Tables[0].Rows.Count; i++)
                {
                    quantity += Convert.ToInt32(dsShoppingCart.Tables[0].Rows[i]["Quantity"].ToString());
                }


                if (quantity == 1)
                {
                    shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingforOneOrder"].ToString();
                    shipping = Convert.ToDecimal(shippingvalue);
                }
                else
                {
                    shipping = Convert.ToDecimal(shippingvalue) * quantity;
                }


                dtcart = dsShoppingCart.Tables[0];

                dtlcart.DataSource = dtcart;
                dtlcart.DataBind();
                lblsubtotal.Text = value.ToString();
                lblShipping.Text = shipping.ToString();
                total = value + shipping;
                lbltotal.Text = total.ToString();
            }
        }
        else
        {
            if (Session["Cart"] != null)
            {
                DataTable dtSessionCart = (DataTable)Session["Cart"];

                if (dtSessionCart.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSessionCart.Rows)
                    {
                        value += Convert.ToDecimal(dr[3].ToString());
                    }

                    int quantity = 0;
                    for (int i = 0; i < dtSessionCart.Rows.Count; i++)
                    {
                        quantity += Convert.ToInt32(dtSessionCart.Rows[i]["Quantity"].ToString());
                    }


                    if (quantity == 1)
                    {
                        shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingforOneOrder"].ToString();
                        shipping = Convert.ToDecimal(shippingvalue);
                    }
                    else
                    {
                        shipping = Convert.ToDecimal(shippingvalue) * quantity;
                    }

                    dtcart = dtSessionCart;

                    dtlcart.DataSource = dtcart;
                    dtlcart.DataBind();
                    lblsubtotal.Text = value.ToString();
                    lblShipping.Text = shipping.ToString();
                    total = value + shipping;
                    lbltotal.Text = total.ToString();
                }

            }
        }


     
    }

    protected void ViewCart_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
        try
        {
            TextBox txtqty=(TextBox)e.Item.FindControl("txtqty");
            
            
            bool isUserExsits = false;
            if (Session["User"] != null)
            {
                Customer customer = (Customer)Session["User"];
                isUserExsits = true;
            }
            

            if (e.CommandName == "LinkUpdate")
            {
                if (isUserExsits == true)
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
                    ShoppingCart _ShoppingCart = new ShoppingCart();
                    _ShoppingCart.ShoppingCartRecId = id;
                    _ShoppingCart.Quantity = Convert.ToInt32(txtqty.Text);
                    _ShoppingCartRepository.UpdateShoppingCartQuantity(_ShoppingCart);
                }
                else
                {
                    string id = e.CommandArgument.ToString();
                    DataTable dtSessionCart = (DataTable)Session["Cart"];
                    for (int i = dtSessionCart.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtSessionCart.Rows[i];
                        if (dr["ShoppingCartRecID"].ToString() == id)
                        {
                            dr["Quantity"] = txtqty.Text;
                            dr["CartTotal"] = Convert.ToInt32(txtqty.Text) * Convert.ToDecimal(dr["ProductPrice"].ToString()) ;
                        }
                    }
                    Session["Cart"] = dtSessionCart;
                }
            }
            if (e.CommandName == "LinkRemove")
            {
                if (isUserExsits == true)
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
                    _ShoppingCartRepository.DeleteShoppingCart(id);
                }
                else
                {
                    string id = e.CommandArgument.ToString();
                    DataTable dtSessionCart = (DataTable)Session["Cart"];
                    for (int i = dtSessionCart.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtSessionCart.Rows[i];
                        if (dr["ShoppingCartRecID"].ToString() == id)
                            dr.Delete();
                    }
                    Session["Cart"] = dtSessionCart;
                }
            }

            BindCart();

            ProductRepository productrep = new ProductRepository();
            DataSet product = new DataSet();

            if (e.CommandName == "ImageRedirect")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                product = productrep.GetProductDataSet(id);
                string link = product.Tables[0].Rows[0]["SeName"] + "-" + id;
                Response.Redirect(link, true);
            }

            if (e.CommandName == "LinkRedirect")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                product = productrep.GetProductDataSet(id);
                string link = product.Tables[0].Rows[0]["SeName"] + "-" + id;
                Response.Redirect(link, true);
            }
            
            


            
        }
        //Product.aspx?nodotnet=1

        catch
        {
            //Response.Redirect("Wishlist.aspx");
        }

    }
    protected void btnchkout_Click(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            Response.Redirect("checkout.aspx");
        }
        else
        {
            Response.Redirect("login.aspx");
        }

    }
}