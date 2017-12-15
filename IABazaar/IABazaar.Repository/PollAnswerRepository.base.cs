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
		
	public abstract partial class PollAnswerRepositoryBase : Repository 
	{
        
        public PollAnswerRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PollAnswerID",new SearchColumn(){Name="PollAnswerID",Title="PollAnswerID",SelectClause="PollAnswerID",WhereClause="AllRecords.PollAnswerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollAnswerGUID",new SearchColumn(){Name="PollAnswerGUID",Title="PollAnswerGUID",SelectClause="PollAnswerGUID",WhereClause="AllRecords.PollAnswerGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollID",new SearchColumn(){Name="PollID",Title="PollID",SelectClause="PollID",WhereClause="AllRecords.PollID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPollAnswerSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPollAnswerBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPollAnswerAdvanceSearchColumns()
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
        
        
        public virtual string GetPollAnswerSelectClause()
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
                        	selectQuery =  "PollAnswer."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",PollAnswer."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual PollAnswer GetPollAnswer(System.Int32 PollAnswerId)
		{

			string sql=GetPollAnswerSelectClause();
			sql+="from PollAnswer where PollAnswerID=@PollAnswerID ";
			SqlParameter parameter=new SqlParameter("@PollAnswerID",PollAnswerId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PollAnswerFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<PollAnswer> GetAllPollAnswer()
		{

			string sql=GetPollAnswerSelectClause();
			sql+="from PollAnswer";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollAnswer>(ds, PollAnswerFromDataRow);
		}

		public virtual List<PollAnswer> GetPagedPollAnswer(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPollAnswerCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PollAnswerID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PollAnswerID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PollAnswerID] ";
            tempsql += " FROM [PollAnswer] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PollAnswerID"))
					tempsql += " , (AllRecords.[PollAnswerID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PollAnswerID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPollAnswerSelectClause()+@" FROM [PollAnswer], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [PollAnswer].[PollAnswerID] = PageIndex.[PollAnswerID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollAnswer>(ds, PollAnswerFromDataRow);
			}else{ return null;}
		}

		private int GetPollAnswerCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM PollAnswer as AllRecords ";
			else
				sql = "SELECT Count(*) FROM PollAnswer as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(PollAnswer))]
		public virtual PollAnswer InsertPollAnswer(PollAnswer entity)
		{

			PollAnswer other=new PollAnswer();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into PollAnswer ( [PollAnswerGUID]
				,[PollID]
				,[Name]
				,[DisplayOrder]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @PollAnswerGUID
				, @PollID
				, @Name
				, @DisplayOrder
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollAnswerID",entity.PollAnswerId)
					, new SqlParameter("@PollAnswerGUID",entity.PollAnswerGuid)
					, new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPollAnswer(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(PollAnswer))]
		public virtual PollAnswer UpdatePollAnswer(PollAnswer entity)
		{

			if (entity.IsTransient()) return entity;
			PollAnswer other = GetPollAnswer(entity.PollAnswerId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update PollAnswer set  [PollAnswerGUID]=@PollAnswerGUID
							, [PollID]=@PollID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where PollAnswerID=@PollAnswerID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollAnswerID",entity.PollAnswerId)
					, new SqlParameter("@PollAnswerGUID",entity.PollAnswerGuid)
					, new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPollAnswer(entity.PollAnswerId);
		}

		public virtual bool DeletePollAnswer(System.Int32 PollAnswerId)
		{

			string sql="delete from PollAnswer where PollAnswerID=@PollAnswerID";
			SqlParameter parameter=new SqlParameter("@PollAnswerID",PollAnswerId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(PollAnswer))]
		public virtual PollAnswer DeletePollAnswer(PollAnswer entity)
		{
			this.DeletePollAnswer(entity.PollAnswerId);
			return entity;
		}


		public virtual PollAnswer PollAnswerFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			PollAnswer entity=new PollAnswer();
			entity.PollAnswerId = (System.Int32)dr["PollAnswerID"];
			entity.PollAnswerGuid = (System.Guid)dr["PollAnswerGUID"];
			entity.PollId = (System.Int32)dr["PollID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
