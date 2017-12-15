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
		
	public abstract partial class PollVotingRecordRepositoryBase : Repository 
	{
        
        public PollVotingRecordRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PollVotingRecordID",new SearchColumn(){Name="PollVotingRecordID",Title="PollVotingRecordID",SelectClause="PollVotingRecordID",WhereClause="AllRecords.PollVotingRecordID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollVotingRecordGUID",new SearchColumn(){Name="PollVotingRecordGUID",Title="PollVotingRecordGUID",SelectClause="PollVotingRecordGUID",WhereClause="AllRecords.PollVotingRecordGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollID",new SearchColumn(){Name="PollID",Title="PollID",SelectClause="PollID",WhereClause="AllRecords.PollID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollAnswerID",new SearchColumn(){Name="PollAnswerID",Title="PollAnswerID",SelectClause="PollAnswerID",WhereClause="AllRecords.PollAnswerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPollVotingRecordSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPollVotingRecordBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPollVotingRecordAdvanceSearchColumns()
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
        
        
        public virtual string GetPollVotingRecordSelectClause()
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
                        	selectQuery =  "PollVotingRecord."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",PollVotingRecord."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual PollVotingRecord GetPollVotingRecord(System.Int32 PollVotingRecordId)
		{

			string sql=GetPollVotingRecordSelectClause();
			sql+="from PollVotingRecord where PollVotingRecordID=@PollVotingRecordID ";
			SqlParameter parameter=new SqlParameter("@PollVotingRecordID",PollVotingRecordId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PollVotingRecordFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<PollVotingRecord> GetAllPollVotingRecord()
		{

			string sql=GetPollVotingRecordSelectClause();
			sql+="from PollVotingRecord";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollVotingRecord>(ds, PollVotingRecordFromDataRow);
		}

		public virtual List<PollVotingRecord> GetPagedPollVotingRecord(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPollVotingRecordCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PollVotingRecordID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PollVotingRecordID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PollVotingRecordID] ";
            tempsql += " FROM [PollVotingRecord] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PollVotingRecordID"))
					tempsql += " , (AllRecords.[PollVotingRecordID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PollVotingRecordID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPollVotingRecordSelectClause()+@" FROM [PollVotingRecord], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [PollVotingRecord].[PollVotingRecordID] = PageIndex.[PollVotingRecordID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollVotingRecord>(ds, PollVotingRecordFromDataRow);
			}else{ return null;}
		}

		private int GetPollVotingRecordCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM PollVotingRecord as AllRecords ";
			else
				sql = "SELECT Count(*) FROM PollVotingRecord as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(PollVotingRecord))]
		public virtual PollVotingRecord InsertPollVotingRecord(PollVotingRecord entity)
		{

			PollVotingRecord other=new PollVotingRecord();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into PollVotingRecord ( [PollVotingRecordGUID]
				,[PollID]
				,[PollAnswerID]
				,[CustomerID]
				,[CreatedOn] )
				Values
				( @PollVotingRecordGUID
				, @PollID
				, @PollAnswerID
				, @CustomerID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollVotingRecordID",entity.PollVotingRecordId)
					, new SqlParameter("@PollVotingRecordGUID",entity.PollVotingRecordGuid)
					, new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@PollAnswerID",entity.PollAnswerId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPollVotingRecord(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(PollVotingRecord))]
		public virtual PollVotingRecord UpdatePollVotingRecord(PollVotingRecord entity)
		{

			if (entity.IsTransient()) return entity;
			PollVotingRecord other = GetPollVotingRecord(entity.PollVotingRecordId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update PollVotingRecord set  [PollVotingRecordGUID]=@PollVotingRecordGUID
							, [PollID]=@PollID
							, [PollAnswerID]=@PollAnswerID
							, [CustomerID]=@CustomerID
							, [CreatedOn]=@CreatedOn 
							 where PollVotingRecordID=@PollVotingRecordID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollVotingRecordID",entity.PollVotingRecordId)
					, new SqlParameter("@PollVotingRecordGUID",entity.PollVotingRecordGuid)
					, new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@PollAnswerID",entity.PollAnswerId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPollVotingRecord(entity.PollVotingRecordId);
		}

		public virtual bool DeletePollVotingRecord(System.Int32 PollVotingRecordId)
		{

			string sql="delete from PollVotingRecord where PollVotingRecordID=@PollVotingRecordID";
			SqlParameter parameter=new SqlParameter("@PollVotingRecordID",PollVotingRecordId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(PollVotingRecord))]
		public virtual PollVotingRecord DeletePollVotingRecord(PollVotingRecord entity)
		{
			this.DeletePollVotingRecord(entity.PollVotingRecordId);
			return entity;
		}


		public virtual PollVotingRecord PollVotingRecordFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			PollVotingRecord entity=new PollVotingRecord();
			entity.PollVotingRecordId = (System.Int32)dr["PollVotingRecordID"];
			entity.PollVotingRecordGuid = (System.Guid)dr["PollVotingRecordGUID"];
			entity.PollId = (System.Int32)dr["PollID"];
			entity.PollAnswerId = (System.Int32)dr["PollAnswerID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
