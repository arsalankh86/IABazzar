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
using System.IO;

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

    protected string GetIPLocation_old(string ipAddress)
    {
        string reply = string.Empty;
        // uCountryCode = string.Empty;
        string uCountryName = string.Empty;
        // city = string.Empty;
        //string apiKey = ConfigurationManager.AppSettings["ipinfodbAPIKey"].ToString();
        //string url = ConfigurationManager.AppSettings["ipinfodbURL"].ToString().Replace("ipinfodbAPIKey", apiKey);

        using (WebClient wc = new WebClient())
        {
            //wc.Encoding = System.Text.Encoding.UTF8;
            reply = wc.UploadString("http://api.ipinfodb.com/v3/ip-country/?key=6c0acca858ce77139471a30f3f0809e68f3c33aeda74ba1aa5cc2f6cbe744740&ip=" + ipAddress + "&format=json", "POST", "");
            //reply = wc.UploadString(HttpUtility.UrlDecode(url + ipAddress + "&format=json"), "POST", "");
        }

        JObject jo = JObject.Parse(reply);

        if (jo["countryName"] != null)
        {
            // uCountryCode = jo["countryCode"].ToString();
            uCountryName = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(jo["countryName"].ToString().ToLower());
        }
        return uCountryName;
    }

    protected string GetIPLocation(string ipAddress)
    {
        var reply = "";
        // uCountryCode = string.Empty;
        string uCountryName = string.Empty;
        // city = string.Empty;
        //string apiKey = ConfigurationManager.AppSettings["ipinfodbAPIKey"].ToString();
        //string url = ConfigurationManager.AppSettings["ipinfodbURL"].ToString().Replace("ipinfodbAPIKey", apiKey);

        string url = "http://api.ipinfodb.com/v3/ip-country/?key=6c0acca858ce77139471a30f3f0809e68f3c33aeda74ba1aa5cc2f6cbe744740&ip=" + ipAddress + "&format=json";

        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        try
        {
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                reply = reader.ReadToEnd();
                reader.Close();
            }
        }
        catch (Exception ex)
        {
        }

        JObject jo = JObject.Parse(reply);

        if (jo["countryName"] != null)
        {
            // uCountryCode = jo["countryCode"].ToString();
            uCountryName = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(jo["countryName"].ToString().ToLower());
        }
        return uCountryName;
    }

    public string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["conn"].ToString();
        }
    }
}