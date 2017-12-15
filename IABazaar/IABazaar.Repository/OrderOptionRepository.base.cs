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
		
	public abstract partial class OrderOptionRepositoryBase : Repository 
	{
        
        public OrderOptionRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("OrderOptionID",new SearchColumn(){Name="OrderOptionID",Title="OrderOptionID",SelectClause="OrderOptionID",WhereClause="AllRecords.OrderOptionID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderOptionGUID",new SearchColumn(){Name="OrderOptionGUID",Title="OrderOptionGUID",SelectClause="OrderOptionGUID",WhereClause="AllRecords.OrderOptionGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Cost",new SearchColumn(){Name="Cost",Title="Cost",SelectClause="Cost",WhereClause="AllRecords.Cost",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DefaultIsChecked",new SearchColumn(){Name="DefaultIsChecked",Title="DefaultIsChecked",SelectClause="DefaultIsChecked",WhereClause="AllRecords.DefaultIsChecked",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetOrderOptionSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetOrderOptionBasicSearchColumns()
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

        public virtual List<SearchColumn> GetOrderOptionAdvanceSearchColumns()
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
        
        
        public virtual string GetOrderOptionSelectClause()
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
                        	selectQuery =  "OrderOption."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",OrderOption."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual OrderOption GetOrderOption(System.Int32 OrderOptionId)
		{

			string sql=GetOrderOptionSelectClause();
			sql+="from OrderOption where OrderOptionID=@OrderOptionID ";
			SqlParameter parameter=new SqlParameter("@OrderOptionID",OrderOptionId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return OrderOptionFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<OrderOption> GetAllOrderOption()
		{

			string sql=GetOrderOptionSelectClause();
			sql+="from OrderOption";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderOption>(ds, OrderOptionFromDataRow);
		}

		public virtual List<OrderOption> GetPagedOrderOption(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetOrderOptionCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [OrderOptionID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([OrderOptionID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [OrderOptionID] ";
            tempsql += " FROM [OrderOption] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("OrderOptionID"))
					tempsql += " , (AllRecords.[OrderOptionID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[OrderOptionID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetOrderOptionSelectClause()+@" FROM [OrderOption], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [OrderOption].[OrderOptionID] = PageIndex.[OrderOptionID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<OrderOption>(ds, OrderOptionFromDataRow);
			}else{ return null;}
		}

		private int GetOrderOptionCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM OrderOption as AllRecords ";
			else
				sql = "SELECT Count(*) FROM OrderOption as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(OrderOption))]
		public virtual OrderOption InsertOrderOption(OrderOption entity)
		{

			OrderOption other=new OrderOption();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into OrderOption ( [OrderOptionGUID]
				,[Name]
				,[Description]
				,[Cost]
				,[DisplayOrder]
				,[DefaultIsChecked]
				,[TaxClassID]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @OrderOptionGUID
				, @Name
				, @Description
				, @Cost
				, @DisplayOrder
				, @DefaultIsChecked
				, @TaxClassID
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderOptionID",entity.OrderOptionId)
					, new SqlParameter("@OrderOptionGUID",entity.OrderOptionGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Cost",entity.Cost)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@DefaultIsChecked",entity.DefaultIsChecked)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetOrderOption(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(OrderOption))]
		public virtual OrderOption UpdateOrderOption(OrderOption entity)
		{

			if (entity.IsTransient()) return entity;
			OrderOption other = GetOrderOption(entity.OrderOptionId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update OrderOption set  [OrderOptionGUID]=@OrderOptionGUID
							, [Name]=@Name
							, [Description]=@Description
							, [Cost]=@Cost
							, [DisplayOrder]=@DisplayOrder
							, [DefaultIsChecked]=@DefaultIsChecked
							, [TaxClassID]=@TaxClassID
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where OrderOptionID=@OrderOptionID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderOptionID",entity.OrderOptionId)
					, new SqlParameter("@OrderOptionGUID",entity.OrderOptionGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@Cost",entity.Cost)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@DefaultIsChecked",entity.DefaultIsChecked)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetOrderOption(entity.OrderOptionId);
		}

		public virtual bool DeleteOrderOption(System.Int32 OrderOptionId)
		{

			string sql="delete from OrderOption where OrderOptionID=@OrderOptionID";
			SqlParameter parameter=new SqlParameter("@OrderOptionID",OrderOptionId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(OrderOption))]
		public virtual OrderOption DeleteOrderOption(OrderOption entity)
		{
			this.DeleteOrderOption(entity.OrderOptionId);
			return entity;
		}


		public virtual OrderOption OrderOptionFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			OrderOption entity=new OrderOption();
			entity.OrderOptionId = (System.Int32)dr["OrderOptionID"];
			entity.OrderOptionGuid = (System.Guid)dr["OrderOptionGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.Cost = (System.Decimal)dr["Cost"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.DefaultIsChecked = (System.Byte)dr["DefaultIsChecked"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
