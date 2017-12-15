using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class PaymentPages_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
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

        decimal totalAmount = 20.0000M;
        int productID = 1;
        int totalUnits = 1;
        decimal totalShipping = 1.00M;
        string paypalURL = "";
        string itemName = "Grace\'s Guitars";
        string itemNumber = "123";

            // Eventually, use a SQL Server job to remove unconfirmed orders

            // Calculate total shipping cost for total number of units
            totalShipping = 20;

            // Get back the URL-encoded URL for PayPal    
            paypalURL = GetPayPalURL(SERVER_URL, BUSINESS, itemName, itemNumber,
                totalAmount, 1, totalShipping, NOTIFY_URL);
            Response.Redirect(paypalURL, true);
    }

    private string GetPayPalURL(string SERVER_URL, string BUSINESS, string itemName, string itemNumber, decimal totalAmount, int quantity, decimal totalShipping, string NOTIFY_URL)
    {
        // Customer will be required to specify 
        // delivery address to PayPal 
        const string NO_SHIPPING = "2";

        StringBuilder url = new StringBuilder();
        url.Append(SERVER_URL + "?cmd=_cart&upload=1");
        url.Append("&business=" + HttpUtility.UrlEncode(BUSINESS));

        //for (int i = 0; i < itemName.Length; i++)
        //{
        string itemName1 = "Sda";

        int i = 0;
            url.Append("&item_name" + "_" + (i + 1).ToString() +
               "=" + HttpUtility.UrlEncode(itemName));
            url.Append("&quantity" + "_" + (i + 1).ToString() +
                  "=" + quantity.ToString().Replace(",", "."));
            url.Append("&amount" + "_" + (i + 1).ToString() +
                   "=" + totalAmount.ToString().Replace(",", "."));


            url.Append("&item_name" + "_" + (i + 2).ToString() +
                   "=" + HttpUtility.UrlEncode(itemName1));
            url.Append("&quantity" + "_" + (i + 2).ToString() +
                   "=" + 2);
            url.Append("&amount" + "_" + (i + 2).ToString() +
                  "=" + 100);
            //url.Append("&weight" + "_" + (i + 1).ToString() +
            //   "=" + itemWeight.ToString().Replace(",", "."));
        //}



        //url.Append("&item_name" +
        //       "=" + HttpUtility.UrlEncode(itemName));
        //url.Append("&quantity" + 
        //   "=" + quantity.ToString().Replace(",", "."));
        //url.Append("&amount" +
        //   "=" + totalAmount.ToString().Replace(",", "."));

            url.Append("&no_shipping="
             + HttpUtility.UrlEncode(NO_SHIPPING));


        url.Append("&no_shipping="
           + HttpUtility.UrlEncode(NO_SHIPPING));
        url.Append("&item_number="
           + HttpUtility.UrlEncode(itemNumber.ToString()));
        url.Append("&notify_url="
           + HttpUtility.UrlEncode(NOTIFY_URL));

        return url.ToString();
    }

    protected string GetPayPalURL(string SERVER_URL, string business, string itemNames, int orderID, decimal amounts, int quantities, decimal shipping, string NOTIFY_URL)
    {
        // Customer will be required to specify 
        // delivery address to PayPal 
        const string NO_SHIPPING = "2";

        StringBuilder url = new StringBuilder();
        url.Append(SERVER_URL + "?cmd=_cart&upload=1");
        url.Append("&business=" + HttpUtility.UrlEncode(business));

        for (int i = 0; i < itemNames.Length; i++)
        {
            url.Append("&item_name" + "_" + (i + 1).ToString() +
               "=" + HttpUtility.UrlEncode(itemNames));
            url.Append("&quantity" + "_" + (i + 1).ToString() +
               "=" + quantities.ToString().Replace(",", "."));
            url.Append("&amount" + "_" + (i + 1).ToString() +
               "=" + amounts.ToString().Replace(",", "."));
            //url.Append("&weight" + "_" + (i + 1).ToString() +
            //   "=" + itemWeight.ToString().Replace(",", "."));
        }

        url.Append("&no_shipping="
           + HttpUtility.UrlEncode(NO_SHIPPING));
        url.Append("&item_number="
           + HttpUtility.UrlEncode(orderID.ToString()));
        url.Append("&notify_url="
           + HttpUtility.UrlEncode(NOTIFY_URL));

        return url.ToString();
    } 
}