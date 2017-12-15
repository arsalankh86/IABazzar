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
		
	public abstract partial class CustomCartRepositoryBase : Repository 
	{
        
        public CustomCartRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomCartRecID",new SearchColumn(){Name="CustomCartRecID",Title="CustomCartRecID",SelectClause="CustomCartRecID",WhereClause="AllRecords.CustomCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PackID",new SearchColumn(){Name="PackID",Title="PackID",SelectClause="PackID",WhereClause="AllRecords.PackID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShoppingCartRecID",new SearchColumn(){Name="ShoppingCartRecID",Title="ShoppingCartRecID",SelectClause="ShoppingCartRecID",WhereClause="AllRecords.ShoppingCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductSKU",new SearchColumn(){Name="ProductSKU",Title="ProductSKU",SelectClause="ProductSKU",WhereClause="AllRecords.ProductSKU",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductWeight",new SearchColumn(){Name="ProductWeight",Title="ProductWeight",SelectClause="ProductWeight",WhereClause="AllRecords.ProductWeight",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Quantity",new SearchColumn(){Name="Quantity",Title="Quantity",SelectClause="Quantity",WhereClause="AllRecords.Quantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColor",new SearchColumn(){Name="ChosenColor",Title="ChosenColor",SelectClause="ChosenColor",WhereClause="AllRecords.ChosenColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColorSKUModifier",new SearchColumn(){Name="ChosenColorSKUModifier",Title="ChosenColorSKUModifier",SelectClause="ChosenColorSKUModifier",WhereClause="AllRecords.ChosenColorSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSize",new SearchColumn(){Name="ChosenSize",Title="ChosenSize",SelectClause="ChosenSize",WhereClause="AllRecords.ChosenSize",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSizeSKUModifier",new SearchColumn(){Name="ChosenSizeSKUModifier",Title="ChosenSizeSKUModifier",SelectClause="ChosenSizeSKUModifier",WhereClause="AllRecords.ChosenSizeSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CartType",new SearchColumn(){Name="CartType",Title="CartType",SelectClause="CartType",WhereClause="AllRecords.CartType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OriginalRecurringOrderNumber",new SearchColumn(){Name="OriginalRecurringOrderNumber",Title="OriginalRecurringOrderNumber",SelectClause="OriginalRecurringOrderNumber",WhereClause="AllRecords.OriginalRecurringOrderNumber",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomCartSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomCartBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomCartAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomCartSelectClause()
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
                        	selectQuery =  "CustomCart."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomCart."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomCart GetCustomCart(System.Int32 CustomCartRecId)
		{

			string sql=GetCustomCartSelectClause();
			sql+="from CustomCart where CustomCartRecID=@CustomCartRecID ";
			SqlParameter parameter=new SqlParameter("@CustomCartRecID",CustomCartRecId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomCartFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomCart> GetAllCustomCart()
		{

			string sql=GetCustomCartSelectClause();
			sql+="from CustomCart";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomCart>(ds, CustomCartFromDataRow);
		}

		public virtual List<CustomCart> GetPagedCustomCart(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomCartCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomCartRecID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomCartRecID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomCartRecID] ";
            tempsql += " FROM [CustomCart] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomCartRecID"))
					tempsql += " , (AllRecords.[CustomCartRecID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomCartRecID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomCartSelectClause()+@" FROM [CustomCart], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomCart].[CustomCartRecID] = PageIndex.[CustomCartRecID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomCart>(ds, CustomCartFromDataRow);
			}else{ return null;}
		}

		private int GetCustomCartCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomCart as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomCart as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomCart))]
		public virtual CustomCart InsertCustomCart(CustomCart entity)
		{

			CustomCart other=new CustomCart();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomCart ( [CustomerID]
				,[PackID]
				,[ShoppingCartRecID]
				,[ProductSKU]
				,[ProductWeight]
				,[ProductID]
				,[VariantID]
				,[Quantity]
				,[ChosenColor]
				,[ChosenColorSKUModifier]
				,[ChosenSize]
				,[ChosenSizeSKUModifier]
				,[CartType]
				,[OriginalRecurringOrderNumber]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @CustomerID
				, @PackID
				, @ShoppingCartRecID
				, @ProductSKU
				, @ProductWeight
				, @ProductID
				, @VariantID
				, @Quantity
				, @ChosenColor
				, @ChosenColorSKUModifier
				, @ChosenSize
				, @ChosenSizeSKUModifier
				, @CartType
				, @OriginalRecurringOrderNumber
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomCartRecID",entity.CustomCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@PackID",entity.PackId)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductSKU",entity.ProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@ProductWeight",entity.ProductWeight)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomCart(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomCart))]
		public virtual CustomCart UpdateCustomCart(CustomCart entity)
		{

			if (entity.IsTransient()) return entity;
			CustomCart other = GetCustomCart(entity.CustomCartRecId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomCart set  [CustomerID]=@CustomerID
							, [PackID]=@PackID
							, [ShoppingCartRecID]=@ShoppingCartRecID
							, [ProductSKU]=@ProductSKU
							, [ProductWeight]=@ProductWeight
							, [ProductID]=@ProductID
							, [VariantID]=@VariantID
							, [Quantity]=@Quantity
							, [ChosenColor]=@ChosenColor
							, [ChosenColorSKUModifier]=@ChosenColorSKUModifier
							, [ChosenSize]=@ChosenSize
							, [ChosenSizeSKUModifier]=@ChosenSizeSKUModifier
							, [CartType]=@CartType
							, [OriginalRecurringOrderNumber]=@OriginalRecurringOrderNumber
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where CustomCartRecID=@CustomCartRecID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomCartRecID",entity.CustomCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@PackID",entity.PackId)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductSKU",entity.ProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@ProductWeight",entity.ProductWeight)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomCart(entity.CustomCartRecId);
		}

		public virtual bool DeleteCustomCart(System.Int32 CustomCartRecId)
		{

			string sql="delete from CustomCart where CustomCartRecID=@CustomCartRecID";
			SqlParameter parameter=new SqlParameter("@CustomCartRecID",CustomCartRecId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomCart))]
		public virtual CustomCart DeleteCustomCart(CustomCart entity)
		{
			this.DeleteCustomCart(entity.CustomCartRecId);
			return entity;
		}


		public virtual CustomCart CustomCartFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomCart entity=new CustomCart();
			entity.CustomCartRecId = (System.Int32)dr["CustomCartRecID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.PackId = (System.Int32)dr["PackID"];
			entity.ShoppingCartRecId = (System.Int32)dr["ShoppingCartRecID"];
			entity.ProductSku = dr["ProductSKU"].ToString();
			entity.ProductWeight = (System.Decimal)dr["ProductWeight"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.Quantity = (System.Int32)dr["Quantity"];
			entity.ChosenColor = dr["ChosenColor"].ToString();
			entity.ChosenColorSkuModifier = dr["ChosenColorSKUModifier"].ToString();
			entity.ChosenSize = dr["ChosenSize"].ToString();
			entity.ChosenSizeSkuModifier = dr["ChosenSizeSKUModifier"].ToString();
			entity.CartType = (System.Int32)dr["CartType"];
			entity.OriginalRecurringOrderNumber = dr["OriginalRecurringOrderNumber"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["OriginalRecurringOrderNumber"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
