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
		
	public abstract partial class LocaleSettingRepositoryBase : Repository 
	{
        
        public LocaleSettingRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LocaleSettingID",new SearchColumn(){Name="LocaleSettingID",Title="LocaleSettingID",SelectClause="LocaleSettingID",WhereClause="AllRecords.LocaleSettingID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSettingGUID",new SearchColumn(){Name="LocaleSettingGUID",Title="LocaleSettingGUID",SelectClause="LocaleSettingGUID",WhereClause="AllRecords.LocaleSettingGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DefaultCurrencyID",new SearchColumn(){Name="DefaultCurrencyID",Title="DefaultCurrencyID",SelectClause="DefaultCurrencyID",WhereClause="AllRecords.DefaultCurrencyID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLocaleSettingSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLocaleSettingBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLocaleSettingAdvanceSearchColumns()
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
        
        
        public virtual string GetLocaleSettingSelectClause()
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
                        	selectQuery =  "LocaleSetting."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",LocaleSetting."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual LocaleSetting GetLocaleSetting(System.Int32 LocaleSettingId)
		{

			string sql=GetLocaleSettingSelectClause();
			sql+="from LocaleSetting where LocaleSettingID=@LocaleSettingID ";
			SqlParameter parameter=new SqlParameter("@LocaleSettingID",LocaleSettingId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LocaleSettingFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<LocaleSetting> GetAllLocaleSetting()
		{

			string sql=GetLocaleSettingSelectClause();
			sql+="from LocaleSetting";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LocaleSetting>(ds, LocaleSettingFromDataRow);
		}

		public virtual List<LocaleSetting> GetPagedLocaleSetting(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLocaleSettingCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LocaleSettingID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LocaleSettingID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LocaleSettingID] ";
            tempsql += " FROM [LocaleSetting] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LocaleSettingID"))
					tempsql += " , (AllRecords.[LocaleSettingID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LocaleSettingID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLocaleSettingSelectClause()+@" FROM [LocaleSetting], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [LocaleSetting].[LocaleSettingID] = PageIndex.[LocaleSettingID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LocaleSetting>(ds, LocaleSettingFromDataRow);
			}else{ return null;}
		}

		private int GetLocaleSettingCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM LocaleSetting as AllRecords ";
			else
				sql = "SELECT Count(*) FROM LocaleSetting as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(LocaleSetting))]
		public virtual LocaleSetting InsertLocaleSetting(LocaleSetting entity)
		{

			LocaleSetting other=new LocaleSetting();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into LocaleSetting ( [LocaleSettingGUID]
				,[Name]
				,[Description]
				,[DisplayOrder]
				,[CreatedOn]
				,[DefaultCurrencyID] )
				Values
				( @LocaleSettingGUID
				, @Name
				, @Description
				, @DisplayOrder
				, @CreatedOn
				, @DefaultCurrencyID );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LocaleSettingID",entity.LocaleSettingId)
					, new SqlParameter("@LocaleSettingGUID",entity.LocaleSettingGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@DefaultCurrencyID",entity.DefaultCurrencyId)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLocaleSetting(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(LocaleSetting))]
		public virtual LocaleSetting UpdateLocaleSetting(LocaleSetting entity)
		{

			if (entity.IsTransient()) return entity;
			LocaleSetting other = GetLocaleSetting(entity.LocaleSettingId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update LocaleSetting set  [LocaleSettingGUID]=@LocaleSettingGUID
							, [Name]=@Name
							, [Description]=@Description
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn
							, [DefaultCurrencyID]=@DefaultCurrencyID 
							 where LocaleSettingID=@LocaleSettingID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LocaleSettingID",entity.LocaleSettingId)
					, new SqlParameter("@LocaleSettingGUID",entity.LocaleSettingGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@DefaultCurrencyID",entity.DefaultCurrencyId)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLocaleSetting(entity.LocaleSettingId);
		}

		public virtual bool DeleteLocaleSetting(System.Int32 LocaleSettingId)
		{

			string sql="delete from LocaleSetting where LocaleSettingID=@LocaleSettingID";
			SqlParameter parameter=new SqlParameter("@LocaleSettingID",LocaleSettingId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(LocaleSetting))]
		public virtual LocaleSetting DeleteLocaleSetting(LocaleSetting entity)
		{
			this.DeleteLocaleSetting(entity.LocaleSettingId);
			return entity;
		}


		public virtual LocaleSetting LocaleSettingFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			LocaleSetting entity=new LocaleSetting();
			entity.LocaleSettingId = (System.Int32)dr["LocaleSettingID"];
			entity.LocaleSettingGuid = (System.Guid)dr["LocaleSettingGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.DefaultCurrencyId = (System.Int32)dr["DefaultCurrencyID"];
			return entity;
		}

	}
	
	
}
