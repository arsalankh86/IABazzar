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
		
	public abstract partial class GalleryRepositoryBase : Repository 
	{
        
        public GalleryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("GalleryID",new SearchColumn(){Name="GalleryID",Title="GalleryID",SelectClause="GalleryID",WhereClause="AllRecords.GalleryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("GalleryGUID",new SearchColumn(){Name="GalleryGUID",Title="GalleryGUID",SelectClause="GalleryGUID",WhereClause="AllRecords.GalleryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DirName",new SearchColumn(){Name="DirName",Title="DirName",SelectClause="DirName",WhereClause="AllRecords.DirName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetGallerySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetGalleryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetGalleryAdvanceSearchColumns()
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
        
        
        public virtual string GetGallerySelectClause()
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
                        	selectQuery =  "Gallery."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Gallery."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Gallery GetGallery(System.Int32 GalleryId)
		{

			string sql=GetGallerySelectClause();
			sql+="from Gallery where GalleryID=@GalleryID ";
			SqlParameter parameter=new SqlParameter("@GalleryID",GalleryId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return GalleryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Gallery> GetAllGallery()
		{

			string sql=GetGallerySelectClause();
			sql+="from Gallery";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Gallery>(ds, GalleryFromDataRow);
		}

		public virtual List<Gallery> GetPagedGallery(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetGalleryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [GalleryID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([GalleryID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [GalleryID] ";
            tempsql += " FROM [Gallery] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("GalleryID"))
					tempsql += " , (AllRecords.[GalleryID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[GalleryID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetGallerySelectClause()+@" FROM [Gallery], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Gallery].[GalleryID] = PageIndex.[GalleryID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Gallery>(ds, GalleryFromDataRow);
			}else{ return null;}
		}

		private int GetGalleryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Gallery as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Gallery as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Gallery))]
		public virtual Gallery InsertGallery(Gallery entity)
		{

			Gallery other=new Gallery();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Gallery ( [GalleryGUID]
				,[Name]
				,[DirName]
				,[Description]
				,[DisplayOrder]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @GalleryGUID
				, @Name
				, @DirName
				, @Description
				, @DisplayOrder
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GalleryID",entity.GalleryId)
					, new SqlParameter("@GalleryGUID",entity.GalleryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DirName",entity.DirName)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetGallery(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Gallery))]
		public virtual Gallery UpdateGallery(Gallery entity)
		{

			if (entity.IsTransient()) return entity;
			Gallery other = GetGallery(entity.GalleryId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Gallery set  [GalleryGUID]=@GalleryGUID
							, [Name]=@Name
							, [DirName]=@DirName
							, [Description]=@Description
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where GalleryID=@GalleryID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@GalleryID",entity.GalleryId)
					, new SqlParameter("@GalleryGUID",entity.GalleryGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DirName",entity.DirName)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetGallery(entity.GalleryId);
		}

		public virtual bool DeleteGallery(System.Int32 GalleryId)
		{

			string sql="delete from Gallery where GalleryID=@GalleryID";
			SqlParameter parameter=new SqlParameter("@GalleryID",GalleryId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Gallery))]
		public virtual Gallery DeleteGallery(Gallery entity)
		{
			this.DeleteGallery(entity.GalleryId);
			return entity;
		}


		public virtual Gallery GalleryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Gallery entity=new Gallery();
			entity.GalleryId = (System.Int32)dr["GalleryID"];
			entity.GalleryGuid = (System.Guid)dr["GalleryGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DirName = dr["DirName"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
