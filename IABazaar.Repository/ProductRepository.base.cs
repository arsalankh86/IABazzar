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
		
	public abstract partial class ProductRepositoryBase : Repository 
	{
        
        public ProductRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductGUID",new SearchColumn(){Name="ProductGUID",Title="ProductGUID",SelectClause="ProductGUID",WhereClause="AllRecords.ProductGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SpecTitle",new SearchColumn(){Name="SpecTitle",Title="SpecTitle",SelectClause="SpecTitle",WhereClause="AllRecords.SpecTitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MiscText",new SearchColumn(){Name="MiscText",Title="MiscText",SelectClause="MiscText",WhereClause="AllRecords.MiscText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SwatchImageMap",new SearchColumn(){Name="SwatchImageMap",Title="SwatchImageMap",SelectClause="SwatchImageMap",WhereClause="AllRecords.SwatchImageMap",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsFeaturedTeaser",new SearchColumn(){Name="IsFeaturedTeaser",Title="IsFeaturedTeaser",SelectClause="IsFeaturedTeaser",WhereClause="AllRecords.IsFeaturedTeaser",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FroogleDescription",new SearchColumn(){Name="FroogleDescription",Title="FroogleDescription",SelectClause="FroogleDescription",WhereClause="AllRecords.FroogleDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SizeOptionPrompt",new SearchColumn(){Name="SizeOptionPrompt",Title="SizeOptionPrompt",SelectClause="SizeOptionPrompt",WhereClause="AllRecords.SizeOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColorOptionPrompt",new SearchColumn(){Name="ColorOptionPrompt",Title="ColorOptionPrompt",SelectClause="ColorOptionPrompt",WhereClause="AllRecords.ColorOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionPrompt",new SearchColumn(){Name="TextOptionPrompt",Title="TextOptionPrompt",SelectClause="TextOptionPrompt",WhereClause="AllRecords.TextOptionPrompt",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductTypeID",new SearchColumn(){Name="ProductTypeID",Title="ProductTypeID",SelectClause="ProductTypeID",WhereClause="AllRecords.ProductTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SKU",new SearchColumn(){Name="SKU",Title="SKU",SelectClause="SKU",WhereClause="AllRecords.SKU",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ManufacturerPartNumber",new SearchColumn(){Name="ManufacturerPartNumber",Title="ManufacturerPartNumber",SelectClause="ManufacturerPartNumber",WhereClause="AllRecords.ManufacturerPartNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SalesPromptID",new SearchColumn(){Name="SalesPromptID",Title="SalesPromptID",SelectClause="SalesPromptID",WhereClause="AllRecords.SalesPromptID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SpecCall",new SearchColumn(){Name="SpecCall",Title="SpecCall",SelectClause="SpecCall",WhereClause="AllRecords.SpecCall",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SpecsInline",new SearchColumn(){Name="SpecsInline",Title="SpecsInline",SelectClause="SpecsInline",WhereClause="AllRecords.SpecsInline",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsFeatured",new SearchColumn(){Name="IsFeatured",Title="IsFeatured",SelectClause="IsFeatured",WhereClause="AllRecords.IsFeatured",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColWidth",new SearchColumn(){Name="ColWidth",Title="ColWidth",SelectClause="ColWidth",WhereClause="AllRecords.ColWidth",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresRegistration",new SearchColumn(){Name="RequiresRegistration",Title="RequiresRegistration",SelectClause="RequiresRegistration",WhereClause="AllRecords.RequiresRegistration",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Looks",new SearchColumn(){Name="Looks",Title="Looks",SelectClause="Looks",WhereClause="AllRecords.Looks",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedProducts",new SearchColumn(){Name="RelatedProducts",Title="RelatedProducts",SelectClause="RelatedProducts",WhereClause="AllRecords.RelatedProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UpsellProducts",new SearchColumn(){Name="UpsellProducts",Title="UpsellProducts",SelectClause="UpsellProducts",WhereClause="AllRecords.UpsellProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UpsellProductDiscountPercentage",new SearchColumn(){Name="UpsellProductDiscountPercentage",Title="UpsellProductDiscountPercentage",SelectClause="UpsellProductDiscountPercentage",WhereClause="AllRecords.UpsellProductDiscountPercentage",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedDocuments",new SearchColumn(){Name="RelatedDocuments",Title="RelatedDocuments",SelectClause="RelatedDocuments",WhereClause="AllRecords.RelatedDocuments",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TrackInventoryBySizeAndColor",new SearchColumn(){Name="TrackInventoryBySizeAndColor",Title="TrackInventoryBySizeAndColor",SelectClause="TrackInventoryBySizeAndColor",WhereClause="AllRecords.TrackInventoryBySizeAndColor",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TrackInventoryBySize",new SearchColumn(){Name="TrackInventoryBySize",Title="TrackInventoryBySize",SelectClause="TrackInventoryBySize",WhereClause="AllRecords.TrackInventoryBySize",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TrackInventoryByColor",new SearchColumn(){Name="TrackInventoryByColor",Title="TrackInventoryByColor",SelectClause="TrackInventoryByColor",WhereClause="AllRecords.TrackInventoryByColor",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAKit",new SearchColumn(){Name="IsAKit",Title="IsAKit",SelectClause="IsAKit",WhereClause="AllRecords.IsAKit",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShowInProductBrowser",new SearchColumn(){Name="ShowInProductBrowser",Title="ShowInProductBrowser",SelectClause="ShowInProductBrowser",WhereClause="AllRecords.ShowInProductBrowser",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAPack",new SearchColumn(){Name="IsAPack",Title="IsAPack",SelectClause="IsAPack",WhereClause="AllRecords.IsAPack",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PackSize",new SearchColumn(){Name="PackSize",Title="PackSize",SelectClause="PackSize",WhereClause="AllRecords.PackSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShowBuyButton",new SearchColumn(){Name="ShowBuyButton",Title="ShowBuyButton",SelectClause="ShowBuyButton",WhereClause="AllRecords.ShowBuyButton",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresProducts",new SearchColumn(){Name="RequiresProducts",Title="RequiresProducts",SelectClause="RequiresProducts",WhereClause="AllRecords.RequiresProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("HidePriceUntilCart",new SearchColumn(){Name="HidePriceUntilCart",Title="HidePriceUntilCart",SelectClause="HidePriceUntilCart",WhereClause="AllRecords.HidePriceUntilCart",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsCalltoOrder",new SearchColumn(){Name="IsCalltoOrder",Title="IsCalltoOrder",SelectClause="IsCalltoOrder",WhereClause="AllRecords.IsCalltoOrder",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExcludeFromPriceFeeds",new SearchColumn(){Name="ExcludeFromPriceFeeds",Title="ExcludeFromPriceFeeds",SelectClause="ExcludeFromPriceFeeds",WhereClause="AllRecords.ExcludeFromPriceFeeds",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresTextOption",new SearchColumn(){Name="RequiresTextOption",Title="RequiresTextOption",SelectClause="RequiresTextOption",WhereClause="AllRecords.RequiresTextOption",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionMaxLength",new SearchColumn(){Name="TextOptionMaxLength",Title="TextOptionMaxLength",SelectClause="TextOptionMaxLength",WhereClause="AllRecords.TextOptionMaxLength",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
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
			this.SearchColumns.Add("IsSystem",new SearchColumn(){Name="IsSystem",Title="IsSystem",SelectClause="IsSystem",WhereClause="AllRecords.IsSystem",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageSize",new SearchColumn(){Name="PageSize",Title="PageSize",SelectClause="PageSize",WhereClause="AllRecords.PageSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("WarehouseLocation",new SearchColumn(){Name="WarehouseLocation",Title="WarehouseLocation",SelectClause="WarehouseLocation",WhereClause="AllRecords.WarehouseLocation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AvailableStartDate",new SearchColumn(){Name="AvailableStartDate",Title="AvailableStartDate",SelectClause="AvailableStartDate",WhereClause="AllRecords.AvailableStartDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AvailableStopDate",new SearchColumn(){Name="AvailableStopDate",Title="AvailableStopDate",SelectClause="AvailableStopDate",WhereClause="AllRecords.AvailableStopDate",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GoogleCheckoutAllowed",new SearchColumn(){Name="GoogleCheckoutAllowed",Title="GoogleCheckoutAllowed",SelectClause="GoogleCheckoutAllowed",WhereClause="AllRecords.GoogleCheckoutAllowed",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TemplateName",new SearchColumn(){Name="TemplateName",Title="TemplateName",SelectClause="TemplateName",WhereClause="AllRecords.TemplateName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StichedPrice",new SearchColumn(){Name="StichedPrice",Title="StichedPrice",SelectClause="StichedPrice",WhereClause="AllRecords.StichedPrice",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Costinrupee",new SearchColumn(){Name="Costinrupee",Title="Costinrupee",SelectClause="Costinrupee",WhereClause="AllRecords.Costinrupee",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Costindollar",new SearchColumn(){Name="Costindollar",Title="Costindollar",SelectClause="Costindollar",WhereClause="AllRecords.Costindollar",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Profitpriceinrupee",new SearchColumn(){Name="Profitpriceinrupee",Title="Profitpriceinrupee",SelectClause="Profitpriceinrupee",WhereClause="AllRecords.Profitpriceinrupee",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Profitpriceindollar",new SearchColumn(){Name="Profitpriceindollar",Title="Profitpriceindollar",SelectClause="Profitpriceindollar",WhereClause="AllRecords.Profitpriceindollar",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("profit",new SearchColumn(){Name="profit",Title="profit",SelectClause="profit",WhereClause="AllRecords.profit",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProductSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProductBasicSearchColumns()
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

        public virtual List<SearchColumn> GetProductAdvanceSearchColumns()
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
        
        
        public virtual string GetProductSelectClause()
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
                        	selectQuery =  "Product."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Product."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Product GetProduct(System.Int32 ProductId)
		{

			string sql=GetProductSelectClause();
			sql+="from Product where ProductID=@ProductID ";
			SqlParameter parameter=new SqlParameter("@ProductID",ProductId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProductFromDataRow(ds.Tables[0].Rows[0]);
		}

        public virtual DataSet GetProductDataSet(System.Int32 ProductId)
        {

            string sql = "select * from Product where ProductID=@ProductID and Deleted = 0";
            SqlParameter parameter = new SqlParameter("@ProductID", ProductId);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
            return ds;
        }


		public virtual List<Product> GetAllProduct()
		{

			string sql=GetProductSelectClause();
			sql+="from Product";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Product>(ds, ProductFromDataRow);
		}

        public virtual DataSet GetAllIABazaarProduct()
        {

            string sql = GetProductSelectClause();
            sql += "from Product";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }


		public virtual List<Product> GetPagedProduct(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProductCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ProductID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ProductID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ProductID] ";
            tempsql += " FROM [Product] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ProductID"))
					tempsql += " , (AllRecords.[ProductID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ProductID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProductSelectClause()+@" FROM [Product], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Product].[ProductID] = PageIndex.[ProductID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Product>(ds, ProductFromDataRow);
			}else{ return null;}
		}

		private int GetProductCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Product as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Product as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Product))]
		public virtual Product InsertProduct(Product entity)
		{

			Product other=new Product();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Product ( [ProductGUID]
				,[Name]
				,[Summary]
				,[Description]
				,[SEKeywords]
				,[SEDescription]
				,[SpecTitle]
				,[MiscText]
				,[SwatchImageMap]
				,[IsFeaturedTeaser]
				,[FroogleDescription]
				,[SETitle]
				,[SENoScript]
				,[SEAltText]
				,[SizeOptionPrompt]
				,[ColorOptionPrompt]
				,[TextOptionPrompt]
				,[ProductTypeID]
				,[TaxClassID]
				,[SKU]
				,[ManufacturerPartNumber]
				,[SalesPromptID]
				,[SpecCall]
				,[SpecsInline]
				,[IsFeatured]
				,[XmlPackage]
				,[ColWidth]
				,[Published]
				,[Wholesale]
				,[RequiresRegistration]
				,[Looks]
				,[Notes]
				,[QuantityDiscountID]
				,[RelatedProducts]
				,[UpsellProducts]
				,[UpsellProductDiscountPercentage]
				,[RelatedDocuments]
				,[TrackInventoryBySizeAndColor]
				,[TrackInventoryBySize]
				,[TrackInventoryByColor]
				,[IsAKit]
				,[ShowInProductBrowser]
				,[IsAPack]
				,[PackSize]
				,[ShowBuyButton]
				,[RequiresProducts]
				,[HidePriceUntilCart]
				,[IsCalltoOrder]
				,[ExcludeFromPriceFeeds]
				,[RequiresTextOption]
				,[TextOptionMaxLength]
				,[SEName]
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
				,[IsSystem]
				,[Deleted]
				,[CreatedOn]
				,[PageSize]
				,[WarehouseLocation]
				,[AvailableStartDate]
				,[AvailableStopDate]
				,[GoogleCheckoutAllowed]
				,[SkinID]
				,[TemplateName]
				,[StichedPrice]
				,[Costinrupee]
				,[Costindollar]
				,[Profitpriceinrupee]
				,[Profitpriceindollar]
				,[profit] )
				Values
				( @ProductGUID
				, @Name
				, @Summary
				, @Description
				, @SEKeywords
				, @SEDescription
				, @SpecTitle
				, @MiscText
				, @SwatchImageMap
				, @IsFeaturedTeaser
				, @FroogleDescription
				, @SETitle
				, @SENoScript
				, @SEAltText
				, @SizeOptionPrompt
				, @ColorOptionPrompt
				, @TextOptionPrompt
				, @ProductTypeID
				, @TaxClassID
				, @SKU
				, @ManufacturerPartNumber
				, @SalesPromptID
				, @SpecCall
				, @SpecsInline
				, @IsFeatured
				, @XmlPackage
				, @ColWidth
				, @Published
				, @Wholesale
				, @RequiresRegistration
				, @Looks
				, @Notes
				, @QuantityDiscountID
				, @RelatedProducts
				, @UpsellProducts
				, @UpsellProductDiscountPercentage
				, @RelatedDocuments
				, @TrackInventoryBySizeAndColor
				, @TrackInventoryBySize
				, @TrackInventoryByColor
				, @IsAKit
				, @ShowInProductBrowser
				, @IsAPack
				, @PackSize
				, @ShowBuyButton
				, @RequiresProducts
				, @HidePriceUntilCart
				, @IsCalltoOrder
				, @ExcludeFromPriceFeeds
				, @RequiresTextOption
				, @TextOptionMaxLength
				, @SEName
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
				, @IsSystem
				, @Deleted
				, @CreatedOn
				, @PageSize
				, @WarehouseLocation
				, @AvailableStartDate
				, @AvailableStopDate
				, @GoogleCheckoutAllowed
				, @SkinID
				, @TemplateName
				, @StichedPrice
				, @Costinrupee
				, @Costindollar
				, @Profitpriceinrupee
				, @Profitpriceindollar
				, @profit );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@ProductGUID",entity.ProductGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SpecTitle",entity.SpecTitle ?? (object)DBNull.Value)
					, new SqlParameter("@MiscText",entity.MiscText ?? (object)DBNull.Value)
					, new SqlParameter("@SwatchImageMap",entity.SwatchImageMap ?? (object)DBNull.Value)
					, new SqlParameter("@IsFeaturedTeaser",entity.IsFeaturedTeaser ?? (object)DBNull.Value)
					, new SqlParameter("@FroogleDescription",entity.FroogleDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SizeOptionPrompt",entity.SizeOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ColorOptionPrompt",entity.ColorOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionPrompt",entity.TextOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ProductTypeID",entity.ProductTypeId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SKU",entity.Sku ?? (object)DBNull.Value)
					, new SqlParameter("@ManufacturerPartNumber",entity.ManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@SalesPromptID",entity.SalesPromptId)
					, new SqlParameter("@SpecCall",entity.SpecCall ?? (object)DBNull.Value)
					, new SqlParameter("@SpecsInline",entity.SpecsInline)
					, new SqlParameter("@IsFeatured",entity.IsFeatured)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@RequiresRegistration",entity.RequiresRegistration)
					, new SqlParameter("@Looks",entity.Looks)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@UpsellProducts",entity.UpsellProducts ?? (object)DBNull.Value)
					, new SqlParameter("@UpsellProductDiscountPercentage",entity.UpsellProductDiscountPercentage)
					, new SqlParameter("@RelatedDocuments",entity.RelatedDocuments ?? (object)DBNull.Value)
					, new SqlParameter("@TrackInventoryBySizeAndColor",entity.TrackInventoryBySizeAndColor)
					, new SqlParameter("@TrackInventoryBySize",entity.TrackInventoryBySize)
					, new SqlParameter("@TrackInventoryByColor",entity.TrackInventoryByColor)
					, new SqlParameter("@IsAKit",entity.IsAkit)
					, new SqlParameter("@ShowInProductBrowser",entity.ShowInProductBrowser)
					, new SqlParameter("@IsAPack",entity.IsApack)
					, new SqlParameter("@PackSize",entity.PackSize)
					, new SqlParameter("@ShowBuyButton",entity.ShowBuyButton)
					, new SqlParameter("@RequiresProducts",entity.RequiresProducts ?? (object)DBNull.Value)
					, new SqlParameter("@HidePriceUntilCart",entity.HidePriceUntilCart)
					, new SqlParameter("@IsCalltoOrder",entity.IsCalltoOrder)
					, new SqlParameter("@ExcludeFromPriceFeeds",entity.ExcludeFromPriceFeeds)
					, new SqlParameter("@RequiresTextOption",entity.RequiresTextOption)
					, new SqlParameter("@TextOptionMaxLength",entity.TextOptionMaxLength ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
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
					, new SqlParameter("@IsSystem",entity.IsSystem)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@WarehouseLocation",entity.WarehouseLocation ?? (object)DBNull.Value)
					, new SqlParameter("@AvailableStartDate",entity.AvailableStartDate)
					, new SqlParameter("@AvailableStopDate",entity.AvailableStopDate ?? (object)DBNull.Value)
					, new SqlParameter("@GoogleCheckoutAllowed",entity.GoogleCheckoutAllowed)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)
					, new SqlParameter("@StichedPrice",entity.StichedPrice ?? (object)DBNull.Value)
					, new SqlParameter("@Costinrupee",entity.Costinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Costindollar",entity.Costindollar ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceinrupee",entity.Profitpriceinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceindollar",entity.Profitpriceindollar ?? (object)DBNull.Value)
					, new SqlParameter("@profit",entity.Profit ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProduct(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Product))]
		public virtual Product UpdateProduct(Product entity)
		{

			if (entity.IsTransient()) return entity;
			Product other = GetProduct(entity.ProductId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Product set  [ProductGUID]=@ProductGUID
							, [Name]=@Name
							, [Summary]=@Summary
							, [Description]=@Description
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [SpecTitle]=@SpecTitle
							, [MiscText]=@MiscText
							, [SwatchImageMap]=@SwatchImageMap
							, [IsFeaturedTeaser]=@IsFeaturedTeaser
							, [FroogleDescription]=@FroogleDescription
							, [SETitle]=@SETitle
							, [SENoScript]=@SENoScript
							, [SEAltText]=@SEAltText
							, [SizeOptionPrompt]=@SizeOptionPrompt
							, [ColorOptionPrompt]=@ColorOptionPrompt
							, [TextOptionPrompt]=@TextOptionPrompt
							, [ProductTypeID]=@ProductTypeID
							, [TaxClassID]=@TaxClassID
							, [SKU]=@SKU
							, [ManufacturerPartNumber]=@ManufacturerPartNumber
							, [SalesPromptID]=@SalesPromptID
							, [SpecCall]=@SpecCall
							, [SpecsInline]=@SpecsInline
							, [IsFeatured]=@IsFeatured
							, [XmlPackage]=@XmlPackage
							, [ColWidth]=@ColWidth
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [RequiresRegistration]=@RequiresRegistration
							, [Looks]=@Looks
							, [Notes]=@Notes
							, [QuantityDiscountID]=@QuantityDiscountID
							, [RelatedProducts]=@RelatedProducts
							, [UpsellProducts]=@UpsellProducts
							, [UpsellProductDiscountPercentage]=@UpsellProductDiscountPercentage
							, [RelatedDocuments]=@RelatedDocuments
							, [TrackInventoryBySizeAndColor]=@TrackInventoryBySizeAndColor
							, [TrackInventoryBySize]=@TrackInventoryBySize
							, [TrackInventoryByColor]=@TrackInventoryByColor
							, [IsAKit]=@IsAKit
							, [ShowInProductBrowser]=@ShowInProductBrowser
							, [IsAPack]=@IsAPack
							, [PackSize]=@PackSize
							, [ShowBuyButton]=@ShowBuyButton
							, [RequiresProducts]=@RequiresProducts
							, [HidePriceUntilCart]=@HidePriceUntilCart
							, [IsCalltoOrder]=@IsCalltoOrder
							, [ExcludeFromPriceFeeds]=@ExcludeFromPriceFeeds
							, [RequiresTextOption]=@RequiresTextOption
							, [TextOptionMaxLength]=@TextOptionMaxLength
							, [SEName]=@SEName
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
							, [IsSystem]=@IsSystem
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [PageSize]=@PageSize
							, [WarehouseLocation]=@WarehouseLocation
							, [AvailableStartDate]=@AvailableStartDate
							, [AvailableStopDate]=@AvailableStopDate
							, [GoogleCheckoutAllowed]=@GoogleCheckoutAllowed
							, [SkinID]=@SkinID
							, [TemplateName]=@TemplateName
							, [StichedPrice]=@StichedPrice
							, [Costinrupee]=@Costinrupee
							, [Costindollar]=@Costindollar
							, [Profitpriceinrupee]=@Profitpriceinrupee
							, [Profitpriceindollar]=@Profitpriceindollar
							, [profit]=@profit 
							 where ProductID=@ProductID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@ProductGUID",entity.ProductGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SpecTitle",entity.SpecTitle ?? (object)DBNull.Value)
					, new SqlParameter("@MiscText",entity.MiscText ?? (object)DBNull.Value)
					, new SqlParameter("@SwatchImageMap",entity.SwatchImageMap ?? (object)DBNull.Value)
					, new SqlParameter("@IsFeaturedTeaser",entity.IsFeaturedTeaser ?? (object)DBNull.Value)
					, new SqlParameter("@FroogleDescription",entity.FroogleDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SizeOptionPrompt",entity.SizeOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ColorOptionPrompt",entity.ColorOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionPrompt",entity.TextOptionPrompt ?? (object)DBNull.Value)
					, new SqlParameter("@ProductTypeID",entity.ProductTypeId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SKU",entity.Sku ?? (object)DBNull.Value)
					, new SqlParameter("@ManufacturerPartNumber",entity.ManufacturerPartNumber ?? (object)DBNull.Value)
					, new SqlParameter("@SalesPromptID",entity.SalesPromptId)
					, new SqlParameter("@SpecCall",entity.SpecCall ?? (object)DBNull.Value)
					, new SqlParameter("@SpecsInline",entity.SpecsInline)
					, new SqlParameter("@IsFeatured",entity.IsFeatured)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@RequiresRegistration",entity.RequiresRegistration)
					, new SqlParameter("@Looks",entity.Looks)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@UpsellProducts",entity.UpsellProducts ?? (object)DBNull.Value)
					, new SqlParameter("@UpsellProductDiscountPercentage",entity.UpsellProductDiscountPercentage)
					, new SqlParameter("@RelatedDocuments",entity.RelatedDocuments ?? (object)DBNull.Value)
					, new SqlParameter("@TrackInventoryBySizeAndColor",entity.TrackInventoryBySizeAndColor)
					, new SqlParameter("@TrackInventoryBySize",entity.TrackInventoryBySize)
					, new SqlParameter("@TrackInventoryByColor",entity.TrackInventoryByColor)
					, new SqlParameter("@IsAKit",entity.IsAkit)
					, new SqlParameter("@ShowInProductBrowser",entity.ShowInProductBrowser)
					, new SqlParameter("@IsAPack",entity.IsApack)
					, new SqlParameter("@PackSize",entity.PackSize)
					, new SqlParameter("@ShowBuyButton",entity.ShowBuyButton)
					, new SqlParameter("@RequiresProducts",entity.RequiresProducts ?? (object)DBNull.Value)
					, new SqlParameter("@HidePriceUntilCart",entity.HidePriceUntilCart)
					, new SqlParameter("@IsCalltoOrder",entity.IsCalltoOrder)
					, new SqlParameter("@ExcludeFromPriceFeeds",entity.ExcludeFromPriceFeeds)
					, new SqlParameter("@RequiresTextOption",entity.RequiresTextOption)
					, new SqlParameter("@TextOptionMaxLength",entity.TextOptionMaxLength ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
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
					, new SqlParameter("@IsSystem",entity.IsSystem)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@WarehouseLocation",entity.WarehouseLocation ?? (object)DBNull.Value)
					, new SqlParameter("@AvailableStartDate",entity.AvailableStartDate)
					, new SqlParameter("@AvailableStopDate",entity.AvailableStopDate ?? (object)DBNull.Value)
					, new SqlParameter("@GoogleCheckoutAllowed",entity.GoogleCheckoutAllowed)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)
					, new SqlParameter("@StichedPrice",entity.StichedPrice ?? (object)DBNull.Value)
					, new SqlParameter("@Costinrupee",entity.Costinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Costindollar",entity.Costindollar ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceinrupee",entity.Profitpriceinrupee ?? (object)DBNull.Value)
					, new SqlParameter("@Profitpriceindollar",entity.Profitpriceindollar ?? (object)DBNull.Value)
					, new SqlParameter("@profit",entity.Profit ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProduct(entity.ProductId);
		}

		public virtual bool DeleteProduct(System.Int32 ProductId)
		{

			string sql="delete from Product where ProductID=@ProductID";
			SqlParameter parameter=new SqlParameter("@ProductID",ProductId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Product))]
		public virtual Product DeleteProduct(Product entity)
		{
			this.DeleteProduct(entity.ProductId);
			return entity;
		}


		public virtual Product ProductFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Product entity=new Product();
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.ProductGuid = (System.Guid)dr["ProductGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.SpecTitle = dr["SpecTitle"].ToString();
			entity.MiscText = dr["MiscText"].ToString();
			entity.SwatchImageMap = dr["SwatchImageMap"].ToString();
			entity.IsFeaturedTeaser = dr["IsFeaturedTeaser"].ToString();
			entity.FroogleDescription = dr["FroogleDescription"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.SizeOptionPrompt = dr["SizeOptionPrompt"].ToString();
			entity.ColorOptionPrompt = dr["ColorOptionPrompt"].ToString();
			entity.TextOptionPrompt = dr["TextOptionPrompt"].ToString();
			entity.ProductTypeId = (System.Int32)dr["ProductTypeID"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.Sku = dr["SKU"].ToString();
			entity.ManufacturerPartNumber = dr["ManufacturerPartNumber"].ToString();
			entity.SalesPromptId = (System.Int32)dr["SalesPromptID"];
			entity.SpecCall = dr["SpecCall"].ToString();
			entity.SpecsInline = (System.Byte)dr["SpecsInline"];
			entity.IsFeatured = (System.Byte)dr["IsFeatured"];
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.ColWidth = (System.Int32)dr["ColWidth"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.RequiresRegistration = (System.Byte)dr["RequiresRegistration"];
			entity.Looks = (System.Int32)dr["Looks"];
			entity.Notes = dr["Notes"].ToString();
			entity.QuantityDiscountId = dr["QuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["QuantityDiscountID"];
			entity.RelatedProducts = dr["RelatedProducts"].ToString();
			entity.UpsellProducts = dr["UpsellProducts"].ToString();
			entity.UpsellProductDiscountPercentage = (System.Decimal)dr["UpsellProductDiscountPercentage"];
			entity.RelatedDocuments = dr["RelatedDocuments"].ToString();
			entity.TrackInventoryBySizeAndColor = (System.Byte)dr["TrackInventoryBySizeAndColor"];
			entity.TrackInventoryBySize = (System.Byte)dr["TrackInventoryBySize"];
			entity.TrackInventoryByColor = (System.Byte)dr["TrackInventoryByColor"];
			entity.IsAkit = (System.Byte)dr["IsAKit"];
			entity.ShowInProductBrowser = (System.Int32)dr["ShowInProductBrowser"];
			entity.IsApack = (System.Int32)dr["IsAPack"];
			entity.PackSize = (System.Int32)dr["PackSize"];
			entity.ShowBuyButton = (System.Int32)dr["ShowBuyButton"];
			entity.RequiresProducts = dr["RequiresProducts"].ToString();
			entity.HidePriceUntilCart = (System.Byte)dr["HidePriceUntilCart"];
			entity.IsCalltoOrder = (System.Byte)dr["IsCalltoOrder"];
			entity.ExcludeFromPriceFeeds = (System.Byte)dr["ExcludeFromPriceFeeds"];
			entity.RequiresTextOption = (System.Byte)dr["RequiresTextOption"];
			entity.TextOptionMaxLength = dr["TextOptionMaxLength"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["TextOptionMaxLength"];
			entity.SeName = dr["SEName"].ToString();
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
			entity.IsSystem = (System.Byte)dr["IsSystem"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.PageSize = (System.Int32)dr["PageSize"];
			entity.WarehouseLocation = dr["WarehouseLocation"].ToString();
			entity.AvailableStartDate = (System.DateTime)dr["AvailableStartDate"];
			entity.AvailableStopDate = dr["AvailableStopDate"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["AvailableStopDate"];
			entity.GoogleCheckoutAllowed = (System.Byte)dr["GoogleCheckoutAllowed"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.TemplateName = dr["TemplateName"].ToString();
			entity.StichedPrice = dr["StichedPrice"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["StichedPrice"];
			entity.Costinrupee = dr["Costinrupee"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Costinrupee"];
			entity.Costindollar = dr["Costindollar"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Costindollar"];
			entity.Profitpriceinrupee = dr["Profitpriceinrupee"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Profitpriceinrupee"];
			entity.Profitpriceindollar = dr["Profitpriceindollar"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["Profitpriceindollar"];
			entity.Profit = dr["profit"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["profit"];
			return entity;
		}

	}
	
	
}
