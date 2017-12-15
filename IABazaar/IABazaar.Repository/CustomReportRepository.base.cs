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
		
	public abstract partial class CustomReportRepositoryBase : Repository 
	{
        
        public CustomReportRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomReportID",new SearchColumn(){Name="CustomReportID",Title="CustomReportID",SelectClause="CustomReportID",WhereClause="AllRecords.CustomReportID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomReportGUID",new SearchColumn(){Name="CustomReportGUID",Title="CustomReportGUID",SelectClause="CustomReportGUID",WhereClause="AllRecords.CustomReportGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SQLCommand",new SearchColumn(){Name="SQLCommand",Title="SQLCommand",SelectClause="SQLCommand",WhereClause="AllRecords.SQLCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomReportSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomReportBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomReportAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomReportSelectClause()
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
                        	selectQuery =  "CustomReport."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomReport."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomReport GetCustomReport(System.Int32 CustomReportId)
		{

			string sql=GetCustomReportSelectClause();
			sql+="from CustomReport where CustomReportID=@CustomReportID ";
			SqlParameter parameter=new SqlParameter("@CustomReportID",CustomReportId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomReportFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomReport> GetAllCustomReport()
		{

			string sql=GetCustomReportSelectClause();
			sql+="from CustomReport";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomReport>(ds, CustomReportFromDataRow);
		}

		public virtual List<CustomReport> GetPagedCustomReport(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomReportCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomReportID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomReportID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomReportID] ";
            tempsql += " FROM [CustomReport] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomReportID"))
					tempsql += " , (AllRecords.[CustomReportID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomReportID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomReportSelectClause()+@" FROM [CustomReport], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomReport].[CustomReportID] = PageIndex.[CustomReportID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomReport>(ds, CustomReportFromDataRow);
			}else{ return null;}
		}

		private int GetCustomReportCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomReport as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomReport as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomReport))]
		public virtual CustomReport InsertCustomReport(CustomReport entity)
		{

			CustomReport other=new CustomReport();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomReport ( [CustomReportGUID]
				,[Name]
				,[Description]
				,[SQLCommand]
				,[CreatedOn] )
				Values
				( @CustomReportGUID
				, @Name
				, @Description
				, @SQLCommand
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomReportID",entity.CustomReportId)
					, new SqlParameter("@CustomReportGUID",entity.CustomReportGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SQLCommand",entity.SqlCommand ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomReport(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomReport))]
		public virtual CustomReport UpdateCustomReport(CustomReport entity)
		{

			if (entity.IsTransient()) return entity;
			CustomReport other = GetCustomReport(entity.CustomReportId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomReport set  [CustomReportGUID]=@CustomReportGUID
							, [Name]=@Name
							, [Description]=@Description
							, [SQLCommand]=@SQLCommand
							, [CreatedOn]=@CreatedOn 
							 where CustomReportID=@CustomReportID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomReportID",entity.CustomReportId)
					, new SqlParameter("@CustomReportGUID",entity.CustomReportGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@SQLCommand",entity.SqlCommand ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomReport(entity.CustomReportId);
		}

		public virtual bool DeleteCustomReport(System.Int32 CustomReportId)
		{

			string sql="delete from CustomReport where CustomReportID=@CustomReportID";
			SqlParameter parameter=new SqlParameter("@CustomReportID",CustomReportId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomReport))]
		public virtual CustomReport DeleteCustomReport(CustomReport entity)
		{
			this.DeleteCustomReport(entity.CustomReportId);
			return entity;
		}


		public virtual CustomReport CustomReportFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomReport entity=new CustomReport();
			entity.CustomReportId = (System.Int32)dr["CustomReportID"];
			entity.CustomReportGuid = (System.Guid)dr["CustomReportGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.SqlCommand = dr["SQLCommand"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
