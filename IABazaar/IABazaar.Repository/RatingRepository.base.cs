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
		
	public abstract partial class RatingRepositoryBase : Repository 
	{
        
        public RatingRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("RatingID",new SearchColumn(){Name="RatingID",Title="RatingID",SelectClause="RatingID",WhereClause="AllRecords.RatingID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Rating",new SearchColumn(){Name="Rating",Title="Rating",SelectClause="Rating",WhereClause="AllRecords.Rating",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Comments",new SearchColumn(){Name="Comments",Title="Comments",SelectClause="Comments",WhereClause="AllRecords.Comments",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("HasComment",new SearchColumn(){Name="HasComment",Title="HasComment",SelectClause="HasComment",WhereClause="AllRecords.HasComment",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsFilthy",new SearchColumn(){Name="IsFilthy",Title="IsFilthy",SelectClause="IsFilthy",WhereClause="AllRecords.IsFilthy",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsROTD",new SearchColumn(){Name="IsROTD",Title="IsROTD",SelectClause="IsROTD",WhereClause="AllRecords.IsROTD",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FoundHelpful",new SearchColumn(){Name="FoundHelpful",Title="FoundHelpful",SelectClause="FoundHelpful",WhereClause="AllRecords.FoundHelpful",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FoundNotHelpful",new SearchColumn(){Name="FoundNotHelpful",Title="FoundNotHelpful",SelectClause="FoundNotHelpful",WhereClause="AllRecords.FoundNotHelpful",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetRatingSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetRatingBasicSearchColumns()
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

        public virtual List<SearchColumn> GetRatingAdvanceSearchColumns()
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
        
        
        public virtual string GetRatingSelectClause()
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
                        	selectQuery =  "Rating."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Rating."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Rating GetRating(System.Int32 RatingId)
		{

			string sql=GetRatingSelectClause();
			sql+="from Rating where RatingID=@RatingID ";
			SqlParameter parameter=new SqlParameter("@RatingID",RatingId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return RatingFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Rating> GetAllRating()
		{

			string sql=GetRatingSelectClause();
			sql+="from Rating";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Rating>(ds, RatingFromDataRow);
		}

		public virtual List<Rating> GetPagedRating(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetRatingCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [RatingID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([RatingID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [RatingID] ";
            tempsql += " FROM [Rating] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("RatingID"))
					tempsql += " , (AllRecords.[RatingID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[RatingID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetRatingSelectClause()+@" FROM [Rating], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Rating].[RatingID] = PageIndex.[RatingID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Rating>(ds, RatingFromDataRow);
			}else{ return null;}
		}

		private int GetRatingCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Rating as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Rating as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Rating))]
		public virtual Rating InsertRating(Rating entity)
		{

			Rating other=new Rating();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Rating ( [StoreID]
				,[ProductID]
				,[CustomerID]
				,[Rating]
				,[Comments]
				,[HasComment]
				,[IsFilthy]
				,[IsROTD]
				,[FoundHelpful]
				,[FoundNotHelpful]
				,[CreatedOn] )
				Values
				( @StoreID
				, @ProductID
				, @CustomerID
				, @Rating
				, @Comments
				, @HasComment
				, @IsFilthy
				, @IsROTD
				, @FoundHelpful
				, @FoundNotHelpful
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@RatingID",entity.RatingId)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@Rating",entity.Rating)
					, new SqlParameter("@Comments",entity.Comments ?? (object)DBNull.Value)
					, new SqlParameter("@HasComment",entity.HasComment)
					, new SqlParameter("@IsFilthy",entity.IsFilthy)
					, new SqlParameter("@IsROTD",entity.IsRotd)
					, new SqlParameter("@FoundHelpful",entity.FoundHelpful)
					, new SqlParameter("@FoundNotHelpful",entity.FoundNotHelpful)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetRating(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Rating))]
		public virtual Rating UpdateRating(Rating entity)
		{

			if (entity.IsTransient()) return entity;
			Rating other = GetRating(entity.RatingId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Rating set  [StoreID]=@StoreID
							, [ProductID]=@ProductID
							, [CustomerID]=@CustomerID
							, [Rating]=@Rating
							, [Comments]=@Comments
							, [HasComment]=@HasComment
							, [IsFilthy]=@IsFilthy
							, [IsROTD]=@IsROTD
							, [FoundHelpful]=@FoundHelpful
							, [FoundNotHelpful]=@FoundNotHelpful
							, [CreatedOn]=@CreatedOn 
							 where RatingID=@RatingID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@RatingID",entity.RatingId)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@Rating",entity.Rating)
					, new SqlParameter("@Comments",entity.Comments ?? (object)DBNull.Value)
					, new SqlParameter("@HasComment",entity.HasComment)
					, new SqlParameter("@IsFilthy",entity.IsFilthy)
					, new SqlParameter("@IsROTD",entity.IsRotd)
					, new SqlParameter("@FoundHelpful",entity.FoundHelpful)
					, new SqlParameter("@FoundNotHelpful",entity.FoundNotHelpful)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetRating(entity.RatingId);
		}

		public virtual bool DeleteRating(System.Int32 RatingId)
		{

			string sql="delete from Rating where RatingID=@RatingID";
			SqlParameter parameter=new SqlParameter("@RatingID",RatingId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Rating))]
		public virtual Rating DeleteRating(Rating entity)
		{
			this.DeleteRating(entity.RatingId);
			return entity;
		}


		public virtual Rating RatingFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Rating entity=new Rating();
			entity.RatingId = (System.Int32)dr["RatingID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.Rating = (System.Int32)dr["Rating"];
			entity.Comments = dr["Comments"].ToString();
			entity.HasComment = (System.Byte)dr["HasComment"];
			entity.IsFilthy = (System.Byte)dr["IsFilthy"];
			entity.IsRotd = (System.Byte)dr["IsROTD"];
			entity.FoundHelpful = (System.Int32)dr["FoundHelpful"];
			entity.FoundNotHelpful = (System.Int32)dr["FoundNotHelpful"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
