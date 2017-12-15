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
		
	public abstract partial class GlobalConfigRepositoryBase : Repository 
	{
        
        public GlobalConfigRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("GlobalConfigID",new SearchColumn(){Name="GlobalConfigID",Title="GlobalConfigID",SelectClause="GlobalConfigID",WhereClause="AllRecords.GlobalConfigID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GlobalConfigGUID",new SearchColumn(){Name="GlobalConfigGUID",Title="GlobalConfigGUID",SelectClause="GlobalConfigGUID",WhereClause="AllRecords.GlobalConfigGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ConfigValue",new SearchColumn(){Name="ConfigValue",Title="ConfigValue",SelectClause="ConfigValue",WhereClause="AllRecords.ConfigValue",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValueType",new SearchColumn(){Name="ValueType",Title="ValueType",SelectClause="ValueType",WhereClause="AllRecords.ValueType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GroupName",new SearchColumn(){Name="GroupName",Title="GroupName",SelectClause="GroupName",WhereClause="AllRecords.GroupName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EnumValues",new SearchColumn(){Name="EnumValues",Title="EnumValues",SelectClause="EnumValues",WhereClause="AllRecords.EnumValues",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SuperOnly",new SearchColumn(){Name="SuperOnly",Title="SuperOnly",SelectClause="SuperOnly",WhereClause="AllRecords.SuperOnly",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Hidden",new SearchColumn(){Name="Hidden",Title="Hidden",SelectClause="Hidden",WhereClause="AllRecords.Hidden",DataType="System.Boolean",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsMultiStore",new SearchColumn(){Name="IsMultiStore",Title="IsMultiStore",SelectClause="IsMultiStore",WhereClause="AllRecords.IsMultiStore",DataType="System.Boolean",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetGlobalConfigSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetGlobalConfigBasicSearchColumns()
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

        public virtual List<SearchColumn> GetGlobalConfigAdvanceSearchColumns()
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
        
        
        public virtual string GetGlobalConfigSelectClause()
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
                        	selectQuery =  "GlobalConfig."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",GlobalConfig."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual GlobalConfig GetGlobalConfig(System.Int32 GlobalConfigId)
		{

			string sql=GetGlobalConfigSelectClause();
			sql+="from GlobalConfig where GlobalConfigID=@GlobalConfigID ";
			SqlParameter parameter=new SqlParameter("@GlobalConfigID",GlobalConfigId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return GlobalConfigFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<GlobalConfig> GetAllGlobalConfig()
		{

			string sql=GetGlobalConfigSelectClause();
			sql+="from GlobalConfig";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GlobalConfig>(ds, GlobalConfigFromDataRow);
		}

		public virtual List<GlobalConfig> GetPagedGlobalConfig(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetGlobalConfigCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [GlobalConfigID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([GlobalConfigID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [GlobalConfigID] ";
            tempsql += " FROM [GlobalConfig] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("GlobalConfigID"))
					tempsql += " , (AllRecords.[GlobalConfigID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[GlobalConfigID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetGlobalConfigSelectClause()+@" FROM [GlobalConfig], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [GlobalConfig].[GlobalConfigID] = PageIndex.[GlobalConfigID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GlobalConfig>(ds, GlobalConfigFromDataRow);
			}else{ return null;}
		}

		private int GetGlobalConfigCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM GlobalConfig as AllRecords ";
			else
				sql = "SELECT Count(*) FROM GlobalConfig as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(GlobalConfig))]
		public virtual GlobalConfig InsertGlobalConfig(GlobalConfig entity)
		{

			GlobalConfig other=new GlobalConfig();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into GlobalConfig ( [GlobalConfigGUID]
				,[Name]
				,[Description]
				,[ConfigValue]
				,[ValueType]
				,[GroupName]
				,[EnumValues]
				,[SuperOnly]
				,[Hidden]
				,[IsMultiStore]
				,[CreatedOn] )
				Values
				( @GlobalConfigGUID
				, @Name
				, @Description
				, @ConfigValue
				, @ValueType
				, @GroupName
				, @EnumValues
				, @SuperOnly
				, @Hidden
				, @IsMultiStore
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GlobalConfigID",entity.GlobalConfigId)
					, new SqlParameter("@GlobalConfigGUID",entity.GlobalConfigGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@ValueType",entity.ValueType)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@EnumValues",entity.EnumValues ?? (object)DBNull.Value)
					, new SqlParameter("@SuperOnly",entity.SuperOnly)
					, new SqlParameter("@Hidden",entity.Hidden)
					, new SqlParameter("@IsMultiStore",entity.IsMultiStore)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetGlobalConfig(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(GlobalConfig))]
		public virtual GlobalConfig UpdateGlobalConfig(GlobalConfig entity)
		{

			if (entity.IsTransient()) return entity;
			GlobalConfig other = GetGlobalConfig(entity.GlobalConfigId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update GlobalConfig set  [GlobalConfigGUID]=@GlobalConfigGUID
							, [Name]=@Name
							, [Description]=@Description
							, [ConfigValue]=@ConfigValue
							, [ValueType]=@ValueType
							, [GroupName]=@GroupName
							, [EnumValues]=@EnumValues
							, [SuperOnly]=@SuperOnly
							, [Hidden]=@Hidden
							, [IsMultiStore]=@IsMultiStore
							, [CreatedOn]=@CreatedOn 
							 where GlobalConfigID=@GlobalConfigID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GlobalConfigID",entity.GlobalConfigId)
					, new SqlParameter("@GlobalConfigGUID",entity.GlobalConfigGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@ValueType",entity.ValueType)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@EnumValues",entity.EnumValues ?? (object)DBNull.Value)
					, new SqlParameter("@SuperOnly",entity.SuperOnly)
					, new SqlParameter("@Hidden",entity.Hidden)
					, new SqlParameter("@IsMultiStore",entity.IsMultiStore)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetGlobalConfig(entity.GlobalConfigId);
		}

		public virtual bool DeleteGlobalConfig(System.Int32 GlobalConfigId)
		{

			string sql="delete from GlobalConfig where GlobalConfigID=@GlobalConfigID";
			SqlParameter parameter=new SqlParameter("@GlobalConfigID",GlobalConfigId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(GlobalConfig))]
		public virtual GlobalConfig DeleteGlobalConfig(GlobalConfig entity)
		{
			this.DeleteGlobalConfig(entity.GlobalConfigId);
			return entity;
		}


		public virtual GlobalConfig GlobalConfigFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			GlobalConfig entity=new GlobalConfig();
			entity.GlobalConfigId = (System.Int32)dr["GlobalConfigID"];
			entity.GlobalConfigGuid = (System.Guid)dr["GlobalConfigGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.ConfigValue = dr["ConfigValue"].ToString();
			entity.ValueType = dr["ValueType"].ToString();
			entity.GroupName = dr["GroupName"].ToString();
			entity.EnumValues = dr["EnumValues"].ToString();
			entity.SuperOnly = (System.Byte)dr["SuperOnly"];
			entity.Hidden = (System.Boolean)dr["Hidden"];
			entity.IsMultiStore = (System.Boolean)dr["IsMultiStore"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
