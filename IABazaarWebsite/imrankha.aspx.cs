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

public partial class imrankha : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(webcon);
        

        // invoice bunch
        string invoice = string.Empty;
        if (Request.QueryString["invoice"] != null)
        {
            invoice = Request.QueryString["invoice"];
        }
        //invoice bunch end

        //string protection_eligibility = Request.QueryString["protection_eligibility"];

        string protection_eligibility = string.Empty;
        if (Request.QueryString["protection_eligibility"] != null)
        {
            protection_eligibility = Request.QueryString["protection_eligibility"];
        }

        //string address_status = Request.QueryString["address_status"];
        string address_status = string.Empty;
        if (Request.QueryString["address_status"] != null)
        {
            address_status = Request.QueryString["address_status"];
        }

        //string payer_id = Request.QueryString["payer_id"];
        string payer_id = string.Empty;
        if (Request.QueryString["payer_id"] != null)
        {
            payer_id = Request.QueryString["payer_id"];
        }
        
        //string tax = Request.QueryString["tax"];
        string tax = string.Empty;
        if (Request.QueryString["tax"] != null)
        {
            tax = Request.QueryString["tax"];
        }
        
        //string address_street = Request.QueryString["address_street"];
        string address_street = string.Empty;
        if (Request.QueryString["address_street"] != null)
        {
            address_street = Request.QueryString["address_street"];
        }
        
        //string payment_date = Request.QueryString["payment_date"];
        string payment_date = string.Empty;
        if (Request.QueryString["payment_date"] != null)
        {
            payment_date = Request.QueryString["payment_date"];
        }
        //string payment_status = Request.QueryString["payment_status"];
        string payment_status = string.Empty;
        if (Request.QueryString["payment_status"] != null)
        {
            payment_status = Request.QueryString["payment_status"];
        }
        //string charset = Request.QueryString["charset"];
        string charset = string.Empty;
        if (Request.QueryString["charset"] != null)
        {
            charset = Request.QueryString["charset"];
        }
        //string address_zip = Request.QueryString["address_zip"];
        string address_zip = string.Empty;
        if (Request.QueryString["address_zip"] != null)
        {
            address_zip = Request.QueryString["address_zip"];
        }
        //string first_name = Request.QueryString["first_name"];
        string first_name = string.Empty;
        if (Request.QueryString["first_name"] != null)
        {
            first_name = Request.QueryString["first_name"];
        }
        //string address_country_code = Request.QueryString["address_country_code"];
        string address_country_code = string.Empty;
        if (Request.QueryString["address_country_code"] != null)
        {
            address_country_code = Request.QueryString["address_country_code"];
        }
        //string address_name = Request.QueryString["address_name"];
        string address_name = string.Empty;
        if (Request.QueryString["address_name"] != null)
        {
            address_name = Request.QueryString["address_name"];
        }
       // string notify_version = Request.QueryString["notify_version"];
        string notify_version = string.Empty;
        if (Request.QueryString["notify_version"] != null)
        {
            notify_version = Request.QueryString["notify_version"];
        }
       // string custom = Request.QueryString["custom"];
        string custom = string.Empty;
        if (Request.QueryString["custom"] != null)
        {
            custom = Request.QueryString["custom"];
        }
       // string payer_status = Request.QueryString["payer_status"];
        string payer_status = string.Empty;
        if (Request.QueryString["payer_status"] != null)
        {
            payer_status = Request.QueryString["payer_status"];
        }
       // string business = Request.QueryString["business"];
        string business = string.Empty;
        if (Request.QueryString["business"] != null)
        {
            business = Request.QueryString["business"];
        }
        //string address_country = Request.QueryString["address_country"];
        string address_country = string.Empty;
        if (Request.QueryString["address_country"] != null)
        {
            address_country = Request.QueryString["address_country"];
        }
        //string address_city = Request.QueryString["address_city"];
        string address_city = string.Empty;
        if (Request.QueryString["address_city"] != null)
        {
            address_city = Request.QueryString["address_city"];
        }
        //string quantity = Request.QueryString["quantity"];
        string quantity = string.Empty;
        if (Request.QueryString["quantity"] != null)
        {
            quantity = Request.QueryString["quantity"];
        }
        //string verify_sign = Request.QueryString["verify_sign"];
        string verify_sign = string.Empty;
        if (Request.QueryString["verify_sign"] != null)
        {
            verify_sign = Request.QueryString["verify_sign"];
        }
        //string payer_email = Request.QueryString["payer_email"];
        string payer_email = string.Empty;
        if (Request.QueryString["payer_email"] != null)
        {
            payer_email = Request.QueryString["payer_email"];
        }
        //string txn_id = Request.QueryString["txn_id"];
        string txn_id = string.Empty;
        if (Request.QueryString["txn_id"] != null)
        {
            txn_id = Request.QueryString["txn_id"];
        }
        //string payment_type = Request.QueryString["payment_type"];
        string payment_type = string.Empty;
        if (Request.QueryString["payment_type"] != null)
        {
            payment_type = Request.QueryString["payment_type"];
        }
        //string last_name = Request.QueryString["last_name"];
        string last_name = string.Empty;
        if (Request.QueryString["last_name"] != null)
        {
            last_name = Request.QueryString["last_name"];
        }
        //string address_state = Request.QueryString["address_state"];
        string address_state = string.Empty;
        if (Request.QueryString["address_state"] != null)
        {
            address_state = Request.QueryString["address_state"];
        }
        //string receiver_email = Request.QueryString["receiver_email"];
        string receiver_email = string.Empty;
        if (Request.QueryString["receiver_email"] != null)
        {
            receiver_email = Request.QueryString["receiver_email"];
        }
        //string pending_reason = Request.QueryString["pending_reason"];
        string pending_reason = string.Empty;
        if (Request.QueryString["pending_reason"] != null)
        {
            pending_reason = Request.QueryString["pending_reason"];
        }
        //string txn_type = Request.QueryString["txn_type"];
        string txn_type = string.Empty;
        if (Request.QueryString["txn_type"] != null)
        {
            txn_type = Request.QueryString["txn_type"];
        }
        //string item_name = Request.QueryString["item_name"];
        string item_name = string.Empty;
        if (Request.QueryString["item_name"] != null)
        {
            item_name = Request.QueryString["item_name"];
        }
        //string mc_currency = Request.QueryString["mc_currency"];
        string mc_currency = string.Empty;
        if (Request.QueryString["mc_currency"] != null)
        {
            mc_currency = Request.QueryString["mc_currency"];
        }
        //string item_number = Request.QueryString["item_number"];
        string item_number = string.Empty;
        if (Request.QueryString["item_number"] != null)
        {
            item_number = Request.QueryString["item_number"];
        }
        //string residence_country = Request.QueryString["residence_country"];
        string residence_country = string.Empty;
        if (Request.QueryString["residence_country"] != null)
        {
            residence_country = Request.QueryString["residence_country"];
        }
        //string test_ipn = Request.QueryString["test_ipn"];
        string test_ipn = string.Empty;
        if (Request.QueryString["test_ipn"] != null)
        {
            test_ipn = Request.QueryString["test_ipn"];
        }
        //string handling_amount = Request.QueryString["handling_amount"];
        string handling_amount = string.Empty;
        if (Request.QueryString["handling_amount"] != null)
        {
            handling_amount = Request.QueryString["handling_amount"];
        }
        //string transaction_subject = Request.QueryString["transaction_subject"];
        string transaction_subject = string.Empty;
        if (Request.QueryString["transaction_subject"] != null)
        {
            transaction_subject = Request.QueryString["transaction_subject"];
        }
        //string payment_gross = Request.QueryString["payment_gross"];
        string payment_gross = string.Empty;
        if (Request.QueryString["payment_gross"] != null)
        {
            payment_gross = Request.QueryString["payment_gross"];
        }
        //string shipping = Request.QueryString["shipping"];
        string shipping = string.Empty;
        if (Request.QueryString["shipping"] != null)
        {
            shipping = Request.QueryString["shipping"];
        }
        //string ipn_track_id = Request.QueryString["ipn_track_id"];
        string ipn_track_id = string.Empty;
        if (Request.QueryString["ipn_track_id"] != null)
        {
            ipn_track_id = Request.QueryString["ipn_track_id"];
        }

        string qry = "insert into Paypal_Ipn (invoice,protection_eligibility,address_status,payer_id,tax,address_street,payment_date,payment_status,charset,address_zip,first_name,address_country_code,address_name,notify_version,custom,payer_status,business,address_country,address_city,quantity,verify_sign,payer_email,txn_id,payment_type,last_name,address_state,receiver_email,pending_reason,txn_type,item_name,mc_currency,item_number,residence_country,test_ipn,handling_amount,transaction_subject,payment_gross,shipping,ipn_track_id) values ('" + invoice + "', '" + protection_eligibility + "', '" + address_status + "', '" + payer_id + "', '" + tax + "', '" + address_street + "', '" + payment_date + "', '" + payment_status + "', '" + charset + "', '" + address_zip + "', '" + first_name + "', '" + address_country_code + "', '" + address_name + "', '" + notify_version + "', '" + custom + "', '" + payer_status + "', '" + business + "', '" + address_country + "', '" + address_city + "', '" + quantity + "', '" + verify_sign + "', '" + payer_email + "', '" + pending_reason + "', '" + txn_type + "', '" + item_name + "', '" + mc_currency + "', '" + item_number + "', '" + residence_country + "', '" + test_ipn + "', '" + handling_amount + "', '" + transaction_subject + "', '" + payment_gross + "', '" + shipping + "', '" + ipn_track_id + "'";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();



    }
}