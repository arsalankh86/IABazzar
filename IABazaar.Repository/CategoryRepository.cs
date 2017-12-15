using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace IABazaar.Repository
{
		
	public partial class CategoryRepository: CategoryRepositoryBase
	{

        public Category GetCategoryByProductID(int ProductID)
        {
            string sql = "select c.* from Category c, ProductCategory pc where pc.CategoryID = c.CategoryID and c.Deleted = 0 and pc.ProductID=@ProductID ";
            SqlParameter parameter = new SqlParameter("@ProductID", ProductID);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
            return CategoryFromDataRow(ds.Tables[0].Rows[0]);
        }

        public virtual bool PreInsertCategory(Category entity)
        {

            try
            {
                string sql = @"Insert into Category ( 
				[Name]
				,[SEKeywords]
				,[SEName]
				 )
				Values
				(  @Name
				, @SEKeywords
				, @SEName
				);
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName)};
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                if (identity == DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
	
	
}
