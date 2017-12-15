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
		
	public abstract partial class MobileDeviceRepositoryBase : Repository 
	{
        
        public MobileDeviceRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("MobileDeviceID",new SearchColumn(){Name="MobileDeviceID",Title="MobileDeviceID",SelectClause="MobileDeviceID",WhereClause="AllRecords.MobileDeviceID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UserAgent",new SearchColumn(){Name="UserAgent",Title="UserAgent",SelectClause="UserAgent",WhereClause="AllRecords.UserAgent",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetMobileDeviceSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetMobileDeviceBasicSearchColumns()
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

        public virtual List<SearchColumn> GetMobileDeviceAdvanceSearchColumns()
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
        
        
        public virtual string GetMobileDeviceSelectClause()
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
                        	selectQuery =  "MobileDevice."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",MobileDevice."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual MobileDevice GetMobileDevice(System.Int32 MobileDeviceId)
		{

			string sql=GetMobileDeviceSelectClause();
			sql+="from MobileDevice where MobileDeviceID=@MobileDeviceID ";
			SqlParameter parameter=new SqlParameter("@MobileDeviceID",MobileDeviceId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return MobileDeviceFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<MobileDevice> GetAllMobileDevice()
		{

			string sql=GetMobileDeviceSelectClause();
			sql+="from MobileDevice";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<MobileDevice>(ds, MobileDeviceFromDataRow);
		}

		public virtual List<MobileDevice> GetPagedMobileDevice(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetMobileDeviceCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [MobileDeviceID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([MobileDeviceID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [MobileDeviceID] ";
            tempsql += " FROM [MobileDevice] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("MobileDeviceID"))
					tempsql += " , (AllRecords.[MobileDeviceID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[MobileDeviceID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetMobileDeviceSelectClause()+@" FROM [MobileDevice], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [MobileDevice].[MobileDeviceID] = PageIndex.[MobileDeviceID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<MobileDevice>(ds, MobileDeviceFromDataRow);
			}else{ return null;}
		}

		private int GetMobileDeviceCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM MobileDevice as AllRecords ";
			else
				sql = "SELECT Count(*) FROM MobileDevice as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(MobileDevice))]
		public virtual MobileDevice InsertMobileDevice(MobileDevice entity)
		{

			MobileDevice other=new MobileDevice();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into MobileDevice ( [UserAgent]
				,[Name] )
				Values
				( @UserAgent
				, @Name );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@MobileDeviceID",entity.MobileDeviceId)
					, new SqlParameter("@UserAgent",entity.UserAgent)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetMobileDevice(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(MobileDevice))]
		public virtual MobileDevice UpdateMobileDevice(MobileDevice entity)
		{

			if (entity.IsTransient()) return entity;
			MobileDevice other = GetMobileDevice(entity.MobileDeviceId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update MobileDevice set  [UserAgent]=@UserAgent
							, [Name]=@Name 
							 where MobileDeviceID=@MobileDeviceID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@MobileDeviceID",entity.MobileDeviceId)
					, new SqlParameter("@UserAgent",entity.UserAgent)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetMobileDevice(entity.MobileDeviceId);
		}

		public virtual bool DeleteMobileDevice(System.Int32 MobileDeviceId)
		{

			string sql="delete from MobileDevice where MobileDeviceID=@MobileDeviceID";
			SqlParameter parameter=new SqlParameter("@MobileDeviceID",MobileDeviceId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(MobileDevice))]
		public virtual MobileDevice DeleteMobileDevice(MobileDevice entity)
		{
			this.DeleteMobileDevice(entity.MobileDeviceId);
			return entity;
		}


		public virtual MobileDevice MobileDeviceFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			MobileDevice entity=new MobileDevice();
			entity.MobileDeviceId = (System.Int32)dr["MobileDeviceID"];
			entity.UserAgent = dr["UserAgent"].ToString();
			entity.Name = dr["Name"].ToString();
			return entity;
		}

	}
	
	
}
