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
		
	public abstract partial class KitCartRepositoryBase : Repository 
	{
        
        public KitCartRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("KitCartRecID",new SearchColumn(){Name="KitCartRecID",Title="KitCartRecID",SelectClause="KitCartRecID",WhereClause="AllRecords.KitCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShoppingCartRecID",new SearchColumn(){Name="ShoppingCartRecID",Title="ShoppingCartRecID",SelectClause="ShoppingCartRecID",WhereClause="AllRecords.ShoppingCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitGroupID",new SearchColumn(){Name="KitGroupID",Title="KitGroupID",SelectClause="KitGroupID",WhereClause="AllRecords.KitGroupID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitGroupTypeID",new SearchColumn(){Name="KitGroupTypeID",Title="KitGroupTypeID",SelectClause="KitGroupTypeID",WhereClause="AllRecords.KitGroupTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitItemID",new SearchColumn(){Name="KitItemID",Title="KitItemID",SelectClause="KitItemID",WhereClause="AllRecords.KitItemID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Quantity",new SearchColumn(){Name="Quantity",Title="Quantity",SelectClause="Quantity",WhereClause="AllRecords.Quantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CartType",new SearchColumn(){Name="CartType",Title="CartType",SelectClause="CartType",WhereClause="AllRecords.CartType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OriginalRecurringOrderNumber",new SearchColumn(){Name="OriginalRecurringOrderNumber",Title="OriginalRecurringOrderNumber",SelectClause="OriginalRecurringOrderNumber",WhereClause="AllRecords.OriginalRecurringOrderNumber",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOption",new SearchColumn(){Name="TextOption",Title="TextOption",SelectClause="TextOption",WhereClause="AllRecords.TextOption",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantID",new SearchColumn(){Name="InventoryVariantID",Title="InventoryVariantID",SelectClause="InventoryVariantID",WhereClause="AllRecords.InventoryVariantID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantColor",new SearchColumn(){Name="InventoryVariantColor",Title="InventoryVariantColor",SelectClause="InventoryVariantColor",WhereClause="AllRecords.InventoryVariantColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantSize",new SearchColumn(){Name="InventoryVariantSize",Title="InventoryVariantSize",SelectClause="InventoryVariantSize",WhereClause="AllRecords.InventoryVariantSize",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetKitCartSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetKitCartBasicSearchColumns()
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

        public virtual List<SearchColumn> GetKitCartAdvanceSearchColumns()
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
        
        
        public virtual string GetKitCartSelectClause()
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
                        	selectQuery =  "KitCart."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",KitCart."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual KitCart GetKitCart(System.Int32 KitCartRecId)
		{

			string sql=GetKitCartSelectClause();
			sql+="from KitCart where KitCartRecID=@KitCartRecID ";
			SqlParameter parameter=new SqlParameter("@KitCartRecID",KitCartRecId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return KitCartFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<KitCart> GetAllKitCart()
		{

			string sql=GetKitCartSelectClause();
			sql+="from KitCart";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitCart>(ds, KitCartFromDataRow);
		}

		public virtual List<KitCart> GetPagedKitCart(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetKitCartCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [KitCartRecID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([KitCartRecID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [KitCartRecID] ";
            tempsql += " FROM [KitCart] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("KitCartRecID"))
					tempsql += " , (AllRecords.[KitCartRecID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[KitCartRecID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetKitCartSelectClause()+@" FROM [KitCart], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [KitCart].[KitCartRecID] = PageIndex.[KitCartRecID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitCart>(ds, KitCartFromDataRow);
			}else{ return null;}
		}

		private int GetKitCartCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM KitCart as AllRecords ";
			else
				sql = "SELECT Count(*) FROM KitCart as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(KitCart))]
		public virtual KitCart InsertKitCart(KitCart entity)
		{

			KitCart other=new KitCart();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into KitCart ( [CustomerID]
				,[ShoppingCartRecID]
				,[ProductID]
				,[VariantID]
				,[KitGroupID]
				,[KitGroupTypeID]
				,[KitItemID]
				,[Quantity]
				,[CartType]
				,[OriginalRecurringOrderNumber]
				,[TextOption]
				,[InventoryVariantID]
				,[InventoryVariantColor]
				,[InventoryVariantSize]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @CustomerID
				, @ShoppingCartRecID
				, @ProductID
				, @VariantID
				, @KitGroupID
				, @KitGroupTypeID
				, @KitItemID
				, @Quantity
				, @CartType
				, @OriginalRecurringOrderNumber
				, @TextOption
				, @InventoryVariantID
				, @InventoryVariantColor
				, @InventoryVariantSize
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitCartRecID",entity.KitCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@KitGroupID",entity.KitGroupId)
					, new SqlParameter("@KitGroupTypeID",entity.KitGroupTypeId)
					, new SqlParameter("@KitItemID",entity.KitItemId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantID",entity.InventoryVariantId ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantColor",entity.InventoryVariantColor ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantSize",entity.InventoryVariantSize ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetKitCart(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(KitCart))]
		public virtual KitCart UpdateKitCart(KitCart entity)
		{

			if (entity.IsTransient()) return entity;
			KitCart other = GetKitCart(entity.KitCartRecId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update KitCart set  [CustomerID]=@CustomerID
							, [ShoppingCartRecID]=@ShoppingCartRecID
							, [ProductID]=@ProductID
							, [VariantID]=@VariantID
							, [KitGroupID]=@KitGroupID
							, [KitGroupTypeID]=@KitGroupTypeID
							, [KitItemID]=@KitItemID
							, [Quantity]=@Quantity
							, [CartType]=@CartType
							, [OriginalRecurringOrderNumber]=@OriginalRecurringOrderNumber
							, [TextOption]=@TextOption
							, [InventoryVariantID]=@InventoryVariantID
							, [InventoryVariantColor]=@InventoryVariantColor
							, [InventoryVariantSize]=@InventoryVariantSize
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where KitCartRecID=@KitCartRecID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitCartRecID",entity.KitCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@KitGroupID",entity.KitGroupId)
					, new SqlParameter("@KitGroupTypeID",entity.KitGroupTypeId)
					, new SqlParameter("@KitItemID",entity.KitItemId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantID",entity.InventoryVariantId ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantColor",entity.InventoryVariantColor ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantSize",entity.InventoryVariantSize ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetKitCart(entity.KitCartRecId);
		}

		public virtual bool DeleteKitCart(System.Int32 KitCartRecId)
		{

			string sql="delete from KitCart where KitCartRecID=@KitCartRecID";
			SqlParameter parameter=new SqlParameter("@KitCartRecID",KitCartRecId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(KitCart))]
		public virtual KitCart DeleteKitCart(KitCart entity)
		{
			this.DeleteKitCart(entity.KitCartRecId);
			return entity;
		}


		public virtual KitCart KitCartFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			KitCart entity=new KitCart();
			entity.KitCartRecId = (System.Int32)dr["KitCartRecID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.ShoppingCartRecId = (System.Int32)dr["ShoppingCartRecID"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.KitGroupId = (System.Int32)dr["KitGroupID"];
			entity.KitGroupTypeId = (System.Int32)dr["KitGroupTypeID"];
			entity.KitItemId = (System.Int32)dr["KitItemID"];
			entity.Quantity = (System.Int32)dr["Quantity"];
			entity.CartType = (System.Int32)dr["CartType"];
			entity.OriginalRecurringOrderNumber = dr["OriginalRecurringOrderNumber"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["OriginalRecurringOrderNumber"];
			entity.TextOption = dr["TextOption"].ToString();
			entity.InventoryVariantId = dr["InventoryVariantID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["InventoryVariantID"];
			entity.InventoryVariantColor = dr["InventoryVariantColor"].ToString();
			entity.InventoryVariantSize = dr["InventoryVariantSize"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
