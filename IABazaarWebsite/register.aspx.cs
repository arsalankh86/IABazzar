using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class register : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        //if (chkprivcy.Checked == true)
        //{
            if (IsEmailAlreadyExisi() != true)
            {
                

                Customer cus = new Customer();
                cus.Email = txtemail.Value;
                cus.FirstName = txtfirstname.Value;
                cus.LastName = txtlastname.Value;
                //cus.Phone = txttelephone.Value;
                cus.Password = password.Value;

                CustomerRepository cusrep = new CustomerRepository();
                Customer customer = cusrep.PreInsertCustomer(cus);

                int customerid = customer.CustomerId;
                Session["User"] = customer;


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
                        cart.CustomerId = customer.CustomerId;
                        cart.ChosenSize = ChosenSize;
                        //TaxRate is used for saving the Cart Total
                        cart.TaxRate = CartTotal;
                        cart.CreatedOn = DateTime.Now;
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
                            qry += "values('" + dr["Size"] + "','" + customer.CustomerId + "','" + dr["ProductId"] + "','" + customer.Email + "','" + dr["BUST"] + "','" + dr["WAIST"] + "','" + dr["SHOULDER"] + "','" + dr["HIP"] + "','" + dr["NECK_WIDTH"] + "','" + dr["SLEEVES_STYLE"] + "','" + dr["TROUSER_STYLE"] + "','" + dr["SHIRT_STYLE"] + "','" + dr["Height_Feet"] + "','" + dr["Instruction"] + "','" + dr["Height_Inches"] + "','" + DateTime.Now.ToString() + "','" + ipAddress + "')";
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
                    Response.Redirect("Myaccount.aspx");
                }

            }
            else
            {

            }
        //}
        //else
        //{

        //}


        //Insert all items in shopping cart
    }

    private bool IsEmailAlreadyExisi()
    {

          CustomerRepository _CustomerRepository = new CustomerRepository();
          Customer _Customer = _CustomerRepository.GetCustomerByEmail(txtemail.Value);

        if (_Customer != null)
            return true;
        else
            return false;

        
    }


  
}