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
		
	public abstract partial class RatingCommentHelpfulnessRepositoryBase : Repository 
	{
        
        public RatingCommentHelpfulnessRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RatingCustomerID",new SearchColumn(){Name="RatingCustomerID",Title="RatingCustomerID",SelectClause="RatingCustomerID",WhereClause="AllRecords.RatingCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VotingCustomerID",new SearchColumn(){Name="VotingCustomerID",Title="VotingCustomerID",SelectClause="VotingCustomerID",WhereClause="AllRecords.VotingCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Helpful",new SearchColumn(){Name="Helpful",Title="Helpful",SelectClause="Helpful",WhereClause="AllRecords.Helpful",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetRatingCommentHelpfulnessSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetRatingCommentHelpfulnessBasicSearchColumns()
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

        public virtual List<SearchColumn> GetRatingCommentHelpfulnessAdvanceSearchColumns()
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
        
        
        public virtual string GetRatingCommentHelpfulnessSelectClause()
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
                        	selectQuery =  "RatingCommentHelpfulness."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",RatingCommentHelpfulness."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual RatingCommentHelpfulness GetRatingCommentHelpfulness(System.Int32 StoreId)
		{

			string sql=GetRatingCommentHelpfulnessSelectClause();
			sql+="from RatingCommentHelpfulness where StoreID=@StoreID ";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return RatingCommentHelpfulnessFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<RatingCommentHelpfulness> GetAllRatingCommentHelpfulness()
		{

			string sql=GetRatingCommentHelpfulnessSelectClause();
			sql+="from RatingCommentHelpfulness";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<RatingCommentHelpfulness>(ds, RatingCommentHelpfulnessFromDataRow);
		}

		public virtual List<RatingCommentHelpfulness> GetPagedRatingCommentHelpfulness(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetRatingCommentHelpfulnessCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StoreID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StoreID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StoreID] ";
            tempsql += " FROM [RatingCommentHelpfulness] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StoreID"))
					tempsql += " , (AllRecords.[StoreID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StoreID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetRatingCommentHelpfulnessSelectClause()+@" FROM [RatingCommentHelpfulness], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [RatingCommentHelpfulness].[StoreID] = PageIndex.[StoreID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<RatingCommentHelpfulness>(ds, RatingCommentHelpfulnessFromDataRow);
			}else{ return null;}
		}

		private int GetRatingCommentHelpfulnessCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM RatingCommentHelpfulness as AllRecords ";
			else
				sql = "SELECT Count(*) FROM RatingCommentHelpfulness as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(RatingCommentHelpfulness))]
		public virtual RatingCommentHelpfulness InsertRatingCommentHelpfulness(RatingCommentHelpfulness entity)
		{

			RatingCommentHelpfulness other=new RatingCommentHelpfulness();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into RatingCommentHelpfulness ( [StoreID]
				,[ProductID]
				,[RatingCustomerID]
				,[VotingCustomerID]
				,[Helpful]
				,[CreatedOn] )
				Values
				( @StoreID
				, @ProductID
				, @RatingCustomerID
				, @VotingCustomerID
				, @Helpful
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@RatingCustomerID",entity.RatingCustomerId)
					, new SqlParameter("@VotingCustomerID",entity.VotingCustomerId)
					, new SqlParameter("@Helpful",entity.Helpful)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetRatingCommentHelpfulness(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(RatingCommentHelpfulness))]
		public virtual RatingCommentHelpfulness UpdateRatingCommentHelpfulness(RatingCommentHelpfulness entity)
		{

			if (entity.IsTransient()) return entity;
			RatingCommentHelpfulness other = GetRatingCommentHelpfulness(entity.StoreId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update RatingCommentHelpfulness set  [ProductID]=@ProductID
							, [RatingCustomerID]=@RatingCustomerID
							, [VotingCustomerID]=@VotingCustomerID
							, [Helpful]=@Helpful
							, [CreatedOn]=@CreatedOn 
							 where StoreID=@StoreID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@RatingCustomerID",entity.RatingCustomerId)
					, new SqlParameter("@VotingCustomerID",entity.VotingCustomerId)
					, new SqlParameter("@Helpful",entity.Helpful)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetRatingCommentHelpfulness(entity.StoreId);
		}

		public virtual bool DeleteRatingCommentHelpfulness(System.Int32 StoreId)
		{

			string sql="delete from RatingCommentHelpfulness where StoreID=@StoreID";
			SqlParameter parameter=new SqlParameter("@StoreID",StoreId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(RatingCommentHelpfulness))]
		public virtual RatingCommentHelpfulness DeleteRatingCommentHelpfulness(RatingCommentHelpfulness entity)
		{
			this.DeleteRatingCommentHelpfulness(entity.StoreId);
			return entity;
		}


		public virtual RatingCommentHelpfulness RatingCommentHelpfulnessFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			RatingCommentHelpfulness entity=new RatingCommentHelpfulness();
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.RatingCustomerId = (System.Int32)dr["RatingCustomerID"];
			entity.VotingCustomerId = (System.Int32)dr["VotingCustomerID"];
			entity.Helpful = (System.Byte)dr["Helpful"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
