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
		
	public abstract partial class CouponUsageRepositoryBase : Repository 
	{
        
        public CouponUsageRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CouponUsageID",new SearchColumn(){Name="CouponUsageID",Title="CouponUsageID",SelectClause="CouponUsageID",WhereClause="AllRecords.CouponUsageID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponCode",new SearchColumn(){Name="CouponCode",Title="CouponCode",SelectClause="CouponCode",WhereClause="AllRecords.CouponCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCouponUsageSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCouponUsageBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCouponUsageAdvanceSearchColumns()
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
        
        
        public virtual string GetCouponUsageSelectClause()
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
                        	selectQuery =  "CouponUsage."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CouponUsage."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CouponUsage GetCouponUsage(System.Int32 CouponUsageId)
		{

			string sql=GetCouponUsageSelectClause();
			sql+="from CouponUsage where CouponUsageID=@CouponUsageID ";
			SqlParameter parameter=new SqlParameter("@CouponUsageID",CouponUsageId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CouponUsageFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CouponUsage> GetAllCouponUsage()
		{

			string sql=GetCouponUsageSelectClause();
			sql+="from CouponUsage";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CouponUsage>(ds, CouponUsageFromDataRow);
		}

		public virtual List<CouponUsage> GetPagedCouponUsage(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCouponUsageCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CouponUsageID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CouponUsageID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CouponUsageID] ";
            tempsql += " FROM [CouponUsage] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CouponUsageID"))
					tempsql += " , (AllRecords.[CouponUsageID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CouponUsageID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCouponUsageSelectClause()+@" FROM [CouponUsage], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CouponUsage].[CouponUsageID] = PageIndex.[CouponUsageID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CouponUsage>(ds, CouponUsageFromDataRow);
			}else{ return null;}
		}

		private int GetCouponUsageCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CouponUsage as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CouponUsage as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CouponUsage))]
		public virtual CouponUsage InsertCouponUsage(CouponUsage entity)
		{

			CouponUsage other=new CouponUsage();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CouponUsage ( [CustomerID]
				,[CouponCode]
				,[CreatedOn] )
				Values
				( @CustomerID
				, @CouponCode
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponUsageID",entity.CouponUsageId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CouponCode",entity.CouponCode)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCouponUsage(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CouponUsage))]
		public virtual CouponUsage UpdateCouponUsage(CouponUsage entity)
		{

			if (entity.IsTransient()) return entity;
			CouponUsage other = GetCouponUsage(entity.CouponUsageId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CouponUsage set  [CustomerID]=@CustomerID
							, [CouponCode]=@CouponCode
							, [CreatedOn]=@CreatedOn 
							 where CouponUsageID=@CouponUsageID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponUsageID",entity.CouponUsageId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CouponCode",entity.CouponCode)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCouponUsage(entity.CouponUsageId);
		}

		public virtual bool DeleteCouponUsage(System.Int32 CouponUsageId)
		{

			string sql="delete from CouponUsage where CouponUsageID=@CouponUsageID";
			SqlParameter parameter=new SqlParameter("@CouponUsageID",CouponUsageId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CouponUsage))]
		public virtual CouponUsage DeleteCouponUsage(CouponUsage entity)
		{
			this.DeleteCouponUsage(entity.CouponUsageId);
			return entity;
		}


		public virtual CouponUsage CouponUsageFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CouponUsage entity=new CouponUsage();
			entity.CouponUsageId = (System.Int32)dr["CouponUsageID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.CouponCode = dr["CouponCode"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
