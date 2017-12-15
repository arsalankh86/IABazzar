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
		
	public abstract partial class RestrictedIpRepositoryBase : Repository 
	{
        
        public RestrictedIpRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("DBRecNo",new SearchColumn(){Name="DBRecNo",Title="DBRecNo",SelectClause="DBRecNo",WhereClause="AllRecords.DBRecNo",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IPAddress",new SearchColumn(){Name="IPAddress",Title="IPAddress",SelectClause="IPAddress",WhereClause="AllRecords.IPAddress",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetRestrictedIpSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetRestrictedIpBasicSearchColumns()
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

        public virtual List<SearchColumn> GetRestrictedIpAdvanceSearchColumns()
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
        
        
        public virtual string GetRestrictedIpSelectClause()
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
                        	selectQuery =  "RestrictedIP."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",RestrictedIP."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual RestrictedIp GetRestrictedIp(System.String IpAddress)
		{

			string sql=GetRestrictedIpSelectClause();
			sql+="from RestrictedIP where IPAddress=@IPAddress ";
			SqlParameter parameter=new SqlParameter("@IPAddress",IpAddress);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return RestrictedIpFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<RestrictedIp> GetAllRestrictedIp()
		{

			string sql=GetRestrictedIpSelectClause();
			sql+="from RestrictedIP";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<RestrictedIp>(ds, RestrictedIpFromDataRow);
		}

		public virtual List<RestrictedIp> GetPagedRestrictedIp(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetRestrictedIpCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [IPAddress] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([IPAddress])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [IPAddress] ";
            tempsql += " FROM [RestrictedIP] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("IPAddress"))
					tempsql += " , (AllRecords.[IPAddress])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[IPAddress])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetRestrictedIpSelectClause()+@" FROM [RestrictedIP], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [RestrictedIP].[IPAddress] = PageIndex.[IPAddress] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<RestrictedIp>(ds, RestrictedIpFromDataRow);
			}else{ return null;}
		}

		private int GetRestrictedIpCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM RestrictedIP as AllRecords ";
			else
				sql = "SELECT Count(*) FROM RestrictedIP as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(RestrictedIp))]
		public virtual RestrictedIp InsertRestrictedIp(RestrictedIp entity)
		{

			RestrictedIp other=new RestrictedIp();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into RestrictedIP ( [IPAddress]
				,[DBRecNo]
				,[CreatedOn] )
				Values
				( @IPAddress
				, @DBRecNo
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@IPAddress",entity.IpAddress)
					, new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetRestrictedIp(Convert.ToInt32(identity));
			}
			return entity;
		}

        private RestrictedIp GetRestrictedIp(int p)
        {
            throw new NotImplementedException();
        }

		[MOLog(AuditOperations.Update,typeof(RestrictedIp))]
		public virtual RestrictedIp UpdateRestrictedIp(RestrictedIp entity)
		{

			if (entity.IsTransient()) return entity;
			RestrictedIp other = GetRestrictedIp(entity.IpAddress);
			if (entity.Equals(other)) return entity;
			string sql=@"Update RestrictedIP set  [DBRecNo]=@DBRecNo
							, [CreatedOn]=@CreatedOn 
							 where IPAddress=@IPAddress";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@IPAddress",entity.IpAddress)
					, new SqlParameter("@DBRecNo",entity.DbRecNo)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetRestrictedIp(entity.IpAddress);
		}

		public virtual bool DeleteRestrictedIp(System.String IpAddress)
		{

			string sql="delete from RestrictedIP where IPAddress=@IPAddress";
			SqlParameter parameter=new SqlParameter("@IPAddress",IpAddress);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(RestrictedIp))]
		public virtual RestrictedIp DeleteRestrictedIp(RestrictedIp entity)
		{
			this.DeleteRestrictedIp(entity.IpAddress);
			return entity;
		}


		public virtual RestrictedIp RestrictedIpFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			RestrictedIp entity=new RestrictedIp();
			entity.DbRecNo = (System.Int32)dr["DBRecNo"];
			entity.IpAddress = dr["IPAddress"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
