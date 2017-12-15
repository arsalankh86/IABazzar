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
		
	public abstract partial class CustomerGiftRegistrySearchesRepositoryBase : Repository 
	{
        
        public CustomerGiftRegistrySearchesRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomerGiftRegistrySearchesID",new SearchColumn(){Name="CustomerGiftRegistrySearchesID",Title="CustomerGiftRegistrySearchesID",SelectClause="CustomerGiftRegistrySearchesID",WhereClause="AllRecords.CustomerGiftRegistrySearchesID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerGiftRegistrySearchesGUID",new SearchColumn(){Name="CustomerGiftRegistrySearchesGUID",Title="CustomerGiftRegistrySearchesGUID",SelectClause="CustomerGiftRegistrySearchesGUID",WhereClause="AllRecords.CustomerGiftRegistrySearchesGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryGUID",new SearchColumn(){Name="GiftRegistryGUID",Title="GiftRegistryGUID",SelectClause="GiftRegistryGUID",WhereClause="AllRecords.GiftRegistryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomerGiftRegistrySearchesSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomerGiftRegistrySearchesBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomerGiftRegistrySearchesAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomerGiftRegistrySearchesSelectClause()
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
                        	selectQuery =  "CustomerGiftRegistrySearches."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomerGiftRegistrySearches."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomerGiftRegistrySearches GetCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId)
		{

			string sql=GetCustomerGiftRegistrySearchesSelectClause();
			sql+="from CustomerGiftRegistrySearches where CustomerGiftRegistrySearchesID=@CustomerGiftRegistrySearchesID ";
			SqlParameter parameter=new SqlParameter("@CustomerGiftRegistrySearchesID",CustomerGiftRegistrySearchesId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomerGiftRegistrySearchesFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomerGiftRegistrySearches> GetAllCustomerGiftRegistrySearches()
		{

			string sql=GetCustomerGiftRegistrySearchesSelectClause();
			sql+="from CustomerGiftRegistrySearches";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerGiftRegistrySearches>(ds, CustomerGiftRegistrySearchesFromDataRow);
		}

		public virtual List<CustomerGiftRegistrySearches> GetPagedCustomerGiftRegistrySearches(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomerGiftRegistrySearchesCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomerGiftRegistrySearchesID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomerGiftRegistrySearchesID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomerGiftRegistrySearchesID] ";
            tempsql += " FROM [CustomerGiftRegistrySearches] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomerGiftRegistrySearchesID"))
					tempsql += " , (AllRecords.[CustomerGiftRegistrySearchesID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomerGiftRegistrySearchesID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomerGiftRegistrySearchesSelectClause()+@" FROM [CustomerGiftRegistrySearches], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomerGiftRegistrySearches].[CustomerGiftRegistrySearchesID] = PageIndex.[CustomerGiftRegistrySearchesID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerGiftRegistrySearches>(ds, CustomerGiftRegistrySearchesFromDataRow);
			}else{ return null;}
		}

		private int GetCustomerGiftRegistrySearchesCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomerGiftRegistrySearches as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomerGiftRegistrySearches as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomerGiftRegistrySearches))]
		public virtual CustomerGiftRegistrySearches InsertCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity)
		{

			CustomerGiftRegistrySearches other=new CustomerGiftRegistrySearches();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomerGiftRegistrySearches ( [CustomerGiftRegistrySearchesGUID]
				,[CustomerID]
				,[GiftRegistryGUID]
				,[CreatedOn] )
				Values
				( @CustomerGiftRegistrySearchesGUID
				, @CustomerID
				, @GiftRegistryGUID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerGiftRegistrySearchesID",entity.CustomerGiftRegistrySearchesId)
					, new SqlParameter("@CustomerGiftRegistrySearchesGUID",entity.CustomerGiftRegistrySearchesGuid)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@GiftRegistryGUID",entity.GiftRegistryGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomerGiftRegistrySearches(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomerGiftRegistrySearches))]
		public virtual CustomerGiftRegistrySearches UpdateCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity)
		{

			if (entity.IsTransient()) return entity;
			CustomerGiftRegistrySearches other = GetCustomerGiftRegistrySearches(entity.CustomerGiftRegistrySearchesId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomerGiftRegistrySearches set  [CustomerGiftRegistrySearchesGUID]=@CustomerGiftRegistrySearchesGUID
							, [CustomerID]=@CustomerID
							, [GiftRegistryGUID]=@GiftRegistryGUID
							, [CreatedOn]=@CreatedOn 
							 where CustomerGiftRegistrySearchesID=@CustomerGiftRegistrySearchesID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerGiftRegistrySearchesID",entity.CustomerGiftRegistrySearchesId)
					, new SqlParameter("@CustomerGiftRegistrySearchesGUID",entity.CustomerGiftRegistrySearchesGuid)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@GiftRegistryGUID",entity.GiftRegistryGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomerGiftRegistrySearches(entity.CustomerGiftRegistrySearchesId);
		}

		public virtual bool DeleteCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId)
		{

			string sql="delete from CustomerGiftRegistrySearches where CustomerGiftRegistrySearchesID=@CustomerGiftRegistrySearchesID";
			SqlParameter parameter=new SqlParameter("@CustomerGiftRegistrySearchesID",CustomerGiftRegistrySearchesId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomerGiftRegistrySearches))]
		public virtual CustomerGiftRegistrySearches DeleteCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity)
		{
			this.DeleteCustomerGiftRegistrySearches(entity.CustomerGiftRegistrySearchesId);
			return entity;
		}


		public virtual CustomerGiftRegistrySearches CustomerGiftRegistrySearchesFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomerGiftRegistrySearches entity=new CustomerGiftRegistrySearches();
			entity.CustomerGiftRegistrySearchesId = (System.Int32)dr["CustomerGiftRegistrySearchesID"];
			entity.CustomerGiftRegistrySearchesGuid = (System.Guid)dr["CustomerGiftRegistrySearchesGUID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.GiftRegistryGuid = (System.Guid)dr["GiftRegistryGUID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
