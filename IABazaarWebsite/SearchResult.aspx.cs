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


public partial class SearchResult : System.Web.UI.Page
{

    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
       
        if (Request.QueryString["searchvalue"] != null)
        {
            string txtsearchText = Request.QueryString["searchvalue"].ToString();


            if (txtsearchText == "Search")
            {
                SqlConnection con = new SqlConnection(webcon);
                //string qry = "select SEName,ProductID,Name,Profitpriceindollar From dbo.Product";
                string qry = "select *, (Profitpriceindollar + 10) as promoamount From dbo.Product where Deleted = 0";
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(qry, con);
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    //lblerror.Visible = true;
                }
                else
                {

                    rptSearchProduct.DataSource = dt;
                    rptSearchProduct.DataBind();
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(webcon);
                //string qry = "select SEName,ProductID,Name,Profitpriceindollar From dbo.Product where Name like '%" + txtsearchText + "%' ";
                string qry = "select *, (Profitpriceindollar + 10) as promoamount from Product where Deleted = 0 and Name like '%" + txtsearchText + "%' ";
                
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(qry, con);
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    lblerror.Visible = true;
                }
                else
                {
                    rptSearchProduct.DataSource = dt;
                    rptSearchProduct.DataBind();
                }
            }


        }
   
    }

    protected void ViewCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {

            int id = Convert.ToInt32(e.CommandArgument.ToString());
            ProductRepository productrep = new ProductRepository();

            DataSet product = new DataSet();
            product = productrep.GetProductDataSet(id);

            string link = product.Tables[0].Rows[0]["SeName"] + "-" + id;
            Response.Redirect(link, true);
        }
        //Product.aspx?nodotnet=1

        catch (Exception ex)
        {
            //Response.Redirect("Wishlist.aspx");
        }
    }
}