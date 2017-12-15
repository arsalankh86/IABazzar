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
		
	public abstract partial class PartnerRepositoryBase : Repository 
	{
        
        public PartnerRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PartnerID",new SearchColumn(){Name="PartnerID",Title="PartnerID",SelectClause="PartnerID",WhereClause="AllRecords.PartnerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PartnerGUID",new SearchColumn(){Name="PartnerGUID",Title="PartnerGUID",SelectClause="PartnerGUID",WhereClause="AllRecords.PartnerGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Summary",new SearchColumn(){Name="Summary",Title="Summary",SelectClause="Summary",WhereClause="AllRecords.Summary",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
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
			this.SearchColumns.Add("LinkToSite",new SearchColumn(){Name="LinkToSite",Title="LinkToSite",SelectClause="LinkToSite",WhereClause="AllRecords.LinkToSite",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LinkInNewWindow",new SearchColumn(){Name="LinkInNewWindow",Title="LinkInNewWindow",SelectClause="LinkInNewWindow",WhereClause="AllRecords.LinkInNewWindow",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Specialty",new SearchColumn(){Name="Specialty",Title="Specialty",SelectClause="Specialty",WhereClause="AllRecords.Specialty",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Instructors",new SearchColumn(){Name="Instructors",Title="Instructors",SelectClause="Instructors",WhereClause="AllRecords.Instructors",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Schedule",new SearchColumn(){Name="Schedule",Title="Schedule",SelectClause="Schedule",WhereClause="AllRecords.Schedule",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Testimonials",new SearchColumn(){Name="Testimonials",Title="Testimonials",SelectClause="Testimonials",WhereClause="AllRecords.Testimonials",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPartnerSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPartnerBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPartnerAdvanceSearchColumns()
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
        
        
        public virtual string GetPartnerSelectClause()
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
                        	selectQuery =  "Partner."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Partner."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Partner GetPartner(System.Int32 PartnerId)
		{

			string sql=GetPartnerSelectClause();
			sql+="from Partner where PartnerID=@PartnerID ";
			SqlParameter parameter=new SqlParameter("@PartnerID",PartnerId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PartnerFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Partner> GetAllPartner()
		{

			string sql=GetPartnerSelectClause();
			sql+="from Partner";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Partner>(ds, PartnerFromDataRow);
		}

		public virtual List<Partner> GetPagedPartner(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPartnerCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PartnerID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PartnerID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PartnerID] ";
            tempsql += " FROM [Partner] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PartnerID"))
					tempsql += " , (AllRecords.[PartnerID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PartnerID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPartnerSelectClause()+@" FROM [Partner], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Partner].[PartnerID] = PageIndex.[PartnerID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Partner>(ds, PartnerFromDataRow);
			}else{ return null;}
		}

		private int GetPartnerCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Partner as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Partner as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Partner))]
		public virtual Partner InsertPartner(Partner entity)
		{

			Partner other=new Partner();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Partner ( [PartnerGUID]
				,[Name]
				,[Summary]
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
				,[LinkToSite]
				,[LinkInNewWindow]
				,[Specialty]
				,[Instructors]
				,[Schedule]
				,[Testimonials]
				,[DisplayOrder]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @PartnerGUID
				, @Name
				, @Summary
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
				, @LinkToSite
				, @LinkInNewWindow
				, @Specialty
				, @Instructors
				, @Schedule
				, @Testimonials
				, @DisplayOrder
				, @Published
				, @Wholesale
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PartnerID",entity.PartnerId)
					, new SqlParameter("@PartnerGUID",entity.PartnerGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
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
					, new SqlParameter("@LinkToSite",entity.LinkToSite)
					, new SqlParameter("@LinkInNewWindow",entity.LinkInNewWindow)
					, new SqlParameter("@Specialty",entity.Specialty ?? (object)DBNull.Value)
					, new SqlParameter("@Instructors",entity.Instructors ?? (object)DBNull.Value)
					, new SqlParameter("@Schedule",entity.Schedule ?? (object)DBNull.Value)
					, new SqlParameter("@Testimonials",entity.Testimonials ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPartner(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Partner))]
		public virtual Partner UpdatePartner(Partner entity)
		{

			if (entity.IsTransient()) return entity;
			Partner other = GetPartner(entity.PartnerId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Partner set  [PartnerGUID]=@PartnerGUID
							, [Name]=@Name
							, [Summary]=@Summary
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
							, [LinkToSite]=@LinkToSite
							, [LinkInNewWindow]=@LinkInNewWindow
							, [Specialty]=@Specialty
							, [Instructors]=@Instructors
							, [Schedule]=@Schedule
							, [Testimonials]=@Testimonials
							, [DisplayOrder]=@DisplayOrder
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where PartnerID=@PartnerID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PartnerID",entity.PartnerId)
					, new SqlParameter("@PartnerGUID",entity.PartnerGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Summary",entity.Summary ?? (object)DBNull.Value)
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
					, new SqlParameter("@LinkToSite",entity.LinkToSite)
					, new SqlParameter("@LinkInNewWindow",entity.LinkInNewWindow)
					, new SqlParameter("@Specialty",entity.Specialty ?? (object)DBNull.Value)
					, new SqlParameter("@Instructors",entity.Instructors ?? (object)DBNull.Value)
					, new SqlParameter("@Schedule",entity.Schedule ?? (object)DBNull.Value)
					, new SqlParameter("@Testimonials",entity.Testimonials ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPartner(entity.PartnerId);
		}

		public virtual bool DeletePartner(System.Int32 PartnerId)
		{

			string sql="delete from Partner where PartnerID=@PartnerID";
			SqlParameter parameter=new SqlParameter("@PartnerID",PartnerId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Partner))]
		public virtual Partner DeletePartner(Partner entity)
		{
			this.DeletePartner(entity.PartnerId);
			return entity;
		}


		public virtual Partner PartnerFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Partner entity=new Partner();
			entity.PartnerId = (System.Int32)dr["PartnerID"];
			entity.PartnerGuid = (System.Guid)dr["PartnerGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Summary = dr["Summary"].ToString();
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
			entity.LinkToSite = (System.Byte)dr["LinkToSite"];
			entity.LinkInNewWindow = (System.Byte)dr["LinkInNewWindow"];
			entity.Specialty = dr["Specialty"].ToString();
			entity.Instructors = dr["Instructors"].ToString();
			entity.Schedule = dr["Schedule"].ToString();
			entity.Testimonials = dr["Testimonials"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
