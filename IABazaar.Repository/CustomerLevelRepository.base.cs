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
		
	public abstract partial class CustomerLevelRepositoryBase : Repository 
	{
        
        public CustomerLevelRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomerLevelID",new SearchColumn(){Name="CustomerLevelID",Title="CustomerLevelID",SelectClause="CustomerLevelID",WhereClause="AllRecords.CustomerLevelID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerLevelGUID",new SearchColumn(){Name="CustomerLevelGUID",Title="CustomerLevelGUID",SelectClause="CustomerLevelGUID",WhereClause="AllRecords.CustomerLevelGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountPercent",new SearchColumn(){Name="LevelDiscountPercent",Title="LevelDiscountPercent",SelectClause="LevelDiscountPercent",WhereClause="AllRecords.LevelDiscountPercent",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountAmount",new SearchColumn(){Name="LevelDiscountAmount",Title="LevelDiscountAmount",SelectClause="LevelDiscountAmount",WhereClause="AllRecords.LevelDiscountAmount",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelHasFreeShipping",new SearchColumn(){Name="LevelHasFreeShipping",Title="LevelHasFreeShipping",SelectClause="LevelHasFreeShipping",WhereClause="AllRecords.LevelHasFreeShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelAllowsQuantityDiscounts",new SearchColumn(){Name="LevelAllowsQuantityDiscounts",Title="LevelAllowsQuantityDiscounts",SelectClause="LevelAllowsQuantityDiscounts",WhereClause="AllRecords.LevelAllowsQuantityDiscounts",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelHasNoTax",new SearchColumn(){Name="LevelHasNoTax",Title="LevelHasNoTax",SelectClause="LevelHasNoTax",WhereClause="AllRecords.LevelHasNoTax",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelAllowsCoupons",new SearchColumn(){Name="LevelAllowsCoupons",Title="LevelAllowsCoupons",SelectClause="LevelAllowsCoupons",WhereClause="AllRecords.LevelAllowsCoupons",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountsApplyToExtendedPrices",new SearchColumn(){Name="LevelDiscountsApplyToExtendedPrices",Title="LevelDiscountsApplyToExtendedPrices",SelectClause="LevelDiscountsApplyToExtendedPrices",WhereClause="AllRecords.LevelDiscountsApplyToExtendedPrices",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelAllowsPO",new SearchColumn(){Name="LevelAllowsPO",Title="LevelAllowsPO",SelectClause="LevelAllowsPO",WhereClause="AllRecords.LevelAllowsPO",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ParentCustomerLevelID",new SearchColumn(){Name="ParentCustomerLevelID",Title="ParentCustomerLevelID",SelectClause="ParentCustomerLevelID",WhereClause="AllRecords.ParentCustomerLevelID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SEName",new SearchColumn(){Name="SEName",Title="SEName",SelectClause="SEName",WhereClause="AllRecords.SEName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TemplateName",new SearchColumn(){Name="TemplateName",Title="TemplateName",SelectClause="TemplateName",WhereClause="AllRecords.TemplateName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomerLevelSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomerLevelBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomerLevelAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomerLevelSelectClause()
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
                        	selectQuery =  "CustomerLevel."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomerLevel."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomerLevel GetCustomerLevel(System.Int32 CustomerLevelId)
		{

			string sql=GetCustomerLevelSelectClause();
			sql+="from CustomerLevel where CustomerLevelID=@CustomerLevelID ";
			SqlParameter parameter=new SqlParameter("@CustomerLevelID",CustomerLevelId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomerLevelFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomerLevel> GetAllCustomerLevel()
		{

			string sql=GetCustomerLevelSelectClause();
			sql+="from CustomerLevel";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerLevel>(ds, CustomerLevelFromDataRow);
		}

		public virtual List<CustomerLevel> GetPagedCustomerLevel(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomerLevelCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomerLevelID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomerLevelID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomerLevelID] ";
            tempsql += " FROM [CustomerLevel] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomerLevelID"))
					tempsql += " , (AllRecords.[CustomerLevelID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomerLevelID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomerLevelSelectClause()+@" FROM [CustomerLevel], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomerLevel].[CustomerLevelID] = PageIndex.[CustomerLevelID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerLevel>(ds, CustomerLevelFromDataRow);
			}else{ return null;}
		}

		private int GetCustomerLevelCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomerLevel as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomerLevel as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomerLevel))]
		public virtual CustomerLevel InsertCustomerLevel(CustomerLevel entity)
		{

			CustomerLevel other=new CustomerLevel();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomerLevel ( [CustomerLevelGUID]
				,[Name]
				,[LevelDiscountPercent]
				,[LevelDiscountAmount]
				,[LevelHasFreeShipping]
				,[LevelAllowsQuantityDiscounts]
				,[LevelHasNoTax]
				,[LevelAllowsCoupons]
				,[LevelDiscountsApplyToExtendedPrices]
				,[LevelAllowsPO]
				,[DisplayOrder]
				,[ParentCustomerLevelID]
				,[SEName]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn]
				,[SkinID]
				,[TemplateName] )
				Values
				( @CustomerLevelGUID
				, @Name
				, @LevelDiscountPercent
				, @LevelDiscountAmount
				, @LevelHasFreeShipping
				, @LevelAllowsQuantityDiscounts
				, @LevelHasNoTax
				, @LevelAllowsCoupons
				, @LevelDiscountsApplyToExtendedPrices
				, @LevelAllowsPO
				, @DisplayOrder
				, @ParentCustomerLevelID
				, @SEName
				, @ExtensionData
				, @Deleted
				, @CreatedOn
				, @SkinID
				, @TemplateName );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@CustomerLevelGUID",entity.CustomerLevelGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@LevelDiscountPercent",entity.LevelDiscountPercent)
					, new SqlParameter("@LevelDiscountAmount",entity.LevelDiscountAmount)
					, new SqlParameter("@LevelHasFreeShipping",entity.LevelHasFreeShipping)
					, new SqlParameter("@LevelAllowsQuantityDiscounts",entity.LevelAllowsQuantityDiscounts)
					, new SqlParameter("@LevelHasNoTax",entity.LevelHasNoTax)
					, new SqlParameter("@LevelAllowsCoupons",entity.LevelAllowsCoupons)
					, new SqlParameter("@LevelDiscountsApplyToExtendedPrices",entity.LevelDiscountsApplyToExtendedPrices)
					, new SqlParameter("@LevelAllowsPO",entity.LevelAllowsPo)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ParentCustomerLevelID",entity.ParentCustomerLevelId)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomerLevel(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomerLevel))]
		public virtual CustomerLevel UpdateCustomerLevel(CustomerLevel entity)
		{

			if (entity.IsTransient()) return entity;
			CustomerLevel other = GetCustomerLevel(entity.CustomerLevelId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomerLevel set  [CustomerLevelGUID]=@CustomerLevelGUID
							, [Name]=@Name
							, [LevelDiscountPercent]=@LevelDiscountPercent
							, [LevelDiscountAmount]=@LevelDiscountAmount
							, [LevelHasFreeShipping]=@LevelHasFreeShipping
							, [LevelAllowsQuantityDiscounts]=@LevelAllowsQuantityDiscounts
							, [LevelHasNoTax]=@LevelHasNoTax
							, [LevelAllowsCoupons]=@LevelAllowsCoupons
							, [LevelDiscountsApplyToExtendedPrices]=@LevelDiscountsApplyToExtendedPrices
							, [LevelAllowsPO]=@LevelAllowsPO
							, [DisplayOrder]=@DisplayOrder
							, [ParentCustomerLevelID]=@ParentCustomerLevelID
							, [SEName]=@SEName
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [SkinID]=@SkinID
							, [TemplateName]=@TemplateName 
							 where CustomerLevelID=@CustomerLevelID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@CustomerLevelGUID",entity.CustomerLevelGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@LevelDiscountPercent",entity.LevelDiscountPercent)
					, new SqlParameter("@LevelDiscountAmount",entity.LevelDiscountAmount)
					, new SqlParameter("@LevelHasFreeShipping",entity.LevelHasFreeShipping)
					, new SqlParameter("@LevelAllowsQuantityDiscounts",entity.LevelAllowsQuantityDiscounts)
					, new SqlParameter("@LevelHasNoTax",entity.LevelHasNoTax)
					, new SqlParameter("@LevelAllowsCoupons",entity.LevelAllowsCoupons)
					, new SqlParameter("@LevelDiscountsApplyToExtendedPrices",entity.LevelDiscountsApplyToExtendedPrices)
					, new SqlParameter("@LevelAllowsPO",entity.LevelAllowsPo)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ParentCustomerLevelID",entity.ParentCustomerLevelId)
					, new SqlParameter("@SEName",entity.SeName ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@TemplateName",entity.TemplateName)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomerLevel(entity.CustomerLevelId);
		}

		public virtual bool DeleteCustomerLevel(System.Int32 CustomerLevelId)
		{

			string sql="delete from CustomerLevel where CustomerLevelID=@CustomerLevelID";
			SqlParameter parameter=new SqlParameter("@CustomerLevelID",CustomerLevelId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomerLevel))]
		public virtual CustomerLevel DeleteCustomerLevel(CustomerLevel entity)
		{
			this.DeleteCustomerLevel(entity.CustomerLevelId);
			return entity;
		}


		public virtual CustomerLevel CustomerLevelFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomerLevel entity=new CustomerLevel();
			entity.CustomerLevelId = (System.Int32)dr["CustomerLevelID"];
			entity.CustomerLevelGuid = (System.Guid)dr["CustomerLevelGUID"];
			entity.Name = dr["Name"].ToString();
			entity.LevelDiscountPercent = (System.Decimal)dr["LevelDiscountPercent"];
			entity.LevelDiscountAmount = (System.Decimal)dr["LevelDiscountAmount"];
			entity.LevelHasFreeShipping = (System.Byte)dr["LevelHasFreeShipping"];
			entity.LevelAllowsQuantityDiscounts = (System.Byte)dr["LevelAllowsQuantityDiscounts"];
			entity.LevelHasNoTax = (System.Byte)dr["LevelHasNoTax"];
			entity.LevelAllowsCoupons = (System.Byte)dr["LevelAllowsCoupons"];
			entity.LevelDiscountsApplyToExtendedPrices = (System.Byte)dr["LevelDiscountsApplyToExtendedPrices"];
			entity.LevelAllowsPo = (System.Byte)dr["LevelAllowsPO"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ParentCustomerLevelId = (System.Int32)dr["ParentCustomerLevelID"];
			entity.SeName = dr["SEName"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.TemplateName = dr["TemplateName"].ToString();
			return entity;
		}

	}
	
	
}
