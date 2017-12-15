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
		
	public abstract partial class NewsletterMailListRepositoryBase : Repository 
	{
        
        public NewsletterMailListRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ID",new SearchColumn(){Name="ID",Title="ID",SelectClause="ID",WhereClause="AllRecords.ID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GUID",new SearchColumn(){Name="GUID",Title="GUID",SelectClause="GUID",WhereClause="AllRecords.GUID",DataType="System.Guid?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EMailAddress",new SearchColumn(){Name="EMailAddress",Title="EMailAddress",SelectClause="EMailAddress",WhereClause="AllRecords.EMailAddress",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FirstName",new SearchColumn(){Name="FirstName",Title="FirstName",SelectClause="FirstName",WhereClause="AllRecords.FirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastName",new SearchColumn(){Name="LastName",Title="LastName",SelectClause="LastName",WhereClause="AllRecords.LastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionConfirmed",new SearchColumn(){Name="SubscriptionConfirmed",Title="SubscriptionConfirmed",SelectClause="SubscriptionConfirmed",WhereClause="AllRecords.SubscriptionConfirmed",DataType="System.Boolean?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AddedOn",new SearchColumn(){Name="AddedOn",Title="AddedOn",SelectClause="AddedOn",WhereClause="AllRecords.AddedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscribedOn",new SearchColumn(){Name="SubscribedOn",Title="SubscribedOn",SelectClause="SubscribedOn",WhereClause="AllRecords.SubscribedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UnsubscribedOn",new SearchColumn(){Name="UnsubscribedOn",Title="UnsubscribedOn",SelectClause="UnsubscribedOn",WhereClause="AllRecords.UnsubscribedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetNewsletterMailListSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetNewsletterMailListBasicSearchColumns()
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

        public virtual List<SearchColumn> GetNewsletterMailListAdvanceSearchColumns()
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
        
        
        public virtual string GetNewsletterMailListSelectClause()
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
                        	selectQuery =  "NewsletterMailList."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",NewsletterMailList."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual NewsletterMailList GetNewsletterMailList(System.Int32 Id)
		{

			string sql=GetNewsletterMailListSelectClause();
			sql+="from NewsletterMailList where ID=@ID ";
			SqlParameter parameter=new SqlParameter("@ID",Id);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return NewsletterMailListFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<NewsletterMailList> GetAllNewsletterMailList()
		{

			string sql=GetNewsletterMailListSelectClause();
			sql+="from NewsletterMailList";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<NewsletterMailList>(ds, NewsletterMailListFromDataRow);
		}

		public virtual List<NewsletterMailList> GetPagedNewsletterMailList(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetNewsletterMailListCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ID] ";
            tempsql += " FROM [NewsletterMailList] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ID"))
					tempsql += " , (AllRecords.[ID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetNewsletterMailListSelectClause()+@" FROM [NewsletterMailList], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [NewsletterMailList].[ID] = PageIndex.[ID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<NewsletterMailList>(ds, NewsletterMailListFromDataRow);
			}else{ return null;}
		}

		private int GetNewsletterMailListCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM NewsletterMailList as AllRecords ";
			else
				sql = "SELECT Count(*) FROM NewsletterMailList as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(NewsletterMailList))]
		public virtual NewsletterMailList InsertNewsletterMailList(NewsletterMailList entity)
		{

			NewsletterMailList other=new NewsletterMailList();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into NewsletterMailList ( [GUID]
				,[EMailAddress]
				,[FirstName]
				,[LastName]
				,[SubscriptionConfirmed]
				,[AddedOn]
				,[SubscribedOn]
				,[UnsubscribedOn] )
				Values
				( @GUID
				, @EMailAddress
				, @FirstName
				, @LastName
				, @SubscriptionConfirmed
				, @AddedOn
				, @SubscribedOn
				, @UnsubscribedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@GUID",entity.Guid ?? (object)DBNull.Value)
					, new SqlParameter("@EMailAddress",entity.EmailAddress ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionConfirmed",entity.SubscriptionConfirmed ?? (object)DBNull.Value)
					, new SqlParameter("@AddedOn",entity.AddedOn ?? (object)DBNull.Value)
					, new SqlParameter("@SubscribedOn",entity.SubscribedOn ?? (object)DBNull.Value)
					, new SqlParameter("@UnsubscribedOn",entity.UnsubscribedOn ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetNewsletterMailList(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(NewsletterMailList))]
		public virtual NewsletterMailList UpdateNewsletterMailList(NewsletterMailList entity)
		{

			if (entity.IsTransient()) return entity;
			NewsletterMailList other = GetNewsletterMailList(entity.Id);
			if (entity.Equals(other)) return entity;
			string sql=@"Update NewsletterMailList set  [GUID]=@GUID
							, [EMailAddress]=@EMailAddress
							, [FirstName]=@FirstName
							, [LastName]=@LastName
							, [SubscriptionConfirmed]=@SubscriptionConfirmed
							, [AddedOn]=@AddedOn
							, [SubscribedOn]=@SubscribedOn
							, [UnsubscribedOn]=@UnsubscribedOn 
							 where ID=@ID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@GUID",entity.Guid ?? (object)DBNull.Value)
					, new SqlParameter("@EMailAddress",entity.EmailAddress ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionConfirmed",entity.SubscriptionConfirmed ?? (object)DBNull.Value)
					, new SqlParameter("@AddedOn",entity.AddedOn ?? (object)DBNull.Value)
					, new SqlParameter("@SubscribedOn",entity.SubscribedOn ?? (object)DBNull.Value)
					, new SqlParameter("@UnsubscribedOn",entity.UnsubscribedOn ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetNewsletterMailList(entity.Id);
		}

		public virtual bool DeleteNewsletterMailList(System.Int32 Id)
		{

			string sql="delete from NewsletterMailList where ID=@ID";
			SqlParameter parameter=new SqlParameter("@ID",Id);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(NewsletterMailList))]
		public virtual NewsletterMailList DeleteNewsletterMailList(NewsletterMailList entity)
		{
			this.DeleteNewsletterMailList(entity.Id);
			return entity;
		}


		public virtual NewsletterMailList NewsletterMailListFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			NewsletterMailList entity=new NewsletterMailList();
			entity.Id = (System.Int32)dr["ID"];
			entity.Guid = dr["GUID"]==DBNull.Value?(System.Guid?)null:(System.Guid?)dr["GUID"];
			entity.EmailAddress = dr["EMailAddress"].ToString();
			entity.FirstName = dr["FirstName"].ToString();
			entity.LastName = dr["LastName"].ToString();
			entity.SubscriptionConfirmed = dr["SubscriptionConfirmed"]==DBNull.Value?(System.Boolean?)null:(System.Boolean?)dr["SubscriptionConfirmed"];
			entity.AddedOn = dr["AddedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["AddedOn"];
			entity.SubscribedOn = dr["SubscribedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["SubscribedOn"];
			entity.UnsubscribedOn = dr["UnsubscribedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["UnsubscribedOn"];
			return entity;
		}

	}
	
	
}
