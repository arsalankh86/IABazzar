using System;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using IABazaar.Core;
using IABazaar.Core.Entities;


namespace IABazaar.Repository
{
		
	public abstract partial class ProductViewRepositoryBase : Repository 
	{
        
        public ProductViewRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ViewID",new SearchColumn(){Name="ViewID",Title="ViewID",SelectClause="ViewID",WhereClause="AllRecords.ViewID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerViewID",new SearchColumn(){Name="CustomerViewID",Title="CustomerViewID",SelectClause="CustomerViewID",WhereClause="AllRecords.CustomerViewID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ViewDate",new SearchColumn(){Name="ViewDate",Title="ViewDate",SelectClause="ViewDate",WhereClause="AllRecords.ViewDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProductViewSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProductViewBasicSearchColumns()
        {
			Dictionary<string, string> columnList = new Dictionary<string, string>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (keyValuePair.Value.IsBasicSearchColumm)
                {
                    columnList.Add(keyValuePair.Key, keyValuePair.Value.Title);
                }
            }
            return columnList;
        }

        public virtual List<SearchColumn> GetProductViewAdvanceSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (keyValuePair.Value.IsAdvanceSearchColumn)
                {
                    searchColumns.Add(keyValuePair.Value);
                }
            }
            return searchColumns;
        }
        
        
        public virtual string GetProductViewSelectClause()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            string selectQuery=string.Empty;
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (!keyValuePair.Value.IgnoreForDefaultSelect)
                {
					if (keyValuePair.Value.IsForeignColumn)
                	{
						if(string.IsNullOrEmpty(selectQuery))
						{
							selectQuery = "("+keyValuePair.Value.SelectClause+") as \""+keyValuePair.Key+"\"";
						}
						else
						{
							selectQuery += ",(" + keyValuePair.Value.SelectClause + ") as \"" + keyValuePair.Key + "\"";
						}
                	}
                	else
                	{
                    	if (string.IsNullOrEmpty(selectQuery))
                    	{
                        	selectQuery =  "ProductView."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ProductView."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ProductView GetProductView(System.Int32 ViewId)
		{

			string sql=GetProductViewSelectClause();
			sql+="from ProductView where ViewID=@ViewID ";
			SqlParameter parameter=new SqlParameter("@ViewID",ViewId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProductViewFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ProductView> GetAllProductView()
		{

			string sql=GetProductViewSelectClause();
			sql+="from ProductView";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductView>(ds, ProductViewFromDataRow);
		}

		public virtual List<ProductView> GetPagedProductView(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProductViewCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ViewID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ViewID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ViewID] ";
            tempsql += " FROM [ProductView] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ViewID"))
					tempsql += " , (AllRecords.[ViewID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ViewID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProductViewSelectClause()+@" FROM [ProductView], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ProductView].[ViewID] = PageIndex.[ViewID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductView>(ds, ProductViewFromDataRow);
			}else{ return null;}
		}

		private int GetProductViewCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ProductView as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ProductView as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ProductView))]
		public virtual ProductView InsertProductView(ProductView entity)
		{

			ProductView other=new ProductView();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ProductView ( [CustomerViewID]
				,[ProductID]
				,[ViewDate] )
				Values
				( @CustomerViewID
				, @ProductID
				, @ViewDate );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ViewID",entity.ViewId)
					, new SqlParameter("@CustomerViewID",entity.CustomerViewId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@ViewDate",entity.ViewDate)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProductView(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ProductView))]
		public virtual ProductView UpdateProductView(ProductView entity)
		{

			if (entity.IsTransient()) return entity;
			ProductView other = GetProductView(entity.ViewId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ProductView set  [CustomerViewID]=@CustomerViewID
							, [ProductID]=@ProductID
							, [ViewDate]=@ViewDate 
							 where ViewID=@ViewID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ViewID",entity.ViewId)
					, new SqlParameter("@CustomerViewID",entity.CustomerViewId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@ViewDate",entity.ViewDate)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProductView(entity.ViewId);
		}

		public virtual bool DeleteProductView(System.Int32 ViewId)
		{

			string sql="delete from ProductView where ViewID=@ViewID";
			SqlParameter parameter=new SqlParameter("@ViewID",ViewId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ProductView))]
		public virtual ProductView DeleteProductView(ProductView entity)
		{
			this.DeleteProductView(entity.ViewId);
			return entity;
		}


		public virtual ProductView ProductViewFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ProductView entity=new ProductView();
			entity.ViewId = (System.Int32)dr["ViewID"];
			entity.CustomerViewId = dr["CustomerViewID"].ToString();
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.ViewDate = (System.DateTime)dr["ViewDate"];
			return entity;
		}

	}
	
	
}
