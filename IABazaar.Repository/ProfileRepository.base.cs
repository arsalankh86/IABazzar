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
		
	public abstract partial class ProfileRepositoryBase : Repository 
	{
        
        public ProfileRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProfileID",new SearchColumn(){Name="ProfileID",Title="ProfileID",SelectClause="ProfileID",WhereClause="AllRecords.ProfileID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PropertyName",new SearchColumn(){Name="PropertyName",Title="PropertyName",SelectClause="PropertyName",WhereClause="AllRecords.PropertyName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerGUID",new SearchColumn(){Name="CustomerGUID",Title="CustomerGUID",SelectClause="CustomerGUID",WhereClause="AllRecords.CustomerGUID",DataType="System.Guid?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PropertyValueString",new SearchColumn(){Name="PropertyValueString",Title="PropertyValueString",SelectClause="PropertyValueString",WhereClause="AllRecords.PropertyValueString",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UpdatedOn",new SearchColumn(){Name="UpdatedOn",Title="UpdatedOn",SelectClause="UpdatedOn",WhereClause="AllRecords.UpdatedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProfileSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProfileBasicSearchColumns()
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

        public virtual List<SearchColumn> GetProfileAdvanceSearchColumns()
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
        
        
        public virtual string GetProfileSelectClause()
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
                        	selectQuery =  "Profile."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Profile."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Profile GetProfile(System.Int32 ProfileId)
		{

			string sql=GetProfileSelectClause();
			sql+="from Profile where ProfileID=@ProfileID ";
			SqlParameter parameter=new SqlParameter("@ProfileID",ProfileId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProfileFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Profile> GetAllProfile()
		{

			string sql=GetProfileSelectClause();
			sql+="from Profile";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Profile>(ds, ProfileFromDataRow);
		}

		public virtual List<Profile> GetPagedProfile(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProfileCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ProfileID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ProfileID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ProfileID] ";
            tempsql += " FROM [Profile] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ProfileID"))
					tempsql += " , (AllRecords.[ProfileID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ProfileID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProfileSelectClause()+@" FROM [Profile], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Profile].[ProfileID] = PageIndex.[ProfileID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Profile>(ds, ProfileFromDataRow);
			}else{ return null;}
		}

		private int GetProfileCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Profile as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Profile as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Profile))]
		public virtual Profile InsertProfile(Profile entity)
		{

			Profile other=new Profile();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Profile ( [StoreID]
				,[CustomerID]
				,[PropertyName]
				,[CustomerGUID]
				,[PropertyValueString]
				,[UpdatedOn] )
				Values
				( @StoreID
				, @CustomerID
				, @PropertyName
				, @CustomerGUID
				, @PropertyValueString
				, @UpdatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProfileID",entity.ProfileId)
					, new SqlParameter("@StoreID",entity.StoreId ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@PropertyName",entity.PropertyName ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerGUID",entity.CustomerGuid ?? (object)DBNull.Value)
					, new SqlParameter("@PropertyValueString",entity.PropertyValueString ?? (object)DBNull.Value)
					, new SqlParameter("@UpdatedOn",entity.UpdatedOn ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProfile(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Profile))]
		public virtual Profile UpdateProfile(Profile entity)
		{

			if (entity.IsTransient()) return entity;
			Profile other = GetProfile(entity.ProfileId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Profile set  [StoreID]=@StoreID
							, [CustomerID]=@CustomerID
							, [PropertyName]=@PropertyName
							, [CustomerGUID]=@CustomerGUID
							, [PropertyValueString]=@PropertyValueString
							, [UpdatedOn]=@UpdatedOn 
							 where ProfileID=@ProfileID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProfileID",entity.ProfileId)
					, new SqlParameter("@StoreID",entity.StoreId ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerID",entity.CustomerId ?? (object)DBNull.Value)
					, new SqlParameter("@PropertyName",entity.PropertyName ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerGUID",entity.CustomerGuid ?? (object)DBNull.Value)
					, new SqlParameter("@PropertyValueString",entity.PropertyValueString ?? (object)DBNull.Value)
					, new SqlParameter("@UpdatedOn",entity.UpdatedOn ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProfile(entity.ProfileId);
		}

		public virtual bool DeleteProfile(System.Int32 ProfileId)
		{

			string sql="delete from Profile where ProfileID=@ProfileID";
			SqlParameter parameter=new SqlParameter("@ProfileID",ProfileId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Profile))]
		public virtual Profile DeleteProfile(Profile entity)
		{
			this.DeleteProfile(entity.ProfileId);
			return entity;
		}


		public virtual Profile ProfileFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Profile entity=new Profile();
			entity.StoreId = dr["StoreID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["StoreID"];
			entity.ProfileId = (System.Int32)dr["ProfileID"];
			entity.CustomerId = dr["CustomerID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["CustomerID"];
			entity.PropertyName = dr["PropertyName"].ToString();
			entity.CustomerGuid = dr["CustomerGUID"]==DBNull.Value?(System.Guid?)null:(System.Guid?)dr["CustomerGUID"];
			entity.PropertyValueString = dr["PropertyValueString"].ToString();
			entity.UpdatedOn = dr["UpdatedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["UpdatedOn"];
			return entity;
		}

	}
	
	
}
