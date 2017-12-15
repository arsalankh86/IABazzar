using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using IABazaar.Repository;

public partial class Issueupdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Admin"] == null)
        //{
        //    Response.Redirect("Default.aspx");
        //}

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConnectionString);
        string sql = "select * from Product";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int productid = Convert.ToInt32(dr["ProductID"].ToString());
                decimal costinrupee = Convert.ToDecimal(dr["CostinRupee"].ToString());
                decimal priceinrupee = Convert.ToDecimal(dr["Profitpriceinrupee"].ToString());

                decimal costindollar = costinrupee / 88;
                decimal priceindollar = priceinrupee / 88;
                decimal profit = priceindollar - costindollar;

                string sqlup = @"Update Product set  
							 [costindollar]=@costindollar	
                            ,[Profitpriceindollar]=@priceindollar	
                            ,[profit]=@profit		                             
							 where ProductID=@ProductID";
                SqlParameter[] parameterArray = new SqlParameter[]{
                    new SqlParameter("@ProductID",productid)
                    ,new SqlParameter("@costindollar",costindollar)
                    ,new SqlParameter("@priceindollar",priceindollar)
                    , new SqlParameter("@profit", profit)};
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sqlup, parameterArray);


            }

        }

    }

  
    protected void Button2_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConnectionString);
        string qry = "select top 26  * from Product order by 1 desc";
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        DataSet ds = new System.Data.DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int productid = Convert.ToInt32(dr["ProductID"].ToString());
                string Name = dr["Name"].ToString();
                //string sename = dr["sename"].ToString();

                
                string sename = Name.Trim().ToLower().Replace(' ', '-').Replace('_', '-').Replace('.', '-').Replace(',', '-');
                
                FixSENameIssue(sename, productid);

            }
        }



    }

    public  string RemoveWhitespace(string input)
    {
       
        return new string(input.ToCharArray()
            .Where(c => !Char.IsWhiteSpace(c))
            .ToArray());
    }


    private void FixSENameIssue(string Sename, int Productid)
    {

                SqlConnection conw = new SqlConnection(ConnectionString);
                string qry = "update Product set SEName = '" + Sename + "' where ProductID=" + Productid + "";
                SqlCommand cmd = new SqlCommand(qry, conw);

                conw.Open();
                cmd.ExecuteNonQuery();
                conw.Close();
           
    }

    public string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["con"].ToString();
        }
    }
}