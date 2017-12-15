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
		
	public abstract partial class SqlLogRepositoryBase : Repository 
	{
        
        public SqlLogRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("SQLLogID",new SearchColumn(){Name="SQLLogID",Title="SQLLogID",SelectClause="SQLLogID",WhereClause="AllRecords.SQLLogID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SQLText",new SearchColumn(){Name="SQLText",Title="SQLText",SelectClause="SQLText",WhereClause="AllRecords.SQLText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExecutedBy",new SearchColumn(){Name="ExecutedBy",Title="ExecutedBy",SelectClause="ExecutedBy",WhereClause="AllRecords.ExecutedBy",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExecutedOn",new SearchColumn(){Name="ExecutedOn",Title="ExecutedOn",SelectClause="ExecutedOn",WhereClause="AllRecords.ExecutedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetSqlLogSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetSqlLogBasicSearchColumns()
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

        public virtual List<SearchColumn> GetSqlLogAdvanceSearchColumns()
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
        
        
        public virtual string GetSqlLogSelectClause()
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
                        	selectQuery =  "SQLLog."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",SQLLog."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual SqlLog GetSqlLog(System.Int32 SqlLogId)
		{

			string sql=GetSqlLogSelectClause();
			sql+="from SQLLog where SQLLogID=@SQLLogID ";
			SqlParameter parameter=new SqlParameter("@SQLLogID",SqlLogId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return SqlLogFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<SqlLog> GetAllSqlLog()
		{

			string sql=GetSqlLogSelectClause();
			sql+="from SQLLog";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SqlLog>(ds, SqlLogFromDataRow);
		}

		public virtual List<SqlLog> GetPagedSqlLog(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetSqlLogCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [SQLLogID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([SQLLogID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [SQLLogID] ";
            tempsql += " FROM [SQLLog] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("SQLLogID"))
					tempsql += " , (AllRecords.[SQLLogID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[SQLLogID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetSqlLogSelectClause()+@" FROM [SQLLog], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [SQLLog].[SQLLogID] = PageIndex.[SQLLogID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SqlLog>(ds, SqlLogFromDataRow);
			}else{ return null;}
		}

		private int GetSqlLogCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM SQLLog as AllRecords ";
			else
				sql = "SELECT Count(*) FROM SQLLog as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(SqlLog))]
		public virtual SqlLog InsertSqlLog(SqlLog entity)
		{

			SqlLog other=new SqlLog();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into SQLLog ( [SQLText]
				,[ExecutedBy]
				,[ExecutedOn] )
				Values
				( @SQLText
				, @ExecutedBy
				, @ExecutedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SQLLogID",entity.SqlLogId)
					, new SqlParameter("@SQLText",entity.SqlText)
					, new SqlParameter("@ExecutedBy",entity.ExecutedBy)
					, new SqlParameter("@ExecutedOn",entity.ExecutedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetSqlLog(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(SqlLog))]
		public virtual SqlLog UpdateSqlLog(SqlLog entity)
		{

			if (entity.IsTransient()) return entity;
			SqlLog other = GetSqlLog(entity.SqlLogId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update SQLLog set  [SQLText]=@SQLText
							, [ExecutedBy]=@ExecutedBy
							, [ExecutedOn]=@ExecutedOn 
							 where SQLLogID=@SQLLogID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SQLLogID",entity.SqlLogId)
					, new SqlParameter("@SQLText",entity.SqlText)
					, new SqlParameter("@ExecutedBy",entity.ExecutedBy)
					, new SqlParameter("@ExecutedOn",entity.ExecutedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetSqlLog(entity.SqlLogId);
		}

		public virtual bool DeleteSqlLog(System.Int32 SqlLogId)
		{

			string sql="delete from SQLLog where SQLLogID=@SQLLogID";
			SqlParameter parameter=new SqlParameter("@SQLLogID",SqlLogId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(SqlLog))]
		public virtual SqlLog DeleteSqlLog(SqlLog entity)
		{
			this.DeleteSqlLog(entity.SqlLogId);
			return entity;
		}


		public virtual SqlLog SqlLogFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			SqlLog entity=new SqlLog();
			entity.SqlLogId = (System.Int32)dr["SQLLogID"];
			entity.SqlText = dr["SQLText"].ToString();
			entity.ExecutedBy = (System.Int32)dr["ExecutedBy"];
			entity.ExecutedOn = (System.DateTime)dr["ExecutedOn"];
			return entity;
		}

	}
	
	
}
