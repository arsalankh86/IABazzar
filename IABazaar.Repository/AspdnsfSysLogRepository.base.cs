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
		
	public abstract partial class AspdnsfSysLogRepositoryBase : Repository 
	{
        
        public AspdnsfSysLogRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("SysLogID",new SearchColumn(){Name="SysLogID",Title="SysLogID",SelectClause="SysLogID",WhereClause="AllRecords.SysLogID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SysLogGUID",new SearchColumn(){Name="SysLogGUID",Title="SysLogGUID",SelectClause="SysLogGUID",WhereClause="AllRecords.SysLogGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Message",new SearchColumn(){Name="Message",Title="Message",SelectClause="Message",WhereClause="AllRecords.Message",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Details",new SearchColumn(){Name="Details",Title="Details",SelectClause="Details",WhereClause="AllRecords.Details",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Type",new SearchColumn(){Name="Type",Title="Type",SelectClause="Type",WhereClause="AllRecords.Type",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Severity",new SearchColumn(){Name="Severity",Title="Severity",SelectClause="Severity",WhereClause="AllRecords.Severity",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetAspdnsfSysLogSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetAspdnsfSysLogBasicSearchColumns()
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

        public virtual List<SearchColumn> GetAspdnsfSysLogAdvanceSearchColumns()
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
        
        
        public virtual string GetAspdnsfSysLogSelectClause()
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
                        	selectQuery =  "aspdnsf_SysLog."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",aspdnsf_SysLog."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual AspdnsfSysLog GetAspdnsfSysLog(System.Int32 SysLogId)
		{

			string sql=GetAspdnsfSysLogSelectClause();
			sql+="from aspdnsf_SysLog where SysLogID=@SysLogID ";
			SqlParameter parameter=new SqlParameter("@SysLogID",SysLogId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return AspdnsfSysLogFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<AspdnsfSysLog> GetAllAspdnsfSysLog()
		{

			string sql=GetAspdnsfSysLogSelectClause();
			sql+="from aspdnsf_SysLog";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AspdnsfSysLog>(ds, AspdnsfSysLogFromDataRow);
		}

		public virtual List<AspdnsfSysLog> GetPagedAspdnsfSysLog(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetAspdnsfSysLogCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [SysLogID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([SysLogID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [SysLogID] ";
            tempsql += " FROM [aspdnsf_SysLog] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("SysLogID"))
					tempsql += " , (AllRecords.[SysLogID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[SysLogID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetAspdnsfSysLogSelectClause()+@" FROM [aspdnsf_SysLog], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [aspdnsf_SysLog].[SysLogID] = PageIndex.[SysLogID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AspdnsfSysLog>(ds, AspdnsfSysLogFromDataRow);
			}else{ return null;}
		}

		private int GetAspdnsfSysLogCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM aspdnsf_SysLog as AllRecords ";
			else
				sql = "SELECT Count(*) FROM aspdnsf_SysLog as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(AspdnsfSysLog))]
		public virtual AspdnsfSysLog InsertAspdnsfSysLog(AspdnsfSysLog entity)
		{

			AspdnsfSysLog other=new AspdnsfSysLog();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into aspdnsf_SysLog ( [SysLogGUID]
				,[Message]
				,[Details]
				,[Type]
				,[Severity]
				,[CreatedOn] )
				Values
				( @SysLogGUID
				, @Message
				, @Details
				, @Type
				, @Severity
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SysLogID",entity.SysLogId)
					, new SqlParameter("@SysLogGUID",entity.SysLogGuid)
					, new SqlParameter("@Message",entity.Message)
					, new SqlParameter("@Details",entity.Details ?? (object)DBNull.Value)
					, new SqlParameter("@Type",entity.Type)
					, new SqlParameter("@Severity",entity.Severity)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetAspdnsfSysLog(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(AspdnsfSysLog))]
		public virtual AspdnsfSysLog UpdateAspdnsfSysLog(AspdnsfSysLog entity)
		{

			if (entity.IsTransient()) return entity;
			AspdnsfSysLog other = GetAspdnsfSysLog(entity.SysLogId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update aspdnsf_SysLog set  [SysLogGUID]=@SysLogGUID
							, [Message]=@Message
							, [Details]=@Details
							, [Type]=@Type
							, [Severity]=@Severity
							, [CreatedOn]=@CreatedOn 
							 where SysLogID=@SysLogID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SysLogID",entity.SysLogId)
					, new SqlParameter("@SysLogGUID",entity.SysLogGuid)
					, new SqlParameter("@Message",entity.Message)
					, new SqlParameter("@Details",entity.Details ?? (object)DBNull.Value)
					, new SqlParameter("@Type",entity.Type)
					, new SqlParameter("@Severity",entity.Severity)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetAspdnsfSysLog(entity.SysLogId);
		}

		public virtual bool DeleteAspdnsfSysLog(System.Int32 SysLogId)
		{

			string sql="delete from aspdnsf_SysLog where SysLogID=@SysLogID";
			SqlParameter parameter=new SqlParameter("@SysLogID",SysLogId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(AspdnsfSysLog))]
		public virtual AspdnsfSysLog DeleteAspdnsfSysLog(AspdnsfSysLog entity)
		{
			this.DeleteAspdnsfSysLog(entity.SysLogId);
			return entity;
		}


		public virtual AspdnsfSysLog AspdnsfSysLogFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			AspdnsfSysLog entity=new AspdnsfSysLog();
			entity.SysLogId = (System.Int32)dr["SysLogID"];
			entity.SysLogGuid = (System.Guid)dr["SysLogGUID"];
			entity.Message = dr["Message"].ToString();
			entity.Details = dr["Details"].ToString();
			entity.Type = dr["Type"].ToString();
			entity.Severity = dr["Severity"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
