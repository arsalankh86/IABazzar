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
		
	public abstract partial class DocumentCustomerLevelRepositoryBase : Repository 
	{
        
        public DocumentCustomerLevelRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DocumentID",new SearchColumn(){Name="DocumentID",Title="DocumentID",SelectClause="DocumentID",WhereClause="AllRecords.DocumentID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerLevelID",new SearchColumn(){Name="CustomerLevelID",Title="CustomerLevelID",SelectClause="CustomerLevelID",WhereClause="AllRecords.CustomerLevelID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetDocumentCustomerLevelSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetDocumentCustomerLevelBasicSearchColumns()
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

        public virtual List<SearchColumn> GetDocumentCustomerLevelAdvanceSearchColumns()
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
        
        
        public virtual string GetDocumentCustomerLevelSelectClause()
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
                        	selectQuery =  "DocumentCustomerLevel."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",DocumentCustomerLevel."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual DocumentCustomerLevel GetDocumentCustomerLevel(System.Int32 DocumentId)
		{

			string sql=GetDocumentCustomerLevelSelectClause();
			sql+="from DocumentCustomerLevel where DocumentID=@DocumentID ";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return DocumentCustomerLevelFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<DocumentCustomerLevel> GetAllDocumentCustomerLevel()
		{

			string sql=GetDocumentCustomerLevelSelectClause();
			sql+="from DocumentCustomerLevel";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentCustomerLevel>(ds, DocumentCustomerLevelFromDataRow);
		}

		public virtual List<DocumentCustomerLevel> GetPagedDocumentCustomerLevel(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetDocumentCustomerLevelCount(whereClause, searchColumns);
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
            tempsql += " FROM [DocumentCustomerLevel] AllRecords";
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
                GetDocumentCustomerLevelSelectClause()+@" FROM [DocumentCustomerLevel], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [DocumentCustomerLevel].[DocumentID] = PageIndex.[DocumentID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentCustomerLevel>(ds, DocumentCustomerLevelFromDataRow);
			}else{ return null;}
		}

		private int GetDocumentCustomerLevelCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM DocumentCustomerLevel as AllRecords ";
			else
				sql = "SELECT Count(*) FROM DocumentCustomerLevel as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(DocumentCustomerLevel))]
		public virtual DocumentCustomerLevel InsertDocumentCustomerLevel(DocumentCustomerLevel entity)
		{

			DocumentCustomerLevel other=new DocumentCustomerLevel();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into DocumentCustomerLevel ( [DocumentID]
				,[CustomerLevelID]
				,[CreatedOn] )
				Values
				( @DocumentID
				, @CustomerLevelID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetDocumentCustomerLevel(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(DocumentCustomerLevel))]
		public virtual DocumentCustomerLevel UpdateDocumentCustomerLevel(DocumentCustomerLevel entity)
		{

			if (entity.IsTransient()) return entity;
			DocumentCustomerLevel other = GetDocumentCustomerLevel(entity.DocumentId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update DocumentCustomerLevel set  [CustomerLevelID]=@CustomerLevelID
							, [CreatedOn]=@CreatedOn 
							 where DocumentID=@DocumentID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetDocumentCustomerLevel(entity.DocumentId);
		}

		public virtual bool DeleteDocumentCustomerLevel(System.Int32 DocumentId)
		{

			string sql="delete from DocumentCustomerLevel where DocumentID=@DocumentID";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(DocumentCustomerLevel))]
		public virtual DocumentCustomerLevel DeleteDocumentCustomerLevel(DocumentCustomerLevel entity)
		{
			this.DeleteDocumentCustomerLevel(entity.DocumentId);
			return entity;
		}


		public virtual DocumentCustomerLevel DocumentCustomerLevelFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			DocumentCustomerLevel entity=new DocumentCustomerLevel();
			entity.DocumentId = (System.Int32)dr["DocumentID"];
			entity.CustomerLevelId = (System.Int32)dr["CustomerLevelID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
