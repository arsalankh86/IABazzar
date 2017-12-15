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
		
	public abstract partial class SalesPromptRepositoryBase : Repository 
	{
        
        public SalesPromptRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("SalesPromptID",new SearchColumn(){Name="SalesPromptID",Title="SalesPromptID",SelectClause="SalesPromptID",WhereClause="AllRecords.SalesPromptID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SalesPromptGUID",new SearchColumn(){Name="SalesPromptGUID",Title="SalesPromptGUID",SelectClause="SalesPromptGUID",WhereClause="AllRecords.SalesPromptGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetSalesPromptSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetSalesPromptBasicSearchColumns()
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

        public virtual List<SearchColumn> GetSalesPromptAdvanceSearchColumns()
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
        
        
        public virtual string GetSalesPromptSelectClause()
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
                        	selectQuery =  "SalesPrompt."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",SalesPrompt."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual SalesPrompt GetSalesPrompt(System.Int32 SalesPromptId)
		{

			string sql=GetSalesPromptSelectClause();
			sql+="from SalesPrompt where SalesPromptID=@SalesPromptID ";
			SqlParameter parameter=new SqlParameter("@SalesPromptID",SalesPromptId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return SalesPromptFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<SalesPrompt> GetAllSalesPrompt()
		{

			string sql=GetSalesPromptSelectClause();
			sql+="from SalesPrompt";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SalesPrompt>(ds, SalesPromptFromDataRow);
		}

		public virtual List<SalesPrompt> GetPagedSalesPrompt(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetSalesPromptCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [SalesPromptID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([SalesPromptID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [SalesPromptID] ";
            tempsql += " FROM [SalesPrompt] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("SalesPromptID"))
					tempsql += " , (AllRecords.[SalesPromptID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[SalesPromptID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetSalesPromptSelectClause()+@" FROM [SalesPrompt], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [SalesPrompt].[SalesPromptID] = PageIndex.[SalesPromptID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SalesPrompt>(ds, SalesPromptFromDataRow);
			}else{ return null;}
		}

		private int GetSalesPromptCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM SalesPrompt as AllRecords ";
			else
				sql = "SELECT Count(*) FROM SalesPrompt as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(SalesPrompt))]
		public virtual SalesPrompt InsertSalesPrompt(SalesPrompt entity)
		{

			SalesPrompt other=new SalesPrompt();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into SalesPrompt ( [SalesPromptGUID]
				,[Name]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @SalesPromptGUID
				, @Name
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SalesPromptID",entity.SalesPromptId)
					, new SqlParameter("@SalesPromptGUID",entity.SalesPromptGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetSalesPrompt(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(SalesPrompt))]
		public virtual SalesPrompt UpdateSalesPrompt(SalesPrompt entity)
		{

			if (entity.IsTransient()) return entity;
			SalesPrompt other = GetSalesPrompt(entity.SalesPromptId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update SalesPrompt set  [SalesPromptGUID]=@SalesPromptGUID
							, [Name]=@Name
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where SalesPromptID=@SalesPromptID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SalesPromptID",entity.SalesPromptId)
					, new SqlParameter("@SalesPromptGUID",entity.SalesPromptGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetSalesPrompt(entity.SalesPromptId);
		}

		public virtual bool DeleteSalesPrompt(System.Int32 SalesPromptId)
		{

			string sql="delete from SalesPrompt where SalesPromptID=@SalesPromptID";
			SqlParameter parameter=new SqlParameter("@SalesPromptID",SalesPromptId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(SalesPrompt))]
		public virtual SalesPrompt DeleteSalesPrompt(SalesPrompt entity)
		{
			this.DeleteSalesPrompt(entity.SalesPromptId);
			return entity;
		}


		public virtual SalesPrompt SalesPromptFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			SalesPrompt entity=new SalesPrompt();
			entity.SalesPromptId = (System.Int32)dr["SalesPromptID"];
			entity.SalesPromptGuid = (System.Guid)dr["SalesPromptGUID"];
			entity.Name = dr["Name"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
