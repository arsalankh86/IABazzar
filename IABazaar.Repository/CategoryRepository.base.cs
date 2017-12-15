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
		
	public abstract partial class CategoryRepositoryBase : Repository 
	{
        
        public CategoryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CategoryID",new SearchColumn(){Name="CategoryID",Title="CategoryID",SelectClause="CategoryID",WhereClause="AllRecords.CategoryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CategoryGUID",new SearchColumn(){Name="CategoryGUID",Title="CategoryGUID",SelectClause="CategoryGUID",WhereClause="AllRecords.CategoryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayPrefix",new SearchColumn(){Name="DisplayPrefix",Title="DisplayPrefix",SelectClause="DisplayPrefix",WhereClause="AllRecords.DisplayPrefix",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ParentCategoryID",new SearchColumn(){Name="ParentCategoryID",Title="ParentCategoryID",SelectClause="ParentCategoryID",WhereClause="AllRecords.ParentCategoryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColWidth",new SearchColumn(){Name="ColWidth",Title="ColWidth",SelectClause="ColWidth",WhereClause="AllRecords.ColWidth",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SortByLooks",new SearchColumn(){Name="SortByLooks",Title="SortByLooks",SelectClause="SortByLooks",WhereClause="AllRecords.SortByLooks",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedDocuments",new SearchColumn(){Name="RelatedDocuments",Title="RelatedDocuments",SelectClause="RelatedDocuments",WhereClause="AllRecords.RelatedDocuments",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AllowSectionFiltering",new SearchColumn(){Name="AllowSectionFiltering",Title="AllowSectionFiltering",SelectClause="AllowSectionFiltering",WhereClause="AllRecords.AllowSectionFiltering",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AllowManufacturerFiltering",new SearchColumn(){Name="AllowManufacturerFiltering",Title="AllowManufacturerFiltering",SelectClause="AllowManufacturerFiltering",WhereClause="AllRecords.AllowManufacturerFiltering",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AllowProductTypeFiltering",new SearchColumn(){Name="AllowProductTypeFiltering",Title="AllowProductTypeFiltering",SelectClause="AllowProductTypeFiltering",WhereClause="AllRecords.AllowProductTypeFiltering",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShowInProductBrowser",new SearchColumn(){Name="ShowInProductBrowser",Title="ShowInProductBrowser",SelectClause="ShowInProductBrowser",WhereClause="AllRecords.ShowInProductBrowser",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ImageFilenameOverride",new SearchColumn(){Name="ImageFilenameOverride",Title="ImageFilenameOverride",SelectClause="ImageFilenameOverride",WhereClause="AllRecords.ImageFilenameOverride",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsImport",new SearchColumn(){Name="IsImport",Title="IsImport",SelectClause="IsImport",WhereClause="AllRecords.IsImport",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageSize",new SearchColumn(){Name="PageSize",Title="PageSize",SelectClause="PageSize",WhereClause="AllRecords.PageSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TemplateName",new SearchColumn(){Name="TemplateName",Title="TemplateName",SelectClause="TemplateName",WhereClause="AllRecords.TemplateName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCategorySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCategoryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCategoryAdvanceSearchColumns()
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
        
        
        public virtual string GetCategorySelectClause()
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
                        	selectQuery =  "Category."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Category."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Category GetCategory(System.Int32 CategoryId)
		{

			string sql=GetCategorySelectClause();
			sql+="from Category where CategoryID=@CategoryID ";
			SqlParameter parameter=new SqlParameter("@CategoryID",CategoryId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CategoryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Category> GetAllCategory()
		{

			string sql=GetCategorySelectClause();
			sql+="from Category";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Category>(ds, CategoryFromDataRow);
		}

        public virtual DataSet GetAllIABazaarCategory()
        {

            string sql = GetCategorySelectClause();
            sql += "from Category";
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, null);
            if (ds == null || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }

		public virtual List<Category> GetPagedCategory(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCategoryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CategoryID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CategoryID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CategoryID] ";
            tempsql += " FROM [Category] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CategoryID"))
					tempsql += " , (AllRecords.[CategoryID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CategoryID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCategorySelectClause()+@" FROM [Category], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Category].[CategoryID] = PageIndex.[CategoryID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Category>(ds, CategoryFromDataRow);
			}else{ return null;}
		}

		private int GetCategoryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Category as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Category as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Category))]
		public virtual Category InsertCategory(Category entity)
		{

			Category other=new Category();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Category ( [CategoryGUID]
				,[Name]
				,[Summary]
				,[Description]
				,[SEKeywords]
				,[SEDescription]
				,[DisplayPrefix]
				,[SETitle]
				,[SENoScript]
				,[SEAltText]
				,[ParentCategoryID]
				,[ColWidth]
				,[SortByLooks]
				,[DisplayOrder]
				,[RelatedDocuments]
				,[XmlPackage]
				,[Published]
				,[Wholesale]
				,[AllowSectionFiltering]
				,[AllowManufacturerFiltering]
				,[AllowProductTypeFiltering]
				,[QuantityDiscountID]
				,[ShowInProductBrowser]
				,[SEName]
				,[ExtensionData]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[ImageFilenameOverride]
				,[IsImport]
				,[Deleted]
				,[CreatedOn]
				,[PageSize]
				,[TaxClassID]
				,[SkinID]
				,[TemplateName] )
				Values
				( @CategoryGUID
				, @Name
				, @Summary
				, @Description
				, @SEKeywords
				, @SEDescription
				, @DisplayPrefix
				, @SETitle
				, @SENoScript
				, @SEAltText
				, @ParentCategoryID
				, @ColWidth
				, @SortByLooks
				, @DisplayOrder
				, @RelatedDocuments
				, @XmlPackage
				, @Published
				, @Wholesale
				, @AllowSectionFiltering
				, @AllowManufacturerFiltering
				, @AllowProductTypeFiltering
				, @QuantityDiscountID
				, @ShowInProductBrowser
				, @SEName
				, @ExtensionData
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @ImageFilenameOverride
				, @IsImport
				, @Deleted
				, @CreatedOn
				, @PageSize
				, @TaxClassID
				, @SkinID
				, @TemplateName );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CategoryID",entity.CategoryId)
					, new SqlParameter("@CategoryGUID",entity.CategoryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayPrefix",entity.DisplayPrefix ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@ParentCategoryID",entity.ParentCategoryId)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@RelatedDocuments",entity.RelatedDocuments ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@AllowSectionFiltering",entity.AllowSectionFiltering)
					, new SqlParameter("@AllowManufacturerFiltering",entity.AllowManufacturerFiltering)
					, new SqlParameter("@AllowProductTypeFiltering",entity.AllowProductTypeFiltering)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@ShowInProductBrowser",entity.ShowInProductBrowser)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCategory(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Category))]
		public virtual Category UpdateCategory(Category entity)
		{

			if (entity.IsTransient()) return entity;
			Category other = GetCategory(entity.CategoryId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Category set  [CategoryGUID]=@CategoryGUID
							, [Name]=@Name
							, [Summary]=@Summary
							, [Description]=@Description
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [DisplayPrefix]=@DisplayPrefix
							, [SETitle]=@SETitle
							, [SENoScript]=@SENoScript
							, [SEAltText]=@SEAltText
							, [ParentCategoryID]=@ParentCategoryID
							, [ColWidth]=@ColWidth
							, [SortByLooks]=@SortByLooks
							, [DisplayOrder]=@DisplayOrder
							, [RelatedDocuments]=@RelatedDocuments
							, [XmlPackage]=@XmlPackage
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [AllowSectionFiltering]=@AllowSectionFiltering
							, [AllowManufacturerFiltering]=@AllowManufacturerFiltering
							, [AllowProductTypeFiltering]=@AllowProductTypeFiltering
							, [QuantityDiscountID]=@QuantityDiscountID
							, [ShowInProductBrowser]=@ShowInProductBrowser
							, [SEName]=@SEName
							, [ExtensionData]=@ExtensionData
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [ImageFilenameOverride]=@ImageFilenameOverride
							, [IsImport]=@IsImport
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [PageSize]=@PageSize
							, [TaxClassID]=@TaxClassID
							, [SkinID]=@SkinID
							, [TemplateName]=@TemplateName 
							 where CategoryID=@CategoryID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CategoryID",entity.CategoryId)
					, new SqlParameter("@CategoryGUID",entity.CategoryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayPrefix",entity.DisplayPrefix ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@ParentCategoryID",entity.ParentCategoryId)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@RelatedDocuments",entity.RelatedDocuments ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@AllowSectionFiltering",entity.AllowSectionFiltering)
					, new SqlParameter("@AllowManufacturerFiltering",entity.AllowManufacturerFiltering)
					, new SqlParameter("@AllowProductTypeFiltering",entity.AllowProductTypeFiltering)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@ShowInProductBrowser",entity.ShowInProductBrowser)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCategory(entity.CategoryId);
		}

		public virtual bool DeleteCategory(System.Int32 CategoryId)
		{

			string sql="delete from Category where CategoryID=@CategoryID";
			SqlParameter parameter=new SqlParameter("@CategoryID",CategoryId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Category))]
		public virtual Category DeleteCategory(Category entity)
		{
			this.DeleteCategory(entity.CategoryId);
			return entity;
		}


		public virtual Category CategoryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Category entity=new Category();
			entity.CategoryId = (System.Int32)dr["CategoryID"];
			entity.CategoryGuid = (System.Guid)dr["CategoryGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.DisplayPrefix = dr["DisplayPrefix"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.ParentCategoryId = (System.Int32)dr["ParentCategoryID"];
			entity.ColWidth = (System.Int32)dr["ColWidth"];
			entity.SortByLooks = (System.Byte)dr["SortByLooks"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.RelatedDocuments = dr["RelatedDocuments"].ToString();
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.AllowSectionFiltering = (System.Byte)dr["AllowSectionFiltering"];
			entity.AllowManufacturerFiltering = (System.Byte)dr["AllowManufacturerFiltering"];
			entity.AllowProductTypeFiltering = (System.Byte)dr["AllowProductTypeFiltering"];
			entity.QuantityDiscountId = dr["QuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["QuantityDiscountID"];
			entity.ShowInProductBrowser = (System.Int32)dr["ShowInProductBrowser"];
			entity.SeName = dr["SEName"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.ImageFilenameOverride = dr["ImageFilenameOverride"].ToString();
			entity.IsImport = (System.Byte)dr["IsImport"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.PageSize = (System.Int32)dr["PageSize"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.TemplateName = dr["TemplateName"].ToString();
			return entity;
		}

	}
	
	
}
