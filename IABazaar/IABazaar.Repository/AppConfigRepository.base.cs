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
		
	public abstract partial class AppConfigRepositoryBase : Repository 
	{
        
        public AppConfigRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("AppConfigID",new SearchColumn(){Name="AppConfigID",Title="AppConfigID",SelectClause="AppConfigID",WhereClause="AllRecords.AppConfigID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AppConfigGUID",new SearchColumn(){Name="AppConfigGUID",Title="AppConfigGUID",SelectClause="AppConfigGUID",WhereClause="AllRecords.AppConfigGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ConfigValue",new SearchColumn(){Name="ConfigValue",Title="ConfigValue",SelectClause="ConfigValue",WhereClause="AllRecords.ConfigValue",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValueType",new SearchColumn(){Name="ValueType",Title="ValueType",SelectClause="ValueType",WhereClause="AllRecords.ValueType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AllowableValues",new SearchColumn(){Name="AllowableValues",Title="AllowableValues",SelectClause="AllowableValues",WhereClause="AllRecords.AllowableValues",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GroupName",new SearchColumn(){Name="GroupName",Title="GroupName",SelectClause="GroupName",WhereClause="AllRecords.GroupName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SuperOnly",new SearchColumn(){Name="SuperOnly",Title="SuperOnly",SelectClause="SuperOnly",WhereClause="AllRecords.SuperOnly",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Hidden",new SearchColumn(){Name="Hidden",Title="Hidden",SelectClause="Hidden",WhereClause="AllRecords.Hidden",DataType="System.Boolean",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetAppConfigSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetAppConfigBasicSearchColumns()
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

        public virtual List<SearchColumn> GetAppConfigAdvanceSearchColumns()
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
        
        
        public virtual string GetAppConfigSelectClause()
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
                        	selectQuery =  "AppConfig."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",AppConfig."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual AppConfig GetAppConfig(System.Int32 AppConfigId)
		{

			string sql=GetAppConfigSelectClause();
			sql+="from AppConfig where AppConfigID=@AppConfigID ";
			SqlParameter parameter=new SqlParameter("@AppConfigID",AppConfigId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return AppConfigFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<AppConfig> GetAllAppConfig()
		{

			string sql=GetAppConfigSelectClause();
			sql+="from AppConfig";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AppConfig>(ds, AppConfigFromDataRow);
		}

		public virtual List<AppConfig> GetPagedAppConfig(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetAppConfigCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [AppConfigID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([AppConfigID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [AppConfigID] ";
            tempsql += " FROM [AppConfig] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("AppConfigID"))
					tempsql += " , (AllRecords.[AppConfigID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[AppConfigID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetAppConfigSelectClause()+@" FROM [AppConfig], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [AppConfig].[AppConfigID] = PageIndex.[AppConfigID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<AppConfig>(ds, AppConfigFromDataRow);
			}else{ return null;}
		}

		private int GetAppConfigCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM AppConfig as AllRecords ";
			else
				sql = "SELECT Count(*) FROM AppConfig as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(AppConfig))]
		public virtual AppConfig InsertAppConfig(AppConfig entity)
		{

			AppConfig other=new AppConfig();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into AppConfig ( [AppConfigGUID]
				,[StoreID]
				,[Name]
				,[Description]
				,[ConfigValue]
				,[ValueType]
				,[AllowableValues]
				,[GroupName]
				,[SuperOnly]
				,[Hidden]
				,[CreatedOn] )
				Values
				( @AppConfigGUID
				, @StoreID
				, @Name
				, @Description
				, @ConfigValue
				, @ValueType
				, @AllowableValues
				, @GroupName
				, @SuperOnly
				, @Hidden
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AppConfigID",entity.AppConfigId)
					, new SqlParameter("@AppConfigGUID",entity.AppConfigGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@ValueType",entity.ValueType ?? (object)DBNull.Value)
					, new SqlParameter("@AllowableValues",entity.AllowableValues ?? (object)DBNull.Value)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@SuperOnly",entity.SuperOnly)
					, new SqlParameter("@Hidden",entity.Hidden)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetAppConfig(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(AppConfig))]
		public virtual AppConfig UpdateAppConfig(AppConfig entity)
		{

			if (entity.IsTransient()) return entity;
			AppConfig other = GetAppConfig(entity.AppConfigId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update AppConfig set  [AppConfigGUID]=@AppConfigGUID
							, [StoreID]=@StoreID
							, [Name]=@Name
							, [Description]=@Description
							, [ConfigValue]=@ConfigValue
							, [ValueType]=@ValueType
							, [AllowableValues]=@AllowableValues
							, [GroupName]=@GroupName
							, [SuperOnly]=@SuperOnly
							, [Hidden]=@Hidden
							, [CreatedOn]=@CreatedOn 
							 where AppConfigID=@AppConfigID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AppConfigID",entity.AppConfigId)
					, new SqlParameter("@AppConfigGUID",entity.AppConfigGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@ValueType",entity.ValueType ?? (object)DBNull.Value)
					, new SqlParameter("@AllowableValues",entity.AllowableValues ?? (object)DBNull.Value)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@SuperOnly",entity.SuperOnly)
					, new SqlParameter("@Hidden",entity.Hidden)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetAppConfig(entity.AppConfigId);
		}

		public virtual bool DeleteAppConfig(System.Int32 AppConfigId)
		{

			string sql="delete from AppConfig where AppConfigID=@AppConfigID";
			SqlParameter parameter=new SqlParameter("@AppConfigID",AppConfigId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(AppConfig))]
		public virtual AppConfig DeleteAppConfig(AppConfig entity)
		{
			this.DeleteAppConfig(entity.AppConfigId);
			return entity;
		}


		public virtual AppConfig AppConfigFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			AppConfig entity=new AppConfig();
			entity.AppConfigId = (System.Int32)dr["AppConfigID"];
			entity.AppConfigGuid = (System.Guid)dr["AppConfigGUID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.ConfigValue = dr["ConfigValue"].ToString();
			entity.ValueType = dr["ValueType"].ToString();
			entity.AllowableValues = dr["AllowableValues"].ToString();
			entity.GroupName = dr["GroupName"].ToString();
			entity.SuperOnly = (System.Byte)dr["SuperOnly"];
			entity.Hidden = (System.Boolean)dr["Hidden"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
