using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json.Linq;

public partial class defualt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
            return;

        
        //string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        //string Location = "";

        //if (ipAddress != null && ipAddress != string.Empty)
        //{
        //    try
        //    {
        //        Location = GetIPLocation(ipAddress);
        //    }
        //    catch (Exception ex)
        //    {
        //        Location = "Not Found";
        //    }

        //    if (Location != "Pakistan")
        //    {
        //        SqlConnection con = new SqlConnection(ConnectionString);
        //        string sql = "insert into Visitors(VisitorIP, VisitorLocation, CreatedDate) Values('" + ipAddress + "', '" + Location + "', '" + DateTime.Now.ToString() + "' )";
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
    }

    //protected string GetIPLocation(string ipAddress)
    //{
    //    string reply = string.Empty;
    //    // uCountryCode = string.Empty;
    //    string uCountryName = string.Empty;
    //    // city = string.Empty;
    //    //string apiKey = ConfigurationManager.AppSettings["ipinfodbAPIKey"].ToString();
    //    //string url = ConfigurationManager.AppSettings["ipinfodbURL"].ToString().Replace("ipinfodbAPIKey", apiKey);

    //    using (WebClient wc = new WebClient())
    //    {
    //        //wc.Encoding = System.Text.Encoding.UTF8;
    //        reply = wc.UploadString("http://api.ipinfodb.com/v3/ip-country/?key=0f7f779aea16790c3566902754028970f809a288f029a95fc4abf8b95fce8bb0&ip=" + ipAddress + "&format=json", "POST", "");
    //        //reply = wc.UploadString(HttpUtility.UrlDecode(url + ipAddress + "&format=json"), "POST", "");
    //    }

    //    JObject jo = JObject.Parse(reply);

    //    if (jo["countryName"] != null)
    //    {
    //        // uCountryCode = jo["countryCode"].ToString();
    //        uCountryName = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(jo["countryName"].ToString().ToLower());
    //    }
    //    return uCountryName;
    //}

    public string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["con"].ToString();
        }
    }
}