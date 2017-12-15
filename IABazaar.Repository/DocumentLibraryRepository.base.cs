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
		
	public abstract partial class DocumentLibraryRepositoryBase : Repository 
	{
        
        public DocumentLibraryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DocumentID",new SearchColumn(){Name="DocumentID",Title="DocumentID",SelectClause="DocumentID",WhereClause="AllRecords.DocumentID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LibraryID",new SearchColumn(){Name="LibraryID",Title="LibraryID",SelectClause="LibraryID",WhereClause="AllRecords.LibraryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetDocumentLibrarySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetDocumentLibraryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetDocumentLibraryAdvanceSearchColumns()
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
        
        
        public virtual string GetDocumentLibrarySelectClause()
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
                        	selectQuery =  "DocumentLibrary."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",DocumentLibrary."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual DocumentLibrary GetDocumentLibrary(System.Int32 DocumentId)
		{

			string sql=GetDocumentLibrarySelectClause();
			sql+="from DocumentLibrary where DocumentID=@DocumentID ";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return DocumentLibraryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<DocumentLibrary> GetAllDocumentLibrary()
		{

			string sql=GetDocumentLibrarySelectClause();
			sql+="from DocumentLibrary";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentLibrary>(ds, DocumentLibraryFromDataRow);
		}

		public virtual List<DocumentLibrary> GetPagedDocumentLibrary(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetDocumentLibraryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [DocumentID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([DocumentID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [DocumentID] ";
            tempsql += " FROM [DocumentLibrary] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("DocumentID"))
					tempsql += " , (AllRecords.[DocumentID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[DocumentID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetDocumentLibrarySelectClause()+@" FROM [DocumentLibrary], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [DocumentLibrary].[DocumentID] = PageIndex.[DocumentID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentLibrary>(ds, DocumentLibraryFromDataRow);
			}else{ return null;}
		}

		private int GetDocumentLibraryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM DocumentLibrary as AllRecords ";
			else
				sql = "SELECT Count(*) FROM DocumentLibrary as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(DocumentLibrary))]
		public virtual DocumentLibrary InsertDocumentLibrary(DocumentLibrary entity)
		{

			DocumentLibrary other=new DocumentLibrary();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into DocumentLibrary ( [DocumentID]
				,[LibraryID]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @DocumentID
				, @LibraryID
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@LibraryID",entity.LibraryId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetDocumentLibrary(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(DocumentLibrary))]
		public virtual DocumentLibrary UpdateDocumentLibrary(DocumentLibrary entity)
		{

			if (entity.IsTransient()) return entity;
			DocumentLibrary other = GetDocumentLibrary(entity.DocumentId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update DocumentLibrary set  [LibraryID]=@LibraryID
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where DocumentID=@DocumentID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@LibraryID",entity.LibraryId)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetDocumentLibrary(entity.DocumentId);
		}

		public virtual bool DeleteDocumentLibrary(System.Int32 DocumentId)
		{

			string sql="delete from DocumentLibrary where DocumentID=@DocumentID";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(DocumentLibrary))]
		public virtual DocumentLibrary DeleteDocumentLibrary(DocumentLibrary entity)
		{
			this.DeleteDocumentLibrary(entity.DocumentId);
			return entity;
		}


		public virtual DocumentLibrary DocumentLibraryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			DocumentLibrary entity=new DocumentLibrary();
			entity.DocumentId = (System.Int32)dr["DocumentID"];
			entity.LibraryId = (System.Int32)dr["LibraryID"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
