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
		
	public abstract partial class ExtendedPriceRepositoryBase : Repository 
	{
        
        public ExtendedPriceRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ExtendedPriceID",new SearchColumn(){Name="ExtendedPriceID",Title="ExtendedPriceID",SelectClause="ExtendedPriceID",WhereClause="AllRecords.ExtendedPriceID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtendedPriceGUID",new SearchColumn(){Name="ExtendedPriceGUID",Title="ExtendedPriceGUID",SelectClause="ExtendedPriceGUID",WhereClause="AllRecords.ExtendedPriceGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerLevelID",new SearchColumn(){Name="CustomerLevelID",Title="CustomerLevelID",SelectClause="CustomerLevelID",WhereClause="AllRecords.CustomerLevelID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Price",new SearchColumn(){Name="Price",Title="Price",SelectClause="Price",WhereClause="AllRecords.Price",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetExtendedPriceSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetExtendedPriceBasicSearchColumns()
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

        public virtual List<SearchColumn> GetExtendedPriceAdvanceSearchColumns()
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
        
        
        public virtual string GetExtendedPriceSelectClause()
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
                        	selectQuery =  "ExtendedPrice."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ExtendedPrice."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ExtendedPrice GetExtendedPrice(System.Int32 ExtendedPriceId)
		{

			string sql=GetExtendedPriceSelectClause();
			sql+="from ExtendedPrice where ExtendedPriceID=@ExtendedPriceID ";
			SqlParameter parameter=new SqlParameter("@ExtendedPriceID",ExtendedPriceId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ExtendedPriceFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ExtendedPrice> GetAllExtendedPrice()
		{

			string sql=GetExtendedPriceSelectClause();
			sql+="from ExtendedPrice";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ExtendedPrice>(ds, ExtendedPriceFromDataRow);
		}

		public virtual List<ExtendedPrice> GetPagedExtendedPrice(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetExtendedPriceCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ExtendedPriceID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ExtendedPriceID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ExtendedPriceID] ";
            tempsql += " FROM [ExtendedPrice] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ExtendedPriceID"))
					tempsql += " , (AllRecords.[ExtendedPriceID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ExtendedPriceID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetExtendedPriceSelectClause()+@" FROM [ExtendedPrice], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ExtendedPrice].[ExtendedPriceID] = PageIndex.[ExtendedPriceID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ExtendedPrice>(ds, ExtendedPriceFromDataRow);
			}else{ return null;}
		}

		private int GetExtendedPriceCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ExtendedPrice as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ExtendedPrice as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ExtendedPrice))]
		public virtual ExtendedPrice InsertExtendedPrice(ExtendedPrice entity)
		{

			ExtendedPrice other=new ExtendedPrice();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ExtendedPrice ( [ExtendedPriceGUID]
				,[VariantID]
				,[CustomerLevelID]
				,[Price]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @ExtendedPriceGUID
				, @VariantID
				, @CustomerLevelID
				, @Price
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ExtendedPriceID",entity.ExtendedPriceId)
					, new SqlParameter("@ExtendedPriceGUID",entity.ExtendedPriceGuid)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@Price",entity.Price)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetExtendedPrice(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ExtendedPrice))]
		public virtual ExtendedPrice UpdateExtendedPrice(ExtendedPrice entity)
		{

			if (entity.IsTransient()) return entity;
			ExtendedPrice other = GetExtendedPrice(entity.ExtendedPriceId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ExtendedPrice set  [ExtendedPriceGUID]=@ExtendedPriceGUID
							, [VariantID]=@VariantID
							, [CustomerLevelID]=@CustomerLevelID
							, [Price]=@Price
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where ExtendedPriceID=@ExtendedPriceID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ExtendedPriceID",entity.ExtendedPriceId)
					, new SqlParameter("@ExtendedPriceGUID",entity.ExtendedPriceGuid)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@Price",entity.Price)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetExtendedPrice(entity.ExtendedPriceId);
		}

		public virtual bool DeleteExtendedPrice(System.Int32 ExtendedPriceId)
		{

			string sql="delete from ExtendedPrice where ExtendedPriceID=@ExtendedPriceID";
			SqlParameter parameter=new SqlParameter("@ExtendedPriceID",ExtendedPriceId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ExtendedPrice))]
		public virtual ExtendedPrice DeleteExtendedPrice(ExtendedPrice entity)
		{
			this.DeleteExtendedPrice(entity.ExtendedPriceId);
			return entity;
		}


		public virtual ExtendedPrice ExtendedPriceFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ExtendedPrice entity=new ExtendedPrice();
			entity.ExtendedPriceId = (System.Int32)dr["ExtendedPriceID"];
			entity.ExtendedPriceGuid = (System.Guid)dr["ExtendedPriceGUID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.CustomerLevelId = (System.Int32)dr["CustomerLevelID"];
			entity.Price = (System.Decimal)dr["Price"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
