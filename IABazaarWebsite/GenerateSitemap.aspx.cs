using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using IABazaar.Core;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class GenerateSitemap : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
   
    protected void btngeneratesitemap_Click(object sender, EventArgs e)
    {
        XmlWriter writer = XmlWriter.Create(Server.MapPath("SiteMap.xml"));

        writer.WriteStartDocument();
        writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

        CategoryRepository catrep = new CategoryRepository();
        DataSet category = new DataSet();
        category = catrep.GetAllIABazaarCategory();

        foreach (DataRow dr in category.Tables[0].Rows)
        {
            string url = "http://www.iabazaar.com/cc-" + dr["SeName"].ToString() + "-" + dr["CategoryID"].ToString();
            WriteTag("1", "Daily", url, writer);
        }
                
        
        ProductRepository productrep = new ProductRepository();
        DataSet product = new DataSet();
        product = productrep.GetAllIABazaarProduct();

        foreach (DataRow dr in product.Tables[0].Rows)
        {
            string url = "http://www.iabazaar.com/" + dr["SeName"].ToString() + "-" + dr["ProductID"].ToString();
            WriteTag("1", "Daily", url, writer);
        }

        //WriteTag("0.6", "Yearly", "http://www.delshad.ir/Contact.aspx", writer);
        //WriteTag("0.8", "Monthly", "http://www.delshad.ir/About.aspx", writer);

        writer.WriteEndDocument();

        writer.Close();

        Response.Redirect("SiteMap.xml");

    }

    private void WriteTag(string Priority, string freq,
           string Navigation, XmlWriter MyWriter)
    {
        MyWriter.WriteStartElement("url");

        MyWriter.WriteStartElement("loc");
        MyWriter.WriteValue(Navigation);
        MyWriter.WriteEndElement();

        string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;


        MyWriter.WriteStartElement("changefreq");
        MyWriter.WriteValue(freq);
        MyWriter.WriteEndElement();

        MyWriter.WriteStartElement("priority");
        MyWriter.WriteValue(Priority);
        MyWriter.WriteEndElement();

        //MyWriter.WriteStartElement("lastmod");
        //MyWriter.WriteValue(date);
        //MyWriter.WriteEndElement();

        MyWriter.WriteEndElement();
    }
}