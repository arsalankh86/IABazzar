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
		
	public abstract partial class CustomerProductSizeDetailRepositoryBase : Repository 
	{
        
        public CustomerProductSizeDetailRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CustomerProductSize",new SearchColumn(){Name="CustomerProductSize",Title="CustomerProductSize",SelectClause="CustomerProductSize",WhereClause="AllRecords.CustomerProductSize",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductID",new SearchColumn(){Name="ProductID",Title="ProductID",SelectClause="ProductID",WhereClause="AllRecords.ProductID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("bustchest",new SearchColumn(){Name="bustchest",Title="bustchest",SelectClause="bustchest",WhereClause="AllRecords.bustchest",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("waist",new SearchColumn(){Name="waist",Title="waist",SelectClause="waist",WhereClause="AllRecords.waist",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("shoulder",new SearchColumn(){Name="shoulder",Title="shoulder",SelectClause="shoulder",WhereClause="AllRecords.shoulder",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("hip",new SearchColumn(){Name="hip",Title="hip",SelectClause="hip",WhereClause="AllRecords.hip",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("neckwidth",new SearchColumn(){Name="neckwidth",Title="neckwidth",SelectClause="neckwidth",WhereClause="AllRecords.neckwidth",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("sleevesstyle",new SearchColumn(){Name="sleevesstyle",Title="sleevesstyle",SelectClause="sleevesstyle",WhereClause="AllRecords.sleevesstyle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("trouserstyle",new SearchColumn(){Name="trouserstyle",Title="trouserstyle",SelectClause="trouserstyle",WhereClause="AllRecords.trouserstyle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("shirtstyle",new SearchColumn(){Name="shirtstyle",Title="shirtstyle",SelectClause="shirtstyle",WhereClause="AllRecords.shirtstyle",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("heightfeet",new SearchColumn(){Name="heightfeet",Title="heightfeet",SelectClause="heightfeet",WhereClause="AllRecords.heightfeet",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("stichinginstructions",new SearchColumn(){Name="stichinginstructions",Title="stichinginstructions",SelectClause="stichinginstructions",WhereClause="AllRecords.stichinginstructions",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCustomerProductSizeDetailSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCustomerProductSizeDetailBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCustomerProductSizeDetailAdvanceSearchColumns()
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
        
        
        public virtual string GetCustomerProductSizeDetailSelectClause()
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
                        	selectQuery =  "CustomerProductSizeDetail."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CustomerProductSizeDetail."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CustomerProductSizeDetail GetCustomerProductSizeDetail(System.Int32 CustomerProductSize)
		{

			string sql=GetCustomerProductSizeDetailSelectClause();
			sql+="from CustomerProductSizeDetail where CustomerProductSize=@CustomerProductSize ";
			SqlParameter parameter=new SqlParameter("@CustomerProductSize",CustomerProductSize);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CustomerProductSizeDetailFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CustomerProductSizeDetail> GetAllCustomerProductSizeDetail()
		{

			string sql=GetCustomerProductSizeDetailSelectClause();
			sql+="from CustomerProductSizeDetail";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerProductSizeDetail>(ds, CustomerProductSizeDetailFromDataRow);
		}

		public virtual List<CustomerProductSizeDetail> GetPagedCustomerProductSizeDetail(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCustomerProductSizeDetailCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CustomerProductSize] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CustomerProductSize])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CustomerProductSize] ";
            tempsql += " FROM [CustomerProductSizeDetail] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CustomerProductSize"))
					tempsql += " , (AllRecords.[CustomerProductSize])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CustomerProductSize])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCustomerProductSizeDetailSelectClause()+@" FROM [CustomerProductSizeDetail], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CustomerProductSizeDetail].[CustomerProductSize] = PageIndex.[CustomerProductSize] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CustomerProductSizeDetail>(ds, CustomerProductSizeDetailFromDataRow);
			}else{ return null;}
		}

		private int GetCustomerProductSizeDetailCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CustomerProductSizeDetail as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CustomerProductSizeDetail as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CustomerProductSizeDetail))]
		public virtual CustomerProductSizeDetail InsertCustomerProductSizeDetail(CustomerProductSizeDetail entity)
		{

			CustomerProductSizeDetail other=new CustomerProductSizeDetail();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CustomerProductSizeDetail ( [CustomerID]
				,[ProductID]
				,[Email]
				,[bustchest]
				,[waist]
				,[shoulder]
				,[hip]
				,[neckwidth]
				,[sleevesstyle]
				,[trouserstyle]
				,[shirtstyle]
				,[heightfeet]
				,[stichinginstructions] )
				Values
				( @CustomerID
				, @ProductID
				, @Email
				, @bustchest
				, @waist
				, @shoulder
				, @hip
				, @neckwidth
				, @sleevesstyle
				, @trouserstyle
				, @shirtstyle
				, @heightfeet
				, @stichinginstructions );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerProductSize",entity.CustomerProductSize)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@bustchest",entity.Bustchest ?? (object)DBNull.Value)
					, new SqlParameter("@waist",entity.Waist ?? (object)DBNull.Value)
					, new SqlParameter("@shoulder",entity.Shoulder ?? (object)DBNull.Value)
					, new SqlParameter("@hip",entity.Hip ?? (object)DBNull.Value)
					, new SqlParameter("@neckwidth",entity.Neckwidth ?? (object)DBNull.Value)
					, new SqlParameter("@sleevesstyle",entity.Sleevesstyle ?? (object)DBNull.Value)
					, new SqlParameter("@trouserstyle",entity.Trouserstyle ?? (object)DBNull.Value)
					, new SqlParameter("@shirtstyle",entity.Shirtstyle ?? (object)DBNull.Value)
					, new SqlParameter("@heightfeet",entity.Heightfeet ?? (object)DBNull.Value)
					, new SqlParameter("@stichinginstructions",entity.Stichinginstructions ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCustomerProductSizeDetail(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CustomerProductSizeDetail))]
		public virtual CustomerProductSizeDetail UpdateCustomerProductSizeDetail(CustomerProductSizeDetail entity)
		{

			if (entity.IsTransient()) return entity;
			CustomerProductSizeDetail other = GetCustomerProductSizeDetail(entity.CustomerProductSize);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CustomerProductSizeDetail set  [CustomerID]=@CustomerID
							, [ProductID]=@ProductID
							, [Email]=@Email
							, [bustchest]=@bustchest
							, [waist]=@waist
							, [shoulder]=@shoulder
							, [hip]=@hip
							, [neckwidth]=@neckwidth
							, [sleevesstyle]=@sleevesstyle
							, [trouserstyle]=@trouserstyle
							, [shirtstyle]=@shirtstyle
							, [heightfeet]=@heightfeet
							, [stichinginstructions]=@stichinginstructions 
							 where CustomerProductSize=@CustomerProductSize";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CustomerProductSize",entity.CustomerProductSize)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@ProductID",entity.ProductId ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@bustchest",entity.Bustchest ?? (object)DBNull.Value)
					, new SqlParameter("@waist",entity.Waist ?? (object)DBNull.Value)
					, new SqlParameter("@shoulder",entity.Shoulder ?? (object)DBNull.Value)
					, new SqlParameter("@hip",entity.Hip ?? (object)DBNull.Value)
					, new SqlParameter("@neckwidth",entity.Neckwidth ?? (object)DBNull.Value)
					, new SqlParameter("@sleevesstyle",entity.Sleevesstyle ?? (object)DBNull.Value)
					, new SqlParameter("@trouserstyle",entity.Trouserstyle ?? (object)DBNull.Value)
					, new SqlParameter("@shirtstyle",entity.Shirtstyle ?? (object)DBNull.Value)
					, new SqlParameter("@heightfeet",entity.Heightfeet ?? (object)DBNull.Value)
					, new SqlParameter("@stichinginstructions",entity.Stichinginstructions ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCustomerProductSizeDetail(entity.CustomerProductSize);
		}

		public virtual bool DeleteCustomerProductSizeDetail(System.Int32 CustomerProductSize)
		{

			string sql="delete from CustomerProductSizeDetail where CustomerProductSize=@CustomerProductSize";
			SqlParameter parameter=new SqlParameter("@CustomerProductSize",CustomerProductSize);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CustomerProductSizeDetail))]
		public virtual CustomerProductSizeDetail DeleteCustomerProductSizeDetail(CustomerProductSizeDetail entity)
		{
			this.DeleteCustomerProductSizeDetail(entity.CustomerProductSize);
			return entity;
		}


		public virtual CustomerProductSizeDetail CustomerProductSizeDetailFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CustomerProductSizeDetail entity=new CustomerProductSizeDetail();
			entity.CustomerProductSize = (System.Int32)dr["CustomerProductSize"];
			entity.CustomerId = dr["CustomerID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["CustomerID"];
			entity.ProductId = dr["ProductID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ProductID"];
			entity.Email = dr["Email"].ToString();
			entity.Bustchest = dr["bustchest"].ToString();
			entity.Waist = dr["waist"].ToString();
			entity.Shoulder = dr["shoulder"].ToString();
			entity.Hip = dr["hip"].ToString();
			entity.Neckwidth = dr["neckwidth"].ToString();
			entity.Sleevesstyle = dr["sleevesstyle"].ToString();
			entity.Trouserstyle = dr["trouserstyle"].ToString();
			entity.Shirtstyle = dr["shirtstyle"].ToString();
			entity.Heightfeet = dr["heightfeet"].ToString();
			entity.Stichinginstructions = dr["stichinginstructions"].ToString();
			return entity;
		}

	}
	
	
}
