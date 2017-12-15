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
		
	public abstract partial class FeedRepositoryBase : Repository 
	{
        
        public FeedRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("FeedID",new SearchColumn(){Name="FeedID",Title="FeedID",SelectClause="FeedID",WhereClause="AllRecords.FeedID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FeedGUID",new SearchColumn(){Name="FeedGUID",Title="FeedGUID",SelectClause="FeedGUID",WhereClause="AllRecords.FeedGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CanAutoFTP",new SearchColumn(){Name="CanAutoFTP",Title="CanAutoFTP",SelectClause="CanAutoFTP",WhereClause="AllRecords.CanAutoFTP",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FTPUsername",new SearchColumn(){Name="FTPUsername",Title="FTPUsername",SelectClause="FTPUsername",WhereClause="AllRecords.FTPUsername",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FTPPassword",new SearchColumn(){Name="FTPPassword",Title="FTPPassword",SelectClause="FTPPassword",WhereClause="AllRecords.FTPPassword",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FTPServer",new SearchColumn(){Name="FTPServer",Title="FTPServer",SelectClause="FTPServer",WhereClause="AllRecords.FTPServer",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FTPPort",new SearchColumn(){Name="FTPPort",Title="FTPPort",SelectClause="FTPPort",WhereClause="AllRecords.FTPPort",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FTPFilename",new SearchColumn(){Name="FTPFilename",Title="FTPFilename",SelectClause="FTPFilename",WhereClause="AllRecords.FTPFilename",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetFeedSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetFeedBasicSearchColumns()
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

        public virtual List<SearchColumn> GetFeedAdvanceSearchColumns()
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
        
        
        public virtual string GetFeedSelectClause()
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
                        	selectQuery =  "Feed."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Feed."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Feed GetFeed(System.Int32 FeedId)
		{

			string sql=GetFeedSelectClause();
			sql+="from Feed where FeedID=@FeedID ";
			SqlParameter parameter=new SqlParameter("@FeedID",FeedId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return FeedFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Feed> GetAllFeed()
		{

			string sql=GetFeedSelectClause();
			sql+="from Feed";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Feed>(ds, FeedFromDataRow);
		}

		public virtual List<Feed> GetPagedFeed(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetFeedCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [FeedID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([FeedID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [FeedID] ";
            tempsql += " FROM [Feed] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("FeedID"))
					tempsql += " , (AllRecords.[FeedID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[FeedID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetFeedSelectClause()+@" FROM [Feed], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Feed].[FeedID] = PageIndex.[FeedID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Feed>(ds, FeedFromDataRow);
			}else{ return null;}
		}

		private int GetFeedCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Feed as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Feed as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Feed))]
		public virtual Feed InsertFeed(Feed entity)
		{

			Feed other=new Feed();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Feed ( [FeedGUID]
				,[StoreID]
				,[Name]
				,[DisplayOrder]
				,[XmlPackage]
				,[CanAutoFTP]
				,[FTPUsername]
				,[FTPPassword]
				,[FTPServer]
				,[FTPPort]
				,[FTPFilename]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @FeedGUID
				, @StoreID
				, @Name
				, @DisplayOrder
				, @XmlPackage
				, @CanAutoFTP
				, @FTPUsername
				, @FTPPassword
				, @FTPServer
				, @FTPPort
				, @FTPFilename
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@FeedID",entity.FeedId)
					, new SqlParameter("@FeedGUID",entity.FeedGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@CanAutoFTP",entity.CanAutoFtp)
					, new SqlParameter("@FTPUsername",entity.FtpUsername ?? (object)DBNull.Value)
					, new SqlParameter("@FTPPassword",entity.FtpPassword ?? (object)DBNull.Value)
					, new SqlParameter("@FTPServer",entity.FtpServer ?? (object)DBNull.Value)
					, new SqlParameter("@FTPPort",entity.FtpPort ?? (object)DBNull.Value)
					, new SqlParameter("@FTPFilename",entity.FtpFilename ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetFeed(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Feed))]
		public virtual Feed UpdateFeed(Feed entity)
		{

			if (entity.IsTransient()) return entity;
			Feed other = GetFeed(entity.FeedId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Feed set  [FeedGUID]=@FeedGUID
							, [StoreID]=@StoreID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [XmlPackage]=@XmlPackage
							, [CanAutoFTP]=@CanAutoFTP
							, [FTPUsername]=@FTPUsername
							, [FTPPassword]=@FTPPassword
							, [FTPServer]=@FTPServer
							, [FTPPort]=@FTPPort
							, [FTPFilename]=@FTPFilename
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where FeedID=@FeedID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@FeedID",entity.FeedId)
					, new SqlParameter("@FeedGUID",entity.FeedGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@CanAutoFTP",entity.CanAutoFtp)
					, new SqlParameter("@FTPUsername",entity.FtpUsername ?? (object)DBNull.Value)
					, new SqlParameter("@FTPPassword",entity.FtpPassword ?? (object)DBNull.Value)
					, new SqlParameter("@FTPServer",entity.FtpServer ?? (object)DBNull.Value)
					, new SqlParameter("@FTPPort",entity.FtpPort ?? (object)DBNull.Value)
					, new SqlParameter("@FTPFilename",entity.FtpFilename ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetFeed(entity.FeedId);
		}

		public virtual bool DeleteFeed(System.Int32 FeedId)
		{

			string sql="delete from Feed where FeedID=@FeedID";
			SqlParameter parameter=new SqlParameter("@FeedID",FeedId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Feed))]
		public virtual Feed DeleteFeed(Feed entity)
		{
			this.DeleteFeed(entity.FeedId);
			return entity;
		}


		public virtual Feed FeedFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Feed entity=new Feed();
			entity.FeedId = (System.Int32)dr["FeedID"];
			entity.FeedGuid = (System.Guid)dr["FeedGUID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.CanAutoFtp = (System.Byte)dr["CanAutoFTP"];
			entity.FtpUsername = dr["FTPUsername"].ToString();
			entity.FtpPassword = dr["FTPPassword"].ToString();
			entity.FtpServer = dr["FTPServer"].ToString();
			entity.FtpPort = dr["FTPPort"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["FTPPort"];
			entity.FtpFilename = dr["FTPFilename"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
