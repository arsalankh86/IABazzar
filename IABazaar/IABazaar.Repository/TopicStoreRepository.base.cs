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
		
	public abstract partial class TopicStoreRepositoryBase : Repository 
	{
        
        public TopicStoreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ID",new SearchColumn(){Name="ID",Title="ID",SelectClause="ID",WhereClause="AllRecords.ID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TopicID",new SearchColumn(){Name="TopicID",Title="TopicID",SelectClause="TopicID",WhereClause="AllRecords.TopicID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetTopicStoreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetTopicStoreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetTopicStoreAdvanceSearchColumns()
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
        
        
        public virtual string GetTopicStoreSelectClause()
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
                        	selectQuery =  "TopicStore."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",TopicStore."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual TopicStore GetTopicStore(System.Int32 TopicId)
		{

			string sql=GetTopicStoreSelectClause();
			sql+="from TopicStore where TopicID=@TopicID ";
			SqlParameter parameter=new SqlParameter("@TopicID",TopicId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return TopicStoreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<TopicStore> GetAllTopicStore()
		{

			string sql=GetTopicStoreSelectClause();
			sql+="from TopicStore";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<TopicStore>(ds, TopicStoreFromDataRow);
		}

		public virtual List<TopicStore> GetPagedTopicStore(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetTopicStoreCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [TopicID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([TopicID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [TopicID] ";
            tempsql += " FROM [TopicStore] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("TopicID"))
					tempsql += " , (AllRecords.[TopicID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[TopicID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetTopicStoreSelectClause()+@" FROM [TopicStore], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [TopicStore].[TopicID] = PageIndex.[TopicID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<TopicStore>(ds, TopicStoreFromDataRow);
			}else{ return null;}
		}

		private int GetTopicStoreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM TopicStore as AllRecords ";
			else
				sql = "SELECT Count(*) FROM TopicStore as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(TopicStore))]
		public virtual TopicStore InsertTopicStore(TopicStore entity)
		{

			TopicStore other=new TopicStore();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into TopicStore ( [TopicID]
				,[ID]
				,[StoreID]
				,[CreatedOn] )
				Values
				( @TopicID
				, @ID
				, @StoreID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TopicID",entity.TopicId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetTopicStore(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(TopicStore))]
		public virtual TopicStore UpdateTopicStore(TopicStore entity)
		{

			if (entity.IsTransient()) return entity;
			TopicStore other = GetTopicStore(entity.TopicId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update TopicStore set  [ID]=@ID
							, [StoreID]=@StoreID
							, [CreatedOn]=@CreatedOn 
							 where TopicID=@TopicID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TopicID",entity.TopicId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetTopicStore(entity.TopicId);
		}

		public virtual bool DeleteTopicStore(System.Int32 TopicId)
		{

			string sql="delete from TopicStore where TopicID=@TopicID";
			SqlParameter parameter=new SqlParameter("@TopicID",TopicId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(TopicStore))]
		public virtual TopicStore DeleteTopicStore(TopicStore entity)
		{
			this.DeleteTopicStore(entity.TopicId);
			return entity;
		}


		public virtual TopicStore TopicStoreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			TopicStore entity=new TopicStore();
			entity.Id = (System.Int32)dr["ID"];
			entity.TopicId = (System.Int32)dr["TopicID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
