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
		
	public abstract partial class LibraryRepositoryBase : Repository 
	{
        
        public LibraryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LibraryID",new SearchColumn(){Name="LibraryID",Title="LibraryID",SelectClause="LibraryID",WhereClause="AllRecords.LibraryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LibraryGUID",new SearchColumn(){Name="LibraryGUID",Title="LibraryGUID",SelectClause="LibraryGUID",WhereClause="AllRecords.LibraryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayPrefix",new SearchColumn(){Name="DisplayPrefix",Title="DisplayPrefix",SelectClause="DisplayPrefix",WhereClause="AllRecords.DisplayPrefix",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ParentLibraryID",new SearchColumn(){Name="ParentLibraryID",Title="ParentLibraryID",SelectClause="ParentLibraryID",WhereClause="AllRecords.ParentLibraryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColWidth",new SearchColumn(){Name="ColWidth",Title="ColWidth",SelectClause="ColWidth",WhereClause="AllRecords.ColWidth",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SortByLooks",new SearchColumn(){Name="SortByLooks",Title="SortByLooks",SelectClause="SortByLooks",WhereClause="AllRecords.SortByLooks",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedCategories",new SearchColumn(){Name="RelatedCategories",Title="RelatedCategories",SelectClause="RelatedCategories",WhereClause="AllRecords.RelatedCategories",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedSections",new SearchColumn(){Name="RelatedSections",Title="RelatedSections",SelectClause="RelatedSections",WhereClause="AllRecords.RelatedSections",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedManufacturers",new SearchColumn(){Name="RelatedManufacturers",Title="RelatedManufacturers",SelectClause="RelatedManufacturers",WhereClause="AllRecords.RelatedManufacturers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedProducts",new SearchColumn(){Name="RelatedProducts",Title="RelatedProducts",SelectClause="RelatedProducts",WhereClause="AllRecords.RelatedProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ImageFilenameOverride",new SearchColumn(){Name="ImageFilenameOverride",Title="ImageFilenameOverride",SelectClause="ImageFilenameOverride",WhereClause="AllRecords.ImageFilenameOverride",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsImport",new SearchColumn(){Name="IsImport",Title="IsImport",SelectClause="IsImport",WhereClause="AllRecords.IsImport",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageSize",new SearchColumn(){Name="PageSize",Title="PageSize",SelectClause="PageSize",WhereClause="AllRecords.PageSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TemplateName",new SearchColumn(){Name="TemplateName",Title="TemplateName",SelectClause="TemplateName",WhereClause="AllRecords.TemplateName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLibrarySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLibraryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLibraryAdvanceSearchColumns()
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
        
        
        public virtual string GetLibrarySelectClause()
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
                        	selectQuery =  "Library."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Library."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Library GetLibrary(System.Int32 LibraryId)
		{

			string sql=GetLibrarySelectClause();
			sql+="from Library where LibraryID=@LibraryID ";
			SqlParameter parameter=new SqlParameter("@LibraryID",LibraryId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LibraryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Library> GetAllLibrary()
		{

			string sql=GetLibrarySelectClause();
			sql+="from Library";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Library>(ds, LibraryFromDataRow);
		}

		public virtual List<Library> GetPagedLibrary(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLibraryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LibraryID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LibraryID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LibraryID] ";
            tempsql += " FROM [Library] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LibraryID"))
					tempsql += " , (AllRecords.[LibraryID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LibraryID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLibrarySelectClause()+@" FROM [Library], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Library].[LibraryID] = PageIndex.[LibraryID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Library>(ds, LibraryFromDataRow);
			}else{ return null;}
		}

		private int GetLibraryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Library as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Library as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Library))]
		public virtual Library InsertLibrary(Library entity)
		{

			Library other=new Library();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Library ( [LibraryGUID]
				,[Name]
				,[Summary]
				,[Description]
				,[SEName]
				,[SETitle]
				,[SENoScript]
				,[SEAltText]
				,[SEKeywords]
				,[SEDescription]
				,[DisplayPrefix]
				,[XmlPackage]
				,[ParentLibraryID]
				,[ColWidth]
				,[SortByLooks]
				,[DisplayOrder]
				,[RelatedCategories]
				,[RelatedSections]
				,[QuantityDiscountID]
				,[RelatedManufacturers]
				,[RelatedProducts]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[ImageFilenameOverride]
				,[IsImport]
				,[Deleted]
				,[CreatedOn]
				,[PageSize]
				,[SkinID]
				,[TemplateName] )
				Values
				( @LibraryGUID
				, @Name
				, @Summary
				, @Description
				, @SEName
				, @SETitle
				, @SENoScript
				, @SEAltText
				, @SEKeywords
				, @SEDescription
				, @DisplayPrefix
				, @XmlPackage
				, @ParentLibraryID
				, @ColWidth
				, @SortByLooks
				, @DisplayOrder
				, @RelatedCategories
				, @RelatedSections
				, @QuantityDiscountID
				, @RelatedManufacturers
				, @RelatedProducts
				, @Published
				, @Wholesale
				, @ExtensionData
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @ImageFilenameOverride
				, @IsImport
				, @Deleted
				, @CreatedOn
				, @PageSize
				, @SkinID
				, @TemplateName );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LibraryID",entity.LibraryId)
					, new SqlParameter("@LibraryGUID",entity.LibraryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayPrefix",entity.DisplayPrefix ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ParentLibraryID",entity.ParentLibraryId)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@RelatedCategories",entity.RelatedCategories ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedSections",entity.RelatedSections ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedManufacturers",entity.RelatedManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLibrary(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Library))]
		public virtual Library UpdateLibrary(Library entity)
		{

			if (entity.IsTransient()) return entity;
			Library other = GetLibrary(entity.LibraryId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Library set  [LibraryGUID]=@LibraryGUID
							, [Name]=@Name
							, [Summary]=@Summary
							, [Description]=@Description
							, [SEName]=@SEName
							, [SETitle]=@SETitle
							, [SENoScript]=@SENoScript
							, [SEAltText]=@SEAltText
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [DisplayPrefix]=@DisplayPrefix
							, [XmlPackage]=@XmlPackage
							, [ParentLibraryID]=@ParentLibraryID
							, [ColWidth]=@ColWidth
							, [SortByLooks]=@SortByLooks
							, [DisplayOrder]=@DisplayOrder
							, [RelatedCategories]=@RelatedCategories
							, [RelatedSections]=@RelatedSections
							, [QuantityDiscountID]=@QuantityDiscountID
							, [RelatedManufacturers]=@RelatedManufacturers
							, [RelatedProducts]=@RelatedProducts
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [ImageFilenameOverride]=@ImageFilenameOverride
							, [IsImport]=@IsImport
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [PageSize]=@PageSize
							, [SkinID]=@SkinID
							, [TemplateName]=@TemplateName 
							 where LibraryID=@LibraryID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LibraryID",entity.LibraryId)
					, new SqlParameter("@LibraryGUID",entity.LibraryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayPrefix",entity.DisplayPrefix ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ParentLibraryID",entity.ParentLibraryId)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@RelatedCategories",entity.RelatedCategories ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedSections",entity.RelatedSections ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedManufacturers",entity.RelatedManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLibrary(entity.LibraryId);
		}

		public virtual bool DeleteLibrary(System.Int32 LibraryId)
		{

			string sql="delete from Library where LibraryID=@LibraryID";
			SqlParameter parameter=new SqlParameter("@LibraryID",LibraryId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Library))]
		public virtual Library DeleteLibrary(Library entity)
		{
			this.DeleteLibrary(entity.LibraryId);
			return entity;
		}


		public virtual Library LibraryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Library entity=new Library();
			entity.LibraryId = (System.Int32)dr["LibraryID"];
			entity.LibraryGuid = (System.Guid)dr["LibraryGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SeName = dr["SEName"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.DisplayPrefix = dr["DisplayPrefix"].ToString();
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.ParentLibraryId = (System.Int32)dr["ParentLibraryID"];
			entity.ColWidth = (System.Int32)dr["ColWidth"];
			entity.SortByLooks = (System.Byte)dr["SortByLooks"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.RelatedCategories = dr["RelatedCategories"].ToString();
			entity.RelatedSections = dr["RelatedSections"].ToString();
			entity.QuantityDiscountId = dr["QuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["QuantityDiscountID"];
			entity.RelatedManufacturers = dr["RelatedManufacturers"].ToString();
			entity.RelatedProducts = dr["RelatedProducts"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.ImageFilenameOverride = dr["ImageFilenameOverride"].ToString();
			entity.IsImport = (System.Byte)dr["IsImport"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.PageSize = (System.Int32)dr["PageSize"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.TemplateName = dr["TemplateName"].ToString();
			return entity;
		}

	}
	
	
}
