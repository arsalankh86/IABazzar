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
		
	public abstract partial class ErrorLogRepositoryBase : Repository 
	{
        
        public ErrorLogRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("logid",new SearchColumn(){Name="logid",Title="logid",SelectClause="logid",WhereClause="AllRecords.logid",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("errorDt",new SearchColumn(){Name="errorDt",Title="errorDt",SelectClause="errorDt",WhereClause="AllRecords.errorDt",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("source",new SearchColumn(){Name="source",Title="source",SelectClause="source",WhereClause="AllRecords.source",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("errormsg",new SearchColumn(){Name="errormsg",Title="errormsg",SelectClause="errormsg",WhereClause="AllRecords.errormsg",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetErrorLogSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetErrorLogBasicSearchColumns()
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

        public virtual List<SearchColumn> GetErrorLogAdvanceSearchColumns()
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
        
        
        public virtual string GetErrorLogSelectClause()
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
                        	selectQuery =  "ErrorLog."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ErrorLog."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ErrorLog GetErrorLog(System.Int32 Logid)
		{

			string sql=GetErrorLogSelectClause();
			sql+="from ErrorLog where logid=@logid ";
			SqlParameter parameter=new SqlParameter("@logid",Logid);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ErrorLogFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ErrorLog> GetAllErrorLog()
		{

			string sql=GetErrorLogSelectClause();
			sql+="from ErrorLog";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ErrorLog>(ds, ErrorLogFromDataRow);
		}

		public virtual List<ErrorLog> GetPagedErrorLog(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetErrorLogCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [logid] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([logid])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [logid] ";
            tempsql += " FROM [ErrorLog] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("logid"))
					tempsql += " , (AllRecords.[logid])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[logid])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetErrorLogSelectClause()+@" FROM [ErrorLog], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ErrorLog].[logid] = PageIndex.[logid] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ErrorLog>(ds, ErrorLogFromDataRow);
			}else{ return null;}
		}

		private int GetErrorLogCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ErrorLog as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ErrorLog as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ErrorLog))]
		public virtual ErrorLog InsertErrorLog(ErrorLog entity)
		{

			ErrorLog other=new ErrorLog();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ErrorLog ( [errorDt]
				,[source]
				,[errormsg] )
				Values
				( @errorDt
				, @source
				, @errormsg );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@logid",entity.Logid)
					, new SqlParameter("@errorDt",entity.ErrorDt)
					, new SqlParameter("@source",entity.Source ?? (object)DBNull.Value)
					, new SqlParameter("@errormsg",entity.Errormsg ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetErrorLog(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ErrorLog))]
		public virtual ErrorLog UpdateErrorLog(ErrorLog entity)
		{

			if (entity.IsTransient()) return entity;
			ErrorLog other = GetErrorLog(entity.Logid);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ErrorLog set  [errorDt]=@errorDt
							, [source]=@source
							, [errormsg]=@errormsg 
							 where logid=@logid";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@logid",entity.Logid)
					, new SqlParameter("@errorDt",entity.ErrorDt)
					, new SqlParameter("@source",entity.Source ?? (object)DBNull.Value)
					, new SqlParameter("@errormsg",entity.Errormsg ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetErrorLog(entity.Logid);
		}

		public virtual bool DeleteErrorLog(System.Int32 Logid)
		{

			string sql="delete from ErrorLog where logid=@logid";
			SqlParameter parameter=new SqlParameter("@logid",Logid);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ErrorLog))]
		public virtual ErrorLog DeleteErrorLog(ErrorLog entity)
		{
			this.DeleteErrorLog(entity.Logid);
			return entity;
		}


		public virtual ErrorLog ErrorLogFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ErrorLog entity=new ErrorLog();
			entity.Logid = (System.Int32)dr["logid"];
			entity.ErrorDt = (System.DateTime)dr["errorDt"];
			entity.Source = dr["source"].ToString();
			entity.Errormsg = dr["errormsg"].ToString();
			return entity;
		}

	}
	
	
}
