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
		
	public abstract partial class SkinPreviewRepositoryBase : Repository 
	{
        
        public SkinPreviewRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("SkinPreviewID",new SearchColumn(){Name="SkinPreviewID",Title="SkinPreviewID",SelectClause="SkinPreviewID",WhereClause="AllRecords.SkinPreviewID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinPreviewGUID",new SearchColumn(){Name="SkinPreviewGUID",Title="SkinPreviewGUID",SelectClause="SkinPreviewGUID",WhereClause="AllRecords.SkinPreviewGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GroupName",new SearchColumn(){Name="GroupName",Title="GroupName",SelectClause="GroupName",WhereClause="AllRecords.GroupName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetSkinPreviewSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetSkinPreviewBasicSearchColumns()
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

        public virtual List<SearchColumn> GetSkinPreviewAdvanceSearchColumns()
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
        
        
        public virtual string GetSkinPreviewSelectClause()
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
                        	selectQuery =  "SkinPreview."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",SkinPreview."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual SkinPreview GetSkinPreview(System.Int32 SkinPreviewId)
		{

			string sql=GetSkinPreviewSelectClause();
			sql+="from SkinPreview where SkinPreviewID=@SkinPreviewID ";
			SqlParameter parameter=new SqlParameter("@SkinPreviewID",SkinPreviewId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return SkinPreviewFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<SkinPreview> GetAllSkinPreview()
		{

			string sql=GetSkinPreviewSelectClause();
			sql+="from SkinPreview";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SkinPreview>(ds, SkinPreviewFromDataRow);
		}

		public virtual List<SkinPreview> GetPagedSkinPreview(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetSkinPreviewCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [SkinPreviewID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([SkinPreviewID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [SkinPreviewID] ";
            tempsql += " FROM [SkinPreview] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("SkinPreviewID"))
					tempsql += " , (AllRecords.[SkinPreviewID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[SkinPreviewID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetSkinPreviewSelectClause()+@" FROM [SkinPreview], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [SkinPreview].[SkinPreviewID] = PageIndex.[SkinPreviewID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<SkinPreview>(ds, SkinPreviewFromDataRow);
			}else{ return null;}
		}

		private int GetSkinPreviewCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM SkinPreview as AllRecords ";
			else
				sql = "SELECT Count(*) FROM SkinPreview as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(SkinPreview))]
		public virtual SkinPreview InsertSkinPreview(SkinPreview entity)
		{

			SkinPreview other=new SkinPreview();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into SkinPreview ( [SkinPreviewGUID]
				,[SkinID]
				,[Name]
				,[GroupName]
				,[CreatedOn] )
				Values
				( @SkinPreviewGUID
				, @SkinID
				, @Name
				, @GroupName
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SkinPreviewID",entity.SkinPreviewId)
					, new SqlParameter("@SkinPreviewGUID",entity.SkinPreviewGuid)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetSkinPreview(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(SkinPreview))]
		public virtual SkinPreview UpdateSkinPreview(SkinPreview entity)
		{

			if (entity.IsTransient()) return entity;
			SkinPreview other = GetSkinPreview(entity.SkinPreviewId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update SkinPreview set  [SkinPreviewGUID]=@SkinPreviewGUID
							, [SkinID]=@SkinID
							, [Name]=@Name
							, [GroupName]=@GroupName
							, [CreatedOn]=@CreatedOn 
							 where SkinPreviewID=@SkinPreviewID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@SkinPreviewID",entity.SkinPreviewId)
					, new SqlParameter("@SkinPreviewGUID",entity.SkinPreviewGuid)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@GroupName",entity.GroupName ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetSkinPreview(entity.SkinPreviewId);
		}

		public virtual bool DeleteSkinPreview(System.Int32 SkinPreviewId)
		{

			string sql="delete from SkinPreview where SkinPreviewID=@SkinPreviewID";
			SqlParameter parameter=new SqlParameter("@SkinPreviewID",SkinPreviewId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(SkinPreview))]
		public virtual SkinPreview DeleteSkinPreview(SkinPreview entity)
		{
			this.DeleteSkinPreview(entity.SkinPreviewId);
			return entity;
		}


		public virtual SkinPreview SkinPreviewFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			SkinPreview entity=new SkinPreview();
			entity.SkinPreviewId = (System.Int32)dr["SkinPreviewID"];
			entity.SkinPreviewGuid = (System.Guid)dr["SkinPreviewGUID"];
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.Name = dr["Name"].ToString();
			entity.GroupName = dr["GroupName"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
