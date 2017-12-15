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
		
	public abstract partial class MailingMgrLogRepositoryBase : Repository 
	{
        
        public MailingMgrLogRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("MailingMgrLogID",new SearchColumn(){Name="MailingMgrLogID",Title="MailingMgrLogID",SelectClause="MailingMgrLogID",WhereClause="AllRecords.MailingMgrLogID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MailingMgrLogGUID",new SearchColumn(){Name="MailingMgrLogGUID",Title="MailingMgrLogGUID",SelectClause="MailingMgrLogGUID",WhereClause="AllRecords.MailingMgrLogGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SentOn",new SearchColumn(){Name="SentOn",Title="SentOn",SelectClause="SentOn",WhereClause="AllRecords.SentOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ToEmail",new SearchColumn(){Name="ToEmail",Title="ToEmail",SelectClause="ToEmail",WhereClause="AllRecords.ToEmail",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FromEmail",new SearchColumn(){Name="FromEmail",Title="FromEmail",SelectClause="FromEmail",WhereClause="AllRecords.FromEmail",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Subject",new SearchColumn(){Name="Subject",Title="Subject",SelectClause="Subject",WhereClause="AllRecords.Subject",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Body",new SearchColumn(){Name="Body",Title="Body",SelectClause="Body",WhereClause="AllRecords.Body",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetMailingMgrLogSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetMailingMgrLogBasicSearchColumns()
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

        public virtual List<SearchColumn> GetMailingMgrLogAdvanceSearchColumns()
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
        
        
        public virtual string GetMailingMgrLogSelectClause()
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
                        	selectQuery =  "MailingMgrLog."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",MailingMgrLog."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual MailingMgrLog GetMailingMgrLog(System.Int32 MailingMgrLogId)
		{

			string sql=GetMailingMgrLogSelectClause();
			sql+="from MailingMgrLog where MailingMgrLogID=@MailingMgrLogID ";
			SqlParameter parameter=new SqlParameter("@MailingMgrLogID",MailingMgrLogId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return MailingMgrLogFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<MailingMgrLog> GetAllMailingMgrLog()
		{

			string sql=GetMailingMgrLogSelectClause();
			sql+="from MailingMgrLog";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<MailingMgrLog>(ds, MailingMgrLogFromDataRow);
		}

		public virtual List<MailingMgrLog> GetPagedMailingMgrLog(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetMailingMgrLogCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [MailingMgrLogID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([MailingMgrLogID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [MailingMgrLogID] ";
            tempsql += " FROM [MailingMgrLog] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("MailingMgrLogID"))
					tempsql += " , (AllRecords.[MailingMgrLogID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[MailingMgrLogID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetMailingMgrLogSelectClause()+@" FROM [MailingMgrLog], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [MailingMgrLog].[MailingMgrLogID] = PageIndex.[MailingMgrLogID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<MailingMgrLog>(ds, MailingMgrLogFromDataRow);
			}else{ return null;}
		}

		private int GetMailingMgrLogCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM MailingMgrLog as AllRecords ";
			else
				sql = "SELECT Count(*) FROM MailingMgrLog as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(MailingMgrLog))]
		public virtual MailingMgrLog InsertMailingMgrLog(MailingMgrLog entity)
		{

			MailingMgrLog other=new MailingMgrLog();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into MailingMgrLog ( [MailingMgrLogGUID]
				,[SentOn]
				,[ToEmail]
				,[FromEmail]
				,[Subject]
				,[Body] )
				Values
				( @MailingMgrLogGUID
				, @SentOn
				, @ToEmail
				, @FromEmail
				, @Subject
				, @Body );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@MailingMgrLogID",entity.MailingMgrLogId)
					, new SqlParameter("@MailingMgrLogGUID",entity.MailingMgrLogGuid)
					, new SqlParameter("@SentOn",entity.SentOn)
					, new SqlParameter("@ToEmail",entity.ToEmail)
					, new SqlParameter("@FromEmail",entity.FromEmail)
					, new SqlParameter("@Subject",entity.Subject ?? (object)DBNull.Value)
					, new SqlParameter("@Body",entity.Body ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetMailingMgrLog(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(MailingMgrLog))]
		public virtual MailingMgrLog UpdateMailingMgrLog(MailingMgrLog entity)
		{

			if (entity.IsTransient()) return entity;
			MailingMgrLog other = GetMailingMgrLog(entity.MailingMgrLogId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update MailingMgrLog set  [MailingMgrLogGUID]=@MailingMgrLogGUID
							, [SentOn]=@SentOn
							, [ToEmail]=@ToEmail
							, [FromEmail]=@FromEmail
							, [Subject]=@Subject
							, [Body]=@Body 
							 where MailingMgrLogID=@MailingMgrLogID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@MailingMgrLogID",entity.MailingMgrLogId)
					, new SqlParameter("@MailingMgrLogGUID",entity.MailingMgrLogGuid)
					, new SqlParameter("@SentOn",entity.SentOn)
					, new SqlParameter("@ToEmail",entity.ToEmail)
					, new SqlParameter("@FromEmail",entity.FromEmail)
					, new SqlParameter("@Subject",entity.Subject ?? (object)DBNull.Value)
					, new SqlParameter("@Body",entity.Body ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetMailingMgrLog(entity.MailingMgrLogId);
		}

		public virtual bool DeleteMailingMgrLog(System.Int32 MailingMgrLogId)
		{

			string sql="delete from MailingMgrLog where MailingMgrLogID=@MailingMgrLogID";
			SqlParameter parameter=new SqlParameter("@MailingMgrLogID",MailingMgrLogId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(MailingMgrLog))]
		public virtual MailingMgrLog DeleteMailingMgrLog(MailingMgrLog entity)
		{
			this.DeleteMailingMgrLog(entity.MailingMgrLogId);
			return entity;
		}


		public virtual MailingMgrLog MailingMgrLogFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			MailingMgrLog entity=new MailingMgrLog();
			entity.MailingMgrLogId = (System.Int32)dr["MailingMgrLogID"];
			entity.MailingMgrLogGuid = (System.Guid)dr["MailingMgrLogGUID"];
			entity.SentOn = (System.DateTime)dr["SentOn"];
			entity.ToEmail = dr["ToEmail"].ToString();
			entity.FromEmail = dr["FromEmail"].ToString();
			entity.Subject = dr["Subject"].ToString();
			entity.Body = dr["Body"].ToString();
			return entity;
		}

	}
	
	
}
