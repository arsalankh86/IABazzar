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
		
	public abstract partial class QuantityDiscountRepositoryBase : Repository 
	{
        
        public QuantityDiscountRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("QuantityDiscountID",new SearchColumn(){Name="QuantityDiscountID",Title="QuantityDiscountID",SelectClause="QuantityDiscountID",WhereClause="AllRecords.QuantityDiscountID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuantityDiscountGUID",new SearchColumn(){Name="QuantityDiscountGUID",Title="QuantityDiscountGUID",SelectClause="QuantityDiscountGUID",WhereClause="AllRecords.QuantityDiscountGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DiscountType",new SearchColumn(){Name="DiscountType",Title="DiscountType",SelectClause="DiscountType",WhereClause="AllRecords.DiscountType",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetQuantityDiscountSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetQuantityDiscountBasicSearchColumns()
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

        public virtual List<SearchColumn> GetQuantityDiscountAdvanceSearchColumns()
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
        
        
        public virtual string GetQuantityDiscountSelectClause()
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
                        	selectQuery =  "QuantityDiscount."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",QuantityDiscount."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual QuantityDiscount GetQuantityDiscount(System.Int32 QuantityDiscountId)
		{

			string sql=GetQuantityDiscountSelectClause();
			sql+="from QuantityDiscount where QuantityDiscountID=@QuantityDiscountID ";
			SqlParameter parameter=new SqlParameter("@QuantityDiscountID",QuantityDiscountId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return QuantityDiscountFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<QuantityDiscount> GetAllQuantityDiscount()
		{

			string sql=GetQuantityDiscountSelectClause();
			sql+="from QuantityDiscount";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<QuantityDiscount>(ds, QuantityDiscountFromDataRow);
		}

		public virtual List<QuantityDiscount> GetPagedQuantityDiscount(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetQuantityDiscountCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [QuantityDiscountID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([QuantityDiscountID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [QuantityDiscountID] ";
            tempsql += " FROM [QuantityDiscount] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("QuantityDiscountID"))
					tempsql += " , (AllRecords.[QuantityDiscountID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[QuantityDiscountID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetQuantityDiscountSelectClause()+@" FROM [QuantityDiscount], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [QuantityDiscount].[QuantityDiscountID] = PageIndex.[QuantityDiscountID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<QuantityDiscount>(ds, QuantityDiscountFromDataRow);
			}else{ return null;}
		}

		private int GetQuantityDiscountCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM QuantityDiscount as AllRecords ";
			else
				sql = "SELECT Count(*) FROM QuantityDiscount as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(QuantityDiscount))]
		public virtual QuantityDiscount InsertQuantityDiscount(QuantityDiscount entity)
		{

			QuantityDiscount other=new QuantityDiscount();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into QuantityDiscount ( [QuantityDiscountGUID]
				,[Name]
				,[DisplayOrder]
				,[ExtensionData]
				,[DiscountType]
				,[CreatedOn] )
				Values
				( @QuantityDiscountGUID
				, @Name
				, @DisplayOrder
				, @ExtensionData
				, @DiscountType
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId)
					, new SqlParameter("@QuantityDiscountGUID",entity.QuantityDiscountGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@DiscountType",entity.DiscountType)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetQuantityDiscount(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(QuantityDiscount))]
		public virtual QuantityDiscount UpdateQuantityDiscount(QuantityDiscount entity)
		{

			if (entity.IsTransient()) return entity;
			QuantityDiscount other = GetQuantityDiscount(entity.QuantityDiscountId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update QuantityDiscount set  [QuantityDiscountGUID]=@QuantityDiscountGUID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [DiscountType]=@DiscountType
							, [CreatedOn]=@CreatedOn 
							 where QuantityDiscountID=@QuantityDiscountID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@QuantityDiscountID",entity.QuantityDiscountId)
					, new SqlParameter("@QuantityDiscountGUID",entity.QuantityDiscountGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@DiscountType",entity.DiscountType)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetQuantityDiscount(entity.QuantityDiscountId);
		}

		public virtual bool DeleteQuantityDiscount(System.Int32 QuantityDiscountId)
		{

			string sql="delete from QuantityDiscount where QuantityDiscountID=@QuantityDiscountID";
			SqlParameter parameter=new SqlParameter("@QuantityDiscountID",QuantityDiscountId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(QuantityDiscount))]
		public virtual QuantityDiscount DeleteQuantityDiscount(QuantityDiscount entity)
		{
			this.DeleteQuantityDiscount(entity.QuantityDiscountId);
			return entity;
		}


		public virtual QuantityDiscount QuantityDiscountFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			QuantityDiscount entity=new QuantityDiscount();
			entity.QuantityDiscountId = (System.Int32)dr["QuantityDiscountID"];
			entity.QuantityDiscountGuid = (System.Guid)dr["QuantityDiscountGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.DiscountType = (System.Byte)dr["DiscountType"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
