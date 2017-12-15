using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Text;

public partial class checkoutreview : System.Web.UI.Page
{
    ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;


        if (Session["User"] != null)
        {
            string shippingvalue = System.Configuration.ConfigurationManager.AppSettings["shippingformany"].ToString(); 
            
            decimal value = 0, shipping = Convert.ToDecimal(shippingvalue), total = 0;
            Customer customer = (Customer)Session["User"];
            
            DataSet dsShoppingCart = _ShoppingCartRepository.GetAllShoppingCartAndProductDetailByCustomerID(customer.CustomerId);

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

            if (dsShoppingCart != null)
            {
            foreach (DataRow dr in dsShoppingCart.Tables[0].Rows)
            {
                value += Convert.ToDecimal(dr[3].ToString());
            }

            dtlcart.DataSource = dsShoppingCart.Tables[0];
            dtlcart.DataBind();
            lblsubtotal.Text = value.ToString();
            lblShipping.Text = shipping.ToString();
            total = value + shipping;
            lbltotal.Text = total.ToString();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
      

    }
    protected void btnContinue_Click(object sender, ImageClickEventArgs e)
    {
        int OrderNumber = 0;
        Orders _Orders = (Orders)Session["OrderInformation"];

        //TODO: Insert Order table information

        Customer customer = (Customer)Session["User"];

        Orders CreateOrder = new Orders();
        CreateOrder.Email = _Orders.Email;
        CreateOrder.Phone = customer.Phone;
        CreateOrder.FirstName = customer.FirstName;
        CreateOrder.LastName = customer.LastName;
        CreateOrder.CustomerId = customer.CustomerId;
        CreateOrder.OrderStatus = "Initiate";

        CreateOrder.OrderTotal = Convert.ToDecimal(lbltotal.Text);
        CreateOrder.OrderShippingCosts = Convert.ToDecimal(lblShipping.Text);
        CreateOrder.OrderSubtotal = Convert.ToDecimal(lblsubtotal.Text);
        CreateOrder.RegisterDate = DateTime.Now;
        

        CreateOrder.ShippingAddress1 = _Orders.ShippingAddress1;
        CreateOrder.ShippingAddress2 = _Orders.ShippingAddress2;
        CreateOrder.ShippingCity = _Orders.ShippingCity;
        CreateOrder.ShippingCountry = _Orders.ShippingCountry;
        CreateOrder.ShippingPhone = _Orders.Phone;
        CreateOrder.ShippingState = _Orders.ShippingState;

        CreateOrder.BillingAddress1 = _Orders.BillingAddress1;
        CreateOrder.BillingAddress2 = _Orders.BillingAddress2;
        CreateOrder.BillingCity = _Orders.ShippingCity;
        CreateOrder.BillingCountry = _Orders.ShippingCountry;
        CreateOrder.BillingPhone = _Orders.Phone;
        CreateOrder.BillingState = _Orders.BillingState;

        OrdersRepository _OrdersRepository = new OrdersRepository();
        OrderNumber = _OrdersRepository.iabazaarInsertOrders(CreateOrder);

        
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
            if(retvalue == true)
                _ShoppingCartRepository.DeleteShoppingCartByCustomerID(customer.CustomerId);

            CallPayPal(OrderNumber);
        }
        
    }

    private void CallPayPal(int OrderNumber)
    {
        // Live PayPal URL
        //const string SERVER_URL = "https://www.paypal.com/cgi-bin/webscr";
        // Sandbox PayPal URL
        const string SERVER_URL = "https://www.sandbox.paypal.com/cgi-bin/webscr";

        // Live business parameter
        const string BUSINESS = "arsalankhankudcs@yahoo.com";
        // Sandbox business parameter
        //const string BUSINESS = "usaimrankhan@gmail.com";

        // Return URL for IPN processing
        const string NOTIFY_URL = "http://www.iabazaar.com/notify.aspx";



        OrdersRepository _OrdersRepository = new OrdersRepository();
        OrdersShoppingCartRepository _OrdersShoppingCartRepository = new OrdersShoppingCartRepository();
        DataSet order = _OrdersRepository.GetOrdersData(OrderNumber);
        DataSet ordercart = new DataSet();

        if(order != null)
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

    protected string GetPayPalURL(string SERVER_URL, string business,  int orderID, decimal shipping, string NOTIFY_URL, DataTable ordercart)
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
         + HttpUtility.UrlEncode("http://www.iabazaar.com/thankyou.aspx"));


        url.Append("&custom="
          + HttpUtility.UrlEncode(orderID.ToString()));

        return url.ToString();
    } 
}