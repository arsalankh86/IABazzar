using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using IABazaar.Repository;
using IABazaar.Core.Entities;
using System.Data;


public partial class notify : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
           CallAfterPayment();

         //EmailToCustomer("123", "imrankhankhan4@hotmail.com");
           
       

    }

    private static void EmailToCustomer(string item_number, string toemail)
    {
        string smtpAddress = "smtp.mail.yahoo.com";
        int portNumber = 587;
        bool enableSSL = true;


        //string emailFrom = System.Configuration.ConfigurationManager.AppSettings["smtpusername"].ToString();
        //string password = System.Configuration.ConfigurationManager.AppSettings["smtppassword"].ToString();

        string emailFrom = "iabazaarsale@yahoo.com";
        string password = "Ia66197816681239";


        string emailTo = toemail;
        string subject = "Hello";
        string body = "Dear Customer, Your Order at Iabazaar have successfully placed. Now we are moving to ship your Order Please Note down your Order Number: " + item_number;
        
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            // Can set to false, if you are sending pure text.

            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }
    }

    private void CallAfterPayment()
    {
        string constring = ConfigurationManager.ConnectionStrings["con"].ToString();
        SqlConnection con = new SqlConnection(constring);
       
        try
        {
        //string invoice = "xxx", status = "xxx", receiver_id = "xxx", test_ipn="xxx";
        //if (Request.Form["invoice"] != null)
        //{
        //    invoice = Request.Form["invoice"].ToString();
        //}
        //if (Request.Form["payment_status"] != null)
        //{
        //    status = Request.Form["payment_status"].ToString();
        //}
        //if (Request.Form["receiver_id"] != null)
        //{
        //    receiver_id = Request.Form["receiver_id"].ToString();
        //}
        //if (Request.Form["test_ipn"] != null)
        //{
        //    test_ipn = Request.Form["test_ipn"].ToString();
        //}       

        string myData = Request.Form.ToString();

        //string myData = "mc_gross=2.00&invoice=10009&protection_eligibility=Ineligible&address_status=confirmed&item_number1=&tax=0.00&item_number2=&payer_id=VXEKN67KHFSGW&address_street=12949+Dawn+dr+Cerritos%0d%0a12949+Dawn+dr+Cerritos&payment_date=16%3a04%3a28+Mar+26%2c+2014+PDT&payment_status=Pending&charset=windows-1252&address_zip=90703&mc_shipping=0.00&mc_handling=0.00&first_name=jack&address_country_code=US&address_name=jack+martin&notify_version=3.7&custom=&payer_status=verified&business=arsalankhankudcs%40yahoo.com&address_country=United+States&num_cart_items=2&mc_handling1=0.00&mc_handling2=0.00&address_city=Cerritos&verify_sign=AGs52InFHk3cJ5j80u2Udq.A26J4Aq28qbWruJggzNaIS133TSw6rY1R&payer_email=softwares.coders%40gmail.com&mc_shipping1=0.00&mc_shipping2=0.00&tax1=0.00&tax2=0.00&txn_id=9J571772SG255981F&payment_type=instant&last_name=martin&address_state=CA&item_name1=Aalishan+1105+-+B&receiver_email=arsalankhankudcs%40yahoo.com&item_name2=Shipping&quantity1=1&quantity2=1&pending_reason=unilateral&txn_type=cart&mc_gross_1=1.00&mc_currency=USD&mc_gross_2=1.00&residence_country=US&test_ipn=1&transaction_subject=&payment_gross=2.00&ipn_track_id=9f311e043cc9";



        //string var = "Invoice: " + invoice + " Status: " + status + " receiver_id: " + receiver_id + " test_ipn:" + test_ipn + " Complete Post Value: " + myData;


        //string bsql = "insert into Table_1(Name, object) values('notify','"+var+"')";
        //SqlCommand bcmd = new SqlCommand(bsql, con);
        //con.Open();
        //bcmd.ExecuteNonQuery();
        //con.Close();

        string mc_gross = string.Empty;
        string invoice = string.Empty;
        string protection_eligibility = string.Empty;
        string address_status = string.Empty;
        string payer_id = string.Empty;
        string tax = string.Empty;
        string address_street = string.Empty;
        string payment_date = string.Empty;
        string payment_status = string.Empty;
        string charset = string.Empty;
        string address_zip = string.Empty;
        string first_name = string.Empty;
        string address_country_code = string.Empty;
        string address_name = string.Empty;
        string notify_version = string.Empty;
        string custom = string.Empty;
        string payer_status = string.Empty;
        string business = string.Empty;
        string address_country = string.Empty;
        string address_city = string.Empty;
        string quantity = string.Empty;
        string verify_sign = string.Empty;
        string payer_email = string.Empty;
        string txn_id = string.Empty;
        string payment_type = string.Empty;
        string last_name = string.Empty;
        string receiver_email = string.Empty;
        string pending_reason = string.Empty;
        string txn_type = string.Empty;
        string item_name = string.Empty;
        string mc_currency = string.Empty;
        string item_number = string.Empty;
        string residence_country = string.Empty;
        string test_ipn = string.Empty;
        string handling_amount = string.Empty;
        string transaction_subject = string.Empty;
        string payment_gross = string.Empty;
        string shipping = string.Empty;
        string ipn_track_id = string.Empty;
        string address_state = string.Empty;

        string[] nameValuePairs = myData.Split('&');
        for (int i = 0; i < nameValuePairs.Length; i++)
        {
            string[] nameValue = nameValuePairs[i].Split('=');

            if (nameValue[0] == "mc_gross")
            {
                mc_gross = nameValue[1].ToString();
            }
            if (nameValue[0] == "invoice")
            {
                invoice = nameValue[1].ToString();
            }
            if (nameValue[0] == "protection_eligibility")
            {
                protection_eligibility = nameValue[1].ToString();
            }
            if (nameValue[0] == "address_status")
            {
                address_status = nameValue[1].ToString();
            }
            if (nameValue[0] == "payer_id")
            {
                payer_id = nameValue[1].ToString();
            }
            if (nameValue[0] == "tax")
            {
                tax = nameValue[1].ToString();
            }
            if (nameValue[0] == "address_street")
            {
                address_street = nameValue[1].ToString();
            }
            if (nameValue[0] == "payment_date")
            {
                payment_date = nameValue[1].ToString();
            }
            if (nameValue[0] == "payment_status")
            {
                payment_status = nameValue[1].ToString();
            }
            if (nameValue[0] == "charset")
            {
                charset = nameValue[1].ToString();
            }
            if (nameValue[0] == "address_zip")
            {
                address_zip = nameValue[1].ToString();
            }
            if (nameValue[0] == "first_name")
            {
                first_name = nameValue[1].ToString();
            }
            if (nameValue[0] == "notify_version")
            {
                notify_version = nameValue[1].ToString();
            }
            if (nameValue[0] == "custom")
            {
                custom = nameValue[1].ToString();
            }
            if (nameValue[0] == "payer_status")
            {
                payer_status = nameValue[1].ToString();
            }
            if (nameValue[0] == "business")
            {
                business = HttpUtility.UrlDecode(nameValue[1].ToString());
            }
            if (nameValue[0] == "address_country")
            {
                address_country = nameValue[1].ToString();
            }
            if (nameValue[0] == "address_city")
            {
                address_city = nameValue[1].ToString();
            }
            if (nameValue[0] == "quantity")
            {
                quantity = nameValue[1].ToString();
            }
            if (nameValue[0] == "verify_sign")
            {
                verify_sign = nameValue[1].ToString();
            }
            if (nameValue[0] == "payer_email")
            {
                payer_email = HttpUtility.UrlDecode(nameValue[1].ToString());
            }
            if (nameValue[0] == "txn_id")
            {
                txn_id = nameValue[1].ToString();
            }
            if (nameValue[0] == "payment_type")
            {
                payment_type = nameValue[1].ToString();
            }
            if (nameValue[0] == "last_name")
            {
                last_name = nameValue[1].ToString();
            }
            if (nameValue[0] == "address_state")
            {
                address_state = nameValue[1].ToString();
            }
            if (nameValue[0] == "receiver_email")
            {
                receiver_email = HttpUtility.UrlDecode(nameValue[1].ToString());
            }
            if (nameValue[0] == "pending_reason")
            {
                pending_reason = nameValue[1].ToString();
            }
            if (nameValue[0] == "txn_type")
            {
                txn_type = nameValue[1].ToString();
            }
            if (nameValue[0] == "item_name")
            {
                item_name = nameValue[1].ToString();
            }
            if (nameValue[0] == "mc_currency")
            {
                mc_currency = nameValue[1].ToString();
            }
            if (nameValue[0] == "item_number")
            {
                item_number = nameValue[1].ToString();
            }
            if (nameValue[0] == "residence_country")
            {
                residence_country = nameValue[1].ToString();
            }
            if (nameValue[0] == "test_ipn")
            {
                test_ipn = nameValue[1].ToString();
            }
            if (nameValue[0] == "handling_amount")
            {
                handling_amount = nameValue[1].ToString();
            }
            if (nameValue[0] == "transaction_subject")
            {
                transaction_subject = nameValue[1].ToString();
            }
            if (nameValue[0] == "payment_gross")
            {
                payment_gross = nameValue[1].ToString();
            }
            if (nameValue[0] == "shipping")
            {
                shipping = nameValue[1].ToString();
            }
            if (nameValue[0] == "ipn_track_id")
            {
                ipn_track_id = nameValue[1].ToString();
            }

        }


        //RequestVariable(out invoice, out protection_eligibility, out address_status, out payer_id, out tax, out address_street, out payment_date, out payment_status, out charset, out address_zip, out first_name, out address_country_code, out address_name, out notify_version, out custom, out payer_status, out business, out address_country, out address_city, out quantity, out verify_sign, out payer_email, out txn_id, out payment_type, out last_name, out receiver_email, out pending_reason, out txn_type, out item_name, out mc_currency, out item_number, out residence_country, out test_ipn, out handling_amount, out transaction_subject, out payment_gross, out shipping, out ipn_track_id);

        string qry = "insert into Paypal_Ipn (invoice,protection_eligibility,address_status,payer_id,tax,address_street,payment_date,payment_status,charset,address_zip,first_name,address_country_code,address_name,notify_version,custom,payer_status,business,address_country,address_city,quantity,verify_sign,payer_email,txn_id,payment_type,last_name,address_state,receiver_email,pending_reason,txn_type,item_name,mc_currency,item_number,residence_country,test_ipn,handling_amount,transaction_subject,payment_gross,shipping,ipn_track_id,query_string,CreatedDate,Updated_IP) values ('" + invoice + "', '" + protection_eligibility + "', '" + address_status + "', '" + payer_id + "', '" + tax + "', '" + address_street + "', '" + payment_date + "', '" + payment_status + "', '" + charset + "', '" + address_zip + "', '" + first_name + "', '" + address_country_code + "', '" + address_name + "', '" + notify_version + "', '" + custom + "', '" + payer_status + "', '" + business + "', '" + address_country + "', '" + address_city + "', '" + quantity + "', '" + verify_sign + "', '" + payer_email + "','" + txn_id + "','" + payment_type + "','" + last_name + "','" + address_city + "','" + receiver_email + "', '" + pending_reason + "', '" + txn_type + "', '" + item_name + "', '" + mc_currency + "', '" + item_number + "', '" + residence_country + "', '" + test_ipn + "', '" + handling_amount + "', '" + transaction_subject + "', '" + payment_gross + "', '" + shipping + "', '" + ipn_track_id + "', '" + myData + "','" + DateTime.Now + "','" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "')";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        if (invoice != "" && invoice != string.Empty)
        {
            string orderqry = "update dbo.Orders set OrderStatus = '" + payment_status + "' where OrderNumber =" + invoice;
            SqlCommand cmdquery = new SqlCommand(orderqry, con);
            con.Open();
            cmdquery.ExecuteNonQuery();
            con.Close();
        }

        if (payer_status == "VERIFIED" || payer_status == "verified")
        {
            if (payment_status == "COMPLETED" || payment_status == "completed")
            {

                    OrdersRepository _OrdersRepository = new OrdersRepository();
                    DataSet order = _OrdersRepository.GetOrdersData(Convert.ToInt32(invoice));
                    string Email = order.Tables[0].Rows[0]["Email"].ToString();
                    EmailToCustomer(item_number, Email);

                // receiver_email 
                // mc_gross
                // mc_currency
                // item_name 
                // item_number

            }

        }
        }
        catch (Exception ex)
        {
            string qry = "insert into ErrorLogs (ErrorLogType,ErrorLogClass,Error,CreationDate,UpdatedIP) values ('PaymentNotification', 'noify.aspx', '" + ex.ToString().Replace("'", " ") + "', '" + DateTime.Now + "', '" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "')";
            SqlCommand cmd = new SqlCommand(qry, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }

    private void RequestVariable(out string invoice, out string protection_eligibility, out string address_status, out string payer_id, out string tax, out string address_street, out string payment_date, out string payment_status, out string charset, out string address_zip, out string first_name, out string address_country_code, out string address_name, out string notify_version, out string custom, out string payer_status, out string business, out string address_country, out string address_city, out string quantity, out string verify_sign, out string payer_email, out string txn_id, out string payment_type, out string last_name, out string receiver_email, out string pending_reason, out string txn_type, out string item_name, out string mc_currency, out string item_number, out string residence_country, out string test_ipn, out string handling_amount, out string transaction_subject, out string payment_gross, out string shipping, out string ipn_track_id)
    {

        // variable bunch
        invoice = string.Empty;
        if (Request.QueryString["invoice"] != null)
        {
            invoice = Request.QueryString["invoice"];
        }
        //invoice bunch end

        //string protection_eligibility = Request.QueryString["protection_eligibility"];

        protection_eligibility = string.Empty;
        if (Request.QueryString["protection_eligibility"] != null)
        {
            protection_eligibility = Request.QueryString["protection_eligibility"];
        }

        //string address_status = Request.QueryString["address_status"];
        address_status = string.Empty;
        if (Request.QueryString["address_status"] != null)
        {
            address_status = Request.QueryString["address_status"];
        }

        //string payer_id = Request.QueryString["payer_id"];
        payer_id = string.Empty;
        if (Request.QueryString["payer_id"] != null)
        {
            payer_id = Request.QueryString["payer_id"];
        }

        //string tax = Request.QueryString["tax"];
        tax = string.Empty;
        if (Request.QueryString["tax"] != null)
        {
            tax = Request.QueryString["tax"];
        }

        //string address_street = Request.QueryString["address_street"];
        address_street = string.Empty;
        if (Request.QueryString["address_street"] != null)
        {
            address_street = Request.QueryString["address_street"];
        }

        //string payment_date = Request.QueryString["payment_date"];
        payment_date = string.Empty;
        if (Request.QueryString["payment_date"] != null)
        {
            payment_date = Request.QueryString["payment_date"];
        }
        //string payment_status = Request.QueryString["payment_status"];
        payment_status = string.Empty;
        if (Request.QueryString["payment_status"] != null)
        {
            payment_status = Request.QueryString["payment_status"];
        }
        //string charset = Request.QueryString["charset"];
        charset = string.Empty;
        if (Request.QueryString["charset"] != null)
        {
            charset = Request.QueryString["charset"];
        }
        //string address_zip = Request.QueryString["address_zip"];
        address_zip = string.Empty;
        if (Request.QueryString["address_zip"] != null)
        {
            address_zip = Request.QueryString["address_zip"];
        }
        //string first_name = Request.QueryString["first_name"];
        first_name = string.Empty;
        if (Request.QueryString["first_name"] != null)
        {
            first_name = Request.QueryString["first_name"];
        }
        //string address_country_code = Request.QueryString["address_country_code"];
        address_country_code = string.Empty;
        if (Request.QueryString["address_country_code"] != null)
        {
            address_country_code = Request.QueryString["address_country_code"];
        }
        //string address_name = Request.QueryString["address_name"];
        address_name = string.Empty;
        if (Request.QueryString["address_name"] != null)
        {
            address_name = Request.QueryString["address_name"];
        }
        // string notify_version = Request.QueryString["notify_version"];
        notify_version = string.Empty;
        if (Request.QueryString["notify_version"] != null)
        {
            notify_version = Request.QueryString["notify_version"];
        }
        // string custom = Request.QueryString["custom"];
        custom = string.Empty;
        if (Request.QueryString["custom"] != null)
        {
            custom = Request.QueryString["custom"];
        }
        // string payer_status = Request.QueryString["payer_status"];
        payer_status = string.Empty;
        if (Request.QueryString["payer_status"] != null)
        {
            payer_status = Request.QueryString["payer_status"];
        }
        // string business = Request.QueryString["business"];
        business = string.Empty;
        if (Request.QueryString["business"] != null)
        {
            business = Request.QueryString["business"];
        }
        //string address_country = Request.QueryString["address_country"];
        address_country = string.Empty;
        if (Request.QueryString["address_country"] != null)
        {
            address_country = Request.QueryString["address_country"];
        }
        //string address_city = Request.QueryString["address_city"];
        address_city = string.Empty;
        if (Request.QueryString["address_city"] != null)
        {
            address_city = Request.QueryString["address_city"];
        }
        //string quantity = Request.QueryString["quantity"];
        quantity = string.Empty;
        if (Request.QueryString["quantity"] != null)
        {
            quantity = Request.QueryString["quantity"];
        }
        //string verify_sign = Request.QueryString["verify_sign"];
        verify_sign = string.Empty;
        if (Request.QueryString["verify_sign"] != null)
        {
            verify_sign = Request.QueryString["verify_sign"];
        }
        //string payer_email = Request.QueryString["payer_email"];
        payer_email = string.Empty;
        if (Request.QueryString["payer_email"] != null)
        {
            payer_email = Request.QueryString["payer_email"];
        }
        //string txn_id = Request.QueryString["txn_id"];
        txn_id = string.Empty;
        if (Request.QueryString["txn_id"] != null)
        {
            txn_id = Request.QueryString["txn_id"];
        }
        //string payment_type = Request.QueryString["payment_type"];
        payment_type = string.Empty;
        if (Request.QueryString["payment_type"] != null)
        {
            payment_type = Request.QueryString["payment_type"];
        }
        //string last_name = Request.QueryString["last_name"];
        last_name = string.Empty;
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
        receiver_email = string.Empty;
        if (Request.QueryString["receiver_email"] != null)
        {
            receiver_email = Request.QueryString["receiver_email"];
        }
        //string pending_reason = Request.QueryString["pending_reason"];
        pending_reason = string.Empty;
        if (Request.QueryString["pending_reason"] != null)
        {
            pending_reason = Request.QueryString["pending_reason"];
        }
        //string txn_type = Request.QueryString["txn_type"];
        txn_type = string.Empty;
        if (Request.QueryString["txn_type"] != null)
        {
            txn_type = Request.QueryString["txn_type"];
        }
        //string item_name = Request.QueryString["item_name"];
        item_name = string.Empty;
        if (Request.QueryString["item_name"] != null)
        {
            item_name = Request.QueryString["item_name"];
        }
        //string mc_currency = Request.QueryString["mc_currency"];
        mc_currency = string.Empty;
        if (Request.QueryString["mc_currency"] != null)
        {
            mc_currency = Request.QueryString["mc_currency"];
        }
        //string item_number = Request.QueryString["item_number"];
        item_number = string.Empty;
        if (Request.QueryString["item_number"] != null)
        {
            item_number = Request.QueryString["item_number"];
        }
        //string residence_country = Request.QueryString["residence_country"];
        residence_country = string.Empty;
        if (Request.QueryString["residence_country"] != null)
        {
            residence_country = Request.QueryString["residence_country"];
        }
        //string test_ipn = Request.QueryString["test_ipn"];
        test_ipn = string.Empty;
        if (Request.QueryString["test_ipn"] != null)
        {
            test_ipn = Request.QueryString["test_ipn"];
        }
        //string handling_amount = Request.QueryString["handling_amount"];
        handling_amount = string.Empty;
        if (Request.QueryString["handling_amount"] != null)
        {
            handling_amount = Request.QueryString["handling_amount"];
        }
        //string transaction_subject = Request.QueryString["transaction_subject"];
        transaction_subject = string.Empty;
        if (Request.QueryString["transaction_subject"] != null)
        {
            transaction_subject = Request.QueryString["transaction_subject"];
        }
        //string payment_gross = Request.QueryString["payment_gross"];
        payment_gross = string.Empty;
        if (Request.QueryString["payment_gross"] != null)
        {
            payment_gross = Request.QueryString["payment_gross"];
        }
        //string shipping = Request.QueryString["shipping"];
        shipping = string.Empty;
        if (Request.QueryString["shipping"] != null)
        {
            shipping = Request.QueryString["shipping"];
        }
        //string ipn_track_id = Request.QueryString["ipn_track_id"];
        ipn_track_id = string.Empty;
        if (Request.QueryString["ipn_track_id"] != null)
        {
            ipn_track_id = Request.QueryString["ipn_track_id"];
        }
    }

  
}