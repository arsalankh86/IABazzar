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
		
	public abstract partial class StoreRepositoryBase : Repository 
	{
        
        public StoreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreGUID",new SearchColumn(){Name="StoreGUID",Title="StoreGUID",SelectClause="StoreGUID",WhereClause="AllRecords.StoreGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductionURI",new SearchColumn(){Name="ProductionURI",Title="ProductionURI",SelectClause="ProductionURI",WhereClause="AllRecords.ProductionURI",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StagingURI",new SearchColumn(){Name="StagingURI",Title="StagingURI",SelectClause="StagingURI",WhereClause="AllRecords.StagingURI",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DevelopmentURI",new SearchColumn(){Name="DevelopmentURI",Title="DevelopmentURI",SelectClause="DevelopmentURI",WhereClause="AllRecords.DevelopmentURI",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDefault",new SearchColumn(){Name="IsDefault",Title="IsDefault",SelectClause="IsDefault",WhereClause="AllRecords.IsDefault",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetStoreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetStoreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetStoreAdvanceSearchColumns()
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
        
        
        public virtual string GetStoreSelectClause()
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
                        	selectQuery =  "Store."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Store."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Store GetStore(System.Int32 StoreId)
		{

			string sql=GetStoreSelectClause();
			sql+="from Store where StoreID=@StoreID ";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return StoreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Store> GetAllStore()
		{

			string sql=GetStoreSelectClause();
			sql+="from Store";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Store>(ds, StoreFromDataRow);
		}

		public virtual List<Store> GetPagedStore(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetStoreCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StoreID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StoreID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StoreID] ";
            tempsql += " FROM [Store] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StoreID"))
					tempsql += " , (AllRecords.[StoreID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StoreID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetStoreSelectClause()+@" FROM [Store], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Store].[StoreID] = PageIndex.[StoreID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Store>(ds, StoreFromDataRow);
			}else{ return null;}
		}

		private int GetStoreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Store as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Store as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Store))]
		public virtual Store InsertStore(Store entity)
		{

			Store other=new Store();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Store ( [StoreGUID]
				,[ProductionURI]
				,[StagingURI]
				,[DevelopmentURI]
				,[Name]
				,[Summary]
				,[Description]
				,[Published]
				,[Deleted]
				,[SkinID]
				,[IsDefault]
				,[CreatedOn] )
				Values
				( @StoreGUID
				, @ProductionURI
				, @StagingURI
				, @DevelopmentURI
				, @Name
				, @Summary
				, @Description
				, @Published
				, @Deleted
				, @SkinID
				, @IsDefault
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@StoreGUID",entity.StoreGuid)
					, new SqlParameter("@ProductionURI",entity.ProductionUri ?? (object)DBNull.Value)
					, new SqlParameter("@StagingURI",entity.StagingUri ?? (object)DBNull.Value)
					, new SqlParameter("@DevelopmentURI",entity.DevelopmentUri ?? (object)DBNull.Value)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetStore(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Store))]
		public virtual Store UpdateStore(Store entity)
		{

			if (entity.IsTransient()) return entity;
			Store other = GetStore(entity.StoreId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Store set  [StoreGUID]=@StoreGUID
							, [ProductionURI]=@ProductionURI
							, [StagingURI]=@StagingURI
							, [DevelopmentURI]=@DevelopmentURI
							, [Name]=@Name
							, [Summary]=@Summary
							, [Description]=@Description
							, [Published]=@Published
							, [Deleted]=@Deleted
							, [SkinID]=@SkinID
							, [IsDefault]=@IsDefault
							, [CreatedOn]=@CreatedOn 
							 where StoreID=@StoreID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@StoreGUID",entity.StoreGuid)
					, new SqlParameter("@ProductionURI",entity.ProductionUri ?? (object)DBNull.Value)
					, new SqlParameter("@StagingURI",entity.StagingUri ?? (object)DBNull.Value)
					, new SqlParameter("@DevelopmentURI",entity.DevelopmentUri ?? (object)DBNull.Value)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetStore(entity.StoreId);
		}

		public virtual bool DeleteStore(System.Int32 StoreId)
		{

			string sql="delete from Store where StoreID=@StoreID";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Store))]
		public virtual Store DeleteStore(Store entity)
		{
			this.DeleteStore(entity.StoreId);
			return entity;
		}


		public virtual Store StoreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Store entity=new Store();
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.StoreGuid = (System.Guid)dr["StoreGUID"];
			entity.ProductionUri = dr["ProductionURI"].ToString();
			entity.StagingUri = dr["StagingURI"].ToString();
			entity.DevelopmentUri = dr["DevelopmentURI"].ToString();
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.IsDefault = (System.Byte)dr["IsDefault"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
