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
		
	public abstract partial class StringResourceRepositoryBase : Repository 
	{
        
        public StringResourceRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StringResourceID",new SearchColumn(){Name="StringResourceID",Title="StringResourceID",SelectClause="StringResourceID",WhereClause="AllRecords.StringResourceID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StringResourceGUID",new SearchColumn(){Name="StringResourceGUID",Title="StringResourceGUID",SelectClause="StringResourceGUID",WhereClause="AllRecords.StringResourceGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSetting",new SearchColumn(){Name="LocaleSetting",Title="LocaleSetting",SelectClause="LocaleSetting",WhereClause="AllRecords.LocaleSetting",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ConfigValue",new SearchColumn(){Name="ConfigValue",Title="ConfigValue",SelectClause="ConfigValue",WhereClause="AllRecords.ConfigValue",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Modified",new SearchColumn(){Name="Modified",Title="Modified",SelectClause="Modified",WhereClause="AllRecords.Modified",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetStringResourceSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetStringResourceBasicSearchColumns()
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

        public virtual List<SearchColumn> GetStringResourceAdvanceSearchColumns()
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
        
        
        public virtual string GetStringResourceSelectClause()
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
                        	selectQuery =  "StringResource."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",StringResource."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual StringResource GetStringResource(System.Int32 StringResourceId)
		{

			string sql=GetStringResourceSelectClause();
			sql+="from StringResource where StringResourceID=@StringResourceID ";
			SqlParameter parameter=new SqlParameter("@StringResourceID",StringResourceId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return StringResourceFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<StringResource> GetAllStringResource()
		{

			string sql=GetStringResourceSelectClause();
			sql+="from StringResource";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<StringResource>(ds, StringResourceFromDataRow);
		}

		public virtual List<StringResource> GetPagedStringResource(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetStringResourceCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StringResourceID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StringResourceID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StringResourceID] ";
            tempsql += " FROM [StringResource] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StringResourceID"))
					tempsql += " , (AllRecords.[StringResourceID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StringResourceID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetStringResourceSelectClause()+@" FROM [StringResource], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [StringResource].[StringResourceID] = PageIndex.[StringResourceID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<StringResource>(ds, StringResourceFromDataRow);
			}else{ return null;}
		}

		private int GetStringResourceCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM StringResource as AllRecords ";
			else
				sql = "SELECT Count(*) FROM StringResource as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(StringResource))]
		public virtual StringResource InsertStringResource(StringResource entity)
		{

			StringResource other=new StringResource();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into StringResource ( [StringResourceGUID]
				,[StoreID]
				,[Name]
				,[LocaleSetting]
				,[ConfigValue]
				,[Modified]
				,[CreatedOn] )
				Values
				( @StringResourceGUID
				, @StoreID
				, @Name
				, @LocaleSetting
				, @ConfigValue
				, @Modified
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StringResourceID",entity.StringResourceId)
					, new SqlParameter("@StringResourceGUID",entity.StringResourceGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@Modified",entity.Modified)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetStringResource(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(StringResource))]
		public virtual StringResource UpdateStringResource(StringResource entity)
		{

			if (entity.IsTransient()) return entity;
			StringResource other = GetStringResource(entity.StringResourceId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update StringResource set  [StringResourceGUID]=@StringResourceGUID
							, [StoreID]=@StoreID
							, [Name]=@Name
							, [LocaleSetting]=@LocaleSetting
							, [ConfigValue]=@ConfigValue
							, [Modified]=@Modified
							, [CreatedOn]=@CreatedOn 
							 where StringResourceID=@StringResourceID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StringResourceID",entity.StringResourceId)
					, new SqlParameter("@StringResourceGUID",entity.StringResourceGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting)
					, new SqlParameter("@ConfigValue",entity.ConfigValue ?? (object)DBNull.Value)
					, new SqlParameter("@Modified",entity.Modified)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetStringResource(entity.StringResourceId);
		}

		public virtual bool DeleteStringResource(System.Int32 StringResourceId)
		{

			string sql="delete from StringResource where StringResourceID=@StringResourceID";
			SqlParameter parameter=new SqlParameter("@StringResourceID",StringResourceId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(StringResource))]
		public virtual StringResource DeleteStringResource(StringResource entity)
		{
			this.DeleteStringResource(entity.StringResourceId);
			return entity;
		}


		public virtual StringResource StringResourceFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			StringResource entity=new StringResource();
			entity.StringResourceId = (System.Int32)dr["StringResourceID"];
			entity.StringResourceGuid = (System.Guid)dr["StringResourceGUID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.Name = dr["Name"].ToString();
			entity.LocaleSetting = dr["LocaleSetting"].ToString();
			entity.ConfigValue = dr["ConfigValue"].ToString();
			entity.Modified = (System.Byte)dr["Modified"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
