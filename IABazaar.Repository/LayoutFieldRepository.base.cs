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
		
	public abstract partial class LayoutFieldRepositoryBase : Repository 
	{
        
        public LayoutFieldRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LayoutFieldID",new SearchColumn(){Name="LayoutFieldID",Title="LayoutFieldID",SelectClause="LayoutFieldID",WhereClause="AllRecords.LayoutFieldID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutFieldGUID",new SearchColumn(){Name="LayoutFieldGUID",Title="LayoutFieldGUID",SelectClause="LayoutFieldGUID",WhereClause="AllRecords.LayoutFieldGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutID",new SearchColumn(){Name="LayoutID",Title="LayoutID",SelectClause="LayoutID",WhereClause="AllRecords.LayoutID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FieldType",new SearchColumn(){Name="FieldType",Title="FieldType",SelectClause="FieldType",WhereClause="AllRecords.FieldType",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FieldID",new SearchColumn(){Name="FieldID",Title="FieldID",SelectClause="FieldID",WhereClause="AllRecords.FieldID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLayoutFieldSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLayoutFieldBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLayoutFieldAdvanceSearchColumns()
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
        
        
        public virtual string GetLayoutFieldSelectClause()
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
                        	selectQuery =  "LayoutField."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",LayoutField."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual LayoutField GetLayoutField(System.Int32 LayoutFieldId)
		{

			string sql=GetLayoutFieldSelectClause();
			sql+="from LayoutField where LayoutFieldID=@LayoutFieldID ";
			SqlParameter parameter=new SqlParameter("@LayoutFieldID",LayoutFieldId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LayoutFieldFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<LayoutField> GetAllLayoutField()
		{

			string sql=GetLayoutFieldSelectClause();
			sql+="from LayoutField";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutField>(ds, LayoutFieldFromDataRow);
		}

		public virtual List<LayoutField> GetPagedLayoutField(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLayoutFieldCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LayoutFieldID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LayoutFieldID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LayoutFieldID] ";
            tempsql += " FROM [LayoutField] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LayoutFieldID"))
					tempsql += " , (AllRecords.[LayoutFieldID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LayoutFieldID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLayoutFieldSelectClause()+@" FROM [LayoutField], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [LayoutField].[LayoutFieldID] = PageIndex.[LayoutFieldID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutField>(ds, LayoutFieldFromDataRow);
			}else{ return null;}
		}

		private int GetLayoutFieldCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM LayoutField as AllRecords ";
			else
				sql = "SELECT Count(*) FROM LayoutField as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(LayoutField))]
		public virtual LayoutField InsertLayoutField(LayoutField entity)
		{

			LayoutField other=new LayoutField();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into LayoutField ( [LayoutFieldGUID]
				,[LayoutID]
				,[FieldType]
				,[FieldID]
				,[CreatedOn] )
				Values
				( @LayoutFieldGUID
				, @LayoutID
				, @FieldType
				, @FieldID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutFieldID",entity.LayoutFieldId)
					, new SqlParameter("@LayoutFieldGUID",entity.LayoutFieldGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId ?? (object)DBNull.Value)
					, new SqlParameter("@FieldType",entity.FieldType ?? (object)DBNull.Value)
					, new SqlParameter("@FieldID",entity.FieldId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLayoutField(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(LayoutField))]
		public virtual LayoutField UpdateLayoutField(LayoutField entity)
		{

			if (entity.IsTransient()) return entity;
			LayoutField other = GetLayoutField(entity.LayoutFieldId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update LayoutField set  [LayoutFieldGUID]=@LayoutFieldGUID
							, [LayoutID]=@LayoutID
							, [FieldType]=@FieldType
							, [FieldID]=@FieldID
							, [CreatedOn]=@CreatedOn 
							 where LayoutFieldID=@LayoutFieldID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutFieldID",entity.LayoutFieldId)
					, new SqlParameter("@LayoutFieldGUID",entity.LayoutFieldGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId ?? (object)DBNull.Value)
					, new SqlParameter("@FieldType",entity.FieldType ?? (object)DBNull.Value)
					, new SqlParameter("@FieldID",entity.FieldId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLayoutField(entity.LayoutFieldId);
		}

		public virtual bool DeleteLayoutField(System.Int32 LayoutFieldId)
		{

			string sql="delete from LayoutField where LayoutFieldID=@LayoutFieldID";
			SqlParameter parameter=new SqlParameter("@LayoutFieldID",LayoutFieldId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(LayoutField))]
		public virtual LayoutField DeleteLayoutField(LayoutField entity)
		{
			this.DeleteLayoutField(entity.LayoutFieldId);
			return entity;
		}


		public virtual LayoutField LayoutFieldFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			LayoutField entity=new LayoutField();
			entity.LayoutFieldId = (System.Int32)dr["LayoutFieldID"];
			entity.LayoutFieldGuid = (System.Guid)dr["LayoutFieldGUID"];
			entity.LayoutId = dr["LayoutID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["LayoutID"];
			entity.FieldType = dr["FieldType"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["FieldType"];
			entity.FieldId = dr["FieldID"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
