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
		
	public abstract partial class StaffRepositoryBase : Repository 
	{
        
        public StaffRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StaffID",new SearchColumn(){Name="StaffID",Title="StaffID",SelectClause="StaffID",WhereClause="AllRecords.StaffID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StaffGUID",new SearchColumn(){Name="StaffGUID",Title="StaffGUID",SelectClause="StaffGUID",WhereClause="AllRecords.StaffGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Title",new SearchColumn(){Name="Title",Title="Title",SelectClause="Title",WhereClause="AllRecords.Title",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Bio",new SearchColumn(){Name="Bio",Title="Bio",SelectClause="Bio",WhereClause="AllRecords.Bio",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Phone",new SearchColumn(){Name="Phone",Title="Phone",SelectClause="Phone",WhereClause="AllRecords.Phone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FAX",new SearchColumn(){Name="FAX",Title="FAX",SelectClause="FAX",WhereClause="AllRecords.FAX",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetStaffSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetStaffBasicSearchColumns()
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

        public virtual List<SearchColumn> GetStaffAdvanceSearchColumns()
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
        
        
        public virtual string GetStaffSelectClause()
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
                        	selectQuery =  "Staff."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Staff."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Staff GetStaff(System.Int32 StaffId)
		{

			string sql=GetStaffSelectClause();
			sql+="from Staff where StaffID=@StaffID ";
			SqlParameter parameter=new SqlParameter("@StaffID",StaffId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return StaffFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Staff> GetAllStaff()
		{

			string sql=GetStaffSelectClause();
			sql+="from Staff";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Staff>(ds, StaffFromDataRow);
		}

		public virtual List<Staff> GetPagedStaff(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetStaffCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StaffID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StaffID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StaffID] ";
            tempsql += " FROM [Staff] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StaffID"))
					tempsql += " , (AllRecords.[StaffID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StaffID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetStaffSelectClause()+@" FROM [Staff], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Staff].[StaffID] = PageIndex.[StaffID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Staff>(ds, StaffFromDataRow);
			}else{ return null;}
		}

		private int GetStaffCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Staff as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Staff as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Staff))]
		public virtual Staff InsertStaff(Staff entity)
		{

			Staff other=new Staff();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Staff ( [StaffGUID]
				,[Name]
				,[Title]
				,[Bio]
				,[Phone]
				,[FAX]
				,[Email]
				,[DisplayOrder]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @StaffGUID
				, @Name
				, @Title
				, @Bio
				, @Phone
				, @FAX
				, @Email
				, @DisplayOrder
				, @Published
				, @Wholesale
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StaffID",entity.StaffId)
					, new SqlParameter("@StaffGUID",entity.StaffGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Title",entity.Title ?? (object)DBNull.Value)
					, new SqlParameter("@Bio",entity.Bio ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@FAX",entity.Fax ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetStaff(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Staff))]
		public virtual Staff UpdateStaff(Staff entity)
		{

			if (entity.IsTransient()) return entity;
			Staff other = GetStaff(entity.StaffId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Staff set  [StaffGUID]=@StaffGUID
							, [Name]=@Name
							, [Title]=@Title
							, [Bio]=@Bio
							, [Phone]=@Phone
							, [FAX]=@FAX
							, [Email]=@Email
							, [DisplayOrder]=@DisplayOrder
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where StaffID=@StaffID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StaffID",entity.StaffId)
					, new SqlParameter("@StaffGUID",entity.StaffGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Title",entity.Title ?? (object)DBNull.Value)
					, new SqlParameter("@Bio",entity.Bio ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@FAX",entity.Fax ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetStaff(entity.StaffId);
		}

		public virtual bool DeleteStaff(System.Int32 StaffId)
		{

			string sql="delete from Staff where StaffID=@StaffID";
			SqlParameter parameter=new SqlParameter("@StaffID",StaffId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Staff))]
		public virtual Staff DeleteStaff(Staff entity)
		{
			this.DeleteStaff(entity.StaffId);
			return entity;
		}


		public virtual Staff StaffFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Staff entity=new Staff();
			entity.StaffId = (System.Int32)dr["StaffID"];
			entity.StaffGuid = (System.Guid)dr["StaffGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Title = dr["Title"].ToString();
			entity.Bio = dr["Bio"].ToString();
			entity.Phone = dr["Phone"].ToString();
			entity.Fax = dr["FAX"].ToString();
			entity.Email = dr["Email"].ToString();
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
