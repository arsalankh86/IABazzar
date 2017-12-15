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
		
	public abstract partial class BadWordRepositoryBase : Repository 
	{
        
        public BadWordRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("BadWordID",new SearchColumn(){Name="BadWordID",Title="BadWordID",SelectClause="BadWordID",WhereClause="AllRecords.BadWordID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSetting",new SearchColumn(){Name="LocaleSetting",Title="LocaleSetting",SelectClause="LocaleSetting",WhereClause="AllRecords.LocaleSetting",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Word",new SearchColumn(){Name="Word",Title="Word",SelectClause="Word",WhereClause="AllRecords.Word",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetBadWordSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetBadWordBasicSearchColumns()
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

        public virtual List<SearchColumn> GetBadWordAdvanceSearchColumns()
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
        
        
        public virtual string GetBadWordSelectClause()
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
                        	selectQuery =  "BadWord."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",BadWord."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual BadWord GetBadWord(System.Int32 BadWordId)
		{

			string sql=GetBadWordSelectClause();
			sql+="from BadWord where BadWordID=@BadWordID ";
			SqlParameter parameter=new SqlParameter("@BadWordID",BadWordId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return BadWordFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<BadWord> GetAllBadWord()
		{

			string sql=GetBadWordSelectClause();
			sql+="from BadWord";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<BadWord>(ds, BadWordFromDataRow);
		}

		public virtual List<BadWord> GetPagedBadWord(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetBadWordCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [BadWordID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([BadWordID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [BadWordID] ";
            tempsql += " FROM [BadWord] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("BadWordID"))
					tempsql += " , (AllRecords.[BadWordID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[BadWordID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetBadWordSelectClause()+@" FROM [BadWord], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [BadWord].[BadWordID] = PageIndex.[BadWordID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<BadWord>(ds, BadWordFromDataRow);
			}else{ return null;}
		}

		private int GetBadWordCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM BadWord as AllRecords ";
			else
				sql = "SELECT Count(*) FROM BadWord as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(BadWord))]
		public virtual BadWord InsertBadWord(BadWord entity)
		{

			BadWord other=new BadWord();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into BadWord ( [LocaleSetting]
				,[Word]
				,[CreatedOn] )
				Values
				( @LocaleSetting
				, @Word
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@BadWordID",entity.BadWordId)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting)
					, new SqlParameter("@Word",entity.Word)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetBadWord(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(BadWord))]
		public virtual BadWord UpdateBadWord(BadWord entity)
		{

			if (entity.IsTransient()) return entity;
			BadWord other = GetBadWord(entity.BadWordId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update BadWord set  [LocaleSetting]=@LocaleSetting
							, [Word]=@Word
							, [CreatedOn]=@CreatedOn 
							 where BadWordID=@BadWordID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@BadWordID",entity.BadWordId)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting)
					, new SqlParameter("@Word",entity.Word)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetBadWord(entity.BadWordId);
		}

		public virtual bool DeleteBadWord(System.Int32 BadWordId)
		{

			string sql="delete from BadWord where BadWordID=@BadWordID";
			SqlParameter parameter=new SqlParameter("@BadWordID",BadWordId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(BadWord))]
		public virtual BadWord DeleteBadWord(BadWord entity)
		{
			this.DeleteBadWord(entity.BadWordId);
			return entity;
		}


		public virtual BadWord BadWordFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			BadWord entity=new BadWord();
			entity.BadWordId = (System.Int32)dr["BadWordID"];
			entity.LocaleSetting = dr["LocaleSetting"].ToString();
			entity.Word = dr["Word"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
