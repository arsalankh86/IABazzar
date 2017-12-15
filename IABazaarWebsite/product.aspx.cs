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

public partial class product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        int CategoryID = 0;

        if (Page.RouteData.Values["id"] != null)
        {
            CategoryID = Convert.ToInt32(Page.RouteData.Values["id"].ToString());
            ProductRepository productrep = new ProductRepository();
            CategoryRepository catrep = new CategoryRepository();

            Category category = new Category();
            category = catrep.GetCategory(CategoryID);
            lblcatname.Text = category.Name;
            lblbcatname.Text = category.Name;
            lblcatdescription.Text = category.Description;
            catimg.Alt = category.Name;

            
            MetaKeywords = category.Name;
            MetaDescription = category.Name;
            catimg.Src = category.ImageFilenameOverride;


            DataSet dsp = new DataSet();
            dsp = productrep.GetAllProductByCategoryId(CategoryID);
            rptViewCart.DataSource = dsp;
            rptViewCart.DataBind();

            DataSet dsSp = new DataSet();
            dsSp = productrep.GetSpecialProducts(CategoryID);
            ViewCart.DataSource = dsSp;
            ViewCart.DataBind();
            //get repeter and bind dsSp

        }


        //if(Request.QueryString["cid"] !=null)
        //{
        //    CategoryID = Convert.ToInt32(Request.QueryString["cid"].ToString());
        //    ProductRepository productrep = new ProductRepository();

        //    DataSet dsp = new DataSet();
        //    dsp = productrep.GetAllProductByCategoryId(CategoryID);
        //    rptViewCart.DataSource = dsp.Tables[0];
        //    rptViewCart.DataBind();
        //}

       

    
    }

    protected void ViewCart_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
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

        catch
        {
            //Response.Redirect("Wishlist.aspx");
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

        catch(Exception ex)
        {
            //Response.Redirect("Wishlist.aspx");
        }
    }
}