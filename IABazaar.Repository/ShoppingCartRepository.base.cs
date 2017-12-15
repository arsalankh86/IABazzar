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
		
	public abstract partial class ShoppingCartRepositoryBase : Repository 
	{
        
        public ShoppingCartRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ShoppingCartRecID",new SearchColumn(){Name="ShoppingCartRecID",Title="ShoppingCartRecID",SelectClause="ShoppingCartRecID",WhereClause="AllRecords.ShoppingCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShoppingCartRecGUID",new SearchColumn(){Name="ShoppingCartRecGUID",Title="ShoppingCartRecGUID",SelectClause="ShoppingCartRecGUID",WhereClause="AllRecords.ShoppingCartRecGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductSKU",new SearchColumn(){Name="ProductSKU",Title="ProductSKU",SelectClause="ProductSKU",WhereClause="AllRecords.ProductSKU",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductPrice",new SearchColumn(){Name="ProductPrice",Title="ProductPrice",SelectClause="ProductPrice",WhereClause="AllRecords.ProductPrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductWeight",new SearchColumn(){Name="ProductWeight",Title="ProductWeight",SelectClause="ProductWeight",WhereClause="AllRecords.ProductWeight",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Quantity",new SearchColumn(){Name="Quantity",Title="Quantity",SelectClause="Quantity",WhereClause="AllRecords.Quantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresCount",new SearchColumn(){Name="RequiresCount",Title="RequiresCount",SelectClause="RequiresCount",WhereClause="AllRecords.RequiresCount",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColor",new SearchColumn(){Name="ChosenColor",Title="ChosenColor",SelectClause="ChosenColor",WhereClause="AllRecords.ChosenColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenColorSKUModifier",new SearchColumn(){Name="ChosenColorSKUModifier",Title="ChosenColorSKUModifier",SelectClause="ChosenColorSKUModifier",WhereClause="AllRecords.ChosenColorSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSize",new SearchColumn(){Name="ChosenSize",Title="ChosenSize",SelectClause="ChosenSize",WhereClause="AllRecords.ChosenSize",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ChosenSizeSKUModifier",new SearchColumn(){Name="ChosenSizeSKUModifier",Title="ChosenSizeSKUModifier",SelectClause="ChosenSizeSKUModifier",WhereClause="AllRecords.ChosenSizeSKUModifier",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsTaxable",new SearchColumn(){Name="IsTaxable",Title="IsTaxable",SelectClause="IsTaxable",WhereClause="AllRecords.IsTaxable",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsShipSeparately",new SearchColumn(){Name="IsShipSeparately",Title="IsShipSeparately",SelectClause="IsShipSeparately",WhereClause="AllRecords.IsShipSeparately",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDownload",new SearchColumn(){Name="IsDownload",Title="IsDownload",SelectClause="IsDownload",WhereClause="AllRecords.IsDownload",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DownloadLocation",new SearchColumn(){Name="DownloadLocation",Title="DownloadLocation",SelectClause="DownloadLocation",WhereClause="AllRecords.DownloadLocation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FreeShipping",new SearchColumn(){Name="FreeShipping",Title="FreeShipping",SelectClause="FreeShipping",WhereClause="AllRecords.FreeShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductDimensions",new SearchColumn(){Name="ProductDimensions",Title="ProductDimensions",SelectClause="ProductDimensions",WhereClause="AllRecords.ProductDimensions",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CartType",new SearchColumn(){Name="CartType",Title="CartType",SelectClause="CartType",WhereClause="AllRecords.CartType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsSecureAttachment",new SearchColumn(){Name="IsSecureAttachment",Title="IsSecureAttachment",SelectClause="IsSecureAttachment",WhereClause="AllRecords.IsSecureAttachment",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOption",new SearchColumn(){Name="TextOption",Title="TextOption",SelectClause="TextOption",WhereClause="AllRecords.TextOption",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NextRecurringShipDate",new SearchColumn(){Name="NextRecurringShipDate",Title="NextRecurringShipDate",SelectClause="NextRecurringShipDate",WhereClause="AllRecords.NextRecurringShipDate",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringIndex",new SearchColumn(){Name="RecurringIndex",Title="RecurringIndex",SelectClause="RecurringIndex",WhereClause="AllRecords.RecurringIndex",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OriginalRecurringOrderNumber",new SearchColumn(){Name="OriginalRecurringOrderNumber",Title="OriginalRecurringOrderNumber",SelectClause="OriginalRecurringOrderNumber",WhereClause="AllRecords.OriginalRecurringOrderNumber",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingAddressID",new SearchColumn(){Name="BillingAddressID",Title="BillingAddressID",SelectClause="BillingAddressID",WhereClause="AllRecords.BillingAddressID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingAddressID",new SearchColumn(){Name="ShippingAddressID",Title="ShippingAddressID",SelectClause="ShippingAddressID",WhereClause="AllRecords.ShippingAddressID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethodID",new SearchColumn(){Name="ShippingMethodID",Title="ShippingMethodID",SelectClause="ShippingMethodID",WhereClause="AllRecords.ShippingMethodID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethod",new SearchColumn(){Name="ShippingMethod",Title="ShippingMethod",SelectClause="ShippingMethod",WhereClause="AllRecords.ShippingMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DistributorID",new SearchColumn(){Name="DistributorID",Title="DistributorID",SelectClause="DistributorID",WhereClause="AllRecords.DistributorID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionInterval",new SearchColumn(){Name="SubscriptionInterval",Title="SubscriptionInterval",SelectClause="SubscriptionInterval",WhereClause="AllRecords.SubscriptionInterval",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsUpsell",new SearchColumn(){Name="IsUpsell",Title="IsUpsell",SelectClause="IsUpsell",WhereClause="AllRecords.IsUpsell",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryForCustomerID",new SearchColumn(){Name="GiftRegistryForCustomerID",Title="GiftRegistryForCustomerID",SelectClause="GiftRegistryForCustomerID",WhereClause="AllRecords.GiftRegistryForCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringInterval",new SearchColumn(){Name="RecurringInterval",Title="RecurringInterval",SelectClause="RecurringInterval",WhereClause="AllRecords.RecurringInterval",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringIntervalType",new SearchColumn(){Name="RecurringIntervalType",Title="RecurringIntervalType",SelectClause="RecurringIntervalType",WhereClause="AllRecords.RecurringIntervalType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionIntervalType",new SearchColumn(){Name="SubscriptionIntervalType",Title="SubscriptionIntervalType",SelectClause="SubscriptionIntervalType",WhereClause="AllRecords.SubscriptionIntervalType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEntersPrice",new SearchColumn(){Name="CustomerEntersPrice",Title="CustomerEntersPrice",SelectClause="CustomerEntersPrice",WhereClause="AllRecords.CustomerEntersPrice",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAKit",new SearchColumn(){Name="IsAKit",Title="IsAKit",SelectClause="IsAKit",WhereClause="AllRecords.IsAKit",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsKit2",new SearchColumn(){Name="IsKit2",Title="IsKit2",SelectClause="IsKit2",WhereClause="AllRecords.IsKit2",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAPack",new SearchColumn(){Name="IsAPack",Title="IsAPack",SelectClause="IsAPack",WhereClause="AllRecords.IsAPack",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsSystem",new SearchColumn(){Name="IsSystem",Title="IsSystem",SelectClause="IsSystem",WhereClause="AllRecords.IsSystem",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxRate",new SearchColumn(){Name="TaxRate",Title="TaxRate",SelectClause="TaxRate",WhereClause="AllRecords.TaxRate",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringSubscriptionID",new SearchColumn(){Name="RecurringSubscriptionID",Title="RecurringSubscriptionID",SelectClause="RecurringSubscriptionID",WhereClause="AllRecords.RecurringSubscriptionID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetShoppingCartSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetShoppingCartBasicSearchColumns()
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

        public virtual List<SearchColumn> GetShoppingCartAdvanceSearchColumns()
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
        
        
        public virtual string GetShoppingCartSelectClause()
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
                        	selectQuery =  "ShoppingCart."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ShoppingCart."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ShoppingCart GetShoppingCart(System.Int32 ShoppingCartRecId)
		{

			string sql=GetShoppingCartSelectClause();
			sql+="from ShoppingCart where ShoppingCartRecID=@ShoppingCartRecID ";
			SqlParameter parameter=new SqlParameter("@ShoppingCartRecID",ShoppingCartRecId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ShoppingCartFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ShoppingCart> GetAllShoppingCart()
		{

			string sql=GetShoppingCartSelectClause();
			sql+="from ShoppingCart";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ShoppingCart>(ds, ShoppingCartFromDataRow);
		}

        public virtual List<ShoppingCart> GetAllShoppingCartByCustomerID(int CustomerID)
        {

            string sql = GetShoppingCartSelectClause();
            sql += "from ShoppingCart where CustomerID = " + CustomerID + " ";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables[0].Rows.Count == 0) return null;
            return CollectionFromDataSet<ShoppingCart>(ds, ShoppingCartFromDataRow);
        }


        public virtual DataSet GetAllShoppingCartAndProductDetailByCustomerID(int CustomerID)
        {

            string sql = "select p.ProductID, c.ProductPrice, c.Quantity, c.TaxRate as CartTotal, p.ImageFilenameOverride,  p.Name, c.CustomerID, c.ShoppingCartRecID, c.ChosenSize from ShoppingCart c, Product p where c.ProductID = p.ProductID and c.CustomerID = " + CustomerID + " ";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }


		public virtual List<ShoppingCart> GetPagedShoppingCart(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetShoppingCartCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ShoppingCartRecID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ShoppingCartRecID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ShoppingCartRecID] ";
            tempsql += " FROM [ShoppingCart] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ShoppingCartRecID"))
					tempsql += " , (AllRecords.[ShoppingCartRecID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ShoppingCartRecID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetShoppingCartSelectClause()+@" FROM [ShoppingCart], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ShoppingCart].[ShoppingCartRecID] = PageIndex.[ShoppingCartRecID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ShoppingCart>(ds, ShoppingCartFromDataRow);
			}else{ return null;}
		}

		private int GetShoppingCartCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ShoppingCart as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ShoppingCart as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ShoppingCart))]
		public virtual ShoppingCart InsertShoppingCart(ShoppingCart entity)
		{

			ShoppingCart other=new ShoppingCart();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ShoppingCart ( [ShoppingCartRecGUID]
				,[StoreID]
				,[CustomerID]
				,[ProductSKU]
				,[ProductPrice]
				,[ProductWeight]
				,[ProductID]
				,[VariantID]
				,[Quantity]
				,[RequiresCount]
				,[ChosenColor]
				,[ChosenColorSKUModifier]
				,[ChosenSize]
				,[ChosenSizeSKUModifier]
				,[IsTaxable]
				,[IsShipSeparately]
				,[IsDownload]
				,[DownloadLocation]
				,[FreeShipping]
				,[CreatedOn]
				,[ProductDimensions]
				,[CartType]
				,[IsSecureAttachment]
				,[TextOption]
				,[NextRecurringShipDate]
				,[RecurringIndex]
				,[OriginalRecurringOrderNumber]
				,[BillingAddressID]
				,[ShippingAddressID]
				,[ShippingMethodID]
				,[ShippingMethod]
				,[DistributorID]
				,[SubscriptionInterval]
				,[Notes]
				,[IsUpsell]
				,[GiftRegistryForCustomerID]
				,[RecurringInterval]
				,[RecurringIntervalType]
				,[ExtensionData]
				,[SubscriptionIntervalType]
				,[CustomerEntersPrice]
				,[IsAKit]
				,[IsKit2]
				,[IsAPack]
				,[IsSystem]
				,[TaxClassID]
				,[TaxRate]
				,[RecurringSubscriptionID] )
				Values
				( @ShoppingCartRecGUID
				, @StoreID
				, @CustomerID
				, @ProductSKU
				, @ProductPrice
				, @ProductWeight
				, @ProductID
				, @VariantID
				, @Quantity
				, @RequiresCount
				, @ChosenColor
				, @ChosenColorSKUModifier
				, @ChosenSize
				, @ChosenSizeSKUModifier
				, @IsTaxable
				, @IsShipSeparately
				, @IsDownload
				, @DownloadLocation
				, @FreeShipping
				, @CreatedOn
				, @ProductDimensions
				, @CartType
				, @IsSecureAttachment
				, @TextOption
				, @NextRecurringShipDate
				, @RecurringIndex
				, @OriginalRecurringOrderNumber
				, @BillingAddressID
				, @ShippingAddressID
				, @ShippingMethodID
				, @ShippingMethod
				, @DistributorID
				, @SubscriptionInterval
				, @Notes
				, @IsUpsell
				, @GiftRegistryForCustomerID
				, @RecurringInterval
				, @RecurringIntervalType
				, @ExtensionData
				, @SubscriptionIntervalType
				, @CustomerEntersPrice
				, @IsAKit
				, @IsKit2
				, @IsAPack
				, @IsSystem
				, @TaxClassID
				, @TaxRate
				, @RecurringSubscriptionID );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ShoppingCartRecGUID",entity.ShoppingCartRecGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ProductSKU",entity.ProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@ProductPrice",entity.ProductPrice ?? (object)DBNull.Value)
					, new SqlParameter("@ProductWeight",entity.ProductWeight ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@RequiresCount",entity.RequiresCount)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@ProductDimensions",entity.ProductDimensions ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@NextRecurringShipDate",entity.NextRecurringShipDate ?? (object)DBNull.Value)
					, new SqlParameter("@RecurringIndex",entity.RecurringIndex)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddressID",entity.BillingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddressID",entity.ShippingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorID",entity.DistributorId ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@IsUpsell",entity.IsUpsell)
					, new SqlParameter("@GiftRegistryForCustomerID",entity.GiftRegistryForCustomerId)
					, new SqlParameter("@RecurringInterval",entity.RecurringInterval)
					, new SqlParameter("@RecurringIntervalType",entity.RecurringIntervalType)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@IsAKit",entity.IsAkit ?? (object)DBNull.Value)
					, new SqlParameter("@IsKit2",entity.IsKit2)
					, new SqlParameter("@IsAPack",entity.IsApack ?? (object)DBNull.Value)
					, new SqlParameter("@IsSystem",entity.IsSystem ?? (object)DBNull.Value)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetShoppingCart(Convert.ToInt32(identity));
			}
			return entity;
		}

        [MOLog(AuditOperations.Create, typeof(ShoppingCart))]
        public virtual bool iabazaarInsertShoppingCart(ShoppingCart entity)
        {

            ShoppingCart other = new ShoppingCart();
            other = entity;
            try
            {
                string sql = @"Insert into ShoppingCart ( 
				[CustomerID]
				,[ProductPrice]
				,[ProductID]
				,[Quantity]
                ,[TaxRate]
                ,[ChosenSize]
				)
				Values
				( @CustomerID
				, @ProductPrice
				, @ProductID
				, @Quantity
                , @TaxRate
                , @ChosenSize
				);
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					 new SqlParameter("@CustomerID",entity.CustomerId)
					
					, new SqlParameter("@ProductPrice",entity.ProductPrice ?? (object)DBNull.Value)
					
					, new SqlParameter("@ProductID",entity.ProductId)
					
					, new SqlParameter("@Quantity",entity.Quantity)
                    , new SqlParameter("@TaxRate",entity.TaxRate)
                    , new SqlParameter("@ChosenSize",entity.ChosenSize)
					};
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                if (identity == DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

     
		[MOLog(AuditOperations.Update,typeof(ShoppingCart))]
		public virtual ShoppingCart UpdateShoppingCart(ShoppingCart entity)
		{

			if (entity.IsTransient()) return entity;
			ShoppingCart other = GetShoppingCart(entity.ShoppingCartRecId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ShoppingCart set  [ShoppingCartRecGUID]=@ShoppingCartRecGUID
							, [StoreID]=@StoreID
							, [CustomerID]=@CustomerID
							, [ProductSKU]=@ProductSKU
							, [ProductPrice]=@ProductPrice
							, [ProductWeight]=@ProductWeight
							, [ProductID]=@ProductID
							, [VariantID]=@VariantID
							, [Quantity]=@Quantity
							, [RequiresCount]=@RequiresCount
							, [ChosenColor]=@ChosenColor
							, [ChosenColorSKUModifier]=@ChosenColorSKUModifier
							, [ChosenSize]=@ChosenSize
							, [ChosenSizeSKUModifier]=@ChosenSizeSKUModifier
							, [IsTaxable]=@IsTaxable
							, [IsShipSeparately]=@IsShipSeparately
							, [IsDownload]=@IsDownload
							, [DownloadLocation]=@DownloadLocation
							, [FreeShipping]=@FreeShipping
							, [CreatedOn]=@CreatedOn
							, [ProductDimensions]=@ProductDimensions
							, [CartType]=@CartType
							, [IsSecureAttachment]=@IsSecureAttachment
							, [TextOption]=@TextOption
							, [NextRecurringShipDate]=@NextRecurringShipDate
							, [RecurringIndex]=@RecurringIndex
							, [OriginalRecurringOrderNumber]=@OriginalRecurringOrderNumber
							, [BillingAddressID]=@BillingAddressID
							, [ShippingAddressID]=@ShippingAddressID
							, [ShippingMethodID]=@ShippingMethodID
							, [ShippingMethod]=@ShippingMethod
							, [DistributorID]=@DistributorID
							, [SubscriptionInterval]=@SubscriptionInterval
							, [Notes]=@Notes
							, [IsUpsell]=@IsUpsell
							, [GiftRegistryForCustomerID]=@GiftRegistryForCustomerID
							, [RecurringInterval]=@RecurringInterval
							, [RecurringIntervalType]=@RecurringIntervalType
							, [ExtensionData]=@ExtensionData
							, [SubscriptionIntervalType]=@SubscriptionIntervalType
							, [CustomerEntersPrice]=@CustomerEntersPrice
							, [IsAKit]=@IsAKit
							, [IsKit2]=@IsKit2
							, [IsAPack]=@IsAPack
							, [IsSystem]=@IsSystem
							, [TaxClassID]=@TaxClassID
							, [TaxRate]=@TaxRate
							, [RecurringSubscriptionID]=@RecurringSubscriptionID 
							 where ShoppingCartRecID=@ShoppingCartRecID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ShoppingCartRecGUID",entity.ShoppingCartRecGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@ProductSKU",entity.ProductSku ?? (object)DBNull.Value)
					, new SqlParameter("@ProductPrice",entity.ProductPrice ?? (object)DBNull.Value)
					, new SqlParameter("@ProductWeight",entity.ProductWeight ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Quantity",entity.Quantity)
					, new SqlParameter("@RequiresCount",entity.RequiresCount)
					, new SqlParameter("@ChosenColor",entity.ChosenColor ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenColorSKUModifier",entity.ChosenColorSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSize",entity.ChosenSize ?? (object)DBNull.Value)
					, new SqlParameter("@ChosenSizeSKUModifier",entity.ChosenSizeSkuModifier ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@ProductDimensions",entity.ProductDimensions ?? (object)DBNull.Value)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@TextOption",entity.TextOption ?? (object)DBNull.Value)
					, new SqlParameter("@NextRecurringShipDate",entity.NextRecurringShipDate ?? (object)DBNull.Value)
					, new SqlParameter("@RecurringIndex",entity.RecurringIndex)
					, new SqlParameter("@OriginalRecurringOrderNumber",entity.OriginalRecurringOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddressID",entity.BillingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddressID",entity.ShippingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorID",entity.DistributorId ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@IsUpsell",entity.IsUpsell)
					, new SqlParameter("@GiftRegistryForCustomerID",entity.GiftRegistryForCustomerId)
					, new SqlParameter("@RecurringInterval",entity.RecurringInterval)
					, new SqlParameter("@RecurringIntervalType",entity.RecurringIntervalType)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@IsAKit",entity.IsAkit ?? (object)DBNull.Value)
					, new SqlParameter("@IsKit2",entity.IsKit2)
					, new SqlParameter("@IsAPack",entity.IsApack ?? (object)DBNull.Value)
					, new SqlParameter("@IsSystem",entity.IsSystem ?? (object)DBNull.Value)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetShoppingCart(entity.ShoppingCartRecId);
		}

        [MOLog(AuditOperations.Update, typeof(ShoppingCart))]
        public virtual bool UpdateShoppingCartQuantity(ShoppingCart entity)
        {
            try
            {
                string sql = @"Update ShoppingCart set  
							 [Quantity]=@Quantity
							 where ShoppingCartRecID=@ShoppingCartRecID";
                SqlParameter[] parameterArray = new SqlParameter[]{
					new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@Quantity",entity.Quantity)	};
                SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sql, parameterArray);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		public virtual bool DeleteShoppingCart(System.Int32 ShoppingCartRecId)
		{

			string sql="delete from ShoppingCart where ShoppingCartRecID=@ShoppingCartRecID";
			SqlParameter parameter=new SqlParameter("@ShoppingCartRecID",ShoppingCartRecId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

        public virtual bool DeleteShoppingCartByCustomerID(System.Int32 CustomerID)
        {

            string sql = "delete from ShoppingCart where CustomerID=@CustomerID";
            SqlParameter parameter = new SqlParameter("@CustomerID", CustomerID);
            var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            return (Convert.ToInt32(identity)) == 1 ? true : false;
        }

		[MOLog(AuditOperations.Delete,typeof(ShoppingCart))]
		public virtual ShoppingCart DeleteShoppingCart(ShoppingCart entity)
		{
			this.DeleteShoppingCart(entity.ShoppingCartRecId);
			return entity;
		}


		public virtual ShoppingCart ShoppingCartFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ShoppingCart entity=new ShoppingCart();
			entity.ShoppingCartRecId = (System.Int32)dr["ShoppingCartRecID"];
			entity.ShoppingCartRecGuid = (System.Guid)dr["ShoppingCartRecGUID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.ProductSku = dr["ProductSKU"].ToString();
			entity.ProductPrice = dr["ProductPrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["ProductPrice"];
			entity.ProductWeight = dr["ProductWeight"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["ProductWeight"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.Quantity = (System.Int32)dr["Quantity"];
			entity.RequiresCount = (System.Int32)dr["RequiresCount"];
			entity.ChosenColor = dr["ChosenColor"].ToString();
			entity.ChosenColorSkuModifier = dr["ChosenColorSKUModifier"].ToString();
			entity.ChosenSize = dr["ChosenSize"].ToString();
			entity.ChosenSizeSkuModifier = dr["ChosenSizeSKUModifier"].ToString();
			entity.IsTaxable = (System.Byte)dr["IsTaxable"];
			entity.IsShipSeparately = (System.Byte)dr["IsShipSeparately"];
			entity.IsDownload = (System.Byte)dr["IsDownload"];
			entity.DownloadLocation = dr["DownloadLocation"].ToString();
			entity.FreeShipping = (System.Byte)dr["FreeShipping"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.ProductDimensions = dr["ProductDimensions"].ToString();
			entity.CartType = (System.Int32)dr["CartType"];
			entity.IsSecureAttachment = (System.Byte)dr["IsSecureAttachment"];
			entity.TextOption = dr["TextOption"].ToString();
			entity.NextRecurringShipDate = dr["NextRecurringShipDate"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["NextRecurringShipDate"];
			entity.RecurringIndex = (System.Int32)dr["RecurringIndex"];
			entity.OriginalRecurringOrderNumber = dr["OriginalRecurringOrderNumber"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["OriginalRecurringOrderNumber"];
			entity.BillingAddressId = dr["BillingAddressID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["BillingAddressID"];
			entity.ShippingAddressId = dr["ShippingAddressID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ShippingAddressID"];
			entity.ShippingMethodId = dr["ShippingMethodID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ShippingMethodID"];
			entity.ShippingMethod = dr["ShippingMethod"].ToString();
			entity.DistributorId = dr["DistributorID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["DistributorID"];
			entity.SubscriptionInterval = dr["SubscriptionInterval"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["SubscriptionInterval"];
			entity.Notes = dr["Notes"].ToString();
			entity.IsUpsell = (System.Byte)dr["IsUpsell"];
			entity.GiftRegistryForCustomerId = (System.Int32)dr["GiftRegistryForCustomerID"];
			entity.RecurringInterval = (System.Int32)dr["RecurringInterval"];
			entity.RecurringIntervalType = (System.Int32)dr["RecurringIntervalType"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.SubscriptionIntervalType = (System.Int32)dr["SubscriptionIntervalType"];
			entity.CustomerEntersPrice = (System.Byte)dr["CustomerEntersPrice"];
			entity.IsAkit = dr["IsAKit"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsAKit"];
			entity.IsKit2 = (System.Byte)dr["IsKit2"];
			entity.IsApack = dr["IsAPack"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsAPack"];
			entity.IsSystem = dr["IsSystem"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["IsSystem"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxRate = (System.Decimal)dr["TaxRate"];
			entity.RecurringSubscriptionId = dr["RecurringSubscriptionID"].ToString();
			return entity;
		}

	}
	
	
}
