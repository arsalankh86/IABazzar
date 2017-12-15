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
		
	public abstract partial class LayoutMapRepositoryBase : Repository 
	{
        
        public LayoutMapRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LayoutMapID",new SearchColumn(){Name="LayoutMapID",Title="LayoutMapID",SelectClause="LayoutMapID",WhereClause="AllRecords.LayoutMapID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutMapGUID",new SearchColumn(){Name="LayoutMapGUID",Title="LayoutMapGUID",SelectClause="LayoutMapGUID",WhereClause="AllRecords.LayoutMapGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutID",new SearchColumn(){Name="LayoutID",Title="LayoutID",SelectClause="LayoutID",WhereClause="AllRecords.LayoutID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageTypeID",new SearchColumn(){Name="PageTypeID",Title="PageTypeID",SelectClause="PageTypeID",WhereClause="AllRecords.PageTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageID",new SearchColumn(){Name="PageID",Title="PageID",SelectClause="PageID",WhereClause="AllRecords.PageID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLayoutMapSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLayoutMapBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLayoutMapAdvanceSearchColumns()
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
        
        
        public virtual string GetLayoutMapSelectClause()
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
                        	selectQuery =  "LayoutMap."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",LayoutMap."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual LayoutMap GetLayoutMap(System.Int32 LayoutMapId)
		{

			string sql=GetLayoutMapSelectClause();
			sql+="from LayoutMap where LayoutMapID=@LayoutMapID ";
			SqlParameter parameter=new SqlParameter("@LayoutMapID",LayoutMapId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LayoutMapFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<LayoutMap> GetAllLayoutMap()
		{

			string sql=GetLayoutMapSelectClause();
			sql+="from LayoutMap";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutMap>(ds, LayoutMapFromDataRow);
		}

		public virtual List<LayoutMap> GetPagedLayoutMap(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLayoutMapCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LayoutMapID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LayoutMapID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LayoutMapID] ";
            tempsql += " FROM [LayoutMap] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LayoutMapID"))
					tempsql += " , (AllRecords.[LayoutMapID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LayoutMapID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLayoutMapSelectClause()+@" FROM [LayoutMap], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [LayoutMap].[LayoutMapID] = PageIndex.[LayoutMapID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutMap>(ds, LayoutMapFromDataRow);
			}else{ return null;}
		}

		private int GetLayoutMapCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM LayoutMap as AllRecords ";
			else
				sql = "SELECT Count(*) FROM LayoutMap as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(LayoutMap))]
		public virtual LayoutMap InsertLayoutMap(LayoutMap entity)
		{

			LayoutMap other=new LayoutMap();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into LayoutMap ( [LayoutMapGUID]
				,[LayoutID]
				,[PageTypeID]
				,[PageID]
				,[CreatedOn] )
				Values
				( @LayoutMapGUID
				, @LayoutID
				, @PageTypeID
				, @PageID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutMapID",entity.LayoutMapId)
					, new SqlParameter("@LayoutMapGUID",entity.LayoutMapGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@PageTypeID",entity.PageTypeId)
					, new SqlParameter("@PageID",entity.PageId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLayoutMap(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(LayoutMap))]
		public virtual LayoutMap UpdateLayoutMap(LayoutMap entity)
		{

			if (entity.IsTransient()) return entity;
			LayoutMap other = GetLayoutMap(entity.LayoutMapId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update LayoutMap set  [LayoutMapGUID]=@LayoutMapGUID
							, [LayoutID]=@LayoutID
							, [PageTypeID]=@PageTypeID
							, [PageID]=@PageID
							, [CreatedOn]=@CreatedOn 
							 where LayoutMapID=@LayoutMapID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutMapID",entity.LayoutMapId)
					, new SqlParameter("@LayoutMapGUID",entity.LayoutMapGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@PageTypeID",entity.PageTypeId)
					, new SqlParameter("@PageID",entity.PageId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLayoutMap(entity.LayoutMapId);
		}

		public virtual bool DeleteLayoutMap(System.Int32 LayoutMapId)
		{

			string sql="delete from LayoutMap where LayoutMapID=@LayoutMapID";
			SqlParameter parameter=new SqlParameter("@LayoutMapID",LayoutMapId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(LayoutMap))]
		public virtual LayoutMap DeleteLayoutMap(LayoutMap entity)
		{
			this.DeleteLayoutMap(entity.LayoutMapId);
			return entity;
		}


		public virtual LayoutMap LayoutMapFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			LayoutMap entity=new LayoutMap();
			entity.LayoutMapId = (System.Int32)dr["LayoutMapID"];
			entity.LayoutMapGuid = (System.Guid)dr["LayoutMapGUID"];
			entity.LayoutId = (System.Int32)dr["LayoutID"];
			entity.PageTypeId = (System.Int32)dr["PageTypeID"];
			entity.PageId = (System.Int32)dr["PageID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
