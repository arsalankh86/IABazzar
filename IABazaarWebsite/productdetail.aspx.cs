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

public partial class productdetail : System.Web.UI.Page
{
    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;


        //DataSet ds = new DataSet();
        //ds = prorep.khanGetProduct(Convert.ToInt32(ID));


        //string ID = Request.QueryString["nodotnet"].ToString();

        //ProductRepository prorep = new ProductRepository();

        //lblName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        //lblPrice.Text = ds.Tables[0].Rows[0]["Profitpriceindollar"].ToString();
        //hdnid.Value = ID;

        //imranimage.ImageUrl = ds.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();

        int ProductID = 0;
        if (Page.RouteData.Values["id"] != null)
        {
            ProductID = Convert.ToInt32(Page.RouteData.Values["id"].ToString());
            ViewState["ProductID"] = ProductID;
            ProductRepository productrep = new ProductRepository();

            DataSet product = new DataSet();
            product = productrep.GetProductDataSet(ProductID);

            if (product == null)
            {
                btnaddtocart.Enabled = false;
                btnaddtocart0.Enabled = false;
                return;
            }

            CategoryRepository catrep = new CategoryRepository();
            Category category = new Category();
            category = catrep.GetCategoryByProductID(ProductID);
            lblcatname.Text = category.Name;
            lblbcatname.NavigateUrl = "/cc-" + category.SeName + "-" + category.CategoryId;
            lblbcatname.Text = category.Name;


               
            ViewState["Product"] = product;


            lblprice.Text = decimal.Round(Convert.ToDecimal(product.Tables[0].Rows[0]["Profitpriceindollar"].ToString()), 2, MidpointRounding.AwayFromZero).ToString();
            //lblname.Text = product.Tables[0].Rows[0]["Name"].ToString();
            lblproductname.Text = product.Tables[0].Rows[0]["Name"].ToString();
            lblbpname.Text = product.Tables[0].Rows[0]["Name"].ToString();
            lblDescribe.Text = product.Tables[0].Rows[0]["Description"].ToString();
            hdnproductid.Value = product.Tables[0].Rows[0]["ProductId"].ToString();
            ViewState["ImagePath"] = product.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();
            image.Src = product.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();
            image.Alt = product.Tables[0].Rows[0]["Name"].ToString();
            zoomc.Title = product.Tables[0].Rows[0]["Name"].ToString();
            zoom1.Title = product.Tables[0].Rows[0]["Name"].ToString();
            zoom1.HRef = product.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();
            zoomc.HRef = product.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();
            lblpromoprice.Text = Convert.ToDecimal(Convert.ToDecimal(product.Tables[0].Rows[0]["Profitpriceindollar"].ToString()) + 10).ToString();

            MetaKeywords = product.Tables[0].Rows[0]["Name"].ToString();
            MetaDescription = product.Tables[0].Rows[0]["SEDescription"].ToString();
            Title = product.Tables[0].Rows[0]["SETitle"].ToString();
         

                if (!DBNull.Value.Equals(product.Tables[0].Rows[0]["InStock"]))
                {
                    bool Instock = Convert.ToBoolean(product.Tables[0].Rows[0]["InStock"]);
                    if (Instock == true)
                        lblstock.Text = "In Stock";
                    else
                    {
                        lblstock.Text = "Out of Stock";
                        lblstock.ForeColor = System.Drawing.Color.Red;
                        btnaddtocart.Enabled = false;
                        btnaddtocart0.Enabled = false;
                        
                    }
                }

            DataTable dt = new DataTable();
            dt.Columns.Add("stprice");
           

            string stichedprice = "0";
            ViewState["stichedprice"] = "0";
            if (product.Tables[0].Rows[0]["StichedPrice"].ToString() != string.Empty)
            {
                stichedprice = product.Tables[0].Rows[0]["StichedPrice"].ToString() + "";
                ViewState["stichedprice"] = product.Tables[0].Rows[0]["StichedPrice"].ToString();
            }




            if (Convert.ToDecimal(stichedprice) != 0)
            {
                DataRow dr1 = dt.NewRow();
                dr1[0] = "Un-stitched";
                dt.Rows.Add(dr1);

                if (category.CategoryId != 97 && category.CategoryId != 98 && category.CategoryId != 99 &&
    category.CategoryId != 100 && category.CategoryId != 101 && category.CategoryId != 102)
                {
                    DataRow dr2 = dt.NewRow();
                    dr2[0] = "X-Small + $" + stichedprice;
                    dt.Rows.Add(dr2);
                }

              
                DataRow dr3 = dt.NewRow();
                dr3[0] = "Small  + $" + stichedprice;
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();
                dr4[0] = "Medium + $" + stichedprice;
                dt.Rows.Add(dr4);

                DataRow dr5 = dt.NewRow();
                dr5[0] = "Large + $" + stichedprice;
                dt.Rows.Add(dr5);

                DataRow dr6 = dt.NewRow();
                dr6[0] = "X-Large + $" + stichedprice;
                dt.Rows.Add(dr6);


                cmdsize0.DataValueField = dt.Columns[0].ToString();
                cmdsize0.DataTextField = dt.Columns[0].ToString();
                cmdsize0.DataSource = dt;
                cmdsize0.DataBind();
                
            }
            else
            {

                pnlsize.Visible = false;


                if(category.CategoryId == 97 || category.CategoryId == 98 || category.CategoryId == 99 || 
                    category.CategoryId == 100 || category.CategoryId == 101 || category.CategoryId == 102 )
                {
                    pnlsemistiched.Visible = true;
                }

                ////// For Disable size selection

                //DataRow dr3 = dt.NewRow();
                //dr3[0] = "Small";
                //dt.Rows.Add(dr3);

                //DataRow dr4 = dt.NewRow();
                //dr4[0] = "Medium";
                //dt.Rows.Add(dr4);

                //DataRow dr5 = dt.NewRow();
                //dr5[0] = "Large";
                //dt.Rows.Add(dr5);

                //cmdsize0.DataValueField = dt.Columns[0].ToString();
                //cmdsize0.DataTextField = dt.Columns[0].ToString();
                //cmdsize0.DataSource = dt;
                //cmdsize0.DataBind();

            }

            
           
        }
    }

    protected void btnaddtocart_Click(object sender, EventArgs e)
    {

        //Arsalan Work start
        DataSet product = (DataSet)ViewState["Product"];
        DataTable dt;

        string quantity = qty.SelectedValue.ToString();

        decimal completeprice = Convert.ToDecimal(product.Tables[0].Rows[0]["Profitpriceindollar"].ToString());
        if (cmdsize0.SelectedItem.Text != "Un-stitched")
        {
            completeprice = Convert.ToDecimal(product.Tables[0].Rows[0]["Profitpriceindollar"].ToString()) + Convert.ToDecimal(ViewState["stichedprice"].ToString());
        }

        if (Session["User"] != null)
        {

            Customer customer = (Customer)Session["User"];

            ShoppingCart cart = new ShoppingCart();
            cart.ProductId = Convert.ToInt32(product.Tables[0].Rows[0]["ProductId"].ToString());
            cart.ProductPrice = completeprice;
            cart.Quantity = Convert.ToInt32(quantity);
            cart.CustomerId = customer.CustomerId;
            cart.ChosenSize = cmdsize0.SelectedValue.ToString();
            //TaxRate is used for saving the Cart Total
            cart.TaxRate = Convert.ToDecimal(Convert.ToInt32(quantity) * completeprice);
            ShoppingCartRepository _ShoppingCartRepository = new ShoppingCartRepository();
            _ShoppingCartRepository.iabazaarInsertShoppingCart(cart);

            if (cmdsize0.SelectedValue != "Un-stitched")
            {
                InsertSizeDetail(customer.CustomerId, customer.Email);
            }
            
        }
        else
        {

            if (Session["Cart"] != null)
            {
                dt = (DataTable)Session["Cart"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("ProductId");
                dt.Columns.Add("ProductPrice");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("CartTotal");
                dt.Columns.Add("ImageFilenameOverride");
                dt.Columns.Add("Name");
                dt.Columns.Add("ShoppingCartRecID");
                dt.Columns.Add("ChosenSize");
            }
           
            DataRow dr = dt.NewRow();
            dr[0] = Convert.ToInt32(product.Tables[0].Rows[0]["ProductId"].ToString());
            dr[1] = completeprice;
            dr[2] = quantity;
            dr[3] = Convert.ToDecimal(Convert.ToInt32(quantity) * completeprice);
            dr[4] = product.Tables[0].Rows[0]["ImageFilenameOverride"].ToString();
            dr[5] = product.Tables[0].Rows[0]["Name"].ToString();
            dr[6] = Guid.NewGuid();
            dr[7] = cmdsize0.SelectedValue.ToString();
            dt.Rows.Add(dr);

            Session["Cart"] = dt;

            if (cmdsize0.SelectedValue != "Un-stitched")
            {
                CreateSizeSession();
            }
        }

       

        Response.Redirect("cart.aspx");
        //Arsalan Code End


    }

    private void InsertSizeDetail(int CustomerId, string email)
    {
        string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        SqlConnection conw = new SqlConnection(webcon);
        string qry = "insert into CustomerProductSizeDetail(Size,CustomerID,ProductID,Email,[bustchest],[waist],[shoulder],[hip],[neckwidth],[sleevesstyle],[trouserstyle],[shirtstyle],[heightfeet],[stichinginstructions],[heightinches],CreatedDate,UpdatedIP)";
        qry += "values('"+ cmdsize0.SelectedValue.ToString() +"','" + CustomerId + "','"+Convert.ToInt32(ViewState["ProductID"].ToString())+"','" + email + "','" + ddlbustchest0.SelectedItem.Text + "','" + ddlWAIST0.SelectedItem.Text + "','" + ddlSHOULDER0.SelectedItem.Text + "','" + ddlHIP0.SelectedItem.Text + "','" + ddlNECKWIDTH0.SelectedItem.Text + "','" + ddlSleveeStyle.SelectedItem.Text + "','" + ddlTROUSERSTYLE0.SelectedItem.Text + "','" + ddlSHIRTSTYLE0.SelectedItem.Text + "','" + ddlHeight0.SelectedItem.Text + "','" + txtinstruction.Text + "','" + ddlHeightInches0.SelectedItem.Text + "','" + DateTime.Now.ToString() + "','" + ipAddress + "')";
        SqlCommand cmd = new SqlCommand(qry, conw);

        conw.Open();
        cmd.ExecuteNonQuery();
        conw.Close();
    }

    private void CreateSizeSession()
    {
            DataTable dt;

            if (Session["Size"] != null)
            {
                dt = (DataTable)Session["Size"];
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("ProductId");
                dt.Columns.Add("Size");
                dt.Columns.Add("Instruction");
                dt.Columns.Add("BUST");
                dt.Columns.Add("WAIST");
                dt.Columns.Add("NECK_WIDTH");
                dt.Columns.Add("HIP");
                dt.Columns.Add("SHOULDER");
                dt.Columns.Add("SLEEVES_STYLE");
                dt.Columns.Add("SHIRT_STYLE");
                dt.Columns.Add("TROUSER_STYLE");
                dt.Columns.Add("Height_Feet");
                dt.Columns.Add("Height_Inches");
            }
           
            DataRow dr = dt.NewRow();
            dr[0] = Convert.ToInt32(ViewState["ProductID"].ToString());
            dr[1] = cmdsize0.SelectedValue.ToString();
            dr[2] = txtinstruction.Text;
            dr[3] = ddlbustchest0.SelectedItem.Text;
            dr[4] = ddlWAIST0.SelectedItem.Text;
            dr[5] = ddlNECKWIDTH0.SelectedItem.Text;
            dr[6] = ddlHIP0.SelectedItem.Text;
            dr[7] = ddlSHOULDER0.SelectedItem.Text;
             dr[8] = ddlSleveeStyle.SelectedItem.Text;
             dr[9] = ddlSHIRTSTYLE0.SelectedItem.Text;
             dr[10] = ddlTROUSERSTYLE0.SelectedItem.Text;
             dr[11] = ddlHeight0.SelectedItem.Text;
             dr[12] = ddlHeightInches0.SelectedItem.Text;
            dt.Rows.Add(dr);

            Session["Size"] = dt;
        
    }

    protected void cmdsize0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(ViewState["stichedprice"].ToString()) != 0)
        {
            if (cmdsize0.SelectedItem.Text != "Un-stitched")
            {
                pnlsize0.Visible = true;
            }
            else
            {
                pnlsize0.Visible = false;
            }

            if (cmdsize0.SelectedItem.Text != "See Below")
            {
                pnlsize0.Visible = true;
            }

            else
            {
                pnlseeblow0.Visible = false;
            }

            string[] size = cmdsize0.SelectedItem.Text.Split('+');
            string orignalsize = size[0].ToString().TrimEnd(' ');


            if (orignalsize == "X-Small")
            {
                ddlbustchest0.SelectedItem.Text = "35";
                ddlSHOULDER0.SelectedItem.Text = "13.5";
                ddlWAIST0.SelectedItem.Text = "29";
                ddlHIP0.SelectedItem.Text = "35";
            }

            if (orignalsize == "Small")
            {
                ddlbustchest0.SelectedItem.Text = "37";
                ddlSHOULDER0.SelectedItem.Text = "14";
                ddlWAIST0.SelectedItem.Text = "32";
                ddlHIP0.SelectedItem.Text = "39";
            }

            if (orignalsize == "Medium")
            {
                ddlbustchest0.SelectedItem.Text = "39";
                ddlSHOULDER0.SelectedItem.Text = "14.5";
                ddlWAIST0.SelectedItem.Text = "34";
                ddlHIP0.SelectedItem.Text = "41";
            }

            if (orignalsize == "Large")
            {
                ddlbustchest0.SelectedItem.Text = "41";
                ddlSHOULDER0.SelectedItem.Text = "15.5";
                ddlWAIST0.SelectedItem.Text = "36";
                ddlHIP0.SelectedItem.Text = "43";
            }

            if (orignalsize == "X-Large")
            {
                ddlbustchest0.SelectedItem.Text = "44";
                ddlSHOULDER0.SelectedItem.Text = "16";
                ddlWAIST0.SelectedItem.Text = "39";
                ddlHIP0.SelectedItem.Text = "47";
            }
        }
    }

    //protected void LinkButton1_Click(Object sender, EventArgs e)

    //{
    //    //Session.Clear();
    //    //Session.RemoveAll();
    //    //Session.Abandon();
    //    //Response.Redirect("Login.aspx");
    //}

    //protected void LinkButton1_Click(object sender, CommandEventArgs e)
    //{
    //    Label1.Text = e.CommandArgument.ToString();
    //}



    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    int ProductID = 0;
    //    ProductID = Convert.ToInt32(Request.QueryString["pid"].ToString());
    //    ProductRepository productrep = new ProductRepository();

    //    Product product = new Product();
    //    product = productrep.GetProduct(ProductID);
    //    ViewState["Product"] = product;

    //    hdnproductid.Value = product.ProductId.ToString();
    //    string ID = Request.QueryString["nodotnet"].ToString();
    //    Customer cus = new Customer();
    //    int idutharahahoo = cus.CustomerId;
    //    Session["Customer"] = cus;

    //    SqlConnection conw = new SqlConnection(webcon);
    //    string qry = "insert into WishList (Customer_ID,Product_ID) values ('" + hdnproductid.ToString() + "', '" + ProductID.ToString() + "')";
    //    SqlCommand cmd = new SqlCommand(qry, conw);

    //    conw.Open();
    //    cmd.ExecuteNonQuery();
    //    conw.Close();




    //    Response.Redirect("Product.aspx");
    //}
    protected void link_button(object sender, EventArgs e)
    {

        int ProductID = 0;
        if (Page.RouteData.Values["id"] != null)
        {
            ProductID = Convert.ToInt32(Page.RouteData.Values["id"].ToString());

            if (Session["User"] != null)
            {

                Customer customer = (Customer)Session["User"];
                int cid = Convert.ToInt32(customer.CustomerId);
                Session["User"] = customer;

                SqlConnection conw = new SqlConnection(webcon);
                string qry = "insert into WishList (Customer_ID,Product_ID) values ('" + customer.CustomerId.ToString() + "', '" + ProductID.ToString() + "')";
                SqlCommand cmd = new SqlCommand(qry, conw);

                conw.Open();
                cmd.ExecuteNonQuery();
                conw.Close();
            }
        }
    }
}