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
		
	public abstract partial class LogCustomerEventRepositoryBase : Repository 
	{
        
        public LogCustomerEventRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DBRecNo",new SearchColumn(){Name="DBRecNo",Title="DBRecNo",SelectClause="DBRecNo",WhereClause="AllRecords.DBRecNo",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EventID",new SearchColumn(){Name="EventID",Title="EventID",SelectClause="EventID",WhereClause="AllRecords.EventID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Timestamp",new SearchColumn(){Name="Timestamp",Title="Timestamp",SelectClause="Timestamp",WhereClause="AllRecords.Timestamp",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Data",new SearchColumn(){Name="Data",Title="Data",SelectClause="Data",WhereClause="AllRecords.Data",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLogCustomerEventSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLogCustomerEventBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLogCustomerEventAdvanceSearchColumns()
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
        
        
        public virtual string GetLogCustomerEventSelectClause()
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
                        	selectQuery =  "LOG_CustomerEvent."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",LOG_CustomerEvent."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual LogCustomerEvent GetLogCustomerEvent(System.Int32 DbRecNo)
		{

			string sql=GetLogCustomerEventSelectClause();
			sql+="from LOG_CustomerEvent where DBRecNo=@DBRecNo ";
			SqlParameter parameter=new SqlParameter("@DBRecNo",DbRecNo);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LogCustomerEventFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<LogCustomerEvent> GetAllLogCustomerEvent()
		{

			string sql=GetLogCustomerEventSelectClause();
			sql+="from LOG_CustomerEvent";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LogCustomerEvent>(ds, LogCustomerEventFromDataRow);
		}

		public virtual List<LogCustomerEvent> GetPagedLogCustomerEvent(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLogCustomerEventCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [DBRecNo] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([DBRecNo])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [DBRecNo] ";
            tempsql += " FROM [LOG_CustomerEvent] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("DBRecNo"))
					tempsql += " , (AllRecords.[DBRecNo])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[DBRecNo])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLogCustomerEventSelectClause()+@" FROM [LOG_CustomerEvent], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [LOG_CustomerEvent].[DBRecNo] = PageIndex.[DBRecNo] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LogCustomerEvent>(ds, LogCustomerEventFromDataRow);
			}else{ return null;}
		}

		private int GetLogCustomerEventCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM LOG_CustomerEvent as AllRecords ";
			else
				sql = "SELECT Count(*) FROM LOG_CustomerEvent as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(LogCustomerEvent))]
		public virtual LogCustomerEvent InsertLogCustomerEvent(LogCustomerEvent entity)
		{

			LogCustomerEvent other=new LogCustomerEvent();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into LOG_CustomerEvent ( [CustomerID]
				,[EventID]
				,[Timestamp]
				,[Data] )
				Values
				( @CustomerID
				, @EventID
				, @Timestamp
				, @Data );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@EventID",entity.EventId ?? (object)DBNull.Value)
					, new SqlParameter("@Timestamp",entity.Timestamp ?? (object)DBNull.Value)
					, new SqlParameter("@Data",entity.Data ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLogCustomerEvent(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(LogCustomerEvent))]
		public virtual LogCustomerEvent UpdateLogCustomerEvent(LogCustomerEvent entity)
		{

			if (entity.IsTransient()) return entity;
			LogCustomerEvent other = GetLogCustomerEvent(entity.DbRecNo);
			if (entity.Equals(other)) return entity;
			string sql=@"Update LOG_CustomerEvent set  [CustomerID]=@CustomerID
							, [EventID]=@EventID
							, [Timestamp]=@Timestamp
							, [Data]=@Data 
							 where DBRecNo=@DBRecNo";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@EventID",entity.EventId ?? (object)DBNull.Value)
					, new SqlParameter("@Timestamp",entity.Timestamp ?? (object)DBNull.Value)
					, new SqlParameter("@Data",entity.Data ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLogCustomerEvent(entity.DbRecNo);
		}

		public virtual bool DeleteLogCustomerEvent(System.Int32 DbRecNo)
		{

			string sql="delete from LOG_CustomerEvent where DBRecNo=@DBRecNo";
			SqlParameter parameter=new SqlParameter("@DBRecNo",DbRecNo);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(LogCustomerEvent))]
		public virtual LogCustomerEvent DeleteLogCustomerEvent(LogCustomerEvent entity)
		{
			this.DeleteLogCustomerEvent(entity.DbRecNo);
			return entity;
		}


		public virtual LogCustomerEvent LogCustomerEventFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			LogCustomerEvent entity=new LogCustomerEvent();
			entity.DbRecNo = (System.Int32)dr["DBRecNo"];
			entity.CustomerId = dr["CustomerID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["CustomerID"];
			entity.EventId = dr["EventID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["EventID"];
			entity.Timestamp = dr["Timestamp"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["Timestamp"];
			entity.Data = dr["Data"].ToString();
			return entity;
		}

	}
	
	
}
