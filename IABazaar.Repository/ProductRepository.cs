using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using System.Data;
using System.Data.SqlClient;

namespace IABazaar.Repository
{
		
	public partial class ProductRepository: ProductRepositoryBase
	{

        public virtual DataSet GetAllProductByCategoryId(int categoryid)
        {

            string sql = "select p.*, (p.Profitpriceindollar + 10) as promoamount from Product p, ProductCategory pc where pc.ProductID = p.ProductID and p.Deleted = 0 and pc.CategoryID = " + categoryid;            
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }

        public virtual DataSet GetSpecialProducts(int categoryid)
        {

            string sql = "select top 2 p.*, (p.Profitpriceindollar + 10) as promoamount from Product p, ProductCategory pc where pc.ProductID = p.ProductID and p.Deleted = 0 and pc.CategoryID <> " + categoryid;
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }
        public virtual int PreInsertProduct(Product entity)
        {

            try
            {
                string sql = @"Insert into Product ( 
				[Name]
				,[Description]
				,[SEKeywords]
				,[SEDescription]
				,[SETitle]
				,[SEName]
				,[ImageFilenameOverride]
				,[CreatedOn]
				,[StichedPrice]
				,[Costinrupee]
				,[Costindollar]
				,[Profitpriceinrupee]
				,[Profitpriceindollar]
				,[profit]
                ,[ProductGUID]
                ,[Summary]
                ,[InStock])
				Values
				( 
				@Name
				, @Description
				, @SEKeywords
				, @SEDescription
				, @SETitle
				, @SEName
				, @ImageFilenameOverride
				, @CreatedOn
				, @StichedPrice
				, @Costinrupee
				, @Costindollar
				, @Profitpriceinrupee
				, @Profitpriceindollar
				, @profit
                , @ProductGUID
                , @Summary 
                , @InStock
                );
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@StichedPrice",entity.StichedPrice ?? (object)DBNull.Value)
					, new SqlParameter("@Costinrupee",entity.Costinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Costindollar",entity.Costindollar ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceinrupee",entity.Profitpriceinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceindollar",entity.Profitpriceindollar ?? (object)DBNull.Value)
                , new SqlParameter("@profit",entity.Profit ?? (object)DBNull.Value)
                , new SqlParameter("@ProductGUID",entity.ProductGuid)
                , new SqlParameter("@Summary",entity.Summary)
                , new SqlParameter("@InStock",entity.InStock)
                };
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                if (identity == DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
                return Convert.ToInt32(identity);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
	
	
}
