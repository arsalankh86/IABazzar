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
		
	public abstract partial class ProductLocaleSettingRepositoryBase : Repository 
	{
        
        public ProductLocaleSettingRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSettingID",new SearchColumn(){Name="LocaleSettingID",Title="LocaleSettingID",SelectClause="LocaleSettingID",WhereClause="AllRecords.LocaleSettingID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProductLocaleSettingSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProductLocaleSettingBasicSearchColumns()
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

        public virtual List<SearchColumn> GetProductLocaleSettingAdvanceSearchColumns()
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
        
        
        public virtual string GetProductLocaleSettingSelectClause()
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
                        	selectQuery =  "ProductLocaleSetting."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ProductLocaleSetting."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ProductLocaleSetting GetProductLocaleSetting(System.Int32 ProductId)
		{

			string sql=GetProductLocaleSettingSelectClause();
			sql+="from ProductLocaleSetting where ProductID=@ProductID ";
			SqlParameter parameter=new SqlParameter("@ProductID",ProductId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProductLocaleSettingFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ProductLocaleSetting> GetAllProductLocaleSetting()
		{

			string sql=GetProductLocaleSettingSelectClause();
			sql+="from ProductLocaleSetting";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductLocaleSetting>(ds, ProductLocaleSettingFromDataRow);
		}

		public virtual List<ProductLocaleSetting> GetPagedProductLocaleSetting(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProductLocaleSettingCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ProductID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ProductID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ProductID] ";
            tempsql += " FROM [ProductLocaleSetting] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ProductID"))
					tempsql += " , (AllRecords.[ProductID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ProductID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProductLocaleSettingSelectClause()+@" FROM [ProductLocaleSetting], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ProductLocaleSetting].[ProductID] = PageIndex.[ProductID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductLocaleSetting>(ds, ProductLocaleSettingFromDataRow);
			}else{ return null;}
		}

		private int GetProductLocaleSettingCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ProductLocaleSetting as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ProductLocaleSetting as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ProductLocaleSetting))]
		public virtual ProductLocaleSetting InsertProductLocaleSetting(ProductLocaleSetting entity)
		{

			ProductLocaleSetting other=new ProductLocaleSetting();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ProductLocaleSetting ( [ProductID]
				,[LocaleSettingID]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @ProductID
				, @LocaleSettingID
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@LocaleSettingID",entity.LocaleSettingId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProductLocaleSetting(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ProductLocaleSetting))]
		public virtual ProductLocaleSetting UpdateProductLocaleSetting(ProductLocaleSetting entity)
		{

			if (entity.IsTransient()) return entity;
			ProductLocaleSetting other = GetProductLocaleSetting(entity.ProductId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ProductLocaleSetting set  [LocaleSettingID]=@LocaleSettingID
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where ProductID=@ProductID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@LocaleSettingID",entity.LocaleSettingId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProductLocaleSetting(entity.ProductId);
		}

		public virtual bool DeleteProductLocaleSetting(System.Int32 ProductId)
		{

			string sql="delete from ProductLocaleSetting where ProductID=@ProductID";
			SqlParameter parameter=new SqlParameter("@ProductID",ProductId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ProductLocaleSetting))]
		public virtual ProductLocaleSetting DeleteProductLocaleSetting(ProductLocaleSetting entity)
		{
			this.DeleteProductLocaleSetting(entity.ProductId);
			return entity;
		}


		public virtual ProductLocaleSetting ProductLocaleSettingFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ProductLocaleSetting entity=new ProductLocaleSetting();
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.LocaleSettingId = (System.Int32)dr["LocaleSettingID"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
