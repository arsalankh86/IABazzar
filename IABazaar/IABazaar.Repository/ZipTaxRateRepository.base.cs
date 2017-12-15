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
		
	public abstract partial class ZipTaxRateRepositoryBase : Repository 
	{
        
        public ZipTaxRateRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ZipTaxID",new SearchColumn(){Name="ZipTaxID",Title="ZipTaxID",SelectClause="ZipTaxID",WhereClause="AllRecords.ZipTaxID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ZipCode",new SearchColumn(){Name="ZipCode",Title="ZipCode",SelectClause="ZipCode",WhereClause="AllRecords.ZipCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxRate",new SearchColumn(){Name="TaxRate",Title="TaxRate",SelectClause="TaxRate",WhereClause="AllRecords.TaxRate",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CountryID",new SearchColumn(){Name="CountryID",Title="CountryID",SelectClause="CountryID",WhereClause="AllRecords.CountryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetZipTaxRateSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetZipTaxRateBasicSearchColumns()
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

        public virtual List<SearchColumn> GetZipTaxRateAdvanceSearchColumns()
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
        
        
        public virtual string GetZipTaxRateSelectClause()
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
                        	selectQuery =  "ZipTaxRate."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ZipTaxRate."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ZipTaxRate GetZipTaxRate(System.Int32 ZipTaxId)
		{

			string sql=GetZipTaxRateSelectClause();
			sql+="from ZipTaxRate where ZipTaxID=@ZipTaxID ";
			SqlParameter parameter=new SqlParameter("@ZipTaxID",ZipTaxId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ZipTaxRateFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ZipTaxRate> GetAllZipTaxRate()
		{

			string sql=GetZipTaxRateSelectClause();
			sql+="from ZipTaxRate";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ZipTaxRate>(ds, ZipTaxRateFromDataRow);
		}

		public virtual List<ZipTaxRate> GetPagedZipTaxRate(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetZipTaxRateCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ZipTaxID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ZipTaxID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ZipTaxID] ";
            tempsql += " FROM [ZipTaxRate] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ZipTaxID"))
					tempsql += " , (AllRecords.[ZipTaxID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ZipTaxID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetZipTaxRateSelectClause()+@" FROM [ZipTaxRate], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ZipTaxRate].[ZipTaxID] = PageIndex.[ZipTaxID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ZipTaxRate>(ds, ZipTaxRateFromDataRow);
			}else{ return null;}
		}

		private int GetZipTaxRateCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ZipTaxRate as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ZipTaxRate as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ZipTaxRate))]
		public virtual ZipTaxRate InsertZipTaxRate(ZipTaxRate entity)
		{

			ZipTaxRate other=new ZipTaxRate();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ZipTaxRate ( [ZipCode]
				,[TaxClassID]
				,[TaxRate]
				,[CreatedOn]
				,[CountryID] )
				Values
				( @ZipCode
				, @TaxClassID
				, @TaxRate
				, @CreatedOn
				, @CountryID );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ZipTaxID",entity.ZipTaxId)
					, new SqlParameter("@ZipCode",entity.ZipCode)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@CountryID",entity.CountryId)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetZipTaxRate(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ZipTaxRate))]
		public virtual ZipTaxRate UpdateZipTaxRate(ZipTaxRate entity)
		{

			if (entity.IsTransient()) return entity;
			ZipTaxRate other = GetZipTaxRate(entity.ZipTaxId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ZipTaxRate set  [ZipCode]=@ZipCode
							, [TaxClassID]=@TaxClassID
							, [TaxRate]=@TaxRate
							, [CreatedOn]=@CreatedOn
							, [CountryID]=@CountryID 
							 where ZipTaxID=@ZipTaxID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ZipTaxID",entity.ZipTaxId)
					, new SqlParameter("@ZipCode",entity.ZipCode)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@CountryID",entity.CountryId)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetZipTaxRate(entity.ZipTaxId);
		}

		public virtual bool DeleteZipTaxRate(System.Int32 ZipTaxId)
		{

			string sql="delete from ZipTaxRate where ZipTaxID=@ZipTaxID";
			SqlParameter parameter=new SqlParameter("@ZipTaxID",ZipTaxId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ZipTaxRate))]
		public virtual ZipTaxRate DeleteZipTaxRate(ZipTaxRate entity)
		{
			this.DeleteZipTaxRate(entity.ZipTaxId);
			return entity;
		}


		public virtual ZipTaxRate ZipTaxRateFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ZipTaxRate entity=new ZipTaxRate();
			entity.ZipTaxId = (System.Int32)dr["ZipTaxID"];
			entity.ZipCode = dr["ZipCode"].ToString();
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxRate = dr["TaxRate"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["TaxRate"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.CountryId = (System.Int32)dr["CountryID"];
			return entity;
		}

	}
	
	
}
