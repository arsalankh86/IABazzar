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
using System.Data;
using System.Text;

public partial class checkoutanon : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;



        string shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingformany"].ToString();
        decimal value = 0, shipping = Convert.ToDecimal(shippingvalue), total = 0;
        DataTable dtcart = new DataTable();

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
            }

        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        dtlcart.DataSource = dtcart;
        dtlcart.DataBind();
        lblsubtotal.Text = value.ToString();
        lblShipping.Text = shipping.ToString();
        total = value + shipping;
        lbltotal.Text = total.ToString();

     
    }
    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {

        // Customer Registration

        Customer cus = new Customer();
        Random random = new Random();
        cus.Email = txtEMail.Text + "_anon" + random.Next(1000, 100000000);
        cus.FirstName = txtFirstName.Text;
        cus.LastName = txtLastName.Text;
        cus.Phone = txtship_Phone.Text;

        CustomerRepository cusrep = new CustomerRepository();
        Customer customer = cusrep.PreInsertCustomer(cus);

        int customerid = customer.CustomerId;
        Session["User"] = customer;


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



        int OrderNumber = 0;

        //TODO: Insert Order table information

         Orders _Orders = new Orders();
        _Orders.Email = txtEMail.Text;
        _Orders.Phone = customer.Phone;
        _Orders.FirstName = customer.FirstName;
        _Orders.LastName = customer.LastName;
        _Orders.CustomerId = customer.CustomerId;
        _Orders.OrderStatus = "Initiate";

        _Orders.OrderTotal = Convert.ToDecimal(lbltotal.Text);
        _Orders.OrderShippingCosts = Convert.ToDecimal(lblShipping.Text);
        _Orders.OrderSubtotal = Convert.ToDecimal(lblsubtotal.Text);
        _Orders.RegisterDate = DateTime.Now;


        _Orders.ShippingAddress1 = txtship_Address.Text;
        _Orders.ShippingAddress2 = txtship_Address2.Text;
        _Orders.ShippingCity = txtshipcity.Text;
        _Orders.ShippingCountry = txtship_Country.Text;
        _Orders.ShippingPhone = txtship_Phone.Text;
        _Orders.ShippingState = txtship_State.Text;
        _Orders.ShippingZip = txtship_Zip.Text;


        if (chkbilldif.Checked == false)
        {

            _Orders.BillingAddress1 = txtship_Address.Text;
            _Orders.BillingAddress2 = txtship_Address2.Text;
            _Orders.BillingCity = txtshipcity.Text;
            _Orders.BillingCountry = txtship_Country.Text;
            _Orders.BillingPhone = txtship_Phone.Text;
            _Orders.BillingState = txtship_State.Text;
            _Orders.BillingZip = txtship_Zip.Text;

        }
        else
        {

            _Orders.BillingAddress1 = txtBll_Address.Text;
            _Orders.BillingAddress2 = txtBll_Address2.Text;
            _Orders.BillingCity = txtBll_City.Text;
            _Orders.BillingCountry = txtBll_Country.Text;
            _Orders.BillingPhone = txtBll_Phone.Text;
            _Orders.BillingState = txtBll_State.Text;
            _Orders.BillingZip = txtBll_Zip.Text;
        }

        OrdersRepository _OrdersRepository = new OrdersRepository();
        OrderNumber = _OrdersRepository.iabazaarInsertOrders(_Orders);


        //TODO: Insert Order Detail table information
        bool retvalue = false;
        if (OrderNumber != 0)
        {
            ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
            DataSet dsShoppingCart = _ShoppingCartRepository.GetAllShoppingCartAndProductDetailByCustomerID(customer.CustomerId);

            foreach (DataRow dr in dsShoppingCart.Tables[0].Rows)
            {
                OrdersShoppingCart _OrdersShoppingCart = new OrdersShoppingCart();
                _OrdersShoppingCart.ShoppingCartRecId = Convert.ToInt32(dr[7].ToString());
                _OrdersShoppingCart.ProductId = Convert.ToInt32(dr[0].ToString());
                _OrdersShoppingCart.OrderedProductPrice = Convert.ToDecimal(dr[1].ToString());
                _OrdersShoppingCart.Quantity = Convert.ToInt32(dr[2].ToString());
                _OrdersShoppingCart.OrderedProductName = dr[5].ToString();
                _OrdersShoppingCart.OrderNumber = OrderNumber;
                _OrdersShoppingCart.ChosenSize = dr["ChosenSize"].ToString();

                OrdersShoppingCartRepository _OrdersShoppingCartRepository = new OrdersShoppingCartRepository();
                retvalue = _OrdersShoppingCartRepository.iabazaarInsertOrdersShoppingCart(_OrdersShoppingCart);

            }

            //TODO: Delete ShoppingCart information of customer
            if (retvalue == true)
                _ShoppingCartRepository.DeleteShoppingCartByCustomerID(customer.CustomerId);

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



            CallPayPal(OrderNumber);
        }

    }

    private void CallPayPal(int OrderNumber)
    {
        // Live PayPal URL
        //const string SERVER_URL = "https://www.paypal.com/cgi-bin/webscr";
        
        // Sandbox PayPal URL
        //const string SERVER_URL = "https://www.sandbox.paypal.com/cgi-bin/webscr";

        // Live business parameter
        //const string BUSINESS = "arsalankhankudcs@yahoo.com";
        
        // Sandbox business parameter
        //const string BUSINESS = "usaimrankhan@gmail.com";

        // Return URL for IPN processing
        const string NOTIFY_URL = "http://www.iabazaar.com/notify.aspx";


        string SERVER_URL = System.Configuration.ConfigurationManager.AppSettings["PaypalURL"].ToString();
        string BUSINESS = System.Configuration.ConfigurationManager.AppSettings["PaypalUserId"].ToString();
        

        OrdersRepository _OrdersRepository = new OrdersRepository();
        OrdersShoppingCartRepository _OrdersShoppingCartRepository = new OrdersShoppingCartRepository();
        DataSet order = _OrdersRepository.GetOrdersData(OrderNumber);
        DataSet ordercart = new DataSet();

        if (order != null)
            ordercart = _OrdersShoppingCartRepository.GetOrdersShoppingCartDetail(OrderNumber);


        //int productID = 1;
        //int totalUnits = 1;
        //decimal totalShipping = 1.00M;
        //string paypalURL = "";

        //string itemNumber = "123";


        //string itemName = "Grace\'s Guitars";
        //decimal totalAmount = 1.00M;
        // Eventually, use a SQL Server job to remove unconfirmed orders

        // Calculate total shipping cost for total number of units
        //totalShipping = 1;

        //Get back the URL-encoded URL for PayPal    

        string paypalURL = GetPayPalURL(SERVER_URL, BUSINESS, OrderNumber, Convert.ToDecimal(order.Tables[0].Rows[0]["OrderShippingCosts"].ToString()), NOTIFY_URL, ordercart.Tables[0]);

        Response.Redirect(paypalURL, true);
    }

    protected string GetPayPalURL(string SERVER_URL, string business, int orderID, decimal shipping, string NOTIFY_URL, DataTable ordercart)
    {
        // Customer will be required to specify 
        // delivery address to PayPal 
        const string NO_SHIPPING = "2";

        StringBuilder url = new StringBuilder();
        url.Append(SERVER_URL + "?cmd=_cart&upload=1");
        url.Append("&business=" + HttpUtility.UrlEncode(business));

        //for (int i = 0; i < itemNames.Length; i++)
        //{
        //    url.Append("&item_name" + "_" + (i + 1).ToString() +
        //       "=" + HttpUtility.UrlEncode(itemNames[i].ToString()));
        //    url.Append("&quantity" + "_" + (i + 1).ToString() +
        //       "=" + quantities.ToString().Replace(",", "."));
        //    url.Append("&amount" + "_" + (i + 1).ToString() +
        //       "=" + amounts.ToString().Replace(",", "."));
        //    //url.Append("&weight" + "_" + (i + 1).ToString() +
        //    //   "=" + itemWeight.ToString().Replace(",", "."));
        //}


        for (int i = 0; i < ordercart.Rows.Count; i++)
        {
            url.Append("&item_name" + "_" + (i + 1).ToString() +
               "=" + HttpUtility.UrlEncode(ordercart.Rows[i]["OrderedProductName"].ToString()));
            url.Append("&quantity" + "_" + (i + 1).ToString() +
               "=" + ordercart.Rows[i]["Quantity"].ToString());
            url.Append("&amount" + "_" + (i + 1).ToString() +
               "=" + Math.Round(Convert.ToDecimal(ordercart.Rows[i]["OrderedProductPrice"].ToString()), 2));
            //url.Append("&weight" + "_" + (i + 1).ToString() +
            //   "=" + itemWeight.ToString().Replace(",", "."));
        }

        //if (ordercart.Rows.Count == 1)
        //{
        //    int quantity = Convert.ToInt32(ordercart.Rows[0]["Quantity"].ToString());

        //    if (quantity == 1)
        //    {
        //        string shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingforOneOrder"].ToString();
        //        shipping = Convert.ToDecimal(shippingvalue);
        //    }
        //    else
        //    {
        //        shipping = shipping * ordercart.Rows.Count;
        //    }
        //}
        //else
        //{
        //    shipping = shipping * ordercart.Rows.Count;
        //}

        url.Append("&item_name" + "_" + (ordercart.Rows.Count + 1).ToString() +
           "=" + HttpUtility.UrlEncode("Shipping"));
        url.Append("&quantity" + "_" + (ordercart.Rows.Count + 1).ToString() +
           "=" + 1);
        url.Append("&amount" + "_" + (ordercart.Rows.Count + 1).ToString() +
           "=" + Math.Round(shipping, 2));



        url.Append("&item_number="
          + HttpUtility.UrlEncode(orderID.ToString()));

        //url.Append("&no_shipping="
        // + HttpUtility.UrlEncode(NO_SHIPPING));

        //url.Append("&shipping="
        //   + Math.Round(Convert.ToDecimal(shipping.ToString()),2));
        url.Append("&currency_code="
         + HttpUtility.UrlEncode("USD"));

        url.Append("&invoice="
         + HttpUtility.UrlEncode(orderID.ToString()));


        url.Append("&notify_url="
           + HttpUtility.UrlEncode(NOTIFY_URL));

        url.Append("&return="
          + HttpUtility.UrlEncode("http://www.iabazaar.com/thankyou.aspx?ordernumber="+ orderID.ToString() +""));


        url.Append("&custom="
          + HttpUtility.UrlEncode(orderID.ToString()));

        return url.ToString();
    } 


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

        if (chkbilldif.Checked == true)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }

        
            
    }

}