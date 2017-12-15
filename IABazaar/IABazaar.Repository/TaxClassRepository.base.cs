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
		
	public abstract partial class TaxClassRepositoryBase : Repository 
	{
        
        public TaxClassRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassGUID",new SearchColumn(){Name="TaxClassGUID",Title="TaxClassGUID",SelectClause="TaxClassGUID",WhereClause="AllRecords.TaxClassGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxCode",new SearchColumn(){Name="TaxCode",Title="TaxCode",SelectClause="TaxCode",WhereClause="AllRecords.TaxCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetTaxClassSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetTaxClassBasicSearchColumns()
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

        public virtual List<SearchColumn> GetTaxClassAdvanceSearchColumns()
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
        
        
        public virtual string GetTaxClassSelectClause()
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
                        	selectQuery =  "TaxClass."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",TaxClass."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual TaxClass GetTaxClass(System.Int32 TaxClassId)
		{

			string sql=GetTaxClassSelectClause();
			sql+="from TaxClass where TaxClassID=@TaxClassID ";
			SqlParameter parameter=new SqlParameter("@TaxClassID",TaxClassId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return TaxClassFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<TaxClass> GetAllTaxClass()
		{

			string sql=GetTaxClassSelectClause();
			sql+="from TaxClass";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<TaxClass>(ds, TaxClassFromDataRow);
		}

		public virtual List<TaxClass> GetPagedTaxClass(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetTaxClassCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [TaxClassID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([TaxClassID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [TaxClassID] ";
            tempsql += " FROM [TaxClass] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("TaxClassID"))
					tempsql += " , (AllRecords.[TaxClassID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[TaxClassID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetTaxClassSelectClause()+@" FROM [TaxClass], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [TaxClass].[TaxClassID] = PageIndex.[TaxClassID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<TaxClass>(ds, TaxClassFromDataRow);
			}else{ return null;}
		}

		private int GetTaxClassCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM TaxClass as AllRecords ";
			else
				sql = "SELECT Count(*) FROM TaxClass as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(TaxClass))]
		public virtual TaxClass InsertTaxClass(TaxClass entity)
		{

			TaxClass other=new TaxClass();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into TaxClass ( [TaxClassGUID]
				,[Name]
				,[TaxCode]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @TaxClassGUID
				, @Name
				, @TaxCode
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxClassGUID",entity.TaxClassGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@TaxCode",entity.TaxCode)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetTaxClass(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(TaxClass))]
		public virtual TaxClass UpdateTaxClass(TaxClass entity)
		{

			if (entity.IsTransient()) return entity;
			TaxClass other = GetTaxClass(entity.TaxClassId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update TaxClass set  [TaxClassGUID]=@TaxClassGUID
							, [Name]=@Name
							, [TaxCode]=@TaxCode
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where TaxClassID=@TaxClassID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxClassGUID",entity.TaxClassGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@TaxCode",entity.TaxCode)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetTaxClass(entity.TaxClassId);
		}

		public virtual bool DeleteTaxClass(System.Int32 TaxClassId)
		{

			string sql="delete from TaxClass where TaxClassID=@TaxClassID";
			SqlParameter parameter=new SqlParameter("@TaxClassID",TaxClassId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(TaxClass))]
		public virtual TaxClass DeleteTaxClass(TaxClass entity)
		{
			this.DeleteTaxClass(entity.TaxClassId);
			return entity;
		}


		public virtual TaxClass TaxClassFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			TaxClass entity=new TaxClass();
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxClassGuid = (System.Guid)dr["TaxClassGUID"];
			entity.Name = dr["Name"].ToString();
			entity.TaxCode = dr["TaxCode"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
