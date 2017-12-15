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
		
	public abstract partial class CustomerRepositoryBase : Repository 
	{
        
        public CustomerRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerGUID",new SearchColumn(){Name="CustomerGUID",Title="CustomerGUID",SelectClause="CustomerGUID",WhereClause="AllRecords.CustomerGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerLevelID",new SearchColumn(){Name="CustomerLevelID",Title="CustomerLevelID",SelectClause="CustomerLevelID",WhereClause="AllRecords.CustomerLevelID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RegisterDate",new SearchColumn(){Name="RegisterDate",Title="RegisterDate",SelectClause="RegisterDate",WhereClause="AllRecords.RegisterDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Password",new SearchColumn(){Name="Password",Title="Password",SelectClause="Password",WhereClause="AllRecords.Password",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SaltKey",new SearchColumn(){Name="SaltKey",Title="SaltKey",SelectClause="SaltKey",WhereClause="AllRecords.SaltKey",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DateOfBirth",new SearchColumn(){Name="DateOfBirth",Title="DateOfBirth",SelectClause="DateOfBirth",WhereClause="AllRecords.DateOfBirth",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Gender",new SearchColumn(){Name="Gender",Title="Gender",SelectClause="Gender",WhereClause="AllRecords.Gender",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FirstName",new SearchColumn(){Name="FirstName",Title="FirstName",SelectClause="FirstName",WhereClause="AllRecords.FirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastName",new SearchColumn(){Name="LastName",Title="LastName",SelectClause="LastName",WhereClause="AllRecords.LastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Phone",new SearchColumn(){Name="Phone",Title="Phone",SelectClause="Phone",WhereClause="AllRecords.Phone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FAX",new SearchColumn(){Name="FAX",Title="FAX",SelectClause="FAX",WhereClause="AllRecords.FAX",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AffiliateID",new SearchColumn(){Name="AffiliateID",Title="AffiliateID",SelectClause="AffiliateID",WhereClause="AllRecords.AffiliateID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Referrer",new SearchColumn(){Name="Referrer",Title="Referrer",SelectClause="Referrer",WhereClause="AllRecords.Referrer",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponCode",new SearchColumn(){Name="CouponCode",Title="CouponCode",SelectClause="CouponCode",WhereClause="AllRecords.CouponCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OkToEmail",new SearchColumn(){Name="OkToEmail",Title="OkToEmail",SelectClause="OkToEmail",WhereClause="AllRecords.OkToEmail",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsAdmin",new SearchColumn(){Name="IsAdmin",Title="IsAdmin",SelectClause="IsAdmin",WhereClause="AllRecords.IsAdmin",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingEqualsShipping",new SearchColumn(){Name="BillingEqualsShipping",Title="BillingEqualsShipping",SelectClause="BillingEqualsShipping",WhereClause="AllRecords.BillingEqualsShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastIPAddress",new SearchColumn(){Name="LastIPAddress",Title="LastIPAddress",SelectClause="LastIPAddress",WhereClause="AllRecords.LastIPAddress",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNotes",new SearchColumn(){Name="OrderNotes",Title="OrderNotes",SelectClause="OrderNotes",WhereClause="AllRecords.OrderNotes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SubscriptionExpiresOn",new SearchColumn(){Name="SubscriptionExpiresOn",Title="SubscriptionExpiresOn",SelectClause="SubscriptionExpiresOn",WhereClause="AllRecords.SubscriptionExpiresOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RTShipRequest",new SearchColumn(){Name="RTShipRequest",Title="RTShipRequest",SelectClause="RTShipRequest",WhereClause="AllRecords.RTShipRequest",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RTShipResponse",new SearchColumn(){Name="RTShipResponse",Title="RTShipResponse",SelectClause="RTShipResponse",WhereClause="AllRecords.RTShipResponse",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderOptions",new SearchColumn(){Name="OrderOptions",Title="OrderOptions",SelectClause="OrderOptions",WhereClause="AllRecords.OrderOptions",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSetting",new SearchColumn(){Name="LocaleSetting",Title="LocaleSetting",SelectClause="LocaleSetting",WhereClause="AllRecords.LocaleSetting",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MicroPayBalance",new SearchColumn(){Name="MicroPayBalance",Title="MicroPayBalance",SelectClause="MicroPayBalance",WhereClause="AllRecords.MicroPayBalance",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringShippingMethodID",new SearchColumn(){Name="RecurringShippingMethodID",Title="RecurringShippingMethodID",SelectClause="RecurringShippingMethodID",WhereClause="AllRecords.RecurringShippingMethodID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringShippingMethod",new SearchColumn(){Name="RecurringShippingMethod",Title="RecurringShippingMethod",SelectClause="RecurringShippingMethod",WhereClause="AllRecords.RecurringShippingMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingAddressID",new SearchColumn(){Name="BillingAddressID",Title="BillingAddressID",SelectClause="BillingAddressID",WhereClause="AllRecords.BillingAddressID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingAddressID",new SearchColumn(){Name="ShippingAddressID",Title="ShippingAddressID",SelectClause="ShippingAddressID",WhereClause="AllRecords.ShippingAddressID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryGUID",new SearchColumn(){Name="GiftRegistryGUID",Title="GiftRegistryGUID",SelectClause="GiftRegistryGUID",WhereClause="AllRecords.GiftRegistryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryIsAnonymous",new SearchColumn(){Name="GiftRegistryIsAnonymous",Title="GiftRegistryIsAnonymous",SelectClause="GiftRegistryIsAnonymous",WhereClause="AllRecords.GiftRegistryIsAnonymous",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryAllowSearchByOthers",new SearchColumn(){Name="GiftRegistryAllowSearchByOthers",Title="GiftRegistryAllowSearchByOthers",SelectClause="GiftRegistryAllowSearchByOthers",WhereClause="AllRecords.GiftRegistryAllowSearchByOthers",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryNickName",new SearchColumn(){Name="GiftRegistryNickName",Title="GiftRegistryNickName",SelectClause="GiftRegistryNickName",WhereClause="AllRecords.GiftRegistryNickName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GiftRegistryHideShippingAddresses",new SearchColumn(){Name="GiftRegistryHideShippingAddresses",Title="GiftRegistryHideShippingAddresses",SelectClause="GiftRegistryHideShippingAddresses",WhereClause="AllRecords.GiftRegistryHideShippingAddresses",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CODCompanyCheckAllowed",new SearchColumn(){Name="CODCompanyCheckAllowed",Title="CODCompanyCheckAllowed",SelectClause="CODCompanyCheckAllowed",WhereClause="AllRecords.CODCompanyCheckAllowed",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CODNet30Allowed",new SearchColumn(){Name="CODNet30Allowed",Title="CODNet30Allowed",SelectClause="CODNet30Allowed",WhereClause="AllRecords.CODNet30Allowed",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FinalizationData",new SearchColumn(){Name="FinalizationData",Title="FinalizationData",SelectClause="FinalizationData",WhereClause="AllRecords.FinalizationData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Over13Checked",new SearchColumn(){Name="Over13Checked",Title="Over13Checked",SelectClause="Over13Checked",WhereClause="AllRecords.Over13Checked",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CurrencySetting",new SearchColumn(){Name="CurrencySetting",Title="CurrencySetting",SelectClause="CurrencySetting",WhereClause="AllRecords.CurrencySetting",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VATSetting",new SearchColumn(){Name="VATSetting",Title="VATSetting",SelectClause="VATSetting",WhereClause="AllRecords.VATSetting",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VATRegistrationID",new SearchColumn(){Name="VATRegistrationID",Title="VATRegistrationID",SelectClause="VATRegistrationID",WhereClause="AllRecords.VATRegistrationID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreCCInDB",new SearchColumn(){Name="StoreCCInDB",Title="StoreCCInDB",SelectClause="StoreCCInDB",WhereClause="AllRecords.StoreCCInDB",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsRegistered",new SearchColumn(){Name="IsRegistered",Title="IsRegistered",SelectClause="IsRegistered",WhereClause="AllRecords.IsRegistered",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LockedUntil",new SearchColumn(){Name="LockedUntil",Title="LockedUntil",SelectClause="LockedUntil",WhereClause="AllRecords.LockedUntil",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AdminCanViewCC",new SearchColumn(){Name="AdminCanViewCC",Title="AdminCanViewCC",SelectClause="AdminCanViewCC",WhereClause="AllRecords.AdminCanViewCC",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PwdChanged",new SearchColumn(){Name="PwdChanged",Title="PwdChanged",SelectClause="PwdChanged",WhereClause="AllRecords.PwdChanged",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BadLoginCount",new SearchColumn(){Name="BadLoginCount",Title="BadLoginCount",SelectClause="BadLoginCount",WhereClause="AllRecords.BadLoginCount",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastBadLogin",new SearchColumn(){Name="LastBadLogin",Title="LastBadLogin",SelectClause="LastBadLogin",WhereClause="AllRecords.LastBadLogin",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Active",new SearchColumn(){Name="Active",Title="Active",SelectClause="Active",WhereClause="AllRecords.Active",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PwdChangeRequired",new SearchColumn(){Name="PwdChangeRequired",Title="PwdChangeRequired",SelectClause="PwdChangeRequired",WhereClause="AllRecords.PwdChangeRequired",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RequestedPaymentMethod",new SearchColumn(){Name="RequestedPaymentMethod",Title="RequestedPaymentMethod",SelectClause="RequestedPaymentMethod",WhereClause="AllRecords.RequestedPaymentMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BuySafe",new SearchColumn(){Name="BuySafe",Title="BuySafe",SelectClause="BuySafe",WhereClause="AllRecords.BuySafe",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomerSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomerBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomerAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomerSelectClause()
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
                        	selectQuery =  "Customer."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Customer."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Customer GetCustomer(System.Int32 CustomerId)
		{

			string sql=GetCustomerSelectClause();
			sql+="from Customer where CustomerID=@CustomerID ";
			SqlParameter parameter=new SqlParameter("@CustomerID",CustomerId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomerFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual DataSet GetAllCustomer()
		{

			string sql=GetCustomerSelectClause();
			sql+="from Customer";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
			//return CollectionFromDataSet<Customer>(ds, CustomerFromDataRow);
		}

		public virtual List<Customer> GetPagedCustomer(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomerCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomerID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomerID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomerID] ";
            tempsql += " FROM [Customer] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomerID"))
					tempsql += " , (AllRecords.[CustomerID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomerID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomerSelectClause()+@" FROM [Customer], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Customer].[CustomerID] = PageIndex.[CustomerID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Customer>(ds, CustomerFromDataRow);
			}else{ return null;}
		}

		private int GetCustomerCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Customer as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Customer as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Customer))]
		public virtual Customer InsertCustomer(Customer entity)
		{

			Customer other=new Customer();
			other = entity;
			if(entity.IsTransient())
			{
				string sql= @"Insert into Customer (
				[Email]
				,[Password]
                ,[FirstName]
                ,[LastName]
                ,[LastIpAddress]
				 )
				Values
				(
				 @Email
				, @Password
                ,@FirstName
                ,@LastName
                ,@LastIpAddress
				 );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					 new SqlParameter("@Email",entity.Email)
					, new SqlParameter("@Password",entity.Password ?? (object)DBNull.Value)
                    , new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
                    , new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
                    , new SqlParameter("@LastIpAddress",entity.LastIpAddress ?? (object)DBNull.Value)
					};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomer(Convert.ToInt32(identity));
			}
			return entity;
		}


        [MOLog(AuditOperations.Create, typeof(Customer))]
        public virtual Customer PreInsertCustomer(Customer entity)
        {

            Customer other = new Customer();
            other = entity;
            if (entity.IsTransient())
            {
                string sql = @"Insert into Customer (
				 [Email]
				,[Password]
                ,[FirstName]
                ,[LastName]
                ,[Phone]                 
                 )
				Values
				(
				 @Email
				,@Password
                ,@FirstName
                ,@LastName
                ,@Phone
                 );
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					 new SqlParameter("@Email",entity.Email)
					, new SqlParameter("@Password",entity.Password ?? (object)DBNull.Value)
                    , new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
                    , new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
                    , new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
                    };
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                if (identity == DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
                return GetCustomer(Convert.ToInt32(identity));
            }
            return entity;
        }

		[MOLog(AuditOperations.Update,typeof(Customer))]
		public virtual Customer UpdateCustomer(Customer entity)
		{

			if (entity.IsTransient()) return entity;
			Customer other = GetCustomer(entity.CustomerId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Customer set  [CustomerGUID]=@CustomerGUID
							, [CustomerLevelID]=@CustomerLevelID
							, [StoreID]=@StoreID
							, [RegisterDate]=@RegisterDate
							, [Email]=@Email
							, [Password]=@Password
							, [SaltKey]=@SaltKey
							, [DateOfBirth]=@DateOfBirth
							, [Gender]=@Gender
							, [FirstName]=@FirstName
							, [LastName]=@LastName
							, [Notes]=@Notes
							, [SkinID]=@SkinID
							, [Phone]=@Phone
							, [FAX]=@FAX
							, [AffiliateID]=@AffiliateID
							, [Referrer]=@Referrer
							, [CouponCode]=@CouponCode
							, [OkToEmail]=@OkToEmail
							, [IsAdmin]=@IsAdmin
							, [BillingEqualsShipping]=@BillingEqualsShipping
							, [LastIPAddress]=@LastIPAddress
							, [OrderNotes]=@OrderNotes
							, [SubscriptionExpiresOn]=@SubscriptionExpiresOn
							, [RTShipRequest]=@RTShipRequest
							, [RTShipResponse]=@RTShipResponse
							, [OrderOptions]=@OrderOptions
							, [LocaleSetting]=@LocaleSetting
							, [MicroPayBalance]=@MicroPayBalance
							, [RecurringShippingMethodID]=@RecurringShippingMethodID
							, [RecurringShippingMethod]=@RecurringShippingMethod
							, [BillingAddressID]=@BillingAddressID
							, [ShippingAddressID]=@ShippingAddressID
							, [GiftRegistryGUID]=@GiftRegistryGUID
							, [GiftRegistryIsAnonymous]=@GiftRegistryIsAnonymous
							, [GiftRegistryAllowSearchByOthers]=@GiftRegistryAllowSearchByOthers
							, [GiftRegistryNickName]=@GiftRegistryNickName
							, [GiftRegistryHideShippingAddresses]=@GiftRegistryHideShippingAddresses
							, [CODCompanyCheckAllowed]=@CODCompanyCheckAllowed
							, [CODNet30Allowed]=@CODNet30Allowed
							, [ExtensionData]=@ExtensionData
							, [FinalizationData]=@FinalizationData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [Over13Checked]=@Over13Checked
							, [CurrencySetting]=@CurrencySetting
							, [VATSetting]=@VATSetting
							, [VATRegistrationID]=@VATRegistrationID
							, [StoreCCInDB]=@StoreCCInDB
							, [IsRegistered]=@IsRegistered
							, [LockedUntil]=@LockedUntil
							, [AdminCanViewCC]=@AdminCanViewCC
							, [PwdChanged]=@PwdChanged
							, [BadLoginCount]=@BadLoginCount
							, [LastBadLogin]=@LastBadLogin
							, [Active]=@Active
							, [PwdChangeRequired]=@PwdChangeRequired
							, [RequestedPaymentMethod]=@RequestedPaymentMethod
							, [BuySafe]=@BuySafe 
							 where CustomerID=@CustomerID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CustomerGUID",entity.CustomerGuid)
					, new SqlParameter("@CustomerLevelID",entity.CustomerLevelId)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@RegisterDate",entity.RegisterDate)
					, new SqlParameter("@Email",entity.Email)
					, new SqlParameter("@Password",entity.Password ?? (object)DBNull.Value)
					, new SqlParameter("@SaltKey",entity.SaltKey)
					, new SqlParameter("@DateOfBirth",entity.DateOfBirth ?? (object)DBNull.Value)
					, new SqlParameter("@Gender",entity.Gender ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@FAX",entity.Fax ?? (object)DBNull.Value)
					, new SqlParameter("@AffiliateID",entity.AffiliateId ?? (object)DBNull.Value)
					, new SqlParameter("@Referrer",entity.Referrer ?? (object)DBNull.Value)
					, new SqlParameter("@CouponCode",entity.CouponCode ?? (object)DBNull.Value)
					, new SqlParameter("@OkToEmail",entity.OkToEmail)
					, new SqlParameter("@IsAdmin",entity.IsAdmin)
					, new SqlParameter("@BillingEqualsShipping",entity.BillingEqualsShipping)
					, new SqlParameter("@LastIPAddress",entity.LastIpAddress ?? (object)DBNull.Value)
					, new SqlParameter("@OrderNotes",entity.OrderNotes ?? (object)DBNull.Value)
					, new SqlParameter("@SubscriptionExpiresOn",entity.SubscriptionExpiresOn ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipRequest",entity.RtShipRequest ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipResponse",entity.RtShipResponse ?? (object)DBNull.Value)
					, new SqlParameter("@OrderOptions",entity.OrderOptions ?? (object)DBNull.Value)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting)
					, new SqlParameter("@MicroPayBalance",entity.MicroPayBalance)
					, new SqlParameter("@RecurringShippingMethodID",entity.RecurringShippingMethodId)
					, new SqlParameter("@RecurringShippingMethod",entity.RecurringShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddressID",entity.BillingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddressID",entity.ShippingAddressId ?? (object)DBNull.Value)
					, new SqlParameter("@GiftRegistryGUID",entity.GiftRegistryGuid)
					, new SqlParameter("@GiftRegistryIsAnonymous",entity.GiftRegistryIsAnonymous)
					, new SqlParameter("@GiftRegistryAllowSearchByOthers",entity.GiftRegistryAllowSearchByOthers)
					, new SqlParameter("@GiftRegistryNickName",entity.GiftRegistryNickName ?? (object)DBNull.Value)
					, new SqlParameter("@GiftRegistryHideShippingAddresses",entity.GiftRegistryHideShippingAddresses)
					, new SqlParameter("@CODCompanyCheckAllowed",entity.CodCompanyCheckAllowed)
					, new SqlParameter("@CODNet30Allowed",entity.CodNet30Allowed)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@FinalizationData",entity.FinalizationData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@Over13Checked",entity.Over13Checked ?? (object)DBNull.Value)
					, new SqlParameter("@CurrencySetting",entity.CurrencySetting ?? (object)DBNull.Value)
					, new SqlParameter("@VATSetting",entity.VatSetting)
					, new SqlParameter("@VATRegistrationID",entity.VatRegistrationId)
					, new SqlParameter("@StoreCCInDB",entity.StoreCcInDb)
					, new SqlParameter("@IsRegistered",entity.IsRegistered)
					, new SqlParameter("@LockedUntil",entity.LockedUntil ?? (object)DBNull.Value)
					, new SqlParameter("@AdminCanViewCC",entity.AdminCanViewCc)
					, new SqlParameter("@PwdChanged",entity.PwdChanged)
					, new SqlParameter("@BadLoginCount",entity.BadLoginCount)
					, new SqlParameter("@LastBadLogin",entity.LastBadLogin ?? (object)DBNull.Value)
					, new SqlParameter("@Active",entity.Active)
					, new SqlParameter("@PwdChangeRequired",entity.PwdChangeRequired ?? (object)DBNull.Value)
					, new SqlParameter("@RequestedPaymentMethod",entity.RequestedPaymentMethod ?? (object)DBNull.Value)
					, new SqlParameter("@BuySafe",entity.BuySafe ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomer(entity.CustomerId);
		}



		public virtual bool DeleteCustomer(System.Int32 CustomerId)
		{

			string sql="delete from Customer where CustomerID=@CustomerID";
			SqlParameter parameter=new SqlParameter("@CustomerID",CustomerId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Customer))]
		public virtual Customer DeleteCustomer(Customer entity)
		{
			this.DeleteCustomer(entity.CustomerId);
			return entity;
		}


		public virtual Customer CustomerFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Customer entity=new Customer();
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.CustomerGuid = (System.Guid)dr["CustomerGUID"];
			entity.CustomerLevelId = (System.Int32)dr["CustomerLevelID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.RegisterDate = (System.DateTime)dr["RegisterDate"];
			entity.Email = dr["Email"].ToString();
			entity.Password = dr["Password"].ToString();
			entity.SaltKey = (System.Int32)dr["SaltKey"];
			entity.DateOfBirth = dr["DateOfBirth"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["DateOfBirth"];
			entity.Gender = dr["Gender"].ToString();
			entity.FirstName = dr["FirstName"].ToString();
			entity.LastName = dr["LastName"].ToString();
			entity.Notes = dr["Notes"].ToString();
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.Phone = dr["Phone"].ToString();
			entity.Fax = dr["FAX"].ToString();
			entity.AffiliateId = dr["AffiliateID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["AffiliateID"];
			entity.Referrer = dr["Referrer"].ToString();
			entity.CouponCode = dr["CouponCode"].ToString();
			entity.OkToEmail = (System.Byte)dr["OkToEmail"];
			entity.IsAdmin = (System.Byte)dr["IsAdmin"];
			entity.BillingEqualsShipping = (System.Byte)dr["BillingEqualsShipping"];
			entity.LastIpAddress = dr["LastIPAddress"].ToString();
			entity.OrderNotes = dr["OrderNotes"].ToString();
			entity.SubscriptionExpiresOn = dr["SubscriptionExpiresOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["SubscriptionExpiresOn"];
			entity.RtShipRequest = dr["RTShipRequest"].ToString();
			entity.RtShipResponse = dr["RTShipResponse"].ToString();
			entity.OrderOptions = dr["OrderOptions"].ToString();
			entity.LocaleSetting = dr["LocaleSetting"].ToString();
			entity.MicroPayBalance = (System.Decimal)dr["MicroPayBalance"];
			entity.RecurringShippingMethodId = (System.Int32)dr["RecurringShippingMethodID"];
			entity.RecurringShippingMethod = dr["RecurringShippingMethod"].ToString();
			entity.BillingAddressId = dr["BillingAddressID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["BillingAddressID"];
			entity.ShippingAddressId = dr["ShippingAddressID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ShippingAddressID"];
			entity.GiftRegistryGuid = (System.Guid)dr["GiftRegistryGUID"];
			entity.GiftRegistryIsAnonymous = (System.Byte)dr["GiftRegistryIsAnonymous"];
			entity.GiftRegistryAllowSearchByOthers = (System.Byte)dr["GiftRegistryAllowSearchByOthers"];
			entity.GiftRegistryNickName = dr["GiftRegistryNickName"].ToString();
			entity.GiftRegistryHideShippingAddresses = (System.Byte)dr["GiftRegistryHideShippingAddresses"];
			entity.CodCompanyCheckAllowed = (System.Byte)dr["CODCompanyCheckAllowed"];
			entity.CodNet30Allowed = (System.Byte)dr["CODNet30Allowed"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.FinalizationData = dr["FinalizationData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.Over13Checked = dr["Over13Checked"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["Over13Checked"];
			entity.CurrencySetting = dr["CurrencySetting"].ToString();
			entity.VatSetting = (System.Int32)dr["VATSetting"];
			entity.VatRegistrationId = dr["VATRegistrationID"].ToString();
			entity.StoreCcInDb = (System.Byte)dr["StoreCCInDB"];
			entity.IsRegistered = (System.Byte)dr["IsRegistered"];
			entity.LockedUntil = dr["LockedUntil"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["LockedUntil"];
			entity.AdminCanViewCc = (System.Byte)dr["AdminCanViewCC"];
            //entity.PwdChanged = (System.DateTime)dr["PwdChanged"];
            //entity.BadLoginCount = (System.Byte)dr["BadLoginCount"];
            //entity.LastBadLogin = dr["LastBadLogin"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["LastBadLogin"];
            //entity.Active = (System.Byte)dr["Active"];
            //entity.PwdChangeRequired = dr["PwdChangeRequired"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["PwdChangeRequired"];
            //entity.RequestedPaymentMethod = dr["RequestedPaymentMethod"].ToString();
            //entity.BuySafe = dr["BuySafe"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["BuySafe"];
			return entity;
		}

        public virtual Customer GetCustomerByEmail(System.String Email)
        {

            string sql = "select * from Customer where Email = @Email";
            SqlParameter parameter = new SqlParameter("@Email", Email);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            if (ds == null  || ds.Tables[0].Rows.Count == 0) return null;
            return CustomerFromDataRow(ds.Tables[0].Rows[0]);
        }

        //public virtual Customer Get1CustomerByEmail(System.String Email)
        //{

        //    string sql = "select * from Customer where Email = @Email";
        //    SqlParameter parameter = new SqlParameter("@Email", Email);
        //    DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
        //    if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
        //    return CustomerFromDataRow(ds.Tables[0].Rows[0]);
        //}

	}
	
	
}
