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
		
	public abstract partial class QuantityDiscountTableRepositoryBase : Repository 
	{
        
        public QuantityDiscountTableRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("QuantityDiscountTableID",new SearchColumn(){Name="QuantityDiscountTableID",Title="QuantityDiscountTableID",SelectClause="QuantityDiscountTableID",WhereClause="AllRecords.QuantityDiscountTableID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountTableGUID",new SearchColumn(){Name="QuantityDiscountTableGUID",Title="QuantityDiscountTableGUID",SelectClause="QuantityDiscountTableGUID",WhereClause="AllRecords.QuantityDiscountTableGUID",DataType="System.Guid?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LowQuantity",new SearchColumn(){Name="LowQuantity",Title="LowQuantity",SelectClause="LowQuantity",WhereClause="AllRecords.LowQuantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("HighQuantity",new SearchColumn(){Name="HighQuantity",Title="HighQuantity",SelectClause="HighQuantity",WhereClause="AllRecords.HighQuantity",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DiscountPercent",new SearchColumn(){Name="DiscountPercent",Title="DiscountPercent",SelectClause="DiscountPercent",WhereClause="AllRecords.DiscountPercent",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetQuantityDiscountTableSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetQuantityDiscountTableBasicSearchColumns()
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

        public virtual List<SearchColumn> GetQuantityDiscountTableAdvanceSearchColumns()
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
        
        
        public virtual string GetQuantityDiscountTableSelectClause()
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
                        	selectQuery =  "QuantityDiscountTable."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",QuantityDiscountTable."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual QuantityDiscountTable GetQuantityDiscountTable(System.Int32 QuantityDiscountTableId)
		{

			string sql=GetQuantityDiscountTableSelectClause();
			sql+="from QuantityDiscountTable where QuantityDiscountTableID=@QuantityDiscountTableID ";
			SqlParameter parameter=new SqlParameter("@QuantityDiscountTableID",QuantityDiscountTableId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return QuantityDiscountTableFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<QuantityDiscountTable> GetAllQuantityDiscountTable()
		{

			string sql=GetQuantityDiscountTableSelectClause();
			sql+="from QuantityDiscountTable";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<QuantityDiscountTable>(ds, QuantityDiscountTableFromDataRow);
		}

		public virtual List<QuantityDiscountTable> GetPagedQuantityDiscountTable(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetQuantityDiscountTableCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [QuantityDiscountTableID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([QuantityDiscountTableID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [QuantityDiscountTableID] ";
            tempsql += " FROM [QuantityDiscountTable] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("QuantityDiscountTableID"))
					tempsql += " , (AllRecords.[QuantityDiscountTableID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[QuantityDiscountTableID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetQuantityDiscountTableSelectClause()+@" FROM [QuantityDiscountTable], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [QuantityDiscountTable].[QuantityDiscountTableID] = PageIndex.[QuantityDiscountTableID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<QuantityDiscountTable>(ds, QuantityDiscountTableFromDataRow);
			}else{ return null;}
		}

		private int GetQuantityDiscountTableCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM QuantityDiscountTable as AllRecords ";
			else
				sql = "SELECT Count(*) FROM QuantityDiscountTable as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(QuantityDiscountTable))]
		public virtual QuantityDiscountTable InsertQuantityDiscountTable(QuantityDiscountTable entity)
		{

			QuantityDiscountTable other=new QuantityDiscountTable();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into QuantityDiscountTable ( [QuantityDiscountTableGUID]
				,[QuantityDiscountID]
				,[LowQuantity]
				,[HighQuantity]
				,[DiscountPercent]
				,[CreatedOn] )
				Values
				( @QuantityDiscountTableGUID
				, @QuantityDiscountID
				, @LowQuantity
				, @HighQuantity
				, @DiscountPercent
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@QuantityDiscountTableID",entity.QuantityDiscountTableId)
					, new SqlParameter("@QuantityDiscountTableGUID",entity.QuantityDiscountTableGuid ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@LowQuantity",entity.LowQuantity)
					, new SqlParameter("@HighQuantity",entity.HighQuantity)
					, new SqlParameter("@DiscountPercent",entity.DiscountPercent)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetQuantityDiscountTable(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(QuantityDiscountTable))]
		public virtual QuantityDiscountTable UpdateQuantityDiscountTable(QuantityDiscountTable entity)
		{

			if (entity.IsTransient()) return entity;
			QuantityDiscountTable other = GetQuantityDiscountTable(entity.QuantityDiscountTableId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update QuantityDiscountTable set  [QuantityDiscountTableGUID]=@QuantityDiscountTableGUID
							, [QuantityDiscountID]=@QuantityDiscountID
							, [LowQuantity]=@LowQuantity
							, [HighQuantity]=@HighQuantity
							, [DiscountPercent]=@DiscountPercent
							, [CreatedOn]=@CreatedOn 
							 where QuantityDiscountTableID=@QuantityDiscountTableID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@QuantityDiscountTableID",entity.QuantityDiscountTableId)
					, new SqlParameter("@QuantityDiscountTableGUID",entity.QuantityDiscountTableGuid ?? (object)DBNull.Value)
					, new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId ?? (object)DBNull.Value)
					, new SqlParameter("@LowQuantity",entity.LowQuantity)
					, new SqlParameter("@HighQuantity",entity.HighQuantity)
					, new SqlParameter("@DiscountPercent",entity.DiscountPercent)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetQuantityDiscountTable(entity.QuantityDiscountTableId);
		}

		public virtual bool DeleteQuantityDiscountTable(System.Int32 QuantityDiscountTableId)
		{

			string sql="delete from QuantityDiscountTable where QuantityDiscountTableID=@QuantityDiscountTableID";
			SqlParameter parameter=new SqlParameter("@QuantityDiscountTableID",QuantityDiscountTableId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(QuantityDiscountTable))]
		public virtual QuantityDiscountTable DeleteQuantityDiscountTable(QuantityDiscountTable entity)
		{
			this.DeleteQuantityDiscountTable(entity.QuantityDiscountTableId);
			return entity;
		}


		public virtual QuantityDiscountTable QuantityDiscountTableFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			QuantityDiscountTable entity=new QuantityDiscountTable();
			entity.QuantityDiscountTableId = (System.Int32)dr["QuantityDiscountTableID"];
			entity.QuantityDiscountTableGuid = dr["QuantityDiscountTableGUID"]==DBNull.Value?(System.Guid?)null:(System.Guid?)dr["QuantityDiscountTableGUID"];
			entity.QuantityDiscountId = dr["QuantityDiscountID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["QuantityDiscountID"];
			entity.LowQuantity = (System.Int32)dr["LowQuantity"];
			entity.HighQuantity = (System.Int32)dr["HighQuantity"];
			entity.DiscountPercent = (System.Decimal)dr["DiscountPercent"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
