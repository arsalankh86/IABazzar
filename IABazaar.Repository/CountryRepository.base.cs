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
		
	public abstract partial class CountryRepositoryBase : Repository 
	{
        
        public CountryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CountryID",new SearchColumn(){Name="CountryID",Title="CountryID",SelectClause="CountryID",WhereClause="AllRecords.CountryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CountryGUID",new SearchColumn(){Name="CountryGUID",Title="CountryGUID",SelectClause="CountryGUID",WhereClause="AllRecords.CountryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TwoLetterISOCode",new SearchColumn(){Name="TwoLetterISOCode",Title="TwoLetterISOCode",SelectClause="TwoLetterISOCode",WhereClause="AllRecords.TwoLetterISOCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ThreeLetterISOCode",new SearchColumn(){Name="ThreeLetterISOCode",Title="ThreeLetterISOCode",SelectClause="ThreeLetterISOCode",WhereClause="AllRecords.ThreeLetterISOCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NumericISOCode",new SearchColumn(){Name="NumericISOCode",Title="NumericISOCode",SelectClause="NumericISOCode",WhereClause="AllRecords.NumericISOCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PostalCodeRequired",new SearchColumn(){Name="PostalCodeRequired",Title="PostalCodeRequired",SelectClause="PostalCodeRequired",WhereClause="AllRecords.PostalCodeRequired",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PostalCodeRegex",new SearchColumn(){Name="PostalCodeRegex",Title="PostalCodeRegex",SelectClause="PostalCodeRegex",WhereClause="AllRecords.PostalCodeRegex",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PostalCodeExample",new SearchColumn(){Name="PostalCodeExample",Title="PostalCodeExample",SelectClause="PostalCodeExample",WhereClause="AllRecords.PostalCodeExample",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCountrySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCountryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCountryAdvanceSearchColumns()
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
        
        
        public virtual string GetCountrySelectClause()
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
                        	selectQuery =  "Country."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Country."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Country GetCountry(System.Int32 CountryId)
		{

			string sql=GetCountrySelectClause();
			sql+="from Country where CountryID=@CountryID ";
			SqlParameter parameter=new SqlParameter("@CountryID",CountryId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CountryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Country> GetAllCountry()
		{

			string sql=GetCountrySelectClause();
			sql+="from Country";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Country>(ds, CountryFromDataRow);
		}

		public virtual List<Country> GetPagedCountry(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCountryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CountryID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CountryID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CountryID] ";
            tempsql += " FROM [Country] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CountryID"))
					tempsql += " , (AllRecords.[CountryID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CountryID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCountrySelectClause()+@" FROM [Country], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Country].[CountryID] = PageIndex.[CountryID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Country>(ds, CountryFromDataRow);
			}else{ return null;}
		}

		private int GetCountryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Country as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Country as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Country))]
		public virtual Country InsertCountry(Country entity)
		{

			Country other=new Country();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Country ( [CountryGUID]
				,[Name]
				,[TwoLetterISOCode]
				,[ThreeLetterISOCode]
				,[NumericISOCode]
				,[Published]
				,[DisplayOrder]
				,[ExtensionData]
				,[CreatedOn]
				,[PostalCodeRequired]
				,[PostalCodeRegex]
				,[PostalCodeExample] )
				Values
				( @CountryGUID
				, @Name
				, @TwoLetterISOCode
				, @ThreeLetterISOCode
				, @NumericISOCode
				, @Published
				, @DisplayOrder
				, @ExtensionData
				, @CreatedOn
				, @PostalCodeRequired
				, @PostalCodeRegex
				, @PostalCodeExample );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CountryID",entity.CountryId)
					, new SqlParameter("@CountryGUID",entity.CountryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@TwoLetterISOCode",entity.TwoLetterIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@ThreeLetterISOCode",entity.ThreeLetterIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@NumericISOCode",entity.NumericIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PostalCodeRequired",entity.PostalCodeRequired)
					, new SqlParameter("@PostalCodeRegex",entity.PostalCodeRegex ?? (object)DBNull.Value)
					, new SqlParameter("@PostalCodeExample",entity.PostalCodeExample ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCountry(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Country))]
		public virtual Country UpdateCountry(Country entity)
		{

			if (entity.IsTransient()) return entity;
			Country other = GetCountry(entity.CountryId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Country set  [CountryGUID]=@CountryGUID
							, [Name]=@Name
							, [TwoLetterISOCode]=@TwoLetterISOCode
							, [ThreeLetterISOCode]=@ThreeLetterISOCode
							, [NumericISOCode]=@NumericISOCode
							, [Published]=@Published
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn
							, [PostalCodeRequired]=@PostalCodeRequired
							, [PostalCodeRegex]=@PostalCodeRegex
							, [PostalCodeExample]=@PostalCodeExample 
							 where CountryID=@CountryID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CountryID",entity.CountryId)
					, new SqlParameter("@CountryGUID",entity.CountryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@TwoLetterISOCode",entity.TwoLetterIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@ThreeLetterISOCode",entity.ThreeLetterIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@NumericISOCode",entity.NumericIsoCode ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PostalCodeRequired",entity.PostalCodeRequired)
					, new SqlParameter("@PostalCodeRegex",entity.PostalCodeRegex ?? (object)DBNull.Value)
					, new SqlParameter("@PostalCodeExample",entity.PostalCodeExample ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCountry(entity.CountryId);
		}

		public virtual bool DeleteCountry(System.Int32 CountryId)
		{

			string sql="delete from Country where CountryID=@CountryID";
			SqlParameter parameter=new SqlParameter("@CountryID",CountryId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Country))]
		public virtual Country DeleteCountry(Country entity)
		{
			this.DeleteCountry(entity.CountryId);
			return entity;
		}


		public virtual Country CountryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Country entity=new Country();
			entity.CountryId = (System.Int32)dr["CountryID"];
			entity.CountryGuid = (System.Guid)dr["CountryGUID"];
			entity.Name = dr["Name"].ToString();
			entity.TwoLetterIsoCode = dr["TwoLetterISOCode"].ToString();
			entity.ThreeLetterIsoCode = dr["ThreeLetterISOCode"].ToString();
			entity.NumericIsoCode = dr["NumericISOCode"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.PostalCodeRequired = (System.Byte)dr["PostalCodeRequired"];
			entity.PostalCodeRegex = dr["PostalCodeRegex"].ToString();
			entity.PostalCodeExample = dr["PostalCodeExample"].ToString();
			return entity;
		}

	}
	
	
}
