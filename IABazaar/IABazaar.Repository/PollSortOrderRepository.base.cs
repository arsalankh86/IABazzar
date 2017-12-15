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
		
	public abstract partial class PollSortOrderRepositoryBase : Repository 
	{
        
        public PollSortOrderRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("PollSortOrderID",new SearchColumn(){Name="PollSortOrderID",Title="PollSortOrderID",SelectClause="PollSortOrderID",WhereClause="AllRecords.PollSortOrderID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PollSortOrderGUID",new SearchColumn(){Name="PollSortOrderGUID",Title="PollSortOrderGUID",SelectClause="PollSortOrderGUID",WhereClause="AllRecords.PollSortOrderGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetPollSortOrderSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetPollSortOrderBasicSearchColumns()
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

        public virtual List<SearchColumn> GetPollSortOrderAdvanceSearchColumns()
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
        
        
        public virtual string GetPollSortOrderSelectClause()
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
                        	selectQuery =  "PollSortOrder."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",PollSortOrder."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual PollSortOrder GetPollSortOrder(System.Int32 PollSortOrderId)
		{

			string sql=GetPollSortOrderSelectClause();
			sql+="from PollSortOrder where PollSortOrderID=@PollSortOrderID ";
			SqlParameter parameter=new SqlParameter("@PollSortOrderID",PollSortOrderId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return PollSortOrderFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<PollSortOrder> GetAllPollSortOrder()
		{

			string sql=GetPollSortOrderSelectClause();
			sql+="from PollSortOrder";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollSortOrder>(ds, PollSortOrderFromDataRow);
		}

		public virtual List<PollSortOrder> GetPagedPollSortOrder(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetPollSortOrderCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [PollSortOrderID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([PollSortOrderID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [PollSortOrderID] ";
            tempsql += " FROM [PollSortOrder] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("PollSortOrderID"))
					tempsql += " , (AllRecords.[PollSortOrderID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[PollSortOrderID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetPollSortOrderSelectClause()+@" FROM [PollSortOrder], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [PollSortOrder].[PollSortOrderID] = PageIndex.[PollSortOrderID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<PollSortOrder>(ds, PollSortOrderFromDataRow);
			}else{ return null;}
		}

		private int GetPollSortOrderCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM PollSortOrder as AllRecords ";
			else
				sql = "SELECT Count(*) FROM PollSortOrder as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(PollSortOrder))]
		public virtual PollSortOrder InsertPollSortOrder(PollSortOrder entity)
		{

			PollSortOrder other=new PollSortOrder();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into PollSortOrder ( [PollSortOrderGUID]
				,[Name]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @PollSortOrderGUID
				, @Name
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollSortOrderID",entity.PollSortOrderId)
					, new SqlParameter("@PollSortOrderGUID",entity.PollSortOrderGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetPollSortOrder(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(PollSortOrder))]
		public virtual PollSortOrder UpdatePollSortOrder(PollSortOrder entity)
		{

			if (entity.IsTransient()) return entity;
			PollSortOrder other = GetPollSortOrder(entity.PollSortOrderId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update PollSortOrder set  [PollSortOrderGUID]=@PollSortOrderGUID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where PollSortOrderID=@PollSortOrderID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@PollSortOrderID",entity.PollSortOrderId)
					, new SqlParameter("@PollSortOrderGUID",entity.PollSortOrderGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetPollSortOrder(entity.PollSortOrderId);
		}

		public virtual bool DeletePollSortOrder(System.Int32 PollSortOrderId)
		{

			string sql="delete from PollSortOrder where PollSortOrderID=@PollSortOrderID";
			SqlParameter parameter=new SqlParameter("@PollSortOrderID",PollSortOrderId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(PollSortOrder))]
		public virtual PollSortOrder DeletePollSortOrder(PollSortOrder entity)
		{
			this.DeletePollSortOrder(entity.PollSortOrderId);
			return entity;
		}


		public virtual PollSortOrder PollSortOrderFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			PollSortOrder entity=new PollSortOrder();
			entity.PollSortOrderId = (System.Int32)dr["PollSortOrderID"];
			entity.PollSortOrderGuid = (System.Guid)dr["PollSortOrderGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
