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
		
	public abstract partial class OrdersShoppingCartRepositoryBase : Repository 
	{
        
        public OrdersShoppingCartRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShoppingCartRecID",new SearchColumn(){Name="ShoppingCartRecID",Title="ShoppingCartRecID",SelectClause="ShoppingCartRecID",WhereClause="AllRecords.ShoppingCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Quantity",new SearchColumn(){Name="Quantity",Title="Quantity",SelectClause="Quantity",WhereClause="AllRecords.Quantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColor",new SearchColumn(){Name="ChosenColor",Title="ChosenColor",SelectClause="ChosenColor",WhereClause="AllRecords.ChosenColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColorSKUModifier",new SearchColumn(){Name="ChosenColorSKUModifier",Title="ChosenColorSKUModifier",SelectClause="ChosenColorSKUModifier",WhereClause="AllRecords.ChosenColorSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSize",new SearchColumn(){Name="ChosenSize",Title="ChosenSize",SelectClause="ChosenSize",WhereClause="AllRecords.ChosenSize",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSizeSKUModifier",new SearchColumn(){Name="ChosenSizeSKUModifier",Title="ChosenSizeSKUModifier",SelectClause="ChosenSizeSKUModifier",WhereClause="AllRecords.ChosenSizeSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductName",new SearchColumn(){Name="OrderedProductName",Title="OrderedProductName",SelectClause="OrderedProductName",WhereClause="AllRecords.OrderedProductName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductVariantName",new SearchColumn(){Name="OrderedProductVariantName",Title="OrderedProductVariantName",SelectClause="OrderedProductVariantName",WhereClause="AllRecords.OrderedProductVariantName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductSKU",new SearchColumn(){Name="OrderedProductSKU",Title="OrderedProductSKU",SelectClause="OrderedProductSKU",WhereClause="AllRecords.OrderedProductSKU",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductManufacturerPartNumber",new SearchColumn(){Name="OrderedProductManufacturerPartNumber",Title="OrderedProductManufacturerPartNumber",SelectClause="OrderedProductManufacturerPartNumber",WhereClause="AllRecords.OrderedProductManufacturerPartNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductWeight",new SearchColumn(){Name="OrderedProductWeight",Title="OrderedProductWeight",SelectClause="OrderedProductWeight",WhereClause="AllRecords.OrderedProductWeight",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductPrice",new SearchColumn(){Name="OrderedProductPrice",Title="OrderedProductPrice",SelectClause="OrderedProductPrice",WhereClause="AllRecords.OrderedProductPrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductRegularPrice",new SearchColumn(){Name="OrderedProductRegularPrice",Title="OrderedProductRegularPrice",SelectClause="OrderedProductRegularPrice",WhereClause="AllRecords.OrderedProductRegularPrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductSalePrice",new SearchColumn(){Name="OrderedProductSalePrice",Title="OrderedProductSalePrice",SelectClause="OrderedProductSalePrice",WhereClause="AllRecords.OrderedProductSalePrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductExtendedPrice",new SearchColumn(){Name="OrderedProductExtendedPrice",Title="OrderedProductExtendedPrice",SelectClause="OrderedProductExtendedPrice",WhereClause="AllRecords.OrderedProductExtendedPrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductQuantityDiscountName",new SearchColumn(){Name="OrderedProductQuantityDiscountName",Title="OrderedProductQuantityDiscountName",SelectClause="OrderedProductQuantityDiscountName",WhereClause="AllRecords.OrderedProductQuantityDiscountName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductQuantityDiscountID",new SearchColumn(){Name="OrderedProductQuantityDiscountID",Title="OrderedProductQuantityDiscountID",SelectClause="OrderedProductQuantityDiscountID",WhereClause="AllRecords.OrderedProductQuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderedProductQuantityDiscountPercent",new SearchColumn(){Name="OrderedProductQuantityDiscountPercent",Title="OrderedProductQuantityDiscountPercent",SelectClause="OrderedProductQuantityDiscountPercent",WhereClause="AllRecords.OrderedProductQuantityDiscountPercent",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsTaxable",new SearchColumn(){Name="IsTaxable",Title="IsTaxable",SelectClause="IsTaxable",WhereClause="AllRecords.IsTaxable",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsShipSeparately",new SearchColumn(){Name="IsShipSeparately",Title="IsShipSeparately",SelectClause="IsShipSeparately",WhereClause="AllRecords.IsShipSeparately",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDownload",new SearchColumn(){Name="IsDownload",Title="IsDownload",SelectClause="IsDownload",WhereClause="AllRecords.IsDownload",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DownloadLocation",new SearchColumn(){Name="DownloadLocation",Title="DownloadLocation",SelectClause="DownloadLocation",WhereClause="AllRecords.DownloadLocation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FreeShipping",new SearchColumn(){Name="FreeShipping",Title="FreeShipping",SelectClause="FreeShipping",WhereClause="AllRecords.FreeShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsSecureAttachment",new SearchColumn(){Name="IsSecureAttachment",Title="IsSecureAttachment",SelectClause="IsSecureAttachment",WhereClause="AllRecords.IsSecureAttachment",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOption",new SearchColumn(){Name="TextOption",Title="TextOption",SelectClause="TextOption",WhereClause="AllRecords.TextOption",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CartType",new SearchColumn(){Name="CartType",Title="CartType",SelectClause="CartType",WhereClause="AllRecords.CartType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionInterval",new SearchColumn(){Name="SubscriptionInterval",Title="SubscriptionInterval",SelectClause="SubscriptionInterval",WhereClause="AllRecords.SubscriptionInterval",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingAddressID",new SearchColumn(){Name="ShippingAddressID",Title="ShippingAddressID",SelectClause="ShippingAddressID",WhereClause="AllRecords.ShippingAddressID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingDetail",new SearchColumn(){Name="ShippingDetail",Title="ShippingDetail",SelectClause="ShippingDetail",WhereClause="AllRecords.ShippingDetail",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethodID",new SearchColumn(){Name="ShippingMethodID",Title="ShippingMethodID",SelectClause="ShippingMethodID",WhereClause="AllRecords.ShippingMethodID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethod",new SearchColumn(){Name="ShippingMethod",Title="ShippingMethod",SelectClause="ShippingMethod",WhereClause="AllRecords.ShippingMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DistributorID",new SearchColumn(){Name="DistributorID",Title="DistributorID",SelectClause="DistributorID",WhereClause="AllRecords.DistributorID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryForCustomerID",new SearchColumn(){Name="GiftRegistryForCustomerID",Title="GiftRegistryForCustomerID",SelectClause="GiftRegistryForCustomerID",WhereClause="AllRecords.GiftRegistryForCustomerID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DistributorEmailSentOn",new SearchColumn(){Name="DistributorEmailSentOn",Title="DistributorEmailSentOn",SelectClause="DistributorEmailSentOn",WhereClause="AllRecords.DistributorEmailSentOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SizeOptionPrompt",new SearchColumn(){Name="SizeOptionPrompt",Title="SizeOptionPrompt",SelectClause="SizeOptionPrompt",WhereClause="AllRecords.SizeOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColorOptionPrompt",new SearchColumn(){Name="ColorOptionPrompt",Title="ColorOptionPrompt",SelectClause="ColorOptionPrompt",WhereClause="AllRecords.ColorOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionPrompt",new SearchColumn(){Name="TextOptionPrompt",Title="TextOptionPrompt",SelectClause="TextOptionPrompt",WhereClause="AllRecords.TextOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionIntervalType",new SearchColumn(){Name="SubscriptionIntervalType",Title="SubscriptionIntervalType",SelectClause="SubscriptionIntervalType",WhereClause="AllRecords.SubscriptionIntervalType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEntersPrice",new SearchColumn(){Name="CustomerEntersPrice",Title="CustomerEntersPrice",SelectClause="CustomerEntersPrice",WhereClause="AllRecords.CustomerEntersPrice",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEntersPricePrompt",new SearchColumn(){Name="CustomerEntersPricePrompt",Title="CustomerEntersPricePrompt",SelectClause="CustomerEntersPricePrompt",WhereClause="AllRecords.CustomerEntersPricePrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAKit",new SearchColumn(){Name="IsAKit",Title="IsAKit",SelectClause="IsAKit",WhereClause="AllRecords.IsAKit",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAPack",new SearchColumn(){Name="IsAPack",Title="IsAPack",SelectClause="IsAPack",WhereClause="AllRecords.IsAPack",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsSystem",new SearchColumn(){Name="IsSystem",Title="IsSystem",SelectClause="IsSystem",WhereClause="AllRecords.IsSystem",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxRate",new SearchColumn(){Name="TaxRate",Title="TaxRate",SelectClause="TaxRate",WhereClause="AllRecords.TaxRate",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetOrdersShoppingCartSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetOrdersShoppingCartBasicSearchColumns()
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

        public virtual List<SearchColumn> GetOrdersShoppingCartAdvanceSearchColumns()
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
        
        
        public virtual string GetOrdersShoppingCartSelectClause()
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
                        	selectQuery =  "Orders_ShoppingCart."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Orders_ShoppingCart."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual OrdersShoppingCart GetOrdersShoppingCart(System.Int32 OrderNumber)
		{

			string sql=GetOrdersShoppingCartSelectClause();
			sql+="from Orders_ShoppingCart where OrderNumber=@OrderNumber ";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return OrdersShoppingCartFromDataRow(ds.Tables[0].Rows[0]);
		}

        public virtual DataSet GetOrdersShoppingCartDetail(System.Int32 OrderNumber)
        {

            string sql = "select * from Orders_ShoppingCart where OrderNumber=@OrderNumber ";
            SqlParameter parameter = new SqlParameter("@OrderNumber", OrderNumber);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            if (ds == null ||  ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }

		public virtual List<OrdersShoppingCart> GetAllOrdersShoppingCart()
		{

			string sql=GetOrdersShoppingCartSelectClause();
			sql+="from Orders_ShoppingCart";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrdersShoppingCart>(ds, OrdersShoppingCartFromDataRow);
		}

		public virtual List<OrdersShoppingCart> GetPagedOrdersShoppingCart(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetOrdersShoppingCartCount(whereClause, searchColumns);
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
            tempsql += " FROM [Orders_ShoppingCart] AllRecords";
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
                GetOrdersShoppingCartSelectClause()+@" FROM [Orders_ShoppingCart], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Orders_ShoppingCart].[OrderNumber] = PageIndex.[OrderNumber] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrdersShoppingCart>(ds, OrdersShoppingCartFromDataRow);
			}else{ return null;}
		}

		private int GetOrdersShoppingCartCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Orders_ShoppingCart as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Orders_ShoppingCart as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(OrdersShoppingCart))]
		public virtual OrdersShoppingCart InsertOrdersShoppingCart(OrdersShoppingCart entity)
		{

			OrdersShoppingCart other=new OrdersShoppingCart();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Orders_ShoppingCart ( [OrderNumber]
				,[ShoppingCartRecID]
				,[CustomerID]
				,[ProductID]
				,[VariantID]
				,[Quantity]
				,[ChosenColor]
				,[ChosenColorSKUModifier]
				,[ChosenSize]
				,[ChosenSizeSKUModifier]
				,[OrderedProductName]
				,[OrderedProductVariantName]
				,[OrderedProductSKU]
				,[OrderedProductManufacturerPartNumber]
				,[OrderedProductWeight]
				,[OrderedProductPrice]
				,[OrderedProductRegularPrice]
				,[OrderedProductSalePrice]
				,[OrderedProductExtendedPrice]
				,[OrderedProductQuantityDiscountName]
				,[OrderedProductQuantityDiscountID]
				,[OrderedProductQuantityDiscountPercent]
				,[IsTaxable]
				,[IsShipSeparately]
				,[IsDownload]
				,[DownloadLocation]
				,[FreeShipping]
				,[IsSecureAttachment]
				,[TextOption]
				,[CartType]
				,[SubscriptionInterval]
				,[ShippingAddressID]
				,[ShippingDetail]
				,[ShippingMethodID]
				,[ShippingMethod]
				,[DistributorID]
				,[GiftRegistryForCustomerID]
				,[Notes]
				,[DistributorEmailSentOn]
				,[ExtensionData]
				,[SizeOptionPrompt]
				,[ColorOptionPrompt]
				,[TextOptionPrompt]
				,[CreatedOn]
				,[SubscriptionIntervalType]
				,[CustomerEntersPrice]
				,[CustomerEntersPricePrompt]
				,[IsAKit]
				,[IsAPack]
				,[IsSystem]
				,[TaxClassID]
				,[TaxRate] )
				Values
				( @OrderNumber
				, @ShoppingCartRecID
				, @CustomerID
				, @ProductID
				, @VariantID
				, @Quantity
				, @ChosenColor
				, @ChosenColorSKUModifier
				, @ChosenSize
				, @ChosenSizeSKUModifier
				, @OrderedProductName
				, @OrderedProductVariantName
				, @OrderedProductSKU
				, @OrderedProductManufacturerPartNumber
				, @OrderedProductWeight
				, @OrderedProductPrice
				, @OrderedProductRegularPrice
				, @OrderedProductSalePrice
				, @OrderedProductExtendedPrice
				, @OrderedProductQuantityDiscountName
				, @OrderedProductQuantityDiscountID
				, @OrderedProductQuantityDiscountPercent
				, @IsTaxable
				, @IsShipSeparately
				, @IsDownload
				, @DownloadLocation
				, @FreeShipping
				, @IsSecureAttachment
				, @TextOption
				, @CartType
				, @SubscriptionInterval
				, @ShippingAddressID
				, @ShippingDetail
				, @ShippingMethodID
				, @ShippingMethod
				, @DistributorID
				, @GiftRegistryForCustomerID
				, @Notes
				, @DistributorEmailSentOn
				, @ExtensionData
				, @SizeOptionPrompt
				, @ColorOptionPrompt
				, @TextOptionPrompt
				, @CreatedOn
				, @SubscriptionIntervalType
				, @CustomerEntersPrice
				, @CustomerEntersPricePrompt
				, @IsAKit
				, @IsAPack
				, @IsSystem
				, @TaxClassID
				, @TaxRate );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductName",entity.OrderedProductName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductVariantName",entity.OrderedProductVariantName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductSKU",entity.OrderedProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductManufacturerPartNumber",entity.OrderedProductManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductWeight",entity.OrderedProductWeight ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductPrice",entity.OrderedProductPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductRegularPrice",entity.OrderedProductRegularPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductSalePrice",entity.OrderedProductSalePrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductExtendedPrice",entity.OrderedProductExtendedPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountName",entity.OrderedProductQuantityDiscountName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountID",entity.OrderedProductQuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountPercent",entity.OrderedProductQuantityDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddressID",entity.ShippingAddressId)
					, new SqlParameter("@ShippingDetail",entity.ShippingDetail ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorID",entity.DistributorId ?? (object)DBNull.Value)
					, new SqlParameter("@GiftRegistryForCustomerID",entity.GiftRegistryForCustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorEmailSentOn",entity.DistributorEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@SizeOptionPrompt",entity.SizeOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ColorOptionPrompt",entity.ColorOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionPrompt",entity.TextOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@CustomerEntersPricePrompt",entity.CustomerEntersPricePrompt ?? (object)DBNull.Value)
					, new SqlParameter("@IsAKit",entity.IsAkit ?? (object)DBNull.Value)
					, new SqlParameter("@IsAPack",entity.IsApack ?? (object)DBNull.Value)
					, new SqlParameter("@IsSystem",entity.IsSystem ?? (object)DBNull.Value)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetOrdersShoppingCart(Convert.ToInt32(identity));
			}
			return entity;
		}

        [MOLog(AuditOperations.Create, typeof(OrdersShoppingCart))]
        public virtual bool iabazaarInsertOrdersShoppingCart(OrdersShoppingCart entity)
        {
            try{
            OrdersShoppingCart other = new OrdersShoppingCart();
            other = entity;
            
                string sql = @"Insert into Orders_ShoppingCart ( [OrderNumber]
				,[ShoppingCartRecID]
				,[CustomerID]
				,[ProductID]
				,[Quantity]
				,[OrderedProductName]
				,[OrderedProductPrice])
				Values
				( @OrderNumber
				, @ShoppingCartRecID
				, @CustomerID
				, @ProductID
				, @Quantity
				, @OrderedProductName
				, @OrderedProductPrice
				);
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@OrderedProductName",entity.OrderedProductName ?? (object)DBNull.Value)
                    , new SqlParameter("@OrderedProductPrice",entity.OrderedProductPrice ?? (object)DBNull.Value)
					};
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }



		[MOLog(AuditOperations.Update,typeof(OrdersShoppingCart))]
		public virtual OrdersShoppingCart UpdateOrdersShoppingCart(OrdersShoppingCart entity)
		{

			if (entity.IsTransient()) return entity;
			OrdersShoppingCart other = GetOrdersShoppingCart(entity.OrderNumber);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Orders_ShoppingCart set  [ShoppingCartRecID]=@ShoppingCartRecID
							, [CustomerID]=@CustomerID
							, [ProductID]=@ProductID
							, [VariantID]=@VariantID
							, [Quantity]=@Quantity
							, [ChosenColor]=@ChosenColor
							, [ChosenColorSKUModifier]=@ChosenColorSKUModifier
							, [ChosenSize]=@ChosenSize
							, [ChosenSizeSKUModifier]=@ChosenSizeSKUModifier
							, [OrderedProductName]=@OrderedProductName
							, [OrderedProductVariantName]=@OrderedProductVariantName
							, [OrderedProductSKU]=@OrderedProductSKU
							, [OrderedProductManufacturerPartNumber]=@OrderedProductManufacturerPartNumber
							, [OrderedProductWeight]=@OrderedProductWeight
							, [OrderedProductPrice]=@OrderedProductPrice
							, [OrderedProductRegularPrice]=@OrderedProductRegularPrice
							, [OrderedProductSalePrice]=@OrderedProductSalePrice
							, [OrderedProductExtendedPrice]=@OrderedProductExtendedPrice
							, [OrderedProductQuantityDiscountName]=@OrderedProductQuantityDiscountName
							, [OrderedProductQuantityDiscountID]=@OrderedProductQuantityDiscountID
							, [OrderedProductQuantityDiscountPercent]=@OrderedProductQuantityDiscountPercent
							, [IsTaxable]=@IsTaxable
							, [IsShipSeparately]=@IsShipSeparately
							, [IsDownload]=@IsDownload
							, [DownloadLocation]=@DownloadLocation
							, [FreeShipping]=@FreeShipping
							, [IsSecureAttachment]=@IsSecureAttachment
							, [TextOption]=@TextOption
							, [CartType]=@CartType
							, [SubscriptionInterval]=@SubscriptionInterval
							, [ShippingAddressID]=@ShippingAddressID
							, [ShippingDetail]=@ShippingDetail
							, [ShippingMethodID]=@ShippingMethodID
							, [ShippingMethod]=@ShippingMethod
							, [DistributorID]=@DistributorID
							, [GiftRegistryForCustomerID]=@GiftRegistryForCustomerID
							, [Notes]=@Notes
							, [DistributorEmailSentOn]=@DistributorEmailSentOn
							, [ExtensionData]=@ExtensionData
							, [SizeOptionPrompt]=@SizeOptionPrompt
							, [ColorOptionPrompt]=@ColorOptionPrompt
							, [TextOptionPrompt]=@TextOptionPrompt
							, [CreatedOn]=@CreatedOn
							, [SubscriptionIntervalType]=@SubscriptionIntervalType
							, [CustomerEntersPrice]=@CustomerEntersPrice
							, [CustomerEntersPricePrompt]=@CustomerEntersPricePrompt
							, [IsAKit]=@IsAKit
							, [IsAPack]=@IsAPack
							, [IsSystem]=@IsSystem
							, [TaxClassID]=@TaxClassID
							, [TaxRate]=@TaxRate 
							 where OrderNumber=@OrderNumber";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductName",entity.OrderedProductName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductVariantName",entity.OrderedProductVariantName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductSKU",entity.OrderedProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductManufacturerPartNumber",entity.OrderedProductManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductWeight",entity.OrderedProductWeight ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductPrice",entity.OrderedProductPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductRegularPrice",entity.OrderedProductRegularPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductSalePrice",entity.OrderedProductSalePrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductExtendedPrice",entity.OrderedProductExtendedPrice ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountName",entity.OrderedProductQuantityDiscountName ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountID",entity.OrderedProductQuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@OrderedProductQuantityDiscountPercent",entity.OrderedProductQuantityDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddressID",entity.ShippingAddressId)
					, new SqlParameter("@ShippingDetail",entity.ShippingDetail ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorID",entity.DistributorId ?? (object)DBNull.Value)
					, new SqlParameter("@GiftRegistryForCustomerID",entity.GiftRegistryForCustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorEmailSentOn",entity.DistributorEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@SizeOptionPrompt",entity.SizeOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ColorOptionPrompt",entity.ColorOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionPrompt",entity.TextOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@CustomerEntersPricePrompt",entity.CustomerEntersPricePrompt ?? (object)DBNull.Value)
					, new SqlParameter("@IsAKit",entity.IsAkit ?? (object)DBNull.Value)
					, new SqlParameter("@IsAPack",entity.IsApack ?? (object)DBNull.Value)
					, new SqlParameter("@IsSystem",entity.IsSystem ?? (object)DBNull.Value)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetOrdersShoppingCart(entity.OrderNumber);
		}

		public virtual bool DeleteOrdersShoppingCart(System.Int32 OrderNumber)
		{

			string sql="delete from Orders_ShoppingCart where OrderNumber=@OrderNumber";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(OrdersShoppingCart))]
		public virtual OrdersShoppingCart DeleteOrdersShoppingCart(OrdersShoppingCart entity)
		{
			this.DeleteOrdersShoppingCart(entity.OrderNumber);
			return entity;
		}


		public virtual OrdersShoppingCart OrdersShoppingCartFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			OrdersShoppingCart entity=new OrdersShoppingCart();
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.ShoppingCartRecId = (System.Int32)dr["ShoppingCartRecID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.Quantity = (System.Int32)dr["Quantity"];
			entity.ChosenColor = dr["ChosenColor"].ToString();
			entity.ChosenColorSkuModifier = dr["ChosenColorSKUModifier"].ToString();
			entity.ChosenSize = dr["ChosenSize"].ToString();
			entity.ChosenSizeSkuModifier = dr["ChosenSizeSKUModifier"].ToString();
			entity.OrderedProductName = dr["OrderedProductName"].ToString();
			entity.OrderedProductVariantName = dr["OrderedProductVariantName"].ToString();
			entity.OrderedProductSku = dr["OrderedProductSKU"].ToString();
			entity.OrderedProductManufacturerPartNumber = dr["OrderedProductManufacturerPartNumber"].ToString();
			entity.OrderedProductWeight = dr["OrderedProductWeight"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductWeight"];
			entity.OrderedProductPrice = dr["OrderedProductPrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductPrice"];
			entity.OrderedProductRegularPrice = dr["OrderedProductRegularPrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductRegularPrice"];
			entity.OrderedProductSalePrice = dr["OrderedProductSalePrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductSalePrice"];
			entity.OrderedProductExtendedPrice = dr["OrderedProductExtendedPrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductExtendedPrice"];
			entity.OrderedProductQuantityDiscountName = dr["OrderedProductQuantityDiscountName"].ToString();
			entity.OrderedProductQuantityDiscountId = dr["OrderedProductQuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["OrderedProductQuantityDiscountID"];
			entity.OrderedProductQuantityDiscountPercent = dr["OrderedProductQuantityDiscountPercent"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["OrderedProductQuantityDiscountPercent"];
			entity.IsTaxable = (System.Byte)dr["IsTaxable"];
			entity.IsShipSeparately = (System.Byte)dr["IsShipSeparately"];
			entity.IsDownload = (System.Byte)dr["IsDownload"];
			entity.DownloadLocation = dr["DownloadLocation"].ToString();
			entity.FreeShipping = (System.Byte)dr["FreeShipping"];
			entity.IsSecureAttachment = (System.Byte)dr["IsSecureAttachment"];
			entity.TextOption = dr["TextOption"].ToString();
			entity.CartType = (System.Int32)dr["CartType"];
			entity.SubscriptionInterval = dr["SubscriptionInterval"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["SubscriptionInterval"];
			entity.ShippingAddressId = (System.Int32)dr["ShippingAddressID"];
			entity.ShippingDetail = dr["ShippingDetail"].ToString();
			entity.ShippingMethodId = dr["ShippingMethodID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ShippingMethodID"];
			entity.ShippingMethod = dr["ShippingMethod"].ToString();
			entity.DistributorId = dr["DistributorID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["DistributorID"];
			entity.GiftRegistryForCustomerId = dr["GiftRegistryForCustomerID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["GiftRegistryForCustomerID"];
			entity.Notes = dr["Notes"].ToString();
			entity.DistributorEmailSentOn = dr["DistributorEmailSentOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["DistributorEmailSentOn"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.SizeOptionPrompt = dr["SizeOptionPrompt"].ToString();
			entity.ColorOptionPrompt = dr["ColorOptionPrompt"].ToString();
			entity.TextOptionPrompt = dr["TextOptionPrompt"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.SubscriptionIntervalType = (System.Int32)dr["SubscriptionIntervalType"];
			entity.CustomerEntersPrice = (System.Byte)dr["CustomerEntersPrice"];
			entity.CustomerEntersPricePrompt = dr["CustomerEntersPricePrompt"].ToString();
			entity.IsAkit = dr["IsAKit"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsAKit"];
			entity.IsApack = dr["IsAPack"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsAPack"];
			entity.IsSystem = dr["IsSystem"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsSystem"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxRate = (System.Decimal)dr["TaxRate"];
			return entity;
		}

	}
	
	
}
