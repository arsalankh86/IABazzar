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

public partial class login : System.Web.UI.Page
{

    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (IsPostBack)
            return;


        if(Session["User"] != null)
        {
            Response.Redirect("MyAccount.aspx");
        }



    }


    protected void btnlogin_Click(object sender, EventArgs e)
    {

        CustomerRepository _CustomerRepository = new CustomerRepository();
        Customer _Customer = _CustomerRepository.GetCustomerByEmail(email.Value);

        if (_Customer != null)
        {
            string sUser = _Customer.Email;
            string sPass = _Customer.Password;
            int cid = Convert.ToInt32(_Customer.CustomerId);
           

            if (email.Value.Equals(sUser) && password.Value.Equals(sPass))
            {
                Session["User"] = _Customer;

                //Insert all items in shopping cart
                if (Session["Cart"] != null)
                {
                    DataTable dtSessionCart = (DataTable)Session["Cart"];

                    foreach (DataRow dr in dtSessionCart.Rows)
                    {
                        int productid = Convert.ToInt32(dr[0].ToString());
                        decimal price = Convert.ToDecimal(dr[1].ToString());
                        int quantity = Convert.ToInt32(dr[2].ToString());
                        decimal CartTotal = Convert.ToDecimal(dr[3].ToString());
                        string ChosenSize = dr["ChosenSize"].ToString();

                        ShoppingCart cart = new ShoppingCart();
                        cart.ProductId = productid;
                        cart.ProductPrice = price;
                        cart.Quantity = quantity;
                        cart.CustomerId = _Customer.CustomerId;
                        //TaxRate is used for saving the Cart Total
                        cart.TaxRate = CartTotal;
                        cart.CreatedOn = DateTime.Now;
                        cart.ChosenSize = ChosenSize;
                        ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
                        _ShoppingCartRepository.iabazaarInsertShoppingCart(cart);

                    }

                    //Insert Size Detail
                    DataTable dtsize;
                    if (Session["Size"] != null)
                    {
                        dtsize = (DataTable)Session["Size"];

                        foreach (DataRow dr in dtsize.Rows)
                        {
                            string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                            SqlConnection conw = new SqlConnection(webcon);
                            string qry = "insert into CustomerProductSizeDetail(Size,CustomerID,ProductID,Email,[bustchest],[waist],[shoulder],[hip],[neckwidth],[sleevesstyle],[trouserstyle],[shirtstyle],[heightfeet],[stichinginstructions],[heightinches],CreatedDate,UpdatedIP)";
                            qry += "values('" + dr["Size"] + "','" + _Customer.CustomerId + "','" + dr["ProductId"] + "','" + _Customer.Email + "','" + dr["BUST"] + "','" + dr["WAIST"] + "','" + dr["SHOULDER"] + "','" + dr["HIP"] + "','" + dr["NECK_WIDTH"] + "','" + dr["SLEEVES_STYLE"] + "','" + dr["TROUSER_STYLE"] + "','" + dr["SHIRT_STYLE"] + "','" + dr["Height_Feet"] + "','" + dr["Instruction"] + "','" + dr["Height_Inches"] + "','" + DateTime.Now.ToString() + "','" + ipAddress + "')";
                            SqlCommand cmd = new SqlCommand(qry, conw);
                            conw.Open();
                            cmd.ExecuteNonQuery();
                            conw.Close();
                        }
                    }

                    Response.Redirect("checkout.aspx");
                }
                else
                {
                    if (Session["Cart"] == null)
                    {
                        Response.Redirect("MyAccount.aspx");
                    }
                    else
                    {
                        Response.Redirect("cart.aspx");
                    }
                }

            }
        }
    }
    protected void CONTINUE_Click(object sender, EventArgs e)
    {
        Response.Redirect("checkoutanon.aspx");
        
    }

    }