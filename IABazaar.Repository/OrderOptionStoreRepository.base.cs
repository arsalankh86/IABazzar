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
		
	public abstract partial class OrderOptionStoreRepositoryBase : Repository 
	{
        
        public OrderOptionStoreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ID",new SearchColumn(){Name="ID",Title="ID",SelectClause="ID",WhereClause="AllRecords.ID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderOptionID",new SearchColumn(){Name="OrderOptionID",Title="OrderOptionID",SelectClause="OrderOptionID",WhereClause="AllRecords.OrderOptionID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetOrderOptionStoreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetOrderOptionStoreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetOrderOptionStoreAdvanceSearchColumns()
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
        
        
        public virtual string GetOrderOptionStoreSelectClause()
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
                        	selectQuery =  "OrderOptionStore."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",OrderOptionStore."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual OrderOptionStore GetOrderOptionStore(System.Int32 OrderOptionId)
		{

			string sql=GetOrderOptionStoreSelectClause();
			sql+="from OrderOptionStore where OrderOptionID=@OrderOptionID ";
			SqlParameter parameter=new SqlParameter("@OrderOptionID",OrderOptionId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return OrderOptionStoreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<OrderOptionStore> GetAllOrderOptionStore()
		{

			string sql=GetOrderOptionStoreSelectClause();
			sql+="from OrderOptionStore";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderOptionStore>(ds, OrderOptionStoreFromDataRow);
		}

		public virtual List<OrderOptionStore> GetPagedOrderOptionStore(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetOrderOptionStoreCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [OrderOptionID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([OrderOptionID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [OrderOptionID] ";
            tempsql += " FROM [OrderOptionStore] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("OrderOptionID"))
					tempsql += " , (AllRecords.[OrderOptionID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[OrderOptionID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetOrderOptionStoreSelectClause()+@" FROM [OrderOptionStore], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [OrderOptionStore].[OrderOptionID] = PageIndex.[OrderOptionID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderOptionStore>(ds, OrderOptionStoreFromDataRow);
			}else{ return null;}
		}

		private int GetOrderOptionStoreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM OrderOptionStore as AllRecords ";
			else
				sql = "SELECT Count(*) FROM OrderOptionStore as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(OrderOptionStore))]
		public virtual OrderOptionStore InsertOrderOptionStore(OrderOptionStore entity)
		{

			OrderOptionStore other=new OrderOptionStore();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into OrderOptionStore ( [OrderOptionID]
				,[ID]
				,[StoreID]
				,[CreatedOn] )
				Values
				( @OrderOptionID
				, @ID
				, @StoreID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderOptionID",entity.OrderOptionId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetOrderOptionStore(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(OrderOptionStore))]
		public virtual OrderOptionStore UpdateOrderOptionStore(OrderOptionStore entity)
		{

			if (entity.IsTransient()) return entity;
			OrderOptionStore other = GetOrderOptionStore(entity.OrderOptionId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update OrderOptionStore set  [ID]=@ID
							, [StoreID]=@StoreID
							, [CreatedOn]=@CreatedOn 
							 where OrderOptionID=@OrderOptionID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderOptionID",entity.OrderOptionId)
					, new SqlParameter("@ID",entity.Id)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetOrderOptionStore(entity.OrderOptionId);
		}

		public virtual bool DeleteOrderOptionStore(System.Int32 OrderOptionId)
		{

			string sql="delete from OrderOptionStore where OrderOptionID=@OrderOptionID";
			SqlParameter parameter=new SqlParameter("@OrderOptionID",OrderOptionId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(OrderOptionStore))]
		public virtual OrderOptionStore DeleteOrderOptionStore(OrderOptionStore entity)
		{
			this.DeleteOrderOptionStore(entity.OrderOptionId);
			return entity;
		}


		public virtual OrderOptionStore OrderOptionStoreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			OrderOptionStore entity=new OrderOptionStore();
			entity.Id = (System.Int32)dr["ID"];
			entity.OrderOptionId = (System.Int32)dr["OrderOptionID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
