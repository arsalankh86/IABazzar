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
		
	public abstract partial class NewsRepositoryBase : Repository 
	{
        
        public NewsRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("NewsID",new SearchColumn(){Name="NewsID",Title="NewsID",SelectClause="NewsID",WhereClause="AllRecords.NewsID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NewsGUID",new SearchColumn(){Name="NewsGUID",Title="NewsGUID",SelectClause="NewsGUID",WhereClause="AllRecords.NewsGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Headline",new SearchColumn(){Name="Headline",Title="Headline",SelectClause="Headline",WhereClause="AllRecords.Headline",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NewsCopy",new SearchColumn(){Name="NewsCopy",Title="NewsCopy",SelectClause="NewsCopy",WhereClause="AllRecords.NewsCopy",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresOn",new SearchColumn(){Name="ExpiresOn",Title="ExpiresOn",SelectClause="ExpiresOn",WhereClause="AllRecords.ExpiresOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetNewsSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetNewsBasicSearchColumns()
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

        public virtual List<SearchColumn> GetNewsAdvanceSearchColumns()
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
        
        
        public virtual string GetNewsSelectClause()
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
                        	selectQuery =  "News."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",News."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual News GetNews(System.Int32 NewsId)
		{

			string sql=GetNewsSelectClause();
			sql+="from News where NewsID=@NewsID ";
			SqlParameter parameter=new SqlParameter("@NewsID",NewsId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return NewsFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<News> GetAllNews()
		{

			string sql=GetNewsSelectClause();
			sql+="from News";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<News>(ds, NewsFromDataRow);
		}

		public virtual List<News> GetPagedNews(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetNewsCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [NewsID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([NewsID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [NewsID] ";
            tempsql += " FROM [News] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("NewsID"))
					tempsql += " , (AllRecords.[NewsID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[NewsID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetNewsSelectClause()+@" FROM [News], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [News].[NewsID] = PageIndex.[NewsID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<News>(ds, NewsFromDataRow);
			}else{ return null;}
		}

		private int GetNewsCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM News as AllRecords ";
			else
				sql = "SELECT Count(*) FROM News as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(News))]
		public virtual News InsertNews(News entity)
		{

			News other=new News();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into News ( [NewsGUID]
				,[Headline]
				,[NewsCopy]
				,[ExpiresOn]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @NewsGUID
				, @Headline
				, @NewsCopy
				, @ExpiresOn
				, @Published
				, @Wholesale
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@NewsID",entity.NewsId)
					, new SqlParameter("@NewsGUID",entity.NewsGuid)
					, new SqlParameter("@Headline",entity.Headline ?? (object)DBNull.Value)
					, new SqlParameter("@NewsCopy",entity.NewsCopy ?? (object)DBNull.Value)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetNews(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(News))]
		public virtual News UpdateNews(News entity)
		{

			if (entity.IsTransient()) return entity;
			News other = GetNews(entity.NewsId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update News set  [NewsGUID]=@NewsGUID
							, [Headline]=@Headline
							, [NewsCopy]=@NewsCopy
							, [ExpiresOn]=@ExpiresOn
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where NewsID=@NewsID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@NewsID",entity.NewsId)
					, new SqlParameter("@NewsGUID",entity.NewsGuid)
					, new SqlParameter("@Headline",entity.Headline ?? (object)DBNull.Value)
					, new SqlParameter("@NewsCopy",entity.NewsCopy ?? (object)DBNull.Value)
					, new SqlParameter("@ExpiresOn",entity.ExpiresOn)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetNews(entity.NewsId);
		}

		public virtual bool DeleteNews(System.Int32 NewsId)
		{

			string sql="delete from News where NewsID=@NewsID";
			SqlParameter parameter=new SqlParameter("@NewsID",NewsId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(News))]
		public virtual News DeleteNews(News entity)
		{
			this.DeleteNews(entity.NewsId);
			return entity;
		}


		public virtual News NewsFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			News entity=new News();
			entity.NewsId = (System.Int32)dr["NewsID"];
			entity.NewsGuid = (System.Guid)dr["NewsGUID"];
			entity.Headline = dr["Headline"].ToString();
			entity.NewsCopy = dr["NewsCopy"].ToString();
			entity.ExpiresOn = (System.DateTime)dr["ExpiresOn"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
