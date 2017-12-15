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
		
	public abstract partial class AuditLogRepositoryBase : Repository 
	{
        
        public AuditLogRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("AuditLogID",new SearchColumn(){Name="AuditLogID",Title="AuditLogID",SelectClause="AuditLogID",WhereClause="AllRecords.AuditLogID",DataType="System.Int64",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ActionDate",new SearchColumn(){Name="ActionDate",Title="ActionDate",SelectClause="ActionDate",WhereClause="AllRecords.ActionDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UpdatedCustomerID",new SearchColumn(){Name="UpdatedCustomerID",Title="UpdatedCustomerID",SelectClause="UpdatedCustomerID",WhereClause="AllRecords.UpdatedCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Details",new SearchColumn(){Name="Details",Title="Details",SelectClause="Details",WhereClause="AllRecords.Details",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PagePath",new SearchColumn(){Name="PagePath",Title="PagePath",SelectClause="PagePath",WhereClause="AllRecords.PagePath",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AuditGroup",new SearchColumn(){Name="AuditGroup",Title="AuditGroup",SelectClause="AuditGroup",WhereClause="AllRecords.AuditGroup",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetAuditLogSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetAuditLogBasicSearchColumns()
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

        public virtual List<SearchColumn> GetAuditLogAdvanceSearchColumns()
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
        
        
        public virtual string GetAuditLogSelectClause()
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
                        	selectQuery =  "AuditLog."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",AuditLog."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual AuditLog GetAuditLog(System.Int64 AuditLogId)
		{

			string sql=GetAuditLogSelectClause();
			sql+="from AuditLog where AuditLogID=@AuditLogID ";
			SqlParameter parameter=new SqlParameter("@AuditLogID",AuditLogId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return AuditLogFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<AuditLog> GetAllAuditLog()
		{

			string sql=GetAuditLogSelectClause();
			sql+="from AuditLog";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AuditLog>(ds, AuditLogFromDataRow);
		}

		public virtual List<AuditLog> GetPagedAuditLog(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetAuditLogCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [AuditLogID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([AuditLogID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [AuditLogID] ";
            tempsql += " FROM [AuditLog] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("AuditLogID"))
					tempsql += " , (AllRecords.[AuditLogID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[AuditLogID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetAuditLogSelectClause()+@" FROM [AuditLog], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [AuditLog].[AuditLogID] = PageIndex.[AuditLogID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AuditLog>(ds, AuditLogFromDataRow);
			}else{ return null;}
		}

		private int GetAuditLogCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM AuditLog as AllRecords ";
			else
				sql = "SELECT Count(*) FROM AuditLog as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(AuditLog))]
		public virtual AuditLog InsertAuditLog(AuditLog entity)
		{

			AuditLog other=new AuditLog();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into AuditLog ( [ActionDate]
				,[CustomerID]
				,[UpdatedCustomerID]
				,[OrderNumber]
				,[Description]
				,[Details]
				,[PagePath]
				,[AuditGroup] )
				Values
				( @ActionDate
				, @CustomerID
				, @UpdatedCustomerID
				, @OrderNumber
				, @Description
				, @Details
				, @PagePath
				, @AuditGroup );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AuditLogID",entity.AuditLogId)
					, new SqlParameter("@ActionDate",entity.ActionDate)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@UpdatedCustomerID",entity.UpdatedCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@Description",entity.Description)
					, new SqlParameter("@Details",entity.Details)
					, new SqlParameter("@PagePath",entity.PagePath)
					, new SqlParameter("@AuditGroup",entity.AuditGroup)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetAuditLog(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(AuditLog))]
		public virtual AuditLog UpdateAuditLog(AuditLog entity)
		{

			if (entity.IsTransient()) return entity;
			AuditLog other = GetAuditLog(entity.AuditLogId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update AuditLog set  [ActionDate]=@ActionDate
							, [CustomerID]=@CustomerID
							, [UpdatedCustomerID]=@UpdatedCustomerID
							, [OrderNumber]=@OrderNumber
							, [Description]=@Description
							, [Details]=@Details
							, [PagePath]=@PagePath
							, [AuditGroup]=@AuditGroup 
							 where AuditLogID=@AuditLogID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AuditLogID",entity.AuditLogId)
					, new SqlParameter("@ActionDate",entity.ActionDate)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@UpdatedCustomerID",entity.UpdatedCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@Description",entity.Description)
					, new SqlParameter("@Details",entity.Details)
					, new SqlParameter("@PagePath",entity.PagePath)
					, new SqlParameter("@AuditGroup",entity.AuditGroup)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetAuditLog(entity.AuditLogId);
		}

		public virtual bool DeleteAuditLog(System.Int64 AuditLogId)
		{

			string sql="delete from AuditLog where AuditLogID=@AuditLogID";
			SqlParameter parameter=new SqlParameter("@AuditLogID",AuditLogId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(AuditLog))]
		public virtual AuditLog DeleteAuditLog(AuditLog entity)
		{
			this.DeleteAuditLog(entity.AuditLogId);
			return entity;
		}


		public virtual AuditLog AuditLogFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			AuditLog entity=new AuditLog();
			entity.AuditLogId = (System.Int64)dr["AuditLogID"];
			entity.ActionDate = (System.DateTime)dr["ActionDate"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.UpdatedCustomerId = (System.Int32)dr["UpdatedCustomerID"];
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.Description = dr["Description"].ToString();
			entity.Details = dr["Details"].ToString();
			entity.PagePath = dr["PagePath"].ToString();
			entity.AuditGroup = dr["AuditGroup"].ToString();
			return entity;
		}

	}
	
	
}
