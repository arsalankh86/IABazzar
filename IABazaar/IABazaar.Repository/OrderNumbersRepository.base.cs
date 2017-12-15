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
		
	public abstract partial class OrderNumbersRepositoryBase : Repository 
	{
        
        public OrderNumbersRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNumberGUID",new SearchColumn(){Name="OrderNumberGUID",Title="OrderNumberGUID",SelectClause="OrderNumberGUID",WhereClause="AllRecords.OrderNumberGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetOrderNumbersSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetOrderNumbersBasicSearchColumns()
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

        public virtual List<SearchColumn> GetOrderNumbersAdvanceSearchColumns()
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
        
        
        public virtual string GetOrderNumbersSelectClause()
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
                        	selectQuery =  "OrderNumbers."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",OrderNumbers."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual OrderNumbers GetOrderNumbers(System.Int32 OrderNumber)
		{

			string sql=GetOrderNumbersSelectClause();
			sql+="from OrderNumbers where OrderNumber=@OrderNumber ";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return OrderNumbersFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<OrderNumbers> GetAllOrderNumbers()
		{

			string sql=GetOrderNumbersSelectClause();
			sql+="from OrderNumbers";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderNumbers>(ds, OrderNumbersFromDataRow);
		}

		public virtual List<OrderNumbers> GetPagedOrderNumbers(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetOrderNumbersCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [OrderNumber] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([OrderNumber])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [OrderNumber] ";
            tempsql += " FROM [OrderNumbers] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("OrderNumber"))
					tempsql += " , (AllRecords.[OrderNumber])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[OrderNumber])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetOrderNumbersSelectClause()+@" FROM [OrderNumbers], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [OrderNumbers].[OrderNumber] = PageIndex.[OrderNumber] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderNumbers>(ds, OrderNumbersFromDataRow);
			}else{ return null;}
		}

		private int GetOrderNumbersCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM OrderNumbers as AllRecords ";
			else
				sql = "SELECT Count(*) FROM OrderNumbers as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(OrderNumbers))]
		public virtual OrderNumbers InsertOrderNumbers(OrderNumbers entity)
		{

			OrderNumbers other=new OrderNumbers();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into OrderNumbers ( [OrderNumberGUID]
				,[CreatedOn] )
				Values
				( @OrderNumberGUID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderNumberGUID",entity.OrderNumberGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetOrderNumbers(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(OrderNumbers))]
		public virtual OrderNumbers UpdateOrderNumbers(OrderNumbers entity)
		{

			if (entity.IsTransient()) return entity;
			OrderNumbers other = GetOrderNumbers(entity.OrderNumber);
			if (entity.Equals(other)) return entity;
			string sql=@"Update OrderNumbers set  [OrderNumberGUID]=@OrderNumberGUID
							, [CreatedOn]=@CreatedOn 
							 where OrderNumber=@OrderNumber";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderNumberGUID",entity.OrderNumberGuid)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetOrderNumbers(entity.OrderNumber);
		}

		public virtual bool DeleteOrderNumbers(System.Int32 OrderNumber)
		{

			string sql="delete from OrderNumbers where OrderNumber=@OrderNumber";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(OrderNumbers))]
		public virtual OrderNumbers DeleteOrderNumbers(OrderNumbers entity)
		{
			this.DeleteOrderNumbers(entity.OrderNumber);
			return entity;
		}


		public virtual OrderNumbers OrderNumbersFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			OrderNumbers entity=new OrderNumbers();
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.OrderNumberGuid = (System.Guid)dr["OrderNumberGUID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
