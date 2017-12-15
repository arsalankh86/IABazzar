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
		
	public abstract partial class PageTypeRepositoryBase : Repository 
	{
        
        public PageTypeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PageTypeID",new SearchColumn(){Name="PageTypeID",Title="PageTypeID",SelectClause="PageTypeID",WhereClause="AllRecords.PageTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageTypeGUID",new SearchColumn(){Name="PageTypeGUID",Title="PageTypeGUID",SelectClause="PageTypeGUID",WhereClause="AllRecords.PageTypeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageTypeName",new SearchColumn(){Name="PageTypeName",Title="PageTypeName",SelectClause="PageTypeName",WhereClause="AllRecords.PageTypeName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPageTypeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPageTypeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPageTypeAdvanceSearchColumns()
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
        
        
        public virtual string GetPageTypeSelectClause()
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
                        	selectQuery =  "PageType."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",PageType."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual PageType GetPageType(System.Int32 PageTypeId)
		{

			string sql=GetPageTypeSelectClause();
			sql+="from PageType where PageTypeID=@PageTypeID ";
			SqlParameter parameter=new SqlParameter("@PageTypeID",PageTypeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PageTypeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<PageType> GetAllPageType()
		{

			string sql=GetPageTypeSelectClause();
			sql+="from PageType";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PageType>(ds, PageTypeFromDataRow);
		}

		public virtual List<PageType> GetPagedPageType(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPageTypeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PageTypeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PageTypeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PageTypeID] ";
            tempsql += " FROM [PageType] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PageTypeID"))
					tempsql += " , (AllRecords.[PageTypeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PageTypeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPageTypeSelectClause()+@" FROM [PageType], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [PageType].[PageTypeID] = PageIndex.[PageTypeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PageType>(ds, PageTypeFromDataRow);
			}else{ return null;}
		}

		private int GetPageTypeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM PageType as AllRecords ";
			else
				sql = "SELECT Count(*) FROM PageType as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(PageType))]
		public virtual PageType InsertPageType(PageType entity)
		{

			PageType other=new PageType();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into PageType ( [PageTypeGUID]
				,[PageTypeName] )
				Values
				( @PageTypeGUID
				, @PageTypeName );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PageTypeID",entity.PageTypeId)
					, new SqlParameter("@PageTypeGUID",entity.PageTypeGuid)
					, new SqlParameter("@PageTypeName",entity.PageTypeName)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPageType(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(PageType))]
		public virtual PageType UpdatePageType(PageType entity)
		{

			if (entity.IsTransient()) return entity;
			PageType other = GetPageType(entity.PageTypeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update PageType set  [PageTypeGUID]=@PageTypeGUID
							, [PageTypeName]=@PageTypeName 
							 where PageTypeID=@PageTypeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PageTypeID",entity.PageTypeId)
					, new SqlParameter("@PageTypeGUID",entity.PageTypeGuid)
					, new SqlParameter("@PageTypeName",entity.PageTypeName)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPageType(entity.PageTypeId);
		}

		public virtual bool DeletePageType(System.Int32 PageTypeId)
		{

			string sql="delete from PageType where PageTypeID=@PageTypeID";
			SqlParameter parameter=new SqlParameter("@PageTypeID",PageTypeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(PageType))]
		public virtual PageType DeletePageType(PageType entity)
		{
			this.DeletePageType(entity.PageTypeId);
			return entity;
		}


		public virtual PageType PageTypeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			PageType entity=new PageType();
			entity.PageTypeId = (System.Int32)dr["PageTypeID"];
			entity.PageTypeGuid = (System.Guid)dr["PageTypeGUID"];
			entity.PageTypeName = dr["PageTypeName"].ToString();
			return entity;
		}

	}
	
	
}
