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
		
	public abstract partial class CouponRepositoryBase : Repository 
	{
        
        public CouponRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CouponID",new SearchColumn(){Name="CouponID",Title="CouponID",SelectClause="CouponID",WhereClause="AllRecords.CouponID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponGUID",new SearchColumn(){Name="CouponGUID",Title="CouponGUID",SelectClause="CouponGUID",WhereClause="AllRecords.CouponGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponCode",new SearchColumn(){Name="CouponCode",Title="CouponCode",SelectClause="CouponCode",WhereClause="AllRecords.CouponCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StartDate",new SearchColumn(){Name="StartDate",Title="StartDate",SelectClause="StartDate",WhereClause="AllRecords.StartDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpirationDate",new SearchColumn(){Name="ExpirationDate",Title="ExpirationDate",SelectClause="ExpirationDate",WhereClause="AllRecords.ExpirationDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DiscountPercent",new SearchColumn(){Name="DiscountPercent",Title="DiscountPercent",SelectClause="DiscountPercent",WhereClause="AllRecords.DiscountPercent",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DiscountAmount",new SearchColumn(){Name="DiscountAmount",Title="DiscountAmount",SelectClause="DiscountAmount",WhereClause="AllRecords.DiscountAmount",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DiscountIncludesFreeShipping",new SearchColumn(){Name="DiscountIncludesFreeShipping",Title="DiscountIncludesFreeShipping",SelectClause="DiscountIncludesFreeShipping",WhereClause="AllRecords.DiscountIncludesFreeShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresOnFirstUseByAnyCustomer",new SearchColumn(){Name="ExpiresOnFirstUseByAnyCustomer",Title="ExpiresOnFirstUseByAnyCustomer",SelectClause="ExpiresOnFirstUseByAnyCustomer",WhereClause="AllRecords.ExpiresOnFirstUseByAnyCustomer",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresAfterOneUsageByEachCustomer",new SearchColumn(){Name="ExpiresAfterOneUsageByEachCustomer",Title="ExpiresAfterOneUsageByEachCustomer",SelectClause="ExpiresAfterOneUsageByEachCustomer",WhereClause="AllRecords.ExpiresAfterOneUsageByEachCustomer",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpiresAfterNUses",new SearchColumn(){Name="ExpiresAfterNUses",Title="ExpiresAfterNUses",SelectClause="ExpiresAfterNUses",WhereClause="AllRecords.ExpiresAfterNUses",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequiresMinimumOrderAmount",new SearchColumn(){Name="RequiresMinimumOrderAmount",Title="RequiresMinimumOrderAmount",SelectClause="RequiresMinimumOrderAmount",WhereClause="AllRecords.RequiresMinimumOrderAmount",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForCustomers",new SearchColumn(){Name="ValidForCustomers",Title="ValidForCustomers",SelectClause="ValidForCustomers",WhereClause="AllRecords.ValidForCustomers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForProducts",new SearchColumn(){Name="ValidForProducts",Title="ValidForProducts",SelectClause="ValidForProducts",WhereClause="AllRecords.ValidForProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForManufacturers",new SearchColumn(){Name="ValidForManufacturers",Title="ValidForManufacturers",SelectClause="ValidForManufacturers",WhereClause="AllRecords.ValidForManufacturers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForCategories",new SearchColumn(){Name="ValidForCategories",Title="ValidForCategories",SelectClause="ValidForCategories",WhereClause="AllRecords.ValidForCategories",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForSections",new SearchColumn(){Name="ValidForSections",Title="ValidForSections",SelectClause="ValidForSections",WhereClause="AllRecords.ValidForSections",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponType",new SearchColumn(){Name="CouponType",Title="CouponType",SelectClause="CouponType",WhereClause="AllRecords.CouponType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NumUses",new SearchColumn(){Name="NumUses",Title="NumUses",SelectClause="NumUses",WhereClause="AllRecords.NumUses",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCouponSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCouponBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCouponAdvanceSearchColumns()
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
        
        
        public virtual string GetCouponSelectClause()
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
                        	selectQuery =  "Coupon."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Coupon."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Coupon GetCoupon(System.Int32 CouponId)
		{

			string sql=GetCouponSelectClause();
			sql+="from Coupon where CouponID=@CouponID ";
			SqlParameter parameter=new SqlParameter("@CouponID",CouponId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CouponFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Coupon> GetAllCoupon()
		{

			string sql=GetCouponSelectClause();
			sql+="from Coupon";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Coupon>(ds, CouponFromDataRow);
		}

		public virtual List<Coupon> GetPagedCoupon(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCouponCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CouponID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CouponID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CouponID] ";
            tempsql += " FROM [Coupon] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CouponID"))
					tempsql += " , (AllRecords.[CouponID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CouponID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCouponSelectClause()+@" FROM [Coupon], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Coupon].[CouponID] = PageIndex.[CouponID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Coupon>(ds, CouponFromDataRow);
			}else{ return null;}
		}

		private int GetCouponCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Coupon as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Coupon as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Coupon))]
		public virtual Coupon InsertCoupon(Coupon entity)
		{

			Coupon other=new Coupon();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Coupon ( [CouponGUID]
				,[CouponCode]
				,[Description]
				,[StartDate]
				,[ExpirationDate]
				,[DiscountPercent]
				,[DiscountAmount]
				,[DiscountIncludesFreeShipping]
				,[ExpiresOnFirstUseByAnyCustomer]
				,[ExpiresAfterOneUsageByEachCustomer]
				,[ExpiresAfterNUses]
				,[RequiresMinimumOrderAmount]
				,[ValidForCustomers]
				,[ValidForProducts]
				,[ValidForManufacturers]
				,[ValidForCategories]
				,[ValidForSections]
				,[CouponType]
				,[NumUses]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @CouponGUID
				, @CouponCode
				, @Description
				, @StartDate
				, @ExpirationDate
				, @DiscountPercent
				, @DiscountAmount
				, @DiscountIncludesFreeShipping
				, @ExpiresOnFirstUseByAnyCustomer
				, @ExpiresAfterOneUsageByEachCustomer
				, @ExpiresAfterNUses
				, @RequiresMinimumOrderAmount
				, @ValidForCustomers
				, @ValidForProducts
				, @ValidForManufacturers
				, @ValidForCategories
				, @ValidForSections
				, @CouponType
				, @NumUses
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponID",entity.CouponId)
					, new SqlParameter("@CouponGUID",entity.CouponGuid)
					, new SqlParameter("@CouponCode",entity.CouponCode)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@StartDate",entity.StartDate)
					, new SqlParameter("@ExpirationDate",entity.ExpirationDate)
					, new SqlParameter("@DiscountPercent",entity.DiscountPercent)
					, new SqlParameter("@DiscountAmount",entity.DiscountAmount)
					, new SqlParameter("@DiscountIncludesFreeShipping",entity.DiscountIncludesFreeShipping)
					, new SqlParameter("@ExpiresOnFirstUseByAnyCustomer",entity.ExpiresOnFirstUseByAnyCustomer)
					, new SqlParameter("@ExpiresAfterOneUsageByEachCustomer",entity.ExpiresAfterOneUsageByEachCustomer)
					, new SqlParameter("@ExpiresAfterNUses",entity.ExpiresAfterNuses ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresMinimumOrderAmount",entity.RequiresMinimumOrderAmount ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCustomers",entity.ValidForCustomers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForProducts",entity.ValidForProducts ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForManufacturers",entity.ValidForManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCategories",entity.ValidForCategories ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForSections",entity.ValidForSections ?? (object)DBNull.Value)
					, new SqlParameter("@CouponType",entity.CouponType)
					, new SqlParameter("@NumUses",entity.NumUses)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCoupon(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Coupon))]
		public virtual Coupon UpdateCoupon(Coupon entity)
		{

			if (entity.IsTransient()) return entity;
			Coupon other = GetCoupon(entity.CouponId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Coupon set  [CouponGUID]=@CouponGUID
							, [CouponCode]=@CouponCode
							, [Description]=@Description
							, [StartDate]=@StartDate
							, [ExpirationDate]=@ExpirationDate
							, [DiscountPercent]=@DiscountPercent
							, [DiscountAmount]=@DiscountAmount
							, [DiscountIncludesFreeShipping]=@DiscountIncludesFreeShipping
							, [ExpiresOnFirstUseByAnyCustomer]=@ExpiresOnFirstUseByAnyCustomer
							, [ExpiresAfterOneUsageByEachCustomer]=@ExpiresAfterOneUsageByEachCustomer
							, [ExpiresAfterNUses]=@ExpiresAfterNUses
							, [RequiresMinimumOrderAmount]=@RequiresMinimumOrderAmount
							, [ValidForCustomers]=@ValidForCustomers
							, [ValidForProducts]=@ValidForProducts
							, [ValidForManufacturers]=@ValidForManufacturers
							, [ValidForCategories]=@ValidForCategories
							, [ValidForSections]=@ValidForSections
							, [CouponType]=@CouponType
							, [NumUses]=@NumUses
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where CouponID=@CouponID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CouponID",entity.CouponId)
					, new SqlParameter("@CouponGUID",entity.CouponGuid)
					, new SqlParameter("@CouponCode",entity.CouponCode)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@StartDate",entity.StartDate)
					, new SqlParameter("@ExpirationDate",entity.ExpirationDate)
					, new SqlParameter("@DiscountPercent",entity.DiscountPercent)
					, new SqlParameter("@DiscountAmount",entity.DiscountAmount)
					, new SqlParameter("@DiscountIncludesFreeShipping",entity.DiscountIncludesFreeShipping)
					, new SqlParameter("@ExpiresOnFirstUseByAnyCustomer",entity.ExpiresOnFirstUseByAnyCustomer)
					, new SqlParameter("@ExpiresAfterOneUsageByEachCustomer",entity.ExpiresAfterOneUsageByEachCustomer)
					, new SqlParameter("@ExpiresAfterNUses",entity.ExpiresAfterNuses ?? (object)DBNull.Value)
					, new SqlParameter("@RequiresMinimumOrderAmount",entity.RequiresMinimumOrderAmount ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCustomers",entity.ValidForCustomers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForProducts",entity.ValidForProducts ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForManufacturers",entity.ValidForManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCategories",entity.ValidForCategories ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForSections",entity.ValidForSections ?? (object)DBNull.Value)
					, new SqlParameter("@CouponType",entity.CouponType)
					, new SqlParameter("@NumUses",entity.NumUses)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCoupon(entity.CouponId);
		}

		public virtual bool DeleteCoupon(System.Int32 CouponId)
		{

			string sql="delete from Coupon where CouponID=@CouponID";
			SqlParameter parameter=new SqlParameter("@CouponID",CouponId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Coupon))]
		public virtual Coupon DeleteCoupon(Coupon entity)
		{
			this.DeleteCoupon(entity.CouponId);
			return entity;
		}


		public virtual Coupon CouponFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Coupon entity=new Coupon();
			entity.CouponId = (System.Int32)dr["CouponID"];
			entity.CouponGuid = (System.Guid)dr["CouponGUID"];
			entity.CouponCode = dr["CouponCode"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.StartDate = (System.DateTime)dr["StartDate"];
			entity.ExpirationDate = (System.DateTime)dr["ExpirationDate"];
			entity.DiscountPercent = (System.Decimal)dr["DiscountPercent"];
			entity.DiscountAmount = (System.Decimal)dr["DiscountAmount"];
			entity.DiscountIncludesFreeShipping = (System.Byte)dr["DiscountIncludesFreeShipping"];
			entity.ExpiresOnFirstUseByAnyCustomer = (System.Byte)dr["ExpiresOnFirstUseByAnyCustomer"];
			entity.ExpiresAfterOneUsageByEachCustomer = (System.Byte)dr["ExpiresAfterOneUsageByEachCustomer"];
			entity.ExpiresAfterNuses = dr["ExpiresAfterNUses"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ExpiresAfterNUses"];
			entity.RequiresMinimumOrderAmount = dr["RequiresMinimumOrderAmount"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["RequiresMinimumOrderAmount"];
			entity.ValidForCustomers = dr["ValidForCustomers"].ToString();
			entity.ValidForProducts = dr["ValidForProducts"].ToString();
			entity.ValidForManufacturers = dr["ValidForManufacturers"].ToString();
			entity.ValidForCategories = dr["ValidForCategories"].ToString();
			entity.ValidForSections = dr["ValidForSections"].ToString();
			entity.CouponType = (System.Int32)dr["CouponType"];
			entity.NumUses = (System.Int32)dr["NumUses"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
