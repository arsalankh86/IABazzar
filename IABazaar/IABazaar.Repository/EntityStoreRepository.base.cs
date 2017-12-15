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
		
	public abstract partial class EntityStoreRepositoryBase : Repository 
	{
        
        public EntityStoreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ID",new SearchColumn(){Name="ID",Title="ID",SelectClause="ID",WhereClause="AllRecords.ID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EntityID",new SearchColumn(){Name="EntityID",Title="EntityID",SelectClause="EntityID",WhereClause="AllRecords.EntityID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EntityType",new SearchColumn(){Name="EntityType",Title="EntityType",SelectClause="EntityType",WhereClause="AllRecords.EntityType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetEntityStoreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetEntityStoreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetEntityStoreAdvanceSearchColumns()
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
        
        
        public virtual string GetEntityStoreSelectClause()
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
                        	selectQuery =  "EntityStore."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",EntityStore."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual EntityStore GetEntityStore(System.Int32 StoreId)
		{

			string sql=GetEntityStoreSelectClause();
			sql+="from EntityStore where StoreID=@StoreID ";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return EntityStoreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<EntityStore> GetAllEntityStore()
		{

			string sql=GetEntityStoreSelectClause();
			sql+="from EntityStore";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<EntityStore>(ds, EntityStoreFromDataRow);
		}

		public virtual List<EntityStore> GetPagedEntityStore(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetEntityStoreCount(whereClause, searchColumns);
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
            tempsql += " FROM [EntityStore] AllRecords";
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
                GetEntityStoreSelectClause()+@" FROM [EntityStore], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [EntityStore].[StoreID] = PageIndex.[StoreID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<EntityStore>(ds, EntityStoreFromDataRow);
			}else{ return null;}
		}

		private int GetEntityStoreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM EntityStore as AllRecords ";
			else
				sql = "SELECT Count(*) FROM EntityStore as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(EntityStore))]
		public virtual EntityStore InsertEntityStore(EntityStore entity)
		{

			EntityStore other=new EntityStore();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into EntityStore ( [StoreID]
				,[ID]
				,[EntityID]
				,[EntityType]
				,[CreatedOn] )
				Values
				( @StoreID
				, @ID
				, @EntityID
				, @EntityType
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@EntityID",entity.EntityId)
					, new SqlParameter("@EntityType",entity.EntityType)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetEntityStore(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(EntityStore))]
		public virtual EntityStore UpdateEntityStore(EntityStore entity)
		{

			if (entity.IsTransient()) return entity;
			EntityStore other = GetEntityStore(entity.StoreId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update EntityStore set  [ID]=@ID
							, [EntityID]=@EntityID
							, [EntityType]=@EntityType
							, [CreatedOn]=@CreatedOn 
							 where StoreID=@StoreID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@EntityID",entity.EntityId)
					, new SqlParameter("@EntityType",entity.EntityType)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetEntityStore(entity.StoreId);
		}

		public virtual bool DeleteEntityStore(System.Int32 StoreId)
		{

			string sql="delete from EntityStore where StoreID=@StoreID";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(EntityStore))]
		public virtual EntityStore DeleteEntityStore(EntityStore entity)
		{
			this.DeleteEntityStore(entity.StoreId);
			return entity;
		}


		public virtual EntityStore EntityStoreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			EntityStore entity=new EntityStore();
			entity.Id = (System.Int32)dr["ID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.EntityId = (System.Int32)dr["EntityID"];
			entity.EntityType = dr["EntityType"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
