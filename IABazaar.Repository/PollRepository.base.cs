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
		
	public abstract partial class PollRepositoryBase : Repository 
	{
        
        public PollRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PollID",new SearchColumn(){Name="PollID",Title="PollID",SelectClause="PollID",WhereClause="AllRecords.PollID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollGUID",new SearchColumn(){Name="PollGUID",Title="PollGUID",SelectClause="PollGUID",WhereClause="AllRecords.PollGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollSortOrderID",new SearchColumn(){Name="PollSortOrderID",Title="PollSortOrderID",SelectClause="PollSortOrderID",WhereClause="AllRecords.PollSortOrderID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AnonsCanVote",new SearchColumn(){Name="AnonsCanVote",Title="AnonsCanVote",SelectClause="AnonsCanVote",WhereClause="AllRecords.AnonsCanVote",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresOn",new SearchColumn(){Name="ExpiresOn",Title="ExpiresOn",SelectClause="ExpiresOn",WhereClause="AllRecords.ExpiresOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPollSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPollBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPollAdvanceSearchColumns()
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
        
        
        public virtual string GetPollSelectClause()
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
                        	selectQuery =  "Poll."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Poll."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Poll GetPoll(System.Int32 PollId)
		{

			string sql=GetPollSelectClause();
			sql+="from Poll where PollID=@PollID ";
			SqlParameter parameter=new SqlParameter("@PollID",PollId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PollFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Poll> GetAllPoll()
		{

			string sql=GetPollSelectClause();
			sql+="from Poll";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Poll>(ds, PollFromDataRow);
		}

		public virtual List<Poll> GetPagedPoll(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPollCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PollID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PollID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PollID] ";
            tempsql += " FROM [Poll] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PollID"))
					tempsql += " , (AllRecords.[PollID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PollID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPollSelectClause()+@" FROM [Poll], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Poll].[PollID] = PageIndex.[PollID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Poll>(ds, PollFromDataRow);
			}else{ return null;}
		}

		private int GetPollCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Poll as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Poll as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Poll))]
		public virtual Poll InsertPoll(Poll entity)
		{

			Poll other=new Poll();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Poll ( [PollGUID]
				,[Name]
				,[PollSortOrderID]
				,[Published]
				,[Wholesale]
				,[DisplayOrder]
				,[Deleted]
				,[AnonsCanVote]
				,[ExpiresOn]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @PollGUID
				, @Name
				, @PollSortOrderID
				, @Published
				, @Wholesale
				, @DisplayOrder
				, @Deleted
				, @AnonsCanVote
				, @ExpiresOn
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@PollGUID",entity.PollGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@PollSortOrderID",entity.PollSortOrderId)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@AnonsCanVote",entity.AnonsCanVote)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPoll(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Poll))]
		public virtual Poll UpdatePoll(Poll entity)
		{

			if (entity.IsTransient()) return entity;
			Poll other = GetPoll(entity.PollId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Poll set  [PollGUID]=@PollGUID
							, [Name]=@Name
							, [PollSortOrderID]=@PollSortOrderID
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [DisplayOrder]=@DisplayOrder
							, [Deleted]=@Deleted
							, [AnonsCanVote]=@AnonsCanVote
							, [ExpiresOn]=@ExpiresOn
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where PollID=@PollID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@PollGUID",entity.PollGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@PollSortOrderID",entity.PollSortOrderId)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@AnonsCanVote",entity.AnonsCanVote)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPoll(entity.PollId);
		}

		public virtual bool DeletePoll(System.Int32 PollId)
		{

			string sql="delete from Poll where PollID=@PollID";
			SqlParameter parameter=new SqlParameter("@PollID",PollId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Poll))]
		public virtual Poll DeletePoll(Poll entity)
		{
			this.DeletePoll(entity.PollId);
			return entity;
		}


		public virtual Poll PollFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Poll entity=new Poll();
			entity.PollId = (System.Int32)dr["PollID"];
			entity.PollGuid = (System.Guid)dr["PollGUID"];
			entity.Name = dr["Name"].ToString();
			entity.PollSortOrderId = (System.Int32)dr["PollSortOrderID"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.AnonsCanVote = (System.Byte)dr["AnonsCanVote"];
			entity.ExpiresOn = (System.DateTime)dr["ExpiresOn"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
