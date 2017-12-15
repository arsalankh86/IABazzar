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
		
	public abstract partial class DocumentTypeRepositoryBase : Repository 
	{
        
        public DocumentTypeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DocumentTypeID",new SearchColumn(){Name="DocumentTypeID",Title="DocumentTypeID",SelectClause="DocumentTypeID",WhereClause="AllRecords.DocumentTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DocumentTypeGUID",new SearchColumn(){Name="DocumentTypeGUID",Title="DocumentTypeGUID",SelectClause="DocumentTypeGUID",WhereClause="AllRecords.DocumentTypeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetDocumentTypeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetDocumentTypeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetDocumentTypeAdvanceSearchColumns()
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
        
        
        public virtual string GetDocumentTypeSelectClause()
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
                        	selectQuery =  "DocumentType."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",DocumentType."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual DocumentType GetDocumentType(System.Int32 DocumentTypeId)
		{

			string sql=GetDocumentTypeSelectClause();
			sql+="from DocumentType where DocumentTypeID=@DocumentTypeID ";
			SqlParameter parameter=new SqlParameter("@DocumentTypeID",DocumentTypeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return DocumentTypeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<DocumentType> GetAllDocumentType()
		{

			string sql=GetDocumentTypeSelectClause();
			sql+="from DocumentType";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentType>(ds, DocumentTypeFromDataRow);
		}

		public virtual List<DocumentType> GetPagedDocumentType(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetDocumentTypeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [DocumentTypeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([DocumentTypeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [DocumentTypeID] ";
            tempsql += " FROM [DocumentType] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("DocumentTypeID"))
					tempsql += " , (AllRecords.[DocumentTypeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[DocumentTypeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetDocumentTypeSelectClause()+@" FROM [DocumentType], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [DocumentType].[DocumentTypeID] = PageIndex.[DocumentTypeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<DocumentType>(ds, DocumentTypeFromDataRow);
			}else{ return null;}
		}

		private int GetDocumentTypeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM DocumentType as AllRecords ";
			else
				sql = "SELECT Count(*) FROM DocumentType as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(DocumentType))]
		public virtual DocumentType InsertDocumentType(DocumentType entity)
		{

			DocumentType other=new DocumentType();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into DocumentType ( [DocumentTypeGUID]
				,[Name]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @DocumentTypeGUID
				, @Name
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentTypeID",entity.DocumentTypeId)
					, new SqlParameter("@DocumentTypeGUID",entity.DocumentTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetDocumentType(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(DocumentType))]
		public virtual DocumentType UpdateDocumentType(DocumentType entity)
		{

			if (entity.IsTransient()) return entity;
			DocumentType other = GetDocumentType(entity.DocumentTypeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update DocumentType set  [DocumentTypeGUID]=@DocumentTypeGUID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where DocumentTypeID=@DocumentTypeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentTypeID",entity.DocumentTypeId)
					, new SqlParameter("@DocumentTypeGUID",entity.DocumentTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetDocumentType(entity.DocumentTypeId);
		}

		public virtual bool DeleteDocumentType(System.Int32 DocumentTypeId)
		{

			string sql="delete from DocumentType where DocumentTypeID=@DocumentTypeID";
			SqlParameter parameter=new SqlParameter("@DocumentTypeID",DocumentTypeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(DocumentType))]
		public virtual DocumentType DeleteDocumentType(DocumentType entity)
		{
			this.DeleteDocumentType(entity.DocumentTypeId);
			return entity;
		}


		public virtual DocumentType DocumentTypeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			DocumentType entity=new DocumentType();
			entity.DocumentTypeId = (System.Int32)dr["DocumentTypeID"];
			entity.DocumentTypeGuid = (System.Guid)dr["DocumentTypeGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
