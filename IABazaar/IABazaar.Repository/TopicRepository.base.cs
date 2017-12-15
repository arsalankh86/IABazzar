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
		
	public abstract partial class TopicRepositoryBase : Repository 
	{
        
        public TopicRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("TopicID",new SearchColumn(){Name="TopicID",Title="TopicID",SelectClause="TopicID",WhereClause="AllRecords.TopicID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TopicGUID",new SearchColumn(){Name="TopicGUID",Title="TopicGUID",SelectClause="TopicGUID",WhereClause="AllRecords.TopicGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Title",new SearchColumn(){Name="Title",Title="Title",SelectClause="Title",WhereClause="AllRecords.Title",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Password",new SearchColumn(){Name="Password",Title="Password",SelectClause="Password",WhereClause="AllRecords.Password",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresSubscription",new SearchColumn(){Name="RequiresSubscription",Title="RequiresSubscription",SelectClause="RequiresSubscription",WhereClause="AllRecords.RequiresSubscription",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresDisclaimer",new SearchColumn(){Name="RequiresDisclaimer",Title="RequiresDisclaimer",SelectClause="RequiresDisclaimer",WhereClause="AllRecords.RequiresDisclaimer",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShowInSiteMap",new SearchColumn(){Name="ShowInSiteMap",Title="ShowInSiteMap",SelectClause="ShowInSiteMap",WhereClause="AllRecords.ShowInSiteMap",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("HTMLOk",new SearchColumn(){Name="HTMLOk",Title="HTMLOk",SelectClause="HTMLOk",WhereClause="AllRecords.HTMLOk",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetTopicSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetTopicBasicSearchColumns()
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

        public virtual List<SearchColumn> GetTopicAdvanceSearchColumns()
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
        
        
        public virtual string GetTopicSelectClause()
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
                        	selectQuery =  "Topic."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Topic."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Topic GetTopic(System.Int32 TopicId)
		{

			string sql=GetTopicSelectClause();
			sql+="from Topic where TopicID=@TopicID ";
			SqlParameter parameter=new SqlParameter("@TopicID",TopicId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return TopicFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Topic> GetAllTopic()
		{

			string sql=GetTopicSelectClause();
			sql+="from Topic";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Topic>(ds, TopicFromDataRow);
		}

		public virtual List<Topic> GetPagedTopic(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetTopicCount(whereClause, searchColumns);
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
            tempsql += " FROM [Topic] AllRecords";
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
                GetTopicSelectClause()+@" FROM [Topic], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Topic].[TopicID] = PageIndex.[TopicID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Topic>(ds, TopicFromDataRow);
			}else{ return null;}
		}

		private int GetTopicCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Topic as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Topic as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Topic))]
		public virtual Topic InsertTopic(Topic entity)
		{

			Topic other=new Topic();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Topic ( [TopicGUID]
				,[Name]
				,[Title]
				,[Description]
				,[SETitle]
				,[SEDescription]
				,[SEKeywords]
				,[SENoScript]
				,[Password]
				,[RequiresSubscription]
				,[RequiresDisclaimer]
				,[XmlPackage]
				,[ExtensionData]
				,[ShowInSiteMap]
				,[SkinID]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[HTMLOk]
				,[Deleted]
				,[StoreID]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @TopicGUID
				, @Name
				, @Title
				, @Description
				, @SETitle
				, @SEDescription
				, @SEKeywords
				, @SENoScript
				, @Password
				, @RequiresSubscription
				, @RequiresDisclaimer
				, @XmlPackage
				, @ExtensionData
				, @ShowInSiteMap
				, @SkinID
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @HTMLOk
				, @Deleted
				, @StoreID
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TopicID",entity.TopicId)
					, new SqlParameter("@TopicGUID",entity.TopicGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Title",entity.Title ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@Password",entity.Password ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresSubscription",entity.RequiresSubscription ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresDisclaimer",entity.RequiresDisclaimer ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ShowInSiteMap",entity.ShowInSiteMap)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@HTMLOk",entity.HtmlOk)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetTopic(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Topic))]
		public virtual Topic UpdateTopic(Topic entity)
		{

			if (entity.IsTransient()) return entity;
			Topic other = GetTopic(entity.TopicId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Topic set  [TopicGUID]=@TopicGUID
							, [Name]=@Name
							, [Title]=@Title
							, [Description]=@Description
							, [SETitle]=@SETitle
							, [SEDescription]=@SEDescription
							, [SEKeywords]=@SEKeywords
							, [SENoScript]=@SENoScript
							, [Password]=@Password
							, [RequiresSubscription]=@RequiresSubscription
							, [RequiresDisclaimer]=@RequiresDisclaimer
							, [XmlPackage]=@XmlPackage
							, [ExtensionData]=@ExtensionData
							, [ShowInSiteMap]=@ShowInSiteMap
							, [SkinID]=@SkinID
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [HTMLOk]=@HTMLOk
							, [Deleted]=@Deleted
							, [StoreID]=@StoreID
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where TopicID=@TopicID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TopicID",entity.TopicId)
					, new SqlParameter("@TopicGUID",entity.TopicGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Title",entity.Title ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@Password",entity.Password ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresSubscription",entity.RequiresSubscription ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresDisclaimer",entity.RequiresDisclaimer ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ShowInSiteMap",entity.ShowInSiteMap)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@HTMLOk",entity.HtmlOk)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetTopic(entity.TopicId);
		}

		public virtual bool DeleteTopic(System.Int32 TopicId)
		{

			string sql="delete from Topic where TopicID=@TopicID";
			SqlParameter parameter=new SqlParameter("@TopicID",TopicId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Topic))]
		public virtual Topic DeleteTopic(Topic entity)
		{
			this.DeleteTopic(entity.TopicId);
			return entity;
		}


		public virtual Topic TopicFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Topic entity=new Topic();
			entity.TopicId = (System.Int32)dr["TopicID"];
			entity.TopicGuid = (System.Guid)dr["TopicGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Title = dr["Title"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.Password = dr["Password"].ToString();
			entity.RequiresSubscription = dr["RequiresSubscription"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["RequiresSubscription"];
			entity.RequiresDisclaimer = dr["RequiresDisclaimer"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["RequiresDisclaimer"];
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ShowInSiteMap = (System.Byte)dr["ShowInSiteMap"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.HtmlOk = (System.Byte)dr["HTMLOk"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
