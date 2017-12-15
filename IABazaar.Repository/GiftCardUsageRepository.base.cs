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
		
	public abstract partial class GiftCardUsageRepositoryBase : Repository 
	{
        
        public GiftCardUsageRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("GiftCardUsageID",new SearchColumn(){Name="GiftCardUsageID",Title="GiftCardUsageID",SelectClause="GiftCardUsageID",WhereClause="AllRecords.GiftCardUsageID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftCardUsageGUID",new SearchColumn(){Name="GiftCardUsageGUID",Title="GiftCardUsageGUID",SelectClause="GiftCardUsageGUID",WhereClause="AllRecords.GiftCardUsageGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftCardID",new SearchColumn(){Name="GiftCardID",Title="GiftCardID",SelectClause="GiftCardID",WhereClause="AllRecords.GiftCardID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UsageTypeID",new SearchColumn(){Name="UsageTypeID",Title="UsageTypeID",SelectClause="UsageTypeID",WhereClause="AllRecords.UsageTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UsedByCustomerID",new SearchColumn(){Name="UsedByCustomerID",Title="UsedByCustomerID",SelectClause="UsedByCustomerID",WhereClause="AllRecords.UsedByCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Amount",new SearchColumn(){Name="Amount",Title="Amount",SelectClause="Amount",WhereClause="AllRecords.Amount",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetGiftCardUsageSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetGiftCardUsageBasicSearchColumns()
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

        public virtual List<SearchColumn> GetGiftCardUsageAdvanceSearchColumns()
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
        
        
        public virtual string GetGiftCardUsageSelectClause()
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
                        	selectQuery =  "GiftCardUsage."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",GiftCardUsage."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual GiftCardUsage GetGiftCardUsage(System.Int32 GiftCardUsageId)
		{

			string sql=GetGiftCardUsageSelectClause();
			sql+="from GiftCardUsage where GiftCardUsageID=@GiftCardUsageID ";
			SqlParameter parameter=new SqlParameter("@GiftCardUsageID",GiftCardUsageId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return GiftCardUsageFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<GiftCardUsage> GetAllGiftCardUsage()
		{

			string sql=GetGiftCardUsageSelectClause();
			sql+="from GiftCardUsage";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GiftCardUsage>(ds, GiftCardUsageFromDataRow);
		}

		public virtual List<GiftCardUsage> GetPagedGiftCardUsage(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetGiftCardUsageCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [GiftCardUsageID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([GiftCardUsageID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [GiftCardUsageID] ";
            tempsql += " FROM [GiftCardUsage] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("GiftCardUsageID"))
					tempsql += " , (AllRecords.[GiftCardUsageID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[GiftCardUsageID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetGiftCardUsageSelectClause()+@" FROM [GiftCardUsage], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [GiftCardUsage].[GiftCardUsageID] = PageIndex.[GiftCardUsageID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GiftCardUsage>(ds, GiftCardUsageFromDataRow);
			}else{ return null;}
		}

		private int GetGiftCardUsageCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM GiftCardUsage as AllRecords ";
			else
				sql = "SELECT Count(*) FROM GiftCardUsage as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(GiftCardUsage))]
		public virtual GiftCardUsage InsertGiftCardUsage(GiftCardUsage entity)
		{

			GiftCardUsage other=new GiftCardUsage();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into GiftCardUsage ( [GiftCardUsageGUID]
				,[GiftCardID]
				,[UsageTypeID]
				,[UsedByCustomerID]
				,[OrderNumber]
				,[Amount]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @GiftCardUsageGUID
				, @GiftCardID
				, @UsageTypeID
				, @UsedByCustomerID
				, @OrderNumber
				, @Amount
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GiftCardUsageID",entity.GiftCardUsageId)
					, new SqlParameter("@GiftCardUsageGUID",entity.GiftCardUsageGuid)
					, new SqlParameter("@GiftCardID",entity.GiftCardId)
					, new SqlParameter("@UsageTypeID",entity.UsageTypeId)
					, new SqlParameter("@UsedByCustomerID",entity.UsedByCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@Amount",entity.Amount)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetGiftCardUsage(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(GiftCardUsage))]
		public virtual GiftCardUsage UpdateGiftCardUsage(GiftCardUsage entity)
		{

			if (entity.IsTransient()) return entity;
			GiftCardUsage other = GetGiftCardUsage(entity.GiftCardUsageId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update GiftCardUsage set  [GiftCardUsageGUID]=@GiftCardUsageGUID
							, [GiftCardID]=@GiftCardID
							, [UsageTypeID]=@UsageTypeID
							, [UsedByCustomerID]=@UsedByCustomerID
							, [OrderNumber]=@OrderNumber
							, [Amount]=@Amount
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where GiftCardUsageID=@GiftCardUsageID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GiftCardUsageID",entity.GiftCardUsageId)
					, new SqlParameter("@GiftCardUsageGUID",entity.GiftCardUsageGuid)
					, new SqlParameter("@GiftCardID",entity.GiftCardId)
					, new SqlParameter("@UsageTypeID",entity.UsageTypeId)
					, new SqlParameter("@UsedByCustomerID",entity.UsedByCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@Amount",entity.Amount)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetGiftCardUsage(entity.GiftCardUsageId);
		}

		public virtual bool DeleteGiftCardUsage(System.Int32 GiftCardUsageId)
		{

			string sql="delete from GiftCardUsage where GiftCardUsageID=@GiftCardUsageID";
			SqlParameter parameter=new SqlParameter("@GiftCardUsageID",GiftCardUsageId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(GiftCardUsage))]
		public virtual GiftCardUsage DeleteGiftCardUsage(GiftCardUsage entity)
		{
			this.DeleteGiftCardUsage(entity.GiftCardUsageId);
			return entity;
		}


		public virtual GiftCardUsage GiftCardUsageFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			GiftCardUsage entity=new GiftCardUsage();
			entity.GiftCardUsageId = (System.Int32)dr["GiftCardUsageID"];
			entity.GiftCardUsageGuid = (System.Guid)dr["GiftCardUsageGUID"];
			entity.GiftCardId = (System.Int32)dr["GiftCardID"];
			entity.UsageTypeId = (System.Int32)dr["UsageTypeID"];
			entity.UsedByCustomerId = (System.Int32)dr["UsedByCustomerID"];
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.Amount = (System.Decimal)dr["Amount"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
