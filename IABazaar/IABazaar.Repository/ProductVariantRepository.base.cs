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
		
	public abstract partial class ProductVariantRepositoryBase : Repository 
	{
        
        public ProductVariantRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantGUID",new SearchColumn(){Name="VariantGUID",Title="VariantGUID",SelectClause="VariantGUID",WhereClause="AllRecords.VariantGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDefault",new SearchColumn(){Name="IsDefault",Title="IsDefault",SelectClause="IsDefault",WhereClause="AllRecords.IsDefault",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Colors",new SearchColumn(){Name="Colors",Title="Colors",SelectClause="Colors",WhereClause="AllRecords.Colors",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColorSKUModifiers",new SearchColumn(){Name="ColorSKUModifiers",Title="ColorSKUModifiers",SelectClause="ColorSKUModifiers",WhereClause="AllRecords.ColorSKUModifiers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Sizes",new SearchColumn(){Name="Sizes",Title="Sizes",SelectClause="Sizes",WhereClause="AllRecords.Sizes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SizeSKUModifiers",new SearchColumn(){Name="SizeSKUModifiers",Title="SizeSKUModifiers",SelectClause="SizeSKUModifiers",WhereClause="AllRecords.SizeSKUModifiers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FroogleDescription",new SearchColumn(){Name="FroogleDescription",Title="FroogleDescription",SelectClause="FroogleDescription",WhereClause="AllRecords.FroogleDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SKUSuffix",new SearchColumn(){Name="SKUSuffix",Title="SKUSuffix",SelectClause="SKUSuffix",WhereClause="AllRecords.SKUSuffix",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ManufacturerPartNumber",new SearchColumn(){Name="ManufacturerPartNumber",Title="ManufacturerPartNumber",SelectClause="ManufacturerPartNumber",WhereClause="AllRecords.ManufacturerPartNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Price",new SearchColumn(){Name="Price",Title="Price",SelectClause="Price",WhereClause="AllRecords.Price",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SalePrice",new SearchColumn(){Name="SalePrice",Title="SalePrice",SelectClause="SalePrice",WhereClause="AllRecords.SalePrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Weight",new SearchColumn(){Name="Weight",Title="Weight",SelectClause="Weight",WhereClause="AllRecords.Weight",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MSRP",new SearchColumn(){Name="MSRP",Title="MSRP",SelectClause="MSRP",WhereClause="AllRecords.MSRP",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Cost",new SearchColumn(){Name="Cost",Title="Cost",SelectClause="Cost",WhereClause="AllRecords.Cost",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Points",new SearchColumn(){Name="Points",Title="Points",SelectClause="Points",WhereClause="AllRecords.Points",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Dimensions",new SearchColumn(){Name="Dimensions",Title="Dimensions",SelectClause="Dimensions",WhereClause="AllRecords.Dimensions",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Inventory",new SearchColumn(){Name="Inventory",Title="Inventory",SelectClause="Inventory",WhereClause="AllRecords.Inventory",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsTaxable",new SearchColumn(){Name="IsTaxable",Title="IsTaxable",SelectClause="IsTaxable",WhereClause="AllRecords.IsTaxable",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsShipSeparately",new SearchColumn(){Name="IsShipSeparately",Title="IsShipSeparately",SelectClause="IsShipSeparately",WhereClause="AllRecords.IsShipSeparately",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDownload",new SearchColumn(){Name="IsDownload",Title="IsDownload",SelectClause="IsDownload",WhereClause="AllRecords.IsDownload",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DownloadLocation",new SearchColumn(){Name="DownloadLocation",Title="DownloadLocation",SelectClause="DownloadLocation",WhereClause="AllRecords.DownloadLocation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FreeShipping",new SearchColumn(){Name="FreeShipping",Title="FreeShipping",SelectClause="FreeShipping",WhereClause="AllRecords.FreeShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsSecureAttachment",new SearchColumn(){Name="IsSecureAttachment",Title="IsSecureAttachment",SelectClause="IsSecureAttachment",WhereClause="AllRecords.IsSecureAttachment",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsRecurring",new SearchColumn(){Name="IsRecurring",Title="IsRecurring",SelectClause="IsRecurring",WhereClause="AllRecords.IsRecurring",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringInterval",new SearchColumn(){Name="RecurringInterval",Title="RecurringInterval",SelectClause="RecurringInterval",WhereClause="AllRecords.RecurringInterval",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringIntervalType",new SearchColumn(){Name="RecurringIntervalType",Title="RecurringIntervalType",SelectClause="RecurringIntervalType",WhereClause="AllRecords.RecurringIntervalType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionInterval",new SearchColumn(){Name="SubscriptionInterval",Title="SubscriptionInterval",SelectClause="SubscriptionInterval",WhereClause="AllRecords.SubscriptionInterval",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RewardPoints",new SearchColumn(){Name="RewardPoints",Title="RewardPoints",SelectClause="RewardPoints",WhereClause="AllRecords.RewardPoints",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RestrictedQuantities",new SearchColumn(){Name="RestrictedQuantities",Title="RestrictedQuantities",SelectClause="RestrictedQuantities",WhereClause="AllRecords.RestrictedQuantities",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MinimumQuantity",new SearchColumn(){Name="MinimumQuantity",Title="MinimumQuantity",SelectClause="MinimumQuantity",WhereClause="AllRecords.MinimumQuantity",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData2",new SearchColumn(){Name="ExtensionData2",Title="ExtensionData2",SelectClause="ExtensionData2",WhereClause="AllRecords.ExtensionData2",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData3",new SearchColumn(){Name="ExtensionData3",Title="ExtensionData3",SelectClause="ExtensionData3",WhereClause="AllRecords.ExtensionData3",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData4",new SearchColumn(){Name="ExtensionData4",Title="ExtensionData4",SelectClause="ExtensionData4",WhereClause="AllRecords.ExtensionData4",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData5",new SearchColumn(){Name="ExtensionData5",Title="ExtensionData5",SelectClause="ExtensionData5",WhereClause="AllRecords.ExtensionData5",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ImageFilenameOverride",new SearchColumn(){Name="ImageFilenameOverride",Title="ImageFilenameOverride",SelectClause="ImageFilenameOverride",WhereClause="AllRecords.ImageFilenameOverride",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsImport",new SearchColumn(){Name="IsImport",Title="IsImport",SelectClause="IsImport",WhereClause="AllRecords.IsImport",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionIntervalType",new SearchColumn(){Name="SubscriptionIntervalType",Title="SubscriptionIntervalType",SelectClause="SubscriptionIntervalType",WhereClause="AllRecords.SubscriptionIntervalType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEntersPrice",new SearchColumn(){Name="CustomerEntersPrice",Title="CustomerEntersPrice",SelectClause="CustomerEntersPrice",WhereClause="AllRecords.CustomerEntersPrice",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerEntersPricePrompt",new SearchColumn(){Name="CustomerEntersPricePrompt",Title="CustomerEntersPricePrompt",SelectClause="CustomerEntersPricePrompt",WhereClause="AllRecords.CustomerEntersPricePrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Condition",new SearchColumn(){Name="Condition",Title="Condition",SelectClause="Condition",WhereClause="AllRecords.Condition",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProductVariantSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProductVariantBasicSearchColumns()
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

        public virtual List<SearchColumn> GetProductVariantAdvanceSearchColumns()
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
        
        
        public virtual string GetProductVariantSelectClause()
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
                        	selectQuery =  "ProductVariant."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ProductVariant."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ProductVariant GetProductVariant(System.Int32 VariantId)
		{

			string sql=GetProductVariantSelectClause();
			sql+="from ProductVariant where VariantID=@VariantID ";
			SqlParameter parameter=new SqlParameter("@VariantID",VariantId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProductVariantFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ProductVariant> GetAllProductVariant()
		{

			string sql=GetProductVariantSelectClause();
			sql+="from ProductVariant";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductVariant>(ds, ProductVariantFromDataRow);
		}

		public virtual List<ProductVariant> GetPagedProductVariant(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProductVariantCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [VariantID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([VariantID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [VariantID] ";
            tempsql += " FROM [ProductVariant] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("VariantID"))
					tempsql += " , (AllRecords.[VariantID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[VariantID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProductVariantSelectClause()+@" FROM [ProductVariant], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ProductVariant].[VariantID] = PageIndex.[VariantID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductVariant>(ds, ProductVariantFromDataRow);
			}else{ return null;}
		}

		private int GetProductVariantCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ProductVariant as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ProductVariant as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ProductVariant))]
		public virtual ProductVariant InsertProductVariant(ProductVariant entity)
		{

			ProductVariant other=new ProductVariant();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ProductVariant ( [VariantGUID]
				,[IsDefault]
				,[Name]
				,[Description]
				,[SEKeywords]
				,[SEDescription]
				,[SEAltText]
				,[Colors]
				,[ColorSKUModifiers]
				,[Sizes]
				,[SizeSKUModifiers]
				,[FroogleDescription]
				,[ProductID]
				,[SKUSuffix]
				,[ManufacturerPartNumber]
				,[Price]
				,[SalePrice]
				,[Weight]
				,[MSRP]
				,[Cost]
				,[Points]
				,[Dimensions]
				,[Inventory]
				,[DisplayOrder]
				,[Notes]
				,[IsTaxable]
				,[IsShipSeparately]
				,[IsDownload]
				,[DownloadLocation]
				,[FreeShipping]
				,[Published]
				,[Wholesale]
				,[IsSecureAttachment]
				,[IsRecurring]
				,[RecurringInterval]
				,[RecurringIntervalType]
				,[SubscriptionInterval]
				,[RewardPoints]
				,[SEName]
				,[RestrictedQuantities]
				,[MinimumQuantity]
				,[ExtensionData]
				,[ExtensionData2]
				,[ExtensionData3]
				,[ExtensionData4]
				,[ExtensionData5]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[ImageFilenameOverride]
				,[IsImport]
				,[Deleted]
				,[CreatedOn]
				,[SubscriptionIntervalType]
				,[CustomerEntersPrice]
				,[CustomerEntersPricePrompt]
				,[Condition] )
				Values
				( @VariantGUID
				, @IsDefault
				, @Name
				, @Description
				, @SEKeywords
				, @SEDescription
				, @SEAltText
				, @Colors
				, @ColorSKUModifiers
				, @Sizes
				, @SizeSKUModifiers
				, @FroogleDescription
				, @ProductID
				, @SKUSuffix
				, @ManufacturerPartNumber
				, @Price
				, @SalePrice
				, @Weight
				, @MSRP
				, @Cost
				, @Points
				, @Dimensions
				, @Inventory
				, @DisplayOrder
				, @Notes
				, @IsTaxable
				, @IsShipSeparately
				, @IsDownload
				, @DownloadLocation
				, @FreeShipping
				, @Published
				, @Wholesale
				, @IsSecureAttachment
				, @IsRecurring
				, @RecurringInterval
				, @RecurringIntervalType
				, @SubscriptionInterval
				, @RewardPoints
				, @SEName
				, @RestrictedQuantities
				, @MinimumQuantity
				, @ExtensionData
				, @ExtensionData2
				, @ExtensionData3
				, @ExtensionData4
				, @ExtensionData5
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @ImageFilenameOverride
				, @IsImport
				, @Deleted
				, @CreatedOn
				, @SubscriptionIntervalType
				, @CustomerEntersPrice
				, @CustomerEntersPricePrompt
				, @Condition );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@VariantGUID",entity.VariantGuid)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@Colors",entity.Colors ?? (object)DBNull.Value)
					, new SqlParameter("@ColorSKUModifiers",entity.ColorSkuModifiers ?? (object)DBNull.Value)
					, new SqlParameter("@Sizes",entity.Sizes ?? (object)DBNull.Value)
					, new SqlParameter("@SizeSKUModifiers",entity.SizeSkuModifiers ?? (object)DBNull.Value)
					, new SqlParameter("@FroogleDescription",entity.FroogleDescription ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@SKUSuffix",entity.SkuSuffix ?? (object)DBNull.Value)
					, new SqlParameter("@ManufacturerPartNumber",entity.ManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@Price",entity.Price)
					, new SqlParameter("@SalePrice",entity.SalePrice ?? (object)DBNull.Value)
					, new SqlParameter("@Weight",entity.Weight ?? (object)DBNull.Value)
					, new SqlParameter("@MSRP",entity.Msrp ?? (object)DBNull.Value)
					, new SqlParameter("@Cost",entity.Cost ?? (object)DBNull.Value)
					, new SqlParameter("@Points",entity.Points ?? (object)DBNull.Value)
					, new SqlParameter("@Dimensions",entity.Dimensions ?? (object)DBNull.Value)
					, new SqlParameter("@Inventory",entity.Inventory)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@IsRecurring",entity.IsRecurring)
					, new SqlParameter("@RecurringInterval",entity.RecurringInterval)
					, new SqlParameter("@RecurringIntervalType",entity.RecurringIntervalType)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@RewardPoints",entity.RewardPoints ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@RestrictedQuantities",entity.RestrictedQuantities ?? (object)DBNull.Value)
					, new SqlParameter("@MinimumQuantity",entity.MinimumQuantity ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData2",entity.ExtensionData2 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData3",entity.ExtensionData3 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData4",entity.ExtensionData4 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData5",entity.ExtensionData5 ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@CustomerEntersPricePrompt",entity.CustomerEntersPricePrompt ?? (object)DBNull.Value)
					, new SqlParameter("@Condition",entity.Condition)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProductVariant(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ProductVariant))]
		public virtual ProductVariant UpdateProductVariant(ProductVariant entity)
		{

			if (entity.IsTransient()) return entity;
			ProductVariant other = GetProductVariant(entity.VariantId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ProductVariant set  [VariantGUID]=@VariantGUID
							, [IsDefault]=@IsDefault
							, [Name]=@Name
							, [Description]=@Description
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [SEAltText]=@SEAltText
							, [Colors]=@Colors
							, [ColorSKUModifiers]=@ColorSKUModifiers
							, [Sizes]=@Sizes
							, [SizeSKUModifiers]=@SizeSKUModifiers
							, [FroogleDescription]=@FroogleDescription
							, [ProductID]=@ProductID
							, [SKUSuffix]=@SKUSuffix
							, [ManufacturerPartNumber]=@ManufacturerPartNumber
							, [Price]=@Price
							, [SalePrice]=@SalePrice
							, [Weight]=@Weight
							, [MSRP]=@MSRP
							, [Cost]=@Cost
							, [Points]=@Points
							, [Dimensions]=@Dimensions
							, [Inventory]=@Inventory
							, [DisplayOrder]=@DisplayOrder
							, [Notes]=@Notes
							, [IsTaxable]=@IsTaxable
							, [IsShipSeparately]=@IsShipSeparately
							, [IsDownload]=@IsDownload
							, [DownloadLocation]=@DownloadLocation
							, [FreeShipping]=@FreeShipping
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [IsSecureAttachment]=@IsSecureAttachment
							, [IsRecurring]=@IsRecurring
							, [RecurringInterval]=@RecurringInterval
							, [RecurringIntervalType]=@RecurringIntervalType
							, [SubscriptionInterval]=@SubscriptionInterval
							, [RewardPoints]=@RewardPoints
							, [SEName]=@SEName
							, [RestrictedQuantities]=@RestrictedQuantities
							, [MinimumQuantity]=@MinimumQuantity
							, [ExtensionData]=@ExtensionData
							, [ExtensionData2]=@ExtensionData2
							, [ExtensionData3]=@ExtensionData3
							, [ExtensionData4]=@ExtensionData4
							, [ExtensionData5]=@ExtensionData5
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [ImageFilenameOverride]=@ImageFilenameOverride
							, [IsImport]=@IsImport
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [SubscriptionIntervalType]=@SubscriptionIntervalType
							, [CustomerEntersPrice]=@CustomerEntersPrice
							, [CustomerEntersPricePrompt]=@CustomerEntersPricePrompt
							, [Condition]=@Condition 
							 where VariantID=@VariantID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@VariantGUID",entity.VariantGuid)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@Colors",entity.Colors ?? (object)DBNull.Value)
					, new SqlParameter("@ColorSKUModifiers",entity.ColorSkuModifiers ?? (object)DBNull.Value)
					, new SqlParameter("@Sizes",entity.Sizes ?? (object)DBNull.Value)
					, new SqlParameter("@SizeSKUModifiers",entity.SizeSkuModifiers ?? (object)DBNull.Value)
					, new SqlParameter("@FroogleDescription",entity.FroogleDescription ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@SKUSuffix",entity.SkuSuffix ?? (object)DBNull.Value)
					, new SqlParameter("@ManufacturerPartNumber",entity.ManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@Price",entity.Price)
					, new SqlParameter("@SalePrice",entity.SalePrice ?? (object)DBNull.Value)
					, new SqlParameter("@Weight",entity.Weight ?? (object)DBNull.Value)
					, new SqlParameter("@MSRP",entity.Msrp ?? (object)DBNull.Value)
					, new SqlParameter("@Cost",entity.Cost ?? (object)DBNull.Value)
					, new SqlParameter("@Points",entity.Points ?? (object)DBNull.Value)
					, new SqlParameter("@Dimensions",entity.Dimensions ?? (object)DBNull.Value)
					, new SqlParameter("@Inventory",entity.Inventory)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@IsTaxable",entity.IsTaxable)
					, new SqlParameter("@IsShipSeparately",entity.IsShipSeparately)
					, new SqlParameter("@IsDownload",entity.IsDownload)
					, new SqlParameter("@DownloadLocation",entity.DownloadLocation ?? (object)DBNull.Value)
					, new SqlParameter("@FreeShipping",entity.FreeShipping)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@IsSecureAttachment",entity.IsSecureAttachment)
					, new SqlParameter("@IsRecurring",entity.IsRecurring)
					, new SqlParameter("@RecurringInterval",entity.RecurringInterval)
					, new SqlParameter("@RecurringIntervalType",entity.RecurringIntervalType)
					, new SqlParameter("@SubscriptionInterval",entity.SubscriptionInterval ?? (object)DBNull.Value)
					, new SqlParameter("@RewardPoints",entity.RewardPoints ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@RestrictedQuantities",entity.RestrictedQuantities ?? (object)DBNull.Value)
					, new SqlParameter("@MinimumQuantity",entity.MinimumQuantity ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData2",entity.ExtensionData2 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData3",entity.ExtensionData3 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData4",entity.ExtensionData4 ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData5",entity.ExtensionData5 ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SubscriptionIntervalType",entity.SubscriptionIntervalType)
					, new SqlParameter("@CustomerEntersPrice",entity.CustomerEntersPrice)
					, new SqlParameter("@CustomerEntersPricePrompt",entity.CustomerEntersPricePrompt ?? (object)DBNull.Value)
					, new SqlParameter("@Condition",entity.Condition)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProductVariant(entity.VariantId);
		}

		public virtual bool DeleteProductVariant(System.Int32 VariantId)
		{

			string sql="delete from ProductVariant where VariantID=@VariantID";
			SqlParameter parameter=new SqlParameter("@VariantID",VariantId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ProductVariant))]
		public virtual ProductVariant DeleteProductVariant(ProductVariant entity)
		{
			this.DeleteProductVariant(entity.VariantId);
			return entity;
		}


		public virtual ProductVariant ProductVariantFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ProductVariant entity=new ProductVariant();
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.VariantGuid = (System.Guid)dr["VariantGUID"];
			entity.IsDefault = (System.Int32)dr["IsDefault"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.Colors = dr["Colors"].ToString();
			entity.ColorSkuModifiers = dr["ColorSKUModifiers"].ToString();
			entity.Sizes = dr["Sizes"].ToString();
			entity.SizeSkuModifiers = dr["SizeSKUModifiers"].ToString();
			entity.FroogleDescription = dr["FroogleDescription"].ToString();
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.SkuSuffix = dr["SKUSuffix"].ToString();
			entity.ManufacturerPartNumber = dr["ManufacturerPartNumber"].ToString();
			entity.Price = (System.Decimal)dr["Price"];
			entity.SalePrice = dr["SalePrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["SalePrice"];
			entity.Weight = dr["Weight"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Weight"];
			entity.Msrp = dr["MSRP"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["MSRP"];
			entity.Cost = dr["Cost"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Cost"];
			entity.Points = dr["Points"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["Points"];
			entity.Dimensions = dr["Dimensions"].ToString();
			entity.Inventory = (System.Int32)dr["Inventory"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.Notes = dr["Notes"].ToString();
			entity.IsTaxable = (System.Byte)dr["IsTaxable"];
			entity.IsShipSeparately = (System.Byte)dr["IsShipSeparately"];
			entity.IsDownload = (System.Byte)dr["IsDownload"];
			entity.DownloadLocation = dr["DownloadLocation"].ToString();
			entity.FreeShipping = (System.Byte)dr["FreeShipping"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.IsSecureAttachment = (System.Byte)dr["IsSecureAttachment"];
			entity.IsRecurring = (System.Byte)dr["IsRecurring"];
			entity.RecurringInterval = (System.Int32)dr["RecurringInterval"];
			entity.RecurringIntervalType = (System.Int32)dr["RecurringIntervalType"];
			entity.SubscriptionInterval = dr["SubscriptionInterval"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["SubscriptionInterval"];
			entity.RewardPoints = dr["RewardPoints"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["RewardPoints"];
			entity.SeName = dr["SEName"].ToString();
			entity.RestrictedQuantities = dr["RestrictedQuantities"].ToString();
			entity.MinimumQuantity = dr["MinimumQuantity"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["MinimumQuantity"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ExtensionData2 = dr["ExtensionData2"].ToString();
			entity.ExtensionData3 = dr["ExtensionData3"].ToString();
			entity.ExtensionData4 = dr["ExtensionData4"].ToString();
			entity.ExtensionData5 = dr["ExtensionData5"].ToString();
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.ImageFilenameOverride = dr["ImageFilenameOverride"].ToString();
			entity.IsImport = (System.Byte)dr["IsImport"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.SubscriptionIntervalType = (System.Int32)dr["SubscriptionIntervalType"];
			entity.CustomerEntersPrice = (System.Byte)dr["CustomerEntersPrice"];
			entity.CustomerEntersPricePrompt = dr["CustomerEntersPricePrompt"].ToString();
			entity.Condition = (System.Byte)dr["Condition"];
			return entity;
		}

	}
	
	
}
