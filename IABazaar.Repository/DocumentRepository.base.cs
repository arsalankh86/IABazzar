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
		
	public abstract partial class DocumentRepositoryBase : Repository 
	{
        
        public DocumentRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DocumentID",new SearchColumn(){Name="DocumentID",Title="DocumentID",SelectClause="DocumentID",WhereClause="AllRecords.DocumentID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DocumentGUID",new SearchColumn(){Name="DocumentGUID",Title="DocumentGUID",SelectClause="DocumentGUID",WhereClause="AllRecords.DocumentGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DocumentTypeID",new SearchColumn(){Name="DocumentTypeID",Title="DocumentTypeID",SelectClause="DocumentTypeID",WhereClause="AllRecords.DocumentTypeID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MiscText",new SearchColumn(){Name="MiscText",Title="MiscText",SelectClause="MiscText",WhereClause="AllRecords.MiscText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SpecTitle",new SearchColumn(){Name="SpecTitle",Title="SpecTitle",SelectClause="SpecTitle",WhereClause="AllRecords.SpecTitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsFeatured",new SearchColumn(){Name="IsFeatured",Title="IsFeatured",SelectClause="IsFeatured",WhereClause="AllRecords.IsFeatured",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresRegistration",new SearchColumn(){Name="RequiresRegistration",Title="RequiresRegistration",SelectClause="RequiresRegistration",WhereClause="AllRecords.RequiresRegistration",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Looks",new SearchColumn(){Name="Looks",Title="Looks",SelectClause="Looks",WhereClause="AllRecords.Looks",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedCategories",new SearchColumn(){Name="RelatedCategories",Title="RelatedCategories",SelectClause="RelatedCategories",WhereClause="AllRecords.RelatedCategories",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedSections",new SearchColumn(){Name="RelatedSections",Title="RelatedSections",SelectClause="RelatedSections",WhereClause="AllRecords.RelatedSections",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedManufacturers",new SearchColumn(){Name="RelatedManufacturers",Title="RelatedManufacturers",SelectClause="RelatedManufacturers",WhereClause="AllRecords.RelatedManufacturers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedProducts",new SearchColumn(){Name="RelatedProducts",Title="RelatedProducts",SelectClause="RelatedProducts",WhereClause="AllRecords.RelatedProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ImageFilenameOverride",new SearchColumn(){Name="ImageFilenameOverride",Title="ImageFilenameOverride",SelectClause="ImageFilenameOverride",WhereClause="AllRecords.ImageFilenameOverride",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsImport",new SearchColumn(){Name="IsImport",Title="IsImport",SelectClause="IsImport",WhereClause="AllRecords.IsImport",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageSize",new SearchColumn(){Name="PageSize",Title="PageSize",SelectClause="PageSize",WhereClause="AllRecords.PageSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetDocumentSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetDocumentBasicSearchColumns()
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

        public virtual List<SearchColumn> GetDocumentAdvanceSearchColumns()
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
        
        
        public virtual string GetDocumentSelectClause()
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
                        	selectQuery =  "Document."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Document."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Document GetDocument(System.Int32 DocumentId)
		{

			string sql=GetDocumentSelectClause();
			sql+="from Document where DocumentID=@DocumentID ";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return DocumentFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Document> GetAllDocument()
		{

			string sql=GetDocumentSelectClause();
			sql+="from Document";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Document>(ds, DocumentFromDataRow);
		}

		public virtual List<Document> GetPagedDocument(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetDocumentCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [DocumentID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([DocumentID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [DocumentID] ";
            tempsql += " FROM [Document] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("DocumentID"))
					tempsql += " , (AllRecords.[DocumentID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[DocumentID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetDocumentSelectClause()+@" FROM [Document], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Document].[DocumentID] = PageIndex.[DocumentID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Document>(ds, DocumentFromDataRow);
			}else{ return null;}
		}

		private int GetDocumentCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Document as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Document as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Document))]
		public virtual Document InsertDocument(Document entity)
		{

			Document other=new Document();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Document ( [DocumentGUID]
				,[DocumentTypeID]
				,[Name]
				,[Summary]
				,[Description]
				,[MiscText]
				,[SEName]
				,[SEKeywords]
				,[SEDescription]
				,[SETitle]
				,[SENoScript]
				,[SEAltText]
				,[SpecTitle]
				,[IsFeatured]
				,[RequiresRegistration]
				,[Looks]
				,[Notes]
				,[RelatedCategories]
				,[RelatedSections]
				,[RelatedManufacturers]
				,[RelatedProducts]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[ImageFilenameOverride]
				,[XmlPackage]
				,[IsImport]
				,[Deleted]
				,[CreatedOn]
				,[PageSize] )
				Values
				( @DocumentGUID
				, @DocumentTypeID
				, @Name
				, @Summary
				, @Description
				, @MiscText
				, @SEName
				, @SEKeywords
				, @SEDescription
				, @SETitle
				, @SENoScript
				, @SEAltText
				, @SpecTitle
				, @IsFeatured
				, @RequiresRegistration
				, @Looks
				, @Notes
				, @RelatedCategories
				, @RelatedSections
				, @RelatedManufacturers
				, @RelatedProducts
				, @Published
				, @Wholesale
				, @ExtensionData
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @ImageFilenameOverride
				, @XmlPackage
				, @IsImport
				, @Deleted
				, @CreatedOn
				, @PageSize );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@DocumentGUID",entity.DocumentGuid)
					, new SqlParameter("@DocumentTypeID",entity.DocumentTypeId ?? (object)DBNull.Value)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@MiscText",entity.MiscText ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SpecTitle",entity.SpecTitle ?? (object)DBNull.Value)
					, new SqlParameter("@IsFeatured",entity.IsFeatured)
					, new SqlParameter("@RequiresRegistration",entity.RequiresRegistration)
					, new SqlParameter("@Looks",entity.Looks)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedCategories",entity.RelatedCategories ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedSections",entity.RelatedSections ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedManufacturers",entity.RelatedManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetDocument(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Document))]
		public virtual Document UpdateDocument(Document entity)
		{

			if (entity.IsTransient()) return entity;
			Document other = GetDocument(entity.DocumentId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Document set  [DocumentGUID]=@DocumentGUID
							, [DocumentTypeID]=@DocumentTypeID
							, [Name]=@Name
							, [Summary]=@Summary
							, [Description]=@Description
							, [MiscText]=@MiscText
							, [SEName]=@SEName
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [SETitle]=@SETitle
							, [SENoScript]=@SENoScript
							, [SEAltText]=@SEAltText
							, [SpecTitle]=@SpecTitle
							, [IsFeatured]=@IsFeatured
							, [RequiresRegistration]=@RequiresRegistration
							, [Looks]=@Looks
							, [Notes]=@Notes
							, [RelatedCategories]=@RelatedCategories
							, [RelatedSections]=@RelatedSections
							, [RelatedManufacturers]=@RelatedManufacturers
							, [RelatedProducts]=@RelatedProducts
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [ImageFilenameOverride]=@ImageFilenameOverride
							, [XmlPackage]=@XmlPackage
							, [IsImport]=@IsImport
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [PageSize]=@PageSize 
							 where DocumentID=@DocumentID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@DocumentID",entity.DocumentId)
					, new SqlParameter("@DocumentGUID",entity.DocumentGuid)
					, new SqlParameter("@DocumentTypeID",entity.DocumentTypeId ?? (object)DBNull.Value)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@MiscText",entity.MiscText ?? (object)DBNull.Value)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@SpecTitle",entity.SpecTitle ?? (object)DBNull.Value)
					, new SqlParameter("@IsFeatured",entity.IsFeatured)
					, new SqlParameter("@RequiresRegistration",entity.RequiresRegistration)
					, new SqlParameter("@Looks",entity.Looks)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedCategories",entity.RelatedCategories ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedSections",entity.RelatedSections ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedManufacturers",entity.RelatedManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@RelatedProducts",entity.RelatedProducts ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetDocument(entity.DocumentId);
		}

		public virtual bool DeleteDocument(System.Int32 DocumentId)
		{

			string sql="delete from Document where DocumentID=@DocumentID";
			SqlParameter parameter=new SqlParameter("@DocumentID",DocumentId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Document))]
		public virtual Document DeleteDocument(Document entity)
		{
			this.DeleteDocument(entity.DocumentId);
			return entity;
		}


		public virtual Document DocumentFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Document entity=new Document();
			entity.DocumentId = (System.Int32)dr["DocumentID"];
			entity.DocumentGuid = (System.Guid)dr["DocumentGUID"];
			entity.DocumentTypeId = dr["DocumentTypeID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["DocumentTypeID"];
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.MiscText = dr["MiscText"].ToString();
			entity.SeName = dr["SEName"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.SpecTitle = dr["SpecTitle"].ToString();
			entity.IsFeatured = (System.Byte)dr["IsFeatured"];
			entity.RequiresRegistration = (System.Byte)dr["RequiresRegistration"];
			entity.Looks = (System.Int32)dr["Looks"];
			entity.Notes = dr["Notes"].ToString();
			entity.RelatedCategories = dr["RelatedCategories"].ToString();
			entity.RelatedSections = dr["RelatedSections"].ToString();
			entity.RelatedManufacturers = dr["RelatedManufacturers"].ToString();
			entity.RelatedProducts = dr["RelatedProducts"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.ImageFilenameOverride = dr["ImageFilenameOverride"].ToString();
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.IsImport = (System.Byte)dr["IsImport"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.PageSize = (System.Int32)dr["PageSize"];
			return entity;
		}

	}
	
	
}
