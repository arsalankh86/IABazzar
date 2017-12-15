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
		
	public abstract partial class AddressRepositoryBase : Repository 
	{
        
        public AddressRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("AddressID",new SearchColumn(){Name="AddressID",Title="AddressID",SelectClause="AddressID",WhereClause="AllRecords.AddressID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AddressGUID",new SearchColumn(){Name="AddressGUID",Title="AddressGUID",SelectClause="AddressGUID",WhereClause="AllRecords.AddressGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("NickName",new SearchColumn(){Name="NickName",Title="NickName",SelectClause="NickName",WhereClause="AllRecords.NickName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FirstName",new SearchColumn(){Name="FirstName",Title="FirstName",SelectClause="FirstName",WhereClause="AllRecords.FirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastName",new SearchColumn(){Name="LastName",Title="LastName",SelectClause="LastName",WhereClause="AllRecords.LastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Company",new SearchColumn(){Name="Company",Title="Company",SelectClause="Company",WhereClause="AllRecords.Company",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Address1",new SearchColumn(){Name="Address1",Title="Address1",SelectClause="Address1",WhereClause="AllRecords.Address1",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Address2",new SearchColumn(){Name="Address2",Title="Address2",SelectClause="Address2",WhereClause="AllRecords.Address2",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Suite",new SearchColumn(){Name="Suite",Title="Suite",SelectClause="Suite",WhereClause="AllRecords.Suite",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("City",new SearchColumn(){Name="City",Title="City",SelectClause="City",WhereClause="AllRecords.City",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("State",new SearchColumn(){Name="State",Title="State",SelectClause="State",WhereClause="AllRecords.State",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Zip",new SearchColumn(){Name="Zip",Title="Zip",SelectClause="Zip",WhereClause="AllRecords.Zip",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Country",new SearchColumn(){Name="Country",Title="Country",SelectClause="Country",WhereClause="AllRecords.Country",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ResidenceType",new SearchColumn(){Name="ResidenceType",Title="ResidenceType",SelectClause="ResidenceType",WhereClause="AllRecords.ResidenceType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Phone",new SearchColumn(){Name="Phone",Title="Phone",SelectClause="Phone",WhereClause="AllRecords.Phone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PaymentMethodLastUsed",new SearchColumn(){Name="PaymentMethodLastUsed",Title="PaymentMethodLastUsed",SelectClause="PaymentMethodLastUsed",WhereClause="AllRecords.PaymentMethodLastUsed",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardType",new SearchColumn(){Name="CardType",Title="CardType",SelectClause="CardType",WhereClause="AllRecords.CardType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardName",new SearchColumn(){Name="CardName",Title="CardName",SelectClause="CardName",WhereClause="AllRecords.CardName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardNumber",new SearchColumn(){Name="CardNumber",Title="CardNumber",SelectClause="CardNumber",WhereClause="AllRecords.CardNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardExpirationMonth",new SearchColumn(){Name="CardExpirationMonth",Title="CardExpirationMonth",SelectClause="CardExpirationMonth",WhereClause="AllRecords.CardExpirationMonth",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardExpirationYear",new SearchColumn(){Name="CardExpirationYear",Title="CardExpirationYear",SelectClause="CardExpirationYear",WhereClause="AllRecords.CardExpirationYear",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardStartDate",new SearchColumn(){Name="CardStartDate",Title="CardStartDate",SelectClause="CardStartDate",WhereClause="AllRecords.CardStartDate",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardIssueNumber",new SearchColumn(){Name="CardIssueNumber",Title="CardIssueNumber",SelectClause="CardIssueNumber",WhereClause="AllRecords.CardIssueNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankABACode",new SearchColumn(){Name="eCheckBankABACode",Title="eCheckBankABACode",SelectClause="eCheckBankABACode",WhereClause="AllRecords.eCheckBankABACode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountNumber",new SearchColumn(){Name="eCheckBankAccountNumber",Title="eCheckBankAccountNumber",SelectClause="eCheckBankAccountNumber",WhereClause="AllRecords.eCheckBankAccountNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountType",new SearchColumn(){Name="eCheckBankAccountType",Title="eCheckBankAccountType",SelectClause="eCheckBankAccountType",WhereClause="AllRecords.eCheckBankAccountType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankName",new SearchColumn(){Name="eCheckBankName",Title="eCheckBankName",SelectClause="eCheckBankName",WhereClause="AllRecords.eCheckBankName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountName",new SearchColumn(){Name="eCheckBankAccountName",Title="eCheckBankAccountName",SelectClause="eCheckBankAccountName",WhereClause="AllRecords.eCheckBankAccountName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PONumber",new SearchColumn(){Name="PONumber",Title="PONumber",SelectClause="PONumber",WhereClause="AllRecords.PONumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Crypt",new SearchColumn(){Name="Crypt",Title="Crypt",SelectClause="Crypt",WhereClause="AllRecords.Crypt",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetAddressSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetAddressBasicSearchColumns()
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

        public virtual List<SearchColumn> GetAddressAdvanceSearchColumns()
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
        
        
        public virtual string GetAddressSelectClause()
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
                        	selectQuery =  "Address."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Address."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Address GetAddress(System.Int32 AddressId)
		{

			string sql=GetAddressSelectClause();
			sql+="from Address where AddressID=@AddressID ";
			SqlParameter parameter=new SqlParameter("@AddressID",AddressId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return AddressFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Address> GetAllAddress()
		{

			string sql=GetAddressSelectClause();
			sql+="from Address";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Address>(ds, AddressFromDataRow);
		}

		public virtual List<Address> GetPagedAddress(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetAddressCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [AddressID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([AddressID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [AddressID] ";
            tempsql += " FROM [Address] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("AddressID"))
					tempsql += " , (AllRecords.[AddressID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[AddressID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetAddressSelectClause()+@" FROM [Address], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Address].[AddressID] = PageIndex.[AddressID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Address>(ds, AddressFromDataRow);
			}else{ return null;}
		}

		private int GetAddressCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Address as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Address as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Address))]
		public virtual Address InsertAddress(Address entity)
		{

			Address other=new Address();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Address ( [AddressGUID]
				,[CustomerID]
				,[NickName]
				,[FirstName]
				,[LastName]
				,[Company]
				,[Address1]
				,[Address2]
				,[Suite]
				,[City]
				,[State]
				,[Zip]
				,[Country]
				,[ResidenceType]
				,[Phone]
				,[Email]
				,[PaymentMethodLastUsed]
				,[CardType]
				,[CardName]
				,[CardNumber]
				,[CardExpirationMonth]
				,[CardExpirationYear]
				,[CardStartDate]
				,[CardIssueNumber]
				,[eCheckBankABACode]
				,[eCheckBankAccountNumber]
				,[eCheckBankAccountType]
				,[eCheckBankName]
				,[eCheckBankAccountName]
				,[PONumber]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn]
				,[Crypt] )
				Values
				( @AddressGUID
				, @CustomerID
				, @NickName
				, @FirstName
				, @LastName
				, @Company
				, @Address1
				, @Address2
				, @Suite
				, @City
				, @State
				, @Zip
				, @Country
				, @ResidenceType
				, @Phone
				, @Email
				, @PaymentMethodLastUsed
				, @CardType
				, @CardName
				, @CardNumber
				, @CardExpirationMonth
				, @CardExpirationYear
				, @CardStartDate
				, @CardIssueNumber
				, @eCheckBankABACode
				, @eCheckBankAccountNumber
				, @eCheckBankAccountType
				, @eCheckBankName
				, @eCheckBankAccountName
				, @PONumber
				, @ExtensionData
				, @Deleted
				, @CreatedOn
				, @Crypt );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AddressID",entity.AddressId)
					, new SqlParameter("@AddressGUID",entity.AddressGuid)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@NickName",entity.NickName ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@Company",entity.Company ?? (object)DBNull.Value)
					, new SqlParameter("@Address1",entity.Address1 ?? (object)DBNull.Value)
					, new SqlParameter("@Address2",entity.Address2 ?? (object)DBNull.Value)
					, new SqlParameter("@Suite",entity.Suite ?? (object)DBNull.Value)
					, new SqlParameter("@City",entity.City ?? (object)DBNull.Value)
					, new SqlParameter("@State",entity.State ?? (object)DBNull.Value)
					, new SqlParameter("@Zip",entity.Zip ?? (object)DBNull.Value)
					, new SqlParameter("@Country",entity.Country ?? (object)DBNull.Value)
					, new SqlParameter("@ResidenceType",entity.ResidenceType)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethodLastUsed",entity.PaymentMethodLastUsed ?? (object)DBNull.Value)
					, new SqlParameter("@CardType",entity.CardType ?? (object)DBNull.Value)
					, new SqlParameter("@CardName",entity.CardName ?? (object)DBNull.Value)
					, new SqlParameter("@CardNumber",entity.CardNumber ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationMonth",entity.CardExpirationMonth ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationYear",entity.CardExpirationYear ?? (object)DBNull.Value)
					, new SqlParameter("@CardStartDate",entity.CardStartDate ?? (object)DBNull.Value)
					, new SqlParameter("@CardIssueNumber",entity.CardIssueNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankABACode",entity.ECheckBankAbaCode ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountNumber",entity.ECheckBankAccountNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountType",entity.ECheckBankAccountType ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankName",entity.ECheckBankName ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountName",entity.ECheckBankAccountName ?? (object)DBNull.Value)
					, new SqlParameter("@PONumber",entity.PoNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@Crypt",entity.Crypt)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetAddress(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Address))]
		public virtual Address UpdateAddress(Address entity)
		{

			if (entity.IsTransient()) return entity;
			Address other = GetAddress(entity.AddressId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Address set  [AddressGUID]=@AddressGUID
							, [CustomerID]=@CustomerID
							, [NickName]=@NickName
							, [FirstName]=@FirstName
							, [LastName]=@LastName
							, [Company]=@Company
							, [Address1]=@Address1
							, [Address2]=@Address2
							, [Suite]=@Suite
							, [City]=@City
							, [State]=@State
							, [Zip]=@Zip
							, [Country]=@Country
							, [ResidenceType]=@ResidenceType
							, [Phone]=@Phone
							, [Email]=@Email
							, [PaymentMethodLastUsed]=@PaymentMethodLastUsed
							, [CardType]=@CardType
							, [CardName]=@CardName
							, [CardNumber]=@CardNumber
							, [CardExpirationMonth]=@CardExpirationMonth
							, [CardExpirationYear]=@CardExpirationYear
							, [CardStartDate]=@CardStartDate
							, [CardIssueNumber]=@CardIssueNumber
							, [eCheckBankABACode]=@eCheckBankABACode
							, [eCheckBankAccountNumber]=@eCheckBankAccountNumber
							, [eCheckBankAccountType]=@eCheckBankAccountType
							, [eCheckBankName]=@eCheckBankName
							, [eCheckBankAccountName]=@eCheckBankAccountName
							, [PONumber]=@PONumber
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn
							, [Crypt]=@Crypt 
							 where AddressID=@AddressID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@AddressID",entity.AddressId)
					, new SqlParameter("@AddressGUID",entity.AddressGuid)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@NickName",entity.NickName ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@Company",entity.Company ?? (object)DBNull.Value)
					, new SqlParameter("@Address1",entity.Address1 ?? (object)DBNull.Value)
					, new SqlParameter("@Address2",entity.Address2 ?? (object)DBNull.Value)
					, new SqlParameter("@Suite",entity.Suite ?? (object)DBNull.Value)
					, new SqlParameter("@City",entity.City ?? (object)DBNull.Value)
					, new SqlParameter("@State",entity.State ?? (object)DBNull.Value)
					, new SqlParameter("@Zip",entity.Zip ?? (object)DBNull.Value)
					, new SqlParameter("@Country",entity.Country ?? (object)DBNull.Value)
					, new SqlParameter("@ResidenceType",entity.ResidenceType)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethodLastUsed",entity.PaymentMethodLastUsed ?? (object)DBNull.Value)
					, new SqlParameter("@CardType",entity.CardType ?? (object)DBNull.Value)
					, new SqlParameter("@CardName",entity.CardName ?? (object)DBNull.Value)
					, new SqlParameter("@CardNumber",entity.CardNumber ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationMonth",entity.CardExpirationMonth ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationYear",entity.CardExpirationYear ?? (object)DBNull.Value)
					, new SqlParameter("@CardStartDate",entity.CardStartDate ?? (object)DBNull.Value)
					, new SqlParameter("@CardIssueNumber",entity.CardIssueNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankABACode",entity.ECheckBankAbaCode ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountNumber",entity.ECheckBankAccountNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountType",entity.ECheckBankAccountType ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankName",entity.ECheckBankName ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountName",entity.ECheckBankAccountName ?? (object)DBNull.Value)
					, new SqlParameter("@PONumber",entity.PoNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@Crypt",entity.Crypt)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetAddress(entity.AddressId);
		}

		public virtual bool DeleteAddress(System.Int32 AddressId)
		{

			string sql="delete from Address where AddressID=@AddressID";
			SqlParameter parameter=new SqlParameter("@AddressID",AddressId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Address))]
		public virtual Address DeleteAddress(Address entity)
		{
			this.DeleteAddress(entity.AddressId);
			return entity;
		}


		public virtual Address AddressFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Address entity=new Address();
			entity.AddressId = (System.Int32)dr["AddressID"];
			entity.AddressGuid = (System.Guid)dr["AddressGUID"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.NickName = dr["NickName"].ToString();
			entity.FirstName = dr["FirstName"].ToString();
			entity.LastName = dr["LastName"].ToString();
			entity.Company = dr["Company"].ToString();
			entity.Address1 = dr["Address1"].ToString();
			entity.Address2 = dr["Address2"].ToString();
			entity.Suite = dr["Suite"].ToString();
			entity.City = dr["City"].ToString();
			entity.State = dr["State"].ToString();
			entity.Zip = dr["Zip"].ToString();
			entity.Country = dr["Country"].ToString();
			entity.ResidenceType = (System.Int32)dr["ResidenceType"];
			entity.Phone = dr["Phone"].ToString();
			entity.Email = dr["Email"].ToString();
			entity.PaymentMethodLastUsed = dr["PaymentMethodLastUsed"].ToString();
			entity.CardType = dr["CardType"].ToString();
			entity.CardName = dr["CardName"].ToString();
			entity.CardNumber = dr["CardNumber"].ToString();
			entity.CardExpirationMonth = dr["CardExpirationMonth"].ToString();
			entity.CardExpirationYear = dr["CardExpirationYear"].ToString();
			entity.CardStartDate = dr["CardStartDate"].ToString();
			entity.CardIssueNumber = dr["CardIssueNumber"].ToString();
			entity.ECheckBankAbaCode = dr["eCheckBankABACode"].ToString();
			entity.ECheckBankAccountNumber = dr["eCheckBankAccountNumber"].ToString();
			entity.ECheckBankAccountType = dr["eCheckBankAccountType"].ToString();
			entity.ECheckBankName = dr["eCheckBankName"].ToString();
			entity.ECheckBankAccountName = dr["eCheckBankAccountName"].ToString();
			entity.PoNumber = dr["PONumber"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.Crypt = (System.Int32)dr["Crypt"];
			return entity;
		}

	}
	
	
}
