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
		
	public abstract partial class CustomerSessionRepositoryBase : Repository 
	{
        
        public CustomerSessionRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomerSessionID",new SearchColumn(){Name="CustomerSessionID",Title="CustomerSessionID",SelectClause="CustomerSessionID",WhereClause="AllRecords.CustomerSessionID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SessionName",new SearchColumn(){Name="SessionName",Title="SessionName",SelectClause="SessionName",WhereClause="AllRecords.SessionName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SessionValue",new SearchColumn(){Name="SessionValue",Title="SessionValue",SelectClause="SessionValue",WhereClause="AllRecords.SessionValue",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ipaddr",new SearchColumn(){Name="ipaddr",Title="ipaddr",SelectClause="ipaddr",WhereClause="AllRecords.ipaddr",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastActivity",new SearchColumn(){Name="LastActivity",Title="LastActivity",SelectClause="LastActivity",WhereClause="AllRecords.LastActivity",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LoggedOut",new SearchColumn(){Name="LoggedOut",Title="LoggedOut",SelectClause="LoggedOut",WhereClause="AllRecords.LoggedOut",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerSessionGUID",new SearchColumn(){Name="CustomerSessionGUID",Title="CustomerSessionGUID",SelectClause="CustomerSessionGUID",WhereClause="AllRecords.CustomerSessionGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresOn",new SearchColumn(){Name="ExpiresOn",Title="ExpiresOn",SelectClause="ExpiresOn",WhereClause="AllRecords.ExpiresOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomerSessionSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomerSessionBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomerSessionAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomerSessionSelectClause()
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
                        	selectQuery =  "CustomerSession."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomerSession."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomerSession GetCustomerSession(System.Int32 CustomerSessionId)
		{

			string sql=GetCustomerSessionSelectClause();
			sql+="from CustomerSession where CustomerSessionID=@CustomerSessionID ";
			SqlParameter parameter=new SqlParameter("@CustomerSessionID",CustomerSessionId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomerSessionFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomerSession> GetAllCustomerSession()
		{

			string sql=GetCustomerSessionSelectClause();
			sql+="from CustomerSession";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerSession>(ds, CustomerSessionFromDataRow);
		}

		public virtual List<CustomerSession> GetPagedCustomerSession(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomerSessionCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomerSessionID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomerSessionID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomerSessionID] ";
            tempsql += " FROM [CustomerSession] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomerSessionID"))
					tempsql += " , (AllRecords.[CustomerSessionID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomerSessionID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomerSessionSelectClause()+@" FROM [CustomerSession], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomerSession].[CustomerSessionID] = PageIndex.[CustomerSessionID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerSession>(ds, CustomerSessionFromDataRow);
			}else{ return null;}
		}

		private int GetCustomerSessionCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomerSession as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomerSession as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomerSession))]
		public virtual CustomerSession InsertCustomerSession(CustomerSession entity)
		{

			CustomerSession other=new CustomerSession();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomerSession ( [CustomerID]
				,[SessionName]
				,[SessionValue]
				,[ipaddr]
				,[LastActivity]
				,[LoggedOut]
				,[CustomerSessionGUID]
				,[CreatedOn]
				,[ExpiresOn] )
				Values
				( @CustomerID
				, @SessionName
				, @SessionValue
				, @ipaddr
				, @LastActivity
				, @LoggedOut
				, @CustomerSessionGUID
				, @CreatedOn
				, @ExpiresOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerSessionID",entity.CustomerSessionId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@SessionName",entity.SessionName)
					, new SqlParameter("@SessionValue",entity.SessionValue ?? (object)DBNull.Value)
					, new SqlParameter("@ipaddr",entity.Ipaddr ?? (object)DBNull.Value)
					, new SqlParameter("@LastActivity",entity.LastActivity)
					, new SqlParameter("@LoggedOut",entity.LoggedOut ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerSessionGUID",entity.CustomerSessionGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomerSession(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomerSession))]
		public virtual CustomerSession UpdateCustomerSession(CustomerSession entity)
		{

			if (entity.IsTransient()) return entity;
			CustomerSession other = GetCustomerSession(entity.CustomerSessionId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomerSession set  [CustomerID]=@CustomerID
							, [SessionName]=@SessionName
							, [SessionValue]=@SessionValue
							, [ipaddr]=@ipaddr
							, [LastActivity]=@LastActivity
							, [LoggedOut]=@LoggedOut
							, [CustomerSessionGUID]=@CustomerSessionGUID
							, [CreatedOn]=@CreatedOn
							, [ExpiresOn]=@ExpiresOn 
							 where CustomerSessionID=@CustomerSessionID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerSessionID",entity.CustomerSessionId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@SessionName",entity.SessionName)
					, new SqlParameter("@SessionValue",entity.SessionValue ?? (object)DBNull.Value)
					, new SqlParameter("@ipaddr",entity.Ipaddr ?? (object)DBNull.Value)
					, new SqlParameter("@LastActivity",entity.LastActivity)
					, new SqlParameter("@LoggedOut",entity.LoggedOut ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerSessionGUID",entity.CustomerSessionGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomerSession(entity.CustomerSessionId);
		}

		public virtual bool DeleteCustomerSession(System.Int32 CustomerSessionId)
		{

			string sql="delete from CustomerSession where CustomerSessionID=@CustomerSessionID";
			SqlParameter parameter=new SqlParameter("@CustomerSessionID",CustomerSessionId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomerSession))]
		public virtual CustomerSession DeleteCustomerSession(CustomerSession entity)
		{
			this.DeleteCustomerSession(entity.CustomerSessionId);
			return entity;
		}


		public virtual CustomerSession CustomerSessionFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomerSession entity=new CustomerSession();
			entity.CustomerSessionId = (System.Int32)dr["CustomerSessionID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.SessionName = dr["SessionName"].ToString();
			entity.SessionValue = dr["SessionValue"].ToString();
			entity.Ipaddr = dr["ipaddr"].ToString();
			entity.LastActivity = (System.DateTime)dr["LastActivity"];
			entity.LoggedOut = dr["LoggedOut"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["LoggedOut"];
			entity.CustomerSessionGuid = (System.Guid)dr["CustomerSessionGUID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.ExpiresOn = (System.DateTime)dr["ExpiresOn"];
			return entity;
		}

	}
	
	
}
