using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using IABazaar.Core.Entities;
using IABazaar.Repository;
using System.Configuration;


public partial class Exceltodb : System.Web.UI.Page
{

    string webcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\FARAZ_MANAN_Crescent_Lawn_2014.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

           


            //string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            //                  "Data Source=" + Server.MapPath("ExcelProduct\\OBworksheet.xlsx") + ";" +
            //                 @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

          //  // For Category
          //  OleDbCommand cmd = new OleDbCommand
          //    ("select Distinct(Category) as cat from [Sheet1$]",
          //excelConnection);
            // DataSet ds = new DataSet();
            // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            // da.Fill(ds);

            

           
             //CategoryInsertion(ds);

           // //For Unstiched Product
           // OleDbCommand cmd = new OleDbCommand
           //("select * from [Unstiched$]",
           //excelConnection);
           // DataSet ds = new DataSet();
           // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           // da.Fill(ds);
           // Productinsertion(ds, "Unstiched");

        //    // For Stiched Product
        //    OleDbCommand cmd = new OleDbCommand
        //("select * from [Stiched$]",
        //excelConnection);
        //    DataSet ds = new DataSet();
        //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //    da.Fill(ds);
        //    Productinsertion(ds, "Stiched");


           // //For Fraz Mannan Product
           // OleDbCommand cmd = new OleDbCommand
           //("select * from [Sheet1$]",
           //excelConnection);
           // DataSet ds = new DataSet();
           // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           // da.Fill(ds);
           // Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void CategoryInsertion(DataSet ds)
    {
        ////nFor Category Insertion
        CategoryRepository catrep = new CategoryRepository();
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["cat"].ToString() != string.Empty)
                {
                    if (dr["cat"].ToString().Trim() != "0")
                    {
                        Category cat = new Category();
                        cat.Name = dr["cat"].ToString().Trim();
                        cat.SeKeywords = dr["cat"].ToString().Trim();
                        cat.SeName = dr["cat"].ToString().Trim().ToLower().Replace(' ', '-');
                        catrep.PreInsertCategory(cat);
                    }
                }
            }
        }
    }

    private void Productinsertion(DataSet ds, string ImageName)
    {
        ////For Product Insertion
        ProductRepository productrep = new ProductRepository();
        ProductCategoryRepository productcatrep = new ProductCategoryRepository();
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            { string name = dr["Name"].ToString();
            if (dr["Name"].ToString() != string.Empty)
            {
                try
                {
                    Product product = new Product();
                    product.Name = dr["Name"].ToString().Trim();
                    product.Description = dr["Description"].ToString().Trim();
                    product.SeName = dr["Name"].ToString().Trim().ToLower().Replace(' ', '-').Replace('_', '-');
                    product.SeKeywords = dr["Name"].ToString().Trim();
                    product.SeDescription = dr["Description"].ToString().Trim();
                    product.Summary = dr["Summary"].ToString().Trim();
                    product.InStock = true; //Convert.ToBoolean(Convert.ToInt32(dr["InStock"].ToString().Trim()));
                    product.CreatedOn = DateTime.Now;
                    product.ProductGuid = Guid.NewGuid();


                    //// Product Price
                    product.Costinrupee = Convert.ToDecimal(dr["Costinrupee"].ToString().Trim());
                    product.Costindollar = Convert.ToDecimal(dr["Costindollar"].ToString().Trim());
                    product.Profitpriceindollar = Convert.ToDecimal(dr["Profitpriceindollar"].ToString().Trim());
                    product.Profitpriceinrupee = Convert.ToDecimal(dr["Profitpriceinrupee"].ToString().Trim());
                    product.Profit = Convert.ToDecimal(dr["Profit"].ToString().Trim());
                    product.StichedPrice = Convert.ToDecimal(dr["StichedPrice"].ToString().Trim());


                    //// Image
                    string image = "~/Images/products/OB/" + ImageName + "/" + dr["ImageName"].ToString().Trim().Replace(' ', '_') + ".jpg";
                    product.ImageFilenameOverride = image;

                    int productid = productrep.PreInsertProduct(product);


                    ProductCategory prodcat = new ProductCategory();
                    prodcat.CategoryId = Convert.ToInt32(dr["catid"].ToString().Trim());
                    prodcat.ProductId = productid;
                    prodcat.CreatedOn = DateTime.Now;
                    productcatrep.InsertProductCategory(prodcat);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString() + " " + name);
                }


            }
            else
            {
                break;
            }
            }
        }
    }

    private void UpdateMetaData(DataSet ds)
    {
        
     
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int productid = 0;
                string setitle="", semetadescription= "";
                try
                {
                    productid = Convert.ToInt32(dr["ProductID"].ToString());
                    setitle = dr["Title"].ToString();
                    semetadescription = dr["Meta Descriptions"].ToString();

                    SqlConnection conw = new SqlConnection(webcon);
                    string qry = "update product set SETitle = '"+ setitle +"', SEDescription='"+ semetadescription+"' where ProductID = " + productid;
                    SqlCommand cmd = new SqlCommand(qry, conw);

                    conw.Open();
                    cmd.ExecuteNonQuery();
                    conw.Close();

                    

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString() + " " + productid);
                    }


               
            }
        }
    }
    
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\OBExcelissue.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            // For Category
            OleDbCommand cmd = new OleDbCommand
            ("select * from [ImageIssue$]",
          excelConnection);

            excelConnection.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            FixImageIssue(ds);

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void FixImageIssue(DataSet ds)
    {
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SqlConnection conw = new SqlConnection(webcon);
                string qry = "update Product set ImageFilenameOverride = '" + dr["Image"].ToString() + "' where ProductID=" + Convert.ToInt32(dr["ID"].ToString()) + "";
                SqlCommand cmd = new SqlCommand(qry, conw);

                conw.Open();
                cmd.ExecuteNonQuery();
                conw.Close();
            }
        }
    }

    private void FixSENameIssue(DataSet ds)
    {
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SqlConnection conw = new SqlConnection(webcon);
                string qry = "update Product set SEName = '" + dr["SEName"].ToString() + "' where ProductID=" + Convert.ToInt32(dr["ID"].ToString()) + "";
                SqlCommand cmd = new SqlCommand(qry, conw);

                conw.Open();
                cmd.ExecuteNonQuery();
                conw.Close();
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\OBExcelissue.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            // For Category
          //  OleDbCommand cmd = new OleDbCommand
          //  ("select * from [SENameIssue$]",
          //excelConnection);

            // For Category
            OleDbCommand cmd = new OleDbCommand
            ("select * from [mariabsename$]",
          excelConnection);
            


            excelConnection.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);

            FixSENameIssue(ds);

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnunstiched_Click(object sender, EventArgs e)
    { 
         try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                              "Data Source=" + Server.MapPath("ExcelProduct\\OBworksheet.xlsx") + ";" +
                             @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            // For Category
            OleDbCommand cmd = new OleDbCommand
                ("select Distinct(Category) as cat from [Unstiched$]",
          excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            CategoryInsertion(ds);

           // //For Unstiched Product
           // OleDbCommand cmd = new OleDbCommand
           //("select * from [Unstiched$]",
           //excelConnection);
           // DataSet ds = new DataSet();
           // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           // da.Fill(ds);
           // Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnunstichedrod_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                              "Data Source=" + Server.MapPath("ExcelProduct\\OBworksheet.xlsx") + ";" +
                             @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            //For Unstiched Product
            OleDbCommand cmd = new OleDbCommand
           ("select * from [Unstiched$]",
           excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
 
    
    protected void btnstiched_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                              "Data Source=" + Server.MapPath("ExcelProduct\\OBworksheet.xlsx") + ";" +
                             @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            // For Category
            OleDbCommand cmd = new OleDbCommand
              ("select Distinct(Category) as cat from [Stiched$]",
          excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            CategoryInsertion(ds);


            //    // For Stiched Product
            //    OleDbCommand cmd = new OleDbCommand
            //("select * from [Stiched$]",
            //excelConnection);
            //    DataSet ds = new DataSet();
            //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //    da.Fill(ds);
            //    Productinsertion(ds, "Stiched");



        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnstichedprod_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                              "Data Source=" + Server.MapPath("ExcelProduct\\OBworksheet.xlsx") + ";" +
                             @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";

            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();


            // For Stiched Product
            OleDbCommand cmd = new OleDbCommand
        ("select * from [Stiched$]",
        excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            Productinsertion(ds, "Stiched");



        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
   
    
    protected void btnfrzcresentlawn_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\FARAZ_MANAN_Crescent_Lawn_2014.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            // For Category
            OleDbCommand cmd = new OleDbCommand
              ("select Distinct(Category) as cat from [Sheet1$]",
          excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            CategoryInsertion(ds);

            
            // //For Fraz Mannan Product
            // OleDbCommand cmd = new OleDbCommand
            //("select * from [Sheet1$]",
            //excelConnection);
            // DataSet ds = new DataSet();
            // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            // da.Fill(ds);
            // Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnfrzcresentlawnprod_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\FARAZ_MANAN_Crescent_Lawn_2014.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            //For Fraz Mannan Product
            OleDbCommand cmd = new OleDbCommand
           ("select * from [Sheet1$]",
           excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }




    protected void btnnacat_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\ob_new_arrival.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            // For Category
            OleDbCommand cmd = new OleDbCommand
              ("select Distinct(Category) as cat from [FinalSheet$]",
          excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            CategoryInsertion(ds);


            // //For Fraz Mannan Product
            // OleDbCommand cmd = new OleDbCommand
            //("select * from [Sheet1$]",
            //excelConnection);
            // DataSet ds = new DataSet();
            // OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            // da.Fill(ds);
            // Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnnaprod_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\ob_new_arrival.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            //For Fraz Mannan Product
            OleDbCommand cmd = new OleDbCommand
           ("select * from [FinalSheet$]",
           excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            Productinsertion(ds, "Unstiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void indianwear_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\indianwear.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            //For Fraz Mannan Product
            OleDbCommand cmd = new OleDbCommand
           ("select * from [remdata$]",
           excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            Productinsertion(ds, "Stiched");


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
    protected void btnmeta_Click(object sender, EventArgs e)
    {
        try
        {
            string strConnection = System.Configuration.ConfigurationManager.
    ConnectionStrings["con"].ConnectionString;

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                "Data Source=" + Server.MapPath("ExcelProduct\\Final_Product_feeds.xlsx") + ";" +
                               @"Extended Properties=""Excel 12.0 Xml;HDR=Yes""";


            //Create Connection to Excel work book
            OleDbConnection excelConnection =
            new OleDbConnection(excelConnectionString);

            //Create OleDbCommand to fetch data from Excel

            excelConnection.Open();

            //For Fraz Mannan Product
            OleDbCommand cmd = new OleDbCommand
           ("select * from [Sheet1$]",
           excelConnection);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            UpdateMetaData(ds);


        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}