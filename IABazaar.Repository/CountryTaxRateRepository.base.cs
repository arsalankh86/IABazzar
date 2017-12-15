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
		
	public abstract partial class CountryTaxRateRepositoryBase : Repository 
	{
        
        public CountryTaxRateRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CountryTaxID",new SearchColumn(){Name="CountryTaxID",Title="CountryTaxID",SelectClause="CountryTaxID",WhereClause="AllRecords.CountryTaxID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CountryID",new SearchColumn(){Name="CountryID",Title="CountryID",SelectClause="CountryID",WhereClause="AllRecords.CountryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxRate",new SearchColumn(){Name="TaxRate",Title="TaxRate",SelectClause="TaxRate",WhereClause="AllRecords.TaxRate",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCountryTaxRateSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCountryTaxRateBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCountryTaxRateAdvanceSearchColumns()
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
        
        
        public virtual string GetCountryTaxRateSelectClause()
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
                        	selectQuery =  "CountryTaxRate."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CountryTaxRate."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CountryTaxRate GetCountryTaxRate(System.Int32 CountryTaxId)
		{

			string sql=GetCountryTaxRateSelectClause();
			sql+="from CountryTaxRate where CountryTaxID=@CountryTaxID ";
			SqlParameter parameter=new SqlParameter("@CountryTaxID",CountryTaxId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CountryTaxRateFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CountryTaxRate> GetAllCountryTaxRate()
		{

			string sql=GetCountryTaxRateSelectClause();
			sql+="from CountryTaxRate";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CountryTaxRate>(ds, CountryTaxRateFromDataRow);
		}

		public virtual List<CountryTaxRate> GetPagedCountryTaxRate(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCountryTaxRateCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CountryTaxID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CountryTaxID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CountryTaxID] ";
            tempsql += " FROM [CountryTaxRate] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CountryTaxID"))
					tempsql += " , (AllRecords.[CountryTaxID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CountryTaxID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCountryTaxRateSelectClause()+@" FROM [CountryTaxRate], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CountryTaxRate].[CountryTaxID] = PageIndex.[CountryTaxID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CountryTaxRate>(ds, CountryTaxRateFromDataRow);
			}else{ return null;}
		}

		private int GetCountryTaxRateCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CountryTaxRate as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CountryTaxRate as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CountryTaxRate))]
		public virtual CountryTaxRate InsertCountryTaxRate(CountryTaxRate entity)
		{

			CountryTaxRate other=new CountryTaxRate();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CountryTaxRate ( [CountryID]
				,[TaxClassID]
				,[TaxRate]
				,[CreatedOn] )
				Values
				( @CountryID
				, @TaxClassID
				, @TaxRate
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CountryTaxID",entity.CountryTaxId)
					, new SqlParameter("@CountryID",entity.CountryId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCountryTaxRate(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CountryTaxRate))]
		public virtual CountryTaxRate UpdateCountryTaxRate(CountryTaxRate entity)
		{

			if (entity.IsTransient()) return entity;
			CountryTaxRate other = GetCountryTaxRate(entity.CountryTaxId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CountryTaxRate set  [CountryID]=@CountryID
							, [TaxClassID]=@TaxClassID
							, [TaxRate]=@TaxRate
							, [CreatedOn]=@CreatedOn 
							 where CountryTaxID=@CountryTaxID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CountryTaxID",entity.CountryTaxId)
					, new SqlParameter("@CountryID",entity.CountryId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCountryTaxRate(entity.CountryTaxId);
		}

		public virtual bool DeleteCountryTaxRate(System.Int32 CountryTaxId)
		{

			string sql="delete from CountryTaxRate where CountryTaxID=@CountryTaxID";
			SqlParameter parameter=new SqlParameter("@CountryTaxID",CountryTaxId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CountryTaxRate))]
		public virtual CountryTaxRate DeleteCountryTaxRate(CountryTaxRate entity)
		{
			this.DeleteCountryTaxRate(entity.CountryTaxId);
			return entity;
		}


		public virtual CountryTaxRate CountryTaxRateFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CountryTaxRate entity=new CountryTaxRate();
			entity.CountryTaxId = (System.Int32)dr["CountryTaxID"];
			entity.CountryId = (System.Int32)dr["CountryID"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxRate = dr["TaxRate"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["TaxRate"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
