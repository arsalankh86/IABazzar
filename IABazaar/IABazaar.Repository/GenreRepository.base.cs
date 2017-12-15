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
		
	public abstract partial class GenreRepositoryBase : Repository 
	{
        
        public GenreRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("GenreID",new SearchColumn(){Name="GenreID",Title="GenreID",SelectClause="GenreID",WhereClause="AllRecords.GenreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GenreGUID",new SearchColumn(){Name="GenreGUID",Title="GenreGUID",SelectClause="GenreGUID",WhereClause="AllRecords.GenreGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEKeywords",new SearchColumn(){Name="SEKeywords",Title="SEKeywords",SelectClause="SEKeywords",WhereClause="AllRecords.SEKeywords",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEDescription",new SearchColumn(){Name="SEDescription",Title="SEDescription",SelectClause="SEDescription",WhereClause="AllRecords.SEDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SETitle",new SearchColumn(){Name="SETitle",Title="SETitle",SelectClause="SETitle",WhereClause="AllRecords.SETitle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SENoScript",new SearchColumn(){Name="SENoScript",Title="SENoScript",SelectClause="SENoScript",WhereClause="AllRecords.SENoScript",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEAltText",new SearchColumn(){Name="SEAltText",Title="SEAltText",SelectClause="SEAltText",WhereClause="AllRecords.SEAltText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Address1",new SearchColumn(){Name="Address1",Title="Address1",SelectClause="Address1",WhereClause="AllRecords.Address1",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Address2",new SearchColumn(){Name="Address2",Title="Address2",SelectClause="Address2",WhereClause="AllRecords.Address2",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Suite",new SearchColumn(){Name="Suite",Title="Suite",SelectClause="Suite",WhereClause="AllRecords.Suite",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("City",new SearchColumn(){Name="City",Title="City",SelectClause="City",WhereClause="AllRecords.City",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("State",new SearchColumn(){Name="State",Title="State",SelectClause="State",WhereClause="AllRecords.State",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ZipCode",new SearchColumn(){Name="ZipCode",Title="ZipCode",SelectClause="ZipCode",WhereClause="AllRecords.ZipCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Country",new SearchColumn(){Name="Country",Title="Country",SelectClause="Country",WhereClause="AllRecords.Country",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Phone",new SearchColumn(){Name="Phone",Title="Phone",SelectClause="Phone",WhereClause="AllRecords.Phone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FAX",new SearchColumn(){Name="FAX",Title="FAX",SelectClause="FAX",WhereClause="AllRecords.FAX",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("URL",new SearchColumn(){Name="URL",Title="URL",SelectClause="URL",WhereClause="AllRecords.URL",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SortByLooks",new SearchColumn(){Name="SortByLooks",Title="SortByLooks",SelectClause="SortByLooks",WhereClause="AllRecords.SortByLooks",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ColWidth",new SearchColumn(){Name="ColWidth",Title="ColWidth",SelectClause="ColWidth",WhereClause="AllRecords.ColWidth",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ContentsBGColor",new SearchColumn(){Name="ContentsBGColor",Title="ContentsBGColor",SelectClause="ContentsBGColor",WhereClause="AllRecords.ContentsBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageBGColor",new SearchColumn(){Name="PageBGColor",Title="PageBGColor",SelectClause="PageBGColor",WhereClause="AllRecords.PageBGColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GraphicsColor",new SearchColumn(){Name="GraphicsColor",Title="GraphicsColor",SelectClause="GraphicsColor",WhereClause="AllRecords.GraphicsColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NotificationXmlPackage",new SearchColumn(){Name="NotificationXmlPackage",Title="NotificationXmlPackage",SelectClause="NotificationXmlPackage",WhereClause="AllRecords.NotificationXmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ImageFilenameOverride",new SearchColumn(){Name="ImageFilenameOverride",Title="ImageFilenameOverride",SelectClause="ImageFilenameOverride",WhereClause="AllRecords.ImageFilenameOverride",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ParentGenreID",new SearchColumn(){Name="ParentGenreID",Title="ParentGenreID",SelectClause="ParentGenreID",WhereClause="AllRecords.ParentGenreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsImport",new SearchColumn(){Name="IsImport",Title="IsImport",SelectClause="IsImport",WhereClause="AllRecords.IsImport",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PageSize",new SearchColumn(){Name="PageSize",Title="PageSize",SelectClause="PageSize",WhereClause="AllRecords.PageSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TemplateName",new SearchColumn(){Name="TemplateName",Title="TemplateName",SelectClause="TemplateName",WhereClause="AllRecords.TemplateName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetGenreSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetGenreBasicSearchColumns()
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

        public virtual List<SearchColumn> GetGenreAdvanceSearchColumns()
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
        
        
        public virtual string GetGenreSelectClause()
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
                        	selectQuery =  "Genre."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Genre."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Genre GetGenre(System.Int32 GenreId)
		{

			string sql=GetGenreSelectClause();
			sql+="from Genre where GenreID=@GenreID ";
			SqlParameter parameter=new SqlParameter("@GenreID",GenreId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return GenreFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Genre> GetAllGenre()
		{

			string sql=GetGenreSelectClause();
			sql+="from Genre";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Genre>(ds, GenreFromDataRow);
		}

		public virtual List<Genre> GetPagedGenre(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetGenreCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [GenreID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([GenreID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [GenreID] ";
            tempsql += " FROM [Genre] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("GenreID"))
					tempsql += " , (AllRecords.[GenreID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[GenreID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetGenreSelectClause()+@" FROM [Genre], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Genre].[GenreID] = PageIndex.[GenreID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Genre>(ds, GenreFromDataRow);
			}else{ return null;}
		}

		private int GetGenreCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Genre as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Genre as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Genre))]
		public virtual Genre InsertGenre(Genre entity)
		{

			Genre other=new Genre();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Genre ( [GenreGUID]
				,[Name]
				,[SEName]
				,[SEKeywords]
				,[SEDescription]
				,[SETitle]
				,[SENoScript]
				,[SEAltText]
				,[Address1]
				,[Address2]
				,[Suite]
				,[City]
				,[State]
				,[ZipCode]
				,[Country]
				,[Phone]
				,[FAX]
				,[URL]
				,[Email]
				,[Summary]
				,[Description]
				,[Notes]
				,[QuantityDiscountID]
				,[SortByLooks]
				,[XmlPackage]
				,[ColWidth]
				,[DisplayOrder]
				,[ExtensionData]
				,[ContentsBGColor]
				,[PageBGColor]
				,[GraphicsColor]
				,[NotificationXmlPackage]
				,[ImageFilenameOverride]
				,[ParentGenreID]
				,[Published]
				,[Wholesale]
				,[IsImport]
				,[Deleted]
				,[CreatedOn]
				,[PageSize]
				,[TaxClassID]
				,[SkinID]
				,[TemplateName] )
				Values
				( @GenreGUID
				, @Name
				, @SEName
				, @SEKeywords
				, @SEDescription
				, @SETitle
				, @SENoScript
				, @SEAltText
				, @Address1
				, @Address2
				, @Suite
				, @City
				, @State
				, @ZipCode
				, @Country
				, @Phone
				, @FAX
				, @URL
				, @Email
				, @Summary
				, @Description
				, @Notes
				, @QuantityDiscountID
				, @SortByLooks
				, @XmlPackage
				, @ColWidth
				, @DisplayOrder
				, @ExtensionData
				, @ContentsBGColor
				, @PageBGColor
				, @GraphicsColor
				, @NotificationXmlPackage
				, @ImageFilenameOverride
				, @ParentGenreID
				, @Published
				, @Wholesale
				, @IsImport
				, @Deleted
				, @CreatedOn
				, @PageSize
				, @TaxClassID
				, @SkinID
				, @TemplateName );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GenreID",entity.GenreId)
					, new SqlParameter("@GenreGUID",entity.GenreGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@Address1",entity.Address1 ?? (object)DBNull.Value)
					, new SqlParameter("@Address2",entity.Address2 ?? (object)DBNull.Value)
					, new SqlParameter("@Suite",entity.Suite ?? (object)DBNull.Value)
					, new SqlParameter("@City",entity.City ?? (object)DBNull.Value)
					, new SqlParameter("@State",entity.State ?? (object)DBNull.Value)
					, new SqlParameter("@ZipCode",entity.ZipCode ?? (object)DBNull.Value)
					, new SqlParameter("@Country",entity.Country ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@FAX",entity.Fax ?? (object)DBNull.Value)
					, new SqlParameter("@URL",entity.Url ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@NotificationXmlPackage",entity.NotificationXmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@ParentGenreID",entity.ParentGenreId)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetGenre(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Genre))]
		public virtual Genre UpdateGenre(Genre entity)
		{

			if (entity.IsTransient()) return entity;
			Genre other = GetGenre(entity.GenreId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Genre set  [GenreGUID]=@GenreGUID
							, [Name]=@Name
							, [SEName]=@SEName
							, [SEKeywords]=@SEKeywords
							, [SEDescription]=@SEDescription
							, [SETitle]=@SETitle
							, [SENoScript]=@SENoScript
							, [SEAltText]=@SEAltText
							, [Address1]=@Address1
							, [Address2]=@Address2
							, [Suite]=@Suite
							, [City]=@City
							, [State]=@State
							, [ZipCode]=@ZipCode
							, [Country]=@Country
							, [Phone]=@Phone
							, [FAX]=@FAX
							, [URL]=@URL
							, [Email]=@Email
							, [Summary]=@Summary
							, [Description]=@Description
							, [Notes]=@Notes
							, [QuantityDiscountID]=@QuantityDiscountID
							, [SortByLooks]=@SortByLooks
							, [XmlPackage]=@XmlPackage
							, [ColWidth]=@ColWidth
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [ContentsBGColor]=@ContentsBGColor
							, [PageBGColor]=@PageBGColor
							, [GraphicsColor]=@GraphicsColor
							, [NotificationXmlPackage]=@NotificationXmlPackage
							, [ImageFilenameOverride]=@ImageFilenameOverride
							, [ParentGenreID]=@ParentGenreID
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [IsImport]=@IsImport
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [PageSize]=@PageSize
							, [TaxClassID]=@TaxClassID
							, [SkinID]=@SkinID
							, [TemplateName]=@TemplateName 
							 where GenreID=@GenreID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GenreID",entity.GenreId)
					, new SqlParameter("@GenreGUID",entity.GenreGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@SEKeywords",entity.SeKeywords ?? (object)DBNull.Value)
					, new SqlParameter("@SEDescription",entity.SeDescription ?? (object)DBNull.Value)
					, new SqlParameter("@SETitle",entity.SeTitle ?? (object)DBNull.Value)
					, new SqlParameter("@SENoScript",entity.SeNoScript ?? (object)DBNull.Value)
					, new SqlParameter("@SEAltText",entity.SeAltText ?? (object)DBNull.Value)
					, new SqlParameter("@Address1",entity.Address1 ?? (object)DBNull.Value)
					, new SqlParameter("@Address2",entity.Address2 ?? (object)DBNull.Value)
					, new SqlParameter("@Suite",entity.Suite ?? (object)DBNull.Value)
					, new SqlParameter("@City",entity.City ?? (object)DBNull.Value)
					, new SqlParameter("@State",entity.State ?? (object)DBNull.Value)
					, new SqlParameter("@ZipCode",entity.ZipCode ?? (object)DBNull.Value)
					, new SqlParameter("@Country",entity.Country ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@FAX",entity.Fax ?? (object)DBNull.Value)
					, new SqlParameter("@URL",entity.Url ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@SortByLooks",entity.SortByLooks)
					, new SqlParameter("@XmlPackage",entity.XmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ColWidth",entity.ColWidth)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@ContentsBGColor",entity.ContentsBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@PageBGColor",entity.PageBgColor ?? (object)DBNull.Value)
					, new SqlParameter("@GraphicsColor",entity.GraphicsColor ?? (object)DBNull.Value)
					, new SqlParameter("@NotificationXmlPackage",entity.NotificationXmlPackage ?? (object)DBNull.Value)
					, new SqlParameter("@ImageFilenameOverride",entity.ImageFilenameOverride ?? (object)DBNull.Value)
					, new SqlParameter("@ParentGenreID",entity.ParentGenreId)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@IsImport",entity.IsImport)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@PageSize",entity.PageSize)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetGenre(entity.GenreId);
		}

		public virtual bool DeleteGenre(System.Int32 GenreId)
		{

			string sql="delete from Genre where GenreID=@GenreID";
			SqlParameter parameter=new SqlParameter("@GenreID",GenreId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Genre))]
		public virtual Genre DeleteGenre(Genre entity)
		{
			this.DeleteGenre(entity.GenreId);
			return entity;
		}


		public virtual Genre GenreFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Genre entity=new Genre();
			entity.GenreId = (System.Int32)dr["GenreID"];
			entity.GenreGuid = (System.Guid)dr["GenreGUID"];
			entity.Name = dr["Name"].ToString();
			entity.SeName = dr["SEName"].ToString();
			entity.SeKeywords = dr["SEKeywords"].ToString();
			entity.SeDescription = dr["SEDescription"].ToString();
			entity.SeTitle = dr["SETitle"].ToString();
			entity.SeNoScript = dr["SENoScript"].ToString();
			entity.SeAltText = dr["SEAltText"].ToString();
			entity.Address1 = dr["Address1"].ToString();
			entity.Address2 = dr["Address2"].ToString();
			entity.Suite = dr["Suite"].ToString();
			entity.City = dr["City"].ToString();
			entity.State = dr["State"].ToString();
			entity.ZipCode = dr["ZipCode"].ToString();
			entity.Country = dr["Country"].ToString();
			entity.Phone = dr["Phone"].ToString();
			entity.Fax = dr["FAX"].ToString();
			entity.Url = dr["URL"].ToString();
			entity.Email = dr["Email"].ToString();
			entity.Summary = dr["Summary"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.Notes = dr["Notes"].ToString();
			entity.QuantityDiscountId = dr["QuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["QuantityDiscountID"];
			entity.SortByLooks = (System.Byte)dr["SortByLooks"];
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.ColWidth = (System.Int32)dr["ColWidth"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.ContentsBgColor = dr["ContentsBGColor"].ToString();
			entity.PageBgColor = dr["PageBGColor"].ToString();
			entity.GraphicsColor = dr["GraphicsColor"].ToString();
			entity.NotificationXmlPackage = dr["NotificationXmlPackage"].ToString();
			entity.ImageFilenameOverride = dr["ImageFilenameOverride"].ToString();
			entity.ParentGenreId = (System.Int32)dr["ParentGenreID"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
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
