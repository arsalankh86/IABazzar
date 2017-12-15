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
		
	public abstract partial class CurrencyRepositoryBase : Repository 
	{
        
        public CurrencyRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CurrencyID",new SearchColumn(){Name="CurrencyID",Title="CurrencyID",SelectClause="CurrencyID",WhereClause="AllRecords.CurrencyID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CurrencyGUID",new SearchColumn(){Name="CurrencyGUID",Title="CurrencyGUID",SelectClause="CurrencyGUID",WhereClause="AllRecords.CurrencyGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CurrencyCode",new SearchColumn(){Name="CurrencyCode",Title="CurrencyCode",SelectClause="CurrencyCode",WhereClause="AllRecords.CurrencyCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExchangeRate",new SearchColumn(){Name="ExchangeRate",Title="ExchangeRate",SelectClause="ExchangeRate",WhereClause="AllRecords.ExchangeRate",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("WasLiveRate",new SearchColumn(){Name="WasLiveRate",Title="WasLiveRate",SelectClause="WasLiveRate",WhereClause="AllRecords.WasLiveRate",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayLocaleFormat",new SearchColumn(){Name="DisplayLocaleFormat",Title="DisplayLocaleFormat",SelectClause="DisplayLocaleFormat",WhereClause="AllRecords.DisplayLocaleFormat",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Symbol",new SearchColumn(){Name="Symbol",Title="Symbol",SelectClause="Symbol",WhereClause="AllRecords.Symbol",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplaySpec",new SearchColumn(){Name="DisplaySpec",Title="DisplaySpec",SelectClause="DisplaySpec",WhereClause="AllRecords.DisplaySpec",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastUpdated",new SearchColumn(){Name="LastUpdated",Title="LastUpdated",SelectClause="LastUpdated",WhereClause="AllRecords.LastUpdated",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCurrencySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCurrencyBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCurrencyAdvanceSearchColumns()
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
        
        
        public virtual string GetCurrencySelectClause()
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
                        	selectQuery =  "Currency."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Currency."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Currency GetCurrency(System.Int32 CurrencyId)
		{

			string sql=GetCurrencySelectClause();
			sql+="from Currency where CurrencyID=@CurrencyID ";
			SqlParameter parameter=new SqlParameter("@CurrencyID",CurrencyId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CurrencyFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Currency> GetAllCurrency()
		{

			string sql=GetCurrencySelectClause();
			sql+="from Currency";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Currency>(ds, CurrencyFromDataRow);
		}

		public virtual List<Currency> GetPagedCurrency(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCurrencyCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CurrencyID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CurrencyID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CurrencyID] ";
            tempsql += " FROM [Currency] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CurrencyID"))
					tempsql += " , (AllRecords.[CurrencyID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CurrencyID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCurrencySelectClause()+@" FROM [Currency], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Currency].[CurrencyID] = PageIndex.[CurrencyID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Currency>(ds, CurrencyFromDataRow);
			}else{ return null;}
		}

		private int GetCurrencyCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Currency as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Currency as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Currency))]
		public virtual Currency InsertCurrency(Currency entity)
		{

			Currency other=new Currency();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Currency ( [CurrencyGUID]
				,[Name]
				,[CurrencyCode]
				,[ExchangeRate]
				,[WasLiveRate]
				,[DisplayLocaleFormat]
				,[Symbol]
				,[ExtensionData]
				,[Published]
				,[DisplayOrder]
				,[DisplaySpec]
				,[CreatedOn]
				,[LastUpdated] )
				Values
				( @CurrencyGUID
				, @Name
				, @CurrencyCode
				, @ExchangeRate
				, @WasLiveRate
				, @DisplayLocaleFormat
				, @Symbol
				, @ExtensionData
				, @Published
				, @DisplayOrder
				, @DisplaySpec
				, @CreatedOn
				, @LastUpdated );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CurrencyID",entity.CurrencyId)
					, new SqlParameter("@CurrencyGUID",entity.CurrencyGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CurrencyCode",entity.CurrencyCode)
					, new SqlParameter("@ExchangeRate",entity.ExchangeRate ?? (object)DBNull.Value)
					, new SqlParameter("@WasLiveRate",entity.WasLiveRate)
					, new SqlParameter("@DisplayLocaleFormat",entity.DisplayLocaleFormat ?? (object)DBNull.Value)
					, new SqlParameter("@Symbol",entity.Symbol ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@DisplaySpec",entity.DisplaySpec ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@LastUpdated",entity.LastUpdated)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCurrency(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Currency))]
		public virtual Currency UpdateCurrency(Currency entity)
		{

			if (entity.IsTransient()) return entity;
			Currency other = GetCurrency(entity.CurrencyId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Currency set  [CurrencyGUID]=@CurrencyGUID
							, [Name]=@Name
							, [CurrencyCode]=@CurrencyCode
							, [ExchangeRate]=@ExchangeRate
							, [WasLiveRate]=@WasLiveRate
							, [DisplayLocaleFormat]=@DisplayLocaleFormat
							, [Symbol]=@Symbol
							, [ExtensionData]=@ExtensionData
							, [Published]=@Published
							, [DisplayOrder]=@DisplayOrder
							, [DisplaySpec]=@DisplaySpec
							, [CreatedOn]=@CreatedOn
							, [LastUpdated]=@LastUpdated 
							 where CurrencyID=@CurrencyID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CurrencyID",entity.CurrencyId)
					, new SqlParameter("@CurrencyGUID",entity.CurrencyGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CurrencyCode",entity.CurrencyCode)
					, new SqlParameter("@ExchangeRate",entity.ExchangeRate ?? (object)DBNull.Value)
					, new SqlParameter("@WasLiveRate",entity.WasLiveRate)
					, new SqlParameter("@DisplayLocaleFormat",entity.DisplayLocaleFormat ?? (object)DBNull.Value)
					, new SqlParameter("@Symbol",entity.Symbol ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@DisplaySpec",entity.DisplaySpec ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@LastUpdated",entity.LastUpdated)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCurrency(entity.CurrencyId);
		}

		public virtual bool DeleteCurrency(System.Int32 CurrencyId)
		{

			string sql="delete from Currency where CurrencyID=@CurrencyID";
			SqlParameter parameter=new SqlParameter("@CurrencyID",CurrencyId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Currency))]
		public virtual Currency DeleteCurrency(Currency entity)
		{
			this.DeleteCurrency(entity.CurrencyId);
			return entity;
		}


		public virtual Currency CurrencyFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Currency entity=new Currency();
			entity.CurrencyId = (System.Int32)dr["CurrencyID"];
			entity.CurrencyGuid = (System.Guid)dr["CurrencyGUID"];
			entity.Name = dr["Name"].ToString();
			entity.CurrencyCode = dr["CurrencyCode"].ToString();
			entity.ExchangeRate = dr["ExchangeRate"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["ExchangeRate"];
			entity.WasLiveRate = (System.Byte)dr["WasLiveRate"];
			entity.DisplayLocaleFormat = dr["DisplayLocaleFormat"].ToString();
			entity.Symbol = dr["Symbol"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.DisplaySpec = dr["DisplaySpec"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.LastUpdated = (System.DateTime)dr["LastUpdated"];
			return entity;
		}

	}
	
	
}
