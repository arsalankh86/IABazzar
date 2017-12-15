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
		
	public abstract partial class FailedTransactionRepositoryBase : Repository 
	{
        
        public FailedTransactionRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DBRecNo",new SearchColumn(){Name="DBRecNo",Title="DBRecNo",SelectClause="DBRecNo",WhereClause="AllRecords.DBRecNo",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderDate",new SearchColumn(){Name="OrderDate",Title="OrderDate",SelectClause="OrderDate",WhereClause="AllRecords.OrderDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PaymentGateway",new SearchColumn(){Name="PaymentGateway",Title="PaymentGateway",SelectClause="PaymentGateway",WhereClause="AllRecords.PaymentGateway",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PaymentMethod",new SearchColumn(){Name="PaymentMethod",Title="PaymentMethod",SelectClause="PaymentMethod",WhereClause="AllRecords.PaymentMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TransactionCommand",new SearchColumn(){Name="TransactionCommand",Title="TransactionCommand",SelectClause="TransactionCommand",WhereClause="AllRecords.TransactionCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TransactionResult",new SearchColumn(){Name="TransactionResult",Title="TransactionResult",SelectClause="TransactionResult",WhereClause="AllRecords.TransactionResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MaxMindDetails",new SearchColumn(){Name="MaxMindDetails",Title="MaxMindDetails",SelectClause="MaxMindDetails",WhereClause="AllRecords.MaxMindDetails",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IPAddress",new SearchColumn(){Name="IPAddress",Title="IPAddress",SelectClause="IPAddress",WhereClause="AllRecords.IPAddress",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MaxMindFraudScore",new SearchColumn(){Name="MaxMindFraudScore",Title="MaxMindFraudScore",SelectClause="MaxMindFraudScore",WhereClause="AllRecords.MaxMindFraudScore",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringSubscriptionID",new SearchColumn(){Name="RecurringSubscriptionID",Title="RecurringSubscriptionID",SelectClause="RecurringSubscriptionID",WhereClause="AllRecords.RecurringSubscriptionID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEMailed",new SearchColumn(){Name="CustomerEMailed",Title="CustomerEMailed",SelectClause="CustomerEMailed",WhereClause="AllRecords.CustomerEMailed",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetFailedTransactionSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetFailedTransactionBasicSearchColumns()
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

        public virtual List<SearchColumn> GetFailedTransactionAdvanceSearchColumns()
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
        
        
        public virtual string GetFailedTransactionSelectClause()
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
                        	selectQuery =  "FailedTransaction."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",FailedTransaction."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual FailedTransaction GetFailedTransaction(System.Int32 DbRecNo)
		{

			string sql=GetFailedTransactionSelectClause();
			sql+="from FailedTransaction where DBRecNo=@DBRecNo ";
			SqlParameter parameter=new SqlParameter("@DBRecNo",DbRecNo);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return FailedTransactionFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<FailedTransaction> GetAllFailedTransaction()
		{

			string sql=GetFailedTransactionSelectClause();
			sql+="from FailedTransaction";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<FailedTransaction>(ds, FailedTransactionFromDataRow);
		}

		public virtual List<FailedTransaction> GetPagedFailedTransaction(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetFailedTransactionCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [DBRecNo] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([DBRecNo])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [DBRecNo] ";
            tempsql += " FROM [FailedTransaction] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("DBRecNo"))
					tempsql += " , (AllRecords.[DBRecNo])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[DBRecNo])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetFailedTransactionSelectClause()+@" FROM [FailedTransaction], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [FailedTransaction].[DBRecNo] = PageIndex.[DBRecNo] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<FailedTransaction>(ds, FailedTransactionFromDataRow);
			}else{ return null;}
		}

		private int GetFailedTransactionCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM FailedTransaction as AllRecords ";
			else
				sql = "SELECT Count(*) FROM FailedTransaction as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(FailedTransaction))]
		public virtual FailedTransaction InsertFailedTransaction(FailedTransaction entity)
		{

			FailedTransaction other=new FailedTransaction();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into FailedTransaction ( [CustomerID]
				,[OrderNumber]
				,[OrderDate]
				,[PaymentGateway]
				,[PaymentMethod]
				,[TransactionCommand]
				,[TransactionResult]
				,[ExtensionData]
				,[MaxMindDetails]
				,[IPAddress]
				,[MaxMindFraudScore]
				,[RecurringSubscriptionID]
				,[CustomerEMailed] )
				Values
				( @CustomerID
				, @OrderNumber
				, @OrderDate
				, @PaymentGateway
				, @PaymentMethod
				, @TransactionCommand
				, @TransactionResult
				, @ExtensionData
				, @MaxMindDetails
				, @IPAddress
				, @MaxMindFraudScore
				, @RecurringSubscriptionID
				, @CustomerEMailed );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderDate",entity.OrderDate)
					, new SqlParameter("@PaymentGateway",entity.PaymentGateway ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethod",entity.PaymentMethod ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionCommand",entity.TransactionCommand ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionResult",entity.TransactionResult ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindDetails",entity.MaxMindDetails ?? (object)DBNull.Value)
					, new SqlParameter("@IPAddress",entity.IpAddress ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindFraudScore",entity.MaxMindFraudScore ?? (object)DBNull.Value)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)
					, new SqlParameter("@CustomerEMailed",entity.CustomerEmailed)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetFailedTransaction(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(FailedTransaction))]
		public virtual FailedTransaction UpdateFailedTransaction(FailedTransaction entity)
		{

			if (entity.IsTransient()) return entity;
			FailedTransaction other = GetFailedTransaction(entity.DbRecNo);
			if (entity.Equals(other)) return entity;
			string sql=@"Update FailedTransaction set  [CustomerID]=@CustomerID
							, [OrderNumber]=@OrderNumber
							, [OrderDate]=@OrderDate
							, [PaymentGateway]=@PaymentGateway
							, [PaymentMethod]=@PaymentMethod
							, [TransactionCommand]=@TransactionCommand
							, [TransactionResult]=@TransactionResult
							, [ExtensionData]=@ExtensionData
							, [MaxMindDetails]=@MaxMindDetails
							, [IPAddress]=@IPAddress
							, [MaxMindFraudScore]=@MaxMindFraudScore
							, [RecurringSubscriptionID]=@RecurringSubscriptionID
							, [CustomerEMailed]=@CustomerEMailed 
							 where DBRecNo=@DBRecNo";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderDate",entity.OrderDate)
					, new SqlParameter("@PaymentGateway",entity.PaymentGateway ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethod",entity.PaymentMethod ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionCommand",entity.TransactionCommand ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionResult",entity.TransactionResult ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindDetails",entity.MaxMindDetails ?? (object)DBNull.Value)
					, new SqlParameter("@IPAddress",entity.IpAddress ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindFraudScore",entity.MaxMindFraudScore ?? (object)DBNull.Value)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)
					, new SqlParameter("@CustomerEMailed",entity.CustomerEmailed)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetFailedTransaction(entity.DbRecNo);
		}

		public virtual bool DeleteFailedTransaction(System.Int32 DbRecNo)
		{

			string sql="delete from FailedTransaction where DBRecNo=@DBRecNo";
			SqlParameter parameter=new SqlParameter("@DBRecNo",DbRecNo);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(FailedTransaction))]
		public virtual FailedTransaction DeleteFailedTransaction(FailedTransaction entity)
		{
			this.DeleteFailedTransaction(entity.DbRecNo);
			return entity;
		}


		public virtual FailedTransaction FailedTransactionFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			FailedTransaction entity=new FailedTransaction();
			entity.DbRecNo = (System.Int32)dr["DBRecNo"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.OrderDate = (System.DateTime)dr["OrderDate"];
			entity.PaymentGateway = dr["PaymentGateway"].ToString();
			entity.PaymentMethod = dr["PaymentMethod"].ToString();
			entity.TransactionCommand = dr["TransactionCommand"].ToString();
			entity.TransactionResult = dr["TransactionResult"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.MaxMindDetails = dr["MaxMindDetails"].ToString();
			entity.IpAddress = dr["IPAddress"].ToString();
			entity.MaxMindFraudScore = dr["MaxMindFraudScore"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["MaxMindFraudScore"];
			entity.RecurringSubscriptionId = dr["RecurringSubscriptionID"].ToString();
			entity.CustomerEmailed = (System.Byte)dr["CustomerEMailed"];
			return entity;
		}

	}
	
	
}
