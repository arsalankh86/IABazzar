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
		
	public abstract partial class GiftCardRepositoryBase : Repository 
	{
        
        public GiftCardRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("GiftCardID",new SearchColumn(){Name="GiftCardID",Title="GiftCardID",SelectClause="GiftCardID",WhereClause="AllRecords.GiftCardID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftCardGUID",new SearchColumn(){Name="GiftCardGUID",Title="GiftCardGUID",SelectClause="GiftCardGUID",WhereClause="AllRecords.GiftCardGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SerialNumber",new SearchColumn(){Name="SerialNumber",Title="SerialNumber",SelectClause="SerialNumber",WhereClause="AllRecords.SerialNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PurchasedByCustomerID",new SearchColumn(){Name="PurchasedByCustomerID",Title="PurchasedByCustomerID",SelectClause="PurchasedByCustomerID",WhereClause="AllRecords.PurchasedByCustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShoppingCartRecID",new SearchColumn(){Name="ShoppingCartRecID",Title="ShoppingCartRecID",SelectClause="ShoppingCartRecID",WhereClause="AllRecords.ShoppingCartRecID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InitialAmount",new SearchColumn(){Name="InitialAmount",Title="InitialAmount",SelectClause="InitialAmount",WhereClause="AllRecords.InitialAmount",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Balance",new SearchColumn(){Name="Balance",Title="Balance",SelectClause="Balance",WhereClause="AllRecords.Balance",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StartDate",new SearchColumn(){Name="StartDate",Title="StartDate",SelectClause="StartDate",WhereClause="AllRecords.StartDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExpirationDate",new SearchColumn(){Name="ExpirationDate",Title="ExpirationDate",SelectClause="ExpirationDate",WhereClause="AllRecords.ExpirationDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftCardTypeID",new SearchColumn(){Name="GiftCardTypeID",Title="GiftCardTypeID",SelectClause="GiftCardTypeID",WhereClause="AllRecords.GiftCardTypeID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EMailName",new SearchColumn(){Name="EMailName",Title="EMailName",SelectClause="EMailName",WhereClause="AllRecords.EMailName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EMailTo",new SearchColumn(){Name="EMailTo",Title="EMailTo",SelectClause="EMailTo",WhereClause="AllRecords.EMailTo",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EMailMessage",new SearchColumn(){Name="EMailMessage",Title="EMailMessage",SelectClause="EMailMessage",WhereClause="AllRecords.EMailMessage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForCustomers",new SearchColumn(){Name="ValidForCustomers",Title="ValidForCustomers",SelectClause="ValidForCustomers",WhereClause="AllRecords.ValidForCustomers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForProducts",new SearchColumn(){Name="ValidForProducts",Title="ValidForProducts",SelectClause="ValidForProducts",WhereClause="AllRecords.ValidForProducts",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForManufacturers",new SearchColumn(){Name="ValidForManufacturers",Title="ValidForManufacturers",SelectClause="ValidForManufacturers",WhereClause="AllRecords.ValidForManufacturers",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForCategories",new SearchColumn(){Name="ValidForCategories",Title="ValidForCategories",SelectClause="ValidForCategories",WhereClause="AllRecords.ValidForCategories",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ValidForSections",new SearchColumn(){Name="ValidForSections",Title="ValidForSections",SelectClause="ValidForSections",WhereClause="AllRecords.ValidForSections",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisabledByAdministrator",new SearchColumn(){Name="DisabledByAdministrator",Title="DisabledByAdministrator",SelectClause="DisabledByAdministrator",WhereClause="AllRecords.DisabledByAdministrator",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetGiftCardSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetGiftCardBasicSearchColumns()
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

        public virtual List<SearchColumn> GetGiftCardAdvanceSearchColumns()
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
        
        
        public virtual string GetGiftCardSelectClause()
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
                        	selectQuery =  "GiftCard."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",GiftCard."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual GiftCard GetGiftCard(System.Int32 GiftCardId)
		{

			string sql=GetGiftCardSelectClause();
			sql+="from GiftCard where GiftCardID=@GiftCardID ";
			SqlParameter parameter=new SqlParameter("@GiftCardID",GiftCardId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return GiftCardFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<GiftCard> GetAllGiftCard()
		{

			string sql=GetGiftCardSelectClause();
			sql+="from GiftCard";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GiftCard>(ds, GiftCardFromDataRow);
		}

		public virtual List<GiftCard> GetPagedGiftCard(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetGiftCardCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [GiftCardID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([GiftCardID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [GiftCardID] ";
            tempsql += " FROM [GiftCard] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("GiftCardID"))
					tempsql += " , (AllRecords.[GiftCardID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[GiftCardID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetGiftCardSelectClause()+@" FROM [GiftCard], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [GiftCard].[GiftCardID] = PageIndex.[GiftCardID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<GiftCard>(ds, GiftCardFromDataRow);
			}else{ return null;}
		}

		private int GetGiftCardCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM GiftCard as AllRecords ";
			else
				sql = "SELECT Count(*) FROM GiftCard as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(GiftCard))]
		public virtual GiftCard InsertGiftCard(GiftCard entity)
		{

			GiftCard other=new GiftCard();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into GiftCard ( [GiftCardGUID]
				,[SerialNumber]
				,[PurchasedByCustomerID]
				,[OrderNumber]
				,[ShoppingCartRecID]
				,[ProductID]
				,[VariantID]
				,[InitialAmount]
				,[Balance]
				,[StartDate]
				,[ExpirationDate]
				,[GiftCardTypeID]
				,[EMailName]
				,[EMailTo]
				,[EMailMessage]
				,[ValidForCustomers]
				,[ValidForProducts]
				,[ValidForManufacturers]
				,[ValidForCategories]
				,[ValidForSections]
				,[DisabledByAdministrator]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @GiftCardGUID
				, @SerialNumber
				, @PurchasedByCustomerID
				, @OrderNumber
				, @ShoppingCartRecID
				, @ProductID
				, @VariantID
				, @InitialAmount
				, @Balance
				, @StartDate
				, @ExpirationDate
				, @GiftCardTypeID
				, @EMailName
				, @EMailTo
				, @EMailMessage
				, @ValidForCustomers
				, @ValidForProducts
				, @ValidForManufacturers
				, @ValidForCategories
				, @ValidForSections
				, @DisabledByAdministrator
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GiftCardID",entity.GiftCardId)
					, new SqlParameter("@GiftCardGUID",entity.GiftCardGuid)
					, new SqlParameter("@SerialNumber",entity.SerialNumber ?? (object)DBNull.Value)
					, new SqlParameter("@PurchasedByCustomerID",entity.PurchasedByCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@InitialAmount",entity.InitialAmount)
					, new SqlParameter("@Balance",entity.Balance)
					, new SqlParameter("@StartDate",entity.StartDate)
					, new SqlParameter("@ExpirationDate",entity.ExpirationDate)
					, new SqlParameter("@GiftCardTypeID",entity.GiftCardTypeId ?? (object)DBNull.Value)
					, new SqlParameter("@EMailName",entity.EmailName ?? (object)DBNull.Value)
					, new SqlParameter("@EMailTo",entity.EmailTo ?? (object)DBNull.Value)
					, new SqlParameter("@EMailMessage",entity.EmailMessage ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCustomers",entity.ValidForCustomers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForProducts",entity.ValidForProducts ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForManufacturers",entity.ValidForManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCategories",entity.ValidForCategories ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForSections",entity.ValidForSections ?? (object)DBNull.Value)
					, new SqlParameter("@DisabledByAdministrator",entity.DisabledByAdministrator)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetGiftCard(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(GiftCard))]
		public virtual GiftCard UpdateGiftCard(GiftCard entity)
		{

			if (entity.IsTransient()) return entity;
			GiftCard other = GetGiftCard(entity.GiftCardId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update GiftCard set  [GiftCardGUID]=@GiftCardGUID
							, [SerialNumber]=@SerialNumber
							, [PurchasedByCustomerID]=@PurchasedByCustomerID
							, [OrderNumber]=@OrderNumber
							, [ShoppingCartRecID]=@ShoppingCartRecID
							, [ProductID]=@ProductID
							, [VariantID]=@VariantID
							, [InitialAmount]=@InitialAmount
							, [Balance]=@Balance
							, [StartDate]=@StartDate
							, [ExpirationDate]=@ExpirationDate
							, [GiftCardTypeID]=@GiftCardTypeID
							, [EMailName]=@EMailName
							, [EMailTo]=@EMailTo
							, [EMailMessage]=@EMailMessage
							, [ValidForCustomers]=@ValidForCustomers
							, [ValidForProducts]=@ValidForProducts
							, [ValidForManufacturers]=@ValidForManufacturers
							, [ValidForCategories]=@ValidForCategories
							, [ValidForSections]=@ValidForSections
							, [DisabledByAdministrator]=@DisabledByAdministrator
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where GiftCardID=@GiftCardID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GiftCardID",entity.GiftCardId)
					, new SqlParameter("@GiftCardGUID",entity.GiftCardGuid)
					, new SqlParameter("@SerialNumber",entity.SerialNumber ?? (object)DBNull.Value)
					, new SqlParameter("@PurchasedByCustomerID",entity.PurchasedByCustomerId)
					, new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@ShoppingCartRecID",entity.ShoppingCartRecId)
					, new SqlParameter("@ProductID",entity.ProductId)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@InitialAmount",entity.InitialAmount)
					, new SqlParameter("@Balance",entity.Balance)
					, new SqlParameter("@StartDate",entity.StartDate)
					, new SqlParameter("@ExpirationDate",entity.ExpirationDate)
					, new SqlParameter("@GiftCardTypeID",entity.GiftCardTypeId ?? (object)DBNull.Value)
					, new SqlParameter("@EMailName",entity.EmailName ?? (object)DBNull.Value)
					, new SqlParameter("@EMailTo",entity.EmailTo ?? (object)DBNull.Value)
					, new SqlParameter("@EMailMessage",entity.EmailMessage ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCustomers",entity.ValidForCustomers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForProducts",entity.ValidForProducts ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForManufacturers",entity.ValidForManufacturers ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForCategories",entity.ValidForCategories ?? (object)DBNull.Value)
					, new SqlParameter("@ValidForSections",entity.ValidForSections ?? (object)DBNull.Value)
					, new SqlParameter("@DisabledByAdministrator",entity.DisabledByAdministrator)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetGiftCard(entity.GiftCardId);
		}

		public virtual bool DeleteGiftCard(System.Int32 GiftCardId)
		{

			string sql="delete from GiftCard where GiftCardID=@GiftCardID";
			SqlParameter parameter=new SqlParameter("@GiftCardID",GiftCardId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(GiftCard))]
		public virtual GiftCard DeleteGiftCard(GiftCard entity)
		{
			this.DeleteGiftCard(entity.GiftCardId);
			return entity;
		}


		public virtual GiftCard GiftCardFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			GiftCard entity=new GiftCard();
			entity.GiftCardId = (System.Int32)dr["GiftCardID"];
			entity.GiftCardGuid = (System.Guid)dr["GiftCardGUID"];
			entity.SerialNumber = dr["SerialNumber"].ToString();
			entity.PurchasedByCustomerId = (System.Int32)dr["PurchasedByCustomerID"];
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.ShoppingCartRecId = (System.Int32)dr["ShoppingCartRecID"];
			entity.ProductId = (System.Int32)dr["ProductID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.InitialAmount = (System.Decimal)dr["InitialAmount"];
			entity.Balance = (System.Decimal)dr["Balance"];
			entity.StartDate = (System.DateTime)dr["StartDate"];
			entity.ExpirationDate = (System.DateTime)dr["ExpirationDate"];
			entity.GiftCardTypeId = dr["GiftCardTypeID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["GiftCardTypeID"];
			entity.EmailName = dr["EMailName"].ToString();
			entity.EmailTo = dr["EMailTo"].ToString();
			entity.EmailMessage = dr["EMailMessage"].ToString();
			entity.ValidForCustomers = dr["ValidForCustomers"].ToString();
			entity.ValidForProducts = dr["ValidForProducts"].ToString();
			entity.ValidForManufacturers = dr["ValidForManufacturers"].ToString();
			entity.ValidForCategories = dr["ValidForCategories"].ToString();
			entity.ValidForSections = dr["ValidForSections"].ToString();
			entity.DisabledByAdministrator = (System.Byte)dr["DisabledByAdministrator"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
