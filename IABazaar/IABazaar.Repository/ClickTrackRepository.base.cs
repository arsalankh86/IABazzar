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
		
	public abstract partial class ClickTrackRepositoryBase : Repository 
	{
        
        public ClickTrackRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ClickTrackID",new SearchColumn(){Name="ClickTrackID",Title="ClickTrackID",SelectClause="ClickTrackID",WhereClause="AllRecords.ClickTrackID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetClickTrackSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetClickTrackBasicSearchColumns()
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

        public virtual List<SearchColumn> GetClickTrackAdvanceSearchColumns()
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
        
        
        public virtual string GetClickTrackSelectClause()
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
                        	selectQuery =  "ClickTrack."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ClickTrack."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ClickTrack GetClickTrack(System.Int32 ClickTrackId)
		{

			string sql=GetClickTrackSelectClause();
			sql+="from ClickTrack where ClickTrackID=@ClickTrackID ";
			SqlParameter parameter=new SqlParameter("@ClickTrackID",ClickTrackId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ClickTrackFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ClickTrack> GetAllClickTrack()
		{

			string sql=GetClickTrackSelectClause();
			sql+="from ClickTrack";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ClickTrack>(ds, ClickTrackFromDataRow);
		}

		public virtual List<ClickTrack> GetPagedClickTrack(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetClickTrackCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ClickTrackID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ClickTrackID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ClickTrackID] ";
            tempsql += " FROM [ClickTrack] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ClickTrackID"))
					tempsql += " , (AllRecords.[ClickTrackID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ClickTrackID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetClickTrackSelectClause()+@" FROM [ClickTrack], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ClickTrack].[ClickTrackID] = PageIndex.[ClickTrackID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ClickTrack>(ds, ClickTrackFromDataRow);
			}else{ return null;}
		}

		private int GetClickTrackCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ClickTrack as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ClickTrack as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ClickTrack))]
		public virtual ClickTrack InsertClickTrack(ClickTrack entity)
		{

			ClickTrack other=new ClickTrack();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ClickTrack ( [Name]
				,[CreatedOn] )
				Values
				( @Name
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ClickTrackID",entity.ClickTrackId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetClickTrack(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ClickTrack))]
		public virtual ClickTrack UpdateClickTrack(ClickTrack entity)
		{

			if (entity.IsTransient()) return entity;
			ClickTrack other = GetClickTrack(entity.ClickTrackId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ClickTrack set  [Name]=@Name
							, [CreatedOn]=@CreatedOn 
							 where ClickTrackID=@ClickTrackID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ClickTrackID",entity.ClickTrackId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetClickTrack(entity.ClickTrackId);
		}

		public virtual bool DeleteClickTrack(System.Int32 ClickTrackId)
		{

			string sql="delete from ClickTrack where ClickTrackID=@ClickTrackID";
			SqlParameter parameter=new SqlParameter("@ClickTrackID",ClickTrackId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ClickTrack))]
		public virtual ClickTrack DeleteClickTrack(ClickTrack entity)
		{
			this.DeleteClickTrack(entity.ClickTrackId);
			return entity;
		}


		public virtual ClickTrack ClickTrackFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ClickTrack entity=new ClickTrack();
			entity.ClickTrackId = (System.Int32)dr["ClickTrackID"];
			entity.Name = dr["Name"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
