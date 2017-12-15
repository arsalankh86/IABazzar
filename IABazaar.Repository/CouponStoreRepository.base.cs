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
		
	public abstract partial class CouponStoreRepositoryBase : Repository 
	{
        
        public CouponStoreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ID",new SearchColumn(){Name="ID",Title="ID",SelectClause="ID",WhereClause="AllRecords.ID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponID",new SearchColumn(){Name="CouponID",Title="CouponID",SelectClause="CouponID",WhereClause="AllRecords.CouponID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCouponStoreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCouponStoreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCouponStoreAdvanceSearchColumns()
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
        
        
        public virtual string GetCouponStoreSelectClause()
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
                        	selectQuery =  "CouponStore."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CouponStore."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CouponStore GetCouponStore(System.Int32 CouponId)
		{

			string sql=GetCouponStoreSelectClause();
			sql+="from CouponStore where CouponID=@CouponID ";
			SqlParameter parameter=new SqlParameter("@CouponID",CouponId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CouponStoreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CouponStore> GetAllCouponStore()
		{

			string sql=GetCouponStoreSelectClause();
			sql+="from CouponStore";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CouponStore>(ds, CouponStoreFromDataRow);
		}

		public virtual List<CouponStore> GetPagedCouponStore(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCouponStoreCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CouponID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CouponID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CouponID] ";
            tempsql += " FROM [CouponStore] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CouponID"))
					tempsql += " , (AllRecords.[CouponID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CouponID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCouponStoreSelectClause()+@" FROM [CouponStore], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CouponStore].[CouponID] = PageIndex.[CouponID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CouponStore>(ds, CouponStoreFromDataRow);
			}else{ return null;}
		}

		private int GetCouponStoreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CouponStore as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CouponStore as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CouponStore))]
		public virtual CouponStore InsertCouponStore(CouponStore entity)
		{

			CouponStore other=new CouponStore();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CouponStore ( [CouponID]
				,[ID]
				,[StoreID]
				,[CreatedOn] )
				Values
				( @CouponID
				, @ID
				, @StoreID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponID",entity.CouponId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCouponStore(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CouponStore))]
		public virtual CouponStore UpdateCouponStore(CouponStore entity)
		{

			if (entity.IsTransient()) return entity;
			CouponStore other = GetCouponStore(entity.CouponId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CouponStore set  [ID]=@ID
							, [StoreID]=@StoreID
							, [CreatedOn]=@CreatedOn 
							 where CouponID=@CouponID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponID",entity.CouponId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCouponStore(entity.CouponId);
		}

		public virtual bool DeleteCouponStore(System.Int32 CouponId)
		{

			string sql="delete from CouponStore where CouponID=@CouponID";
			SqlParameter parameter=new SqlParameter("@CouponID",CouponId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CouponStore))]
		public virtual CouponStore DeleteCouponStore(CouponStore entity)
		{
			this.DeleteCouponStore(entity.CouponId);
			return entity;
		}


		public virtual CouponStore CouponStoreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CouponStore entity=new CouponStore();
			entity.Id = (System.Int32)dr["ID"];
			entity.CouponId = (System.Int32)dr["CouponID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
