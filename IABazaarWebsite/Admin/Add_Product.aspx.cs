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
using System.Text;

public partial class Add_Product : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (IsPostBack)
            return;

        BindDDlProduct();
        BindGridviw();
       
    
    }

    private void BindGridviw()
    {
        SqlConnection con = new SqlConnection(webcon);
        string qry = "select ProductID,Name,Summary,SEName,Costinrupee,Description,Costindollar,Profitpriceinrupee,Profitpriceindollar,profit,StichedPrice from Product";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    private void BindDDlProduct()
    {
        SqlConnection con = new SqlConnection(webcon);
        string qry = "Select CategoryID,Name from Category";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);

        ddlCategory.DataValueField = ds.Tables[0].Columns[0].ToString();
        ddlCategory.DataTextField = ds.Tables[0].Columns[1].ToString();
        ddlCategory.DataSource = ds.Tables[0];
        ddlCategory.DataBind();
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductRepository productrep = new ProductRepository();
        ProductCategoryRepository productcatrep = new ProductCategoryRepository();

                string name = txtname.Text;
                if (txtname.Text != string.Empty)
                {
                    try
                    {
                        Product product = new Product();
                        product.Name = txtname.Text.Trim();
                        product.Description = txtDescription.Text.Trim();
                        product.SeName = txtSEName.Text.Trim().ToLower().Replace(' ', '-').Replace('_', '-').Replace('.', '-');
                        product.SeKeywords = txtname.Text.Trim();
                        product.SeDescription = txtDescription.Text.Trim();
                        product.Summary = txtSummary.Text.Trim();
                        product.InStock = true; //Convert.ToBoolean(Convert.ToInt32(dr["InStock"].ToString().Trim()));
                        product.CreatedOn = DateTime.Now;
                        product.ProductGuid = Guid.NewGuid();


                        //////Product product = new Product();
                        //////product.Name = dr["Name"].ToString().Trim();
                        //////product.Description = dr["Description"].ToString().Trim();
                        //////product.SeName = dr["Name"].ToString().Trim().ToLower().Replace(' ', '-').Replace('_', '-');
                        //////product.SeKeywords = dr["Name"].ToString().Trim();
                        //////product.SeDescription = dr["Description"].ToString().Trim();
                        //////product.Summary = dr["Summary"].ToString().Trim();
                        //////product.InStock = true; //Convert.ToBoolean(Convert.ToInt32(dr["InStock"].ToString().Trim()));
                        //////product.CreatedOn = DateTime.Now;
                        //////product.ProductGuid = Guid.NewGuid();


                        //// Product Price
                        product.Costinrupee = Convert.ToDecimal(txtCostinrupee.Text.Trim());
                        product.Costindollar = Convert.ToDecimal(txtCostindollar.Text.Trim());
                        product.Profitpriceindollar = Convert.ToDecimal(txtProfitpriceindollar.Text.Trim());
                        product.Profitpriceinrupee = Convert.ToDecimal(txtProfitpriceinrupee.Text.Trim()); 
                        product.Profit = Convert.ToDecimal(txtprofit.Text.Trim());
                        product.StichedPrice = Convert.ToDecimal(txtStichedPrice.Text.Trim());
                        product.Deleted = 0;

                        ////product.Costinrupee = Convert.ToDecimal(dr["Costinrupee"].ToString().Trim());
                        ////product.Costindollar = Convert.ToDecimal(dr["Costindollar"].ToString().Trim());
                        ////product.Profitpriceindollar = Convert.ToDecimal(dr["Profitpriceindollar"].ToString().Trim());
                        ////product.Profitpriceinrupee = Convert.ToDecimal(dr["Profitpriceinrupee"].ToString().Trim());
                        ////product.Profit = Convert.ToDecimal(dr["Profit"].ToString().Trim());
                        ////product.StichedPrice = Convert.ToDecimal(dr["StichedPrice"].ToString().Trim());
                        ////product.Deleted = 0;


                        //// Image
                        string image = "~/Images/products/OB/" + ddlType.SelectedValue + "/" + txtimage.Text.Trim().Replace(' ', '_') + ".jpg";
                        product.ImageFilenameOverride = image;

                        int productid = productrep.PreInsertProduct(product);
                        
                        ProductCategory prodcat = new ProductCategory();
                        prodcat.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                        prodcat.ProductId = productid;
                        prodcat.CreatedOn = DateTime.Now;
                        productcatrep.InsertProductCategory(prodcat);

                        txtname.Text = string.Empty;
                        BindGridviw();

                       
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString() + " " + name);
                    }


                }
                else
                {
                    
                }
    }

    
    protected void txtCostinrupee_TextChanged(object sender, EventArgs e)
    {
        int dollarrate = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["dollarprice"].ToString());
        int profitpercentage = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["profitpercentage"].ToString());


        decimal COSTINRUPEE=0;
        decimal COSTINDOLLAR = 0;
        decimal PROFITPRICEINRUPEE = 0;
        decimal PROFITPRICEINDOLLAR = 0;
        decimal PROFIT = 0;

        COSTINRUPEE = Convert.ToDecimal(txtCostinrupee.Text);
        COSTINDOLLAR = COSTINRUPEE / dollarrate ;
        PROFITPRICEINRUPEE = ((COSTINRUPEE * profitpercentage) / 100) + COSTINRUPEE;
        PROFITPRICEINDOLLAR = PROFITPRICEINRUPEE / dollarrate;
        PROFIT = PROFITPRICEINDOLLAR - COSTINDOLLAR;

        txtCostindollar.Text = decimal.Round(COSTINDOLLAR, 2, MidpointRounding.AwayFromZero).ToString();
        txtProfitpriceinrupee.Text = decimal.Round(PROFITPRICEINRUPEE, 2, MidpointRounding.AwayFromZero).ToString();
        txtProfitpriceindollar.Text = decimal.Round(PROFITPRICEINDOLLAR, 2, MidpointRounding.AwayFromZero).ToString(); 
        txtprofit.Text = decimal.Round(PROFIT, 2, MidpointRounding.AwayFromZero).ToString();


        //int b = int.Parse(txtProfitpriceinrupee.Text);
        //int result = b / 88;
    
        //int b = int.Parse(txtProfitpriceinrupee.Text);
        //int result = ((b * 40) / 100) + a;

        //txtProfitpriceinrupee.Text = result.ToString();

        //int a = int.Parse(txtCostinrupee.Text);
        //int b = int.Parse(txtProfitpriceinrupee.Text);
        //int result = ((b * 40) / 100) + a;

        //txtProfitpriceinrupee.Text = result.ToString();


        //int d = int.Parse(txtProfitpriceindollar.Text);
        //int a = int.Parse(txtCostindollar.Text);
        //int result = (d - a);

        //txtprofit.Text = result.ToString();


        //int a = int.Parse(txtCostinrupee.Text);
        //int b = int.Parse(txtCostindollar.Text);
        //int result = a / b;
        //txtCostindollar.Text = result.ToString();

        //int b = int.Parse(txtProfitpriceinrupee.Text);
        //int result = b / 88;
        //txtProfitpriceindollar.Text = result.ToString();


    }
}