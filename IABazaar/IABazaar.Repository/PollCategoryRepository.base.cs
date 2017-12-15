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
		
	public abstract partial class PollCategoryRepositoryBase : Repository 
	{
        
        public PollCategoryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PollID",new SearchColumn(){Name="PollID",Title="PollID",SelectClause="PollID",WhereClause="AllRecords.PollID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CategoryID",new SearchColumn(){Name="CategoryID",Title="CategoryID",SelectClause="CategoryID",WhereClause="AllRecords.CategoryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPollCategorySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPollCategoryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPollCategoryAdvanceSearchColumns()
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
        
        
        public virtual string GetPollCategorySelectClause()
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
                        	selectQuery =  "PollCategory."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",PollCategory."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual PollCategory GetPollCategory(System.Int32 PollId)
		{

			string sql=GetPollCategorySelectClause();
			sql+="from PollCategory where PollID=@PollID ";
			SqlParameter parameter=new SqlParameter("@PollID",PollId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PollCategoryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<PollCategory> GetAllPollCategory()
		{

			string sql=GetPollCategorySelectClause();
			sql+="from PollCategory";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollCategory>(ds, PollCategoryFromDataRow);
		}

		public virtual List<PollCategory> GetPagedPollCategory(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPollCategoryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PollID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PollID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PollID] ";
            tempsql += " FROM [PollCategory] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PollID"))
					tempsql += " , (AllRecords.[PollID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PollID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPollCategorySelectClause()+@" FROM [PollCategory], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [PollCategory].[PollID] = PageIndex.[PollID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollCategory>(ds, PollCategoryFromDataRow);
			}else{ return null;}
		}

		private int GetPollCategoryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM PollCategory as AllRecords ";
			else
				sql = "SELECT Count(*) FROM PollCategory as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(PollCategory))]
		public virtual PollCategory InsertPollCategory(PollCategory entity)
		{

			PollCategory other=new PollCategory();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into PollCategory ( [PollID]
				,[CategoryID]
				,[CreatedOn] )
				Values
				( @PollID
				, @CategoryID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@CategoryID",entity.CategoryId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPollCategory(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(PollCategory))]
		public virtual PollCategory UpdatePollCategory(PollCategory entity)
		{

			if (entity.IsTransient()) return entity;
			PollCategory other = GetPollCategory(entity.PollId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update PollCategory set  [CategoryID]=@CategoryID
							, [CreatedOn]=@CreatedOn 
							 where PollID=@PollID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollID",entity.PollId)
					, new SqlParameter("@CategoryID",entity.CategoryId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPollCategory(entity.PollId);
		}

		public virtual bool DeletePollCategory(System.Int32 PollId)
		{

			string sql="delete from PollCategory where PollID=@PollID";
			SqlParameter parameter=new SqlParameter("@PollID",PollId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(PollCategory))]
		public virtual PollCategory DeletePollCategory(PollCategory entity)
		{
			this.DeletePollCategory(entity.PollId);
			return entity;
		}


		public virtual PollCategory PollCategoryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			PollCategory entity=new PollCategory();
			entity.PollId = (System.Int32)dr["PollID"];
			entity.CategoryId = (System.Int32)dr["CategoryID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
