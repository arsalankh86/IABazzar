using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using System.Data;

namespace IABazaar.Repository
{
		
	public partial class ProductRepository: ProductRepositoryBase
	{

        public virtual DataSet GetAllProductByCategoryId(int categoryid)
        {

            string sql = "select p.* from Product p, ProductCategory pc where pc.ProductID = p.ProductID and pc.CategoryID = " + categoryid;            
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }
    }
	
	
}
