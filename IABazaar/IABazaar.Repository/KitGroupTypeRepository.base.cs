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
		
	public abstract partial class KitGroupTypeRepositoryBase : Repository 
	{
        
        public KitGroupTypeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("KitGroupTypeID",new SearchColumn(){Name="KitGroupTypeID",Title="KitGroupTypeID",SelectClause="KitGroupTypeID",WhereClause="AllRecords.KitGroupTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitGroupTypeGUID",new SearchColumn(){Name="KitGroupTypeGUID",Title="KitGroupTypeGUID",SelectClause="KitGroupTypeGUID",WhereClause="AllRecords.KitGroupTypeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetKitGroupTypeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetKitGroupTypeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetKitGroupTypeAdvanceSearchColumns()
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
        
        
        public virtual string GetKitGroupTypeSelectClause()
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
                        	selectQuery =  "KitGroupType."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",KitGroupType."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual KitGroupType GetKitGroupType(System.Int32 KitGroupTypeId)
		{

			string sql=GetKitGroupTypeSelectClause();
			sql+="from KitGroupType where KitGroupTypeID=@KitGroupTypeID ";
			SqlParameter parameter=new SqlParameter("@KitGroupTypeID",KitGroupTypeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return KitGroupTypeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<KitGroupType> GetAllKitGroupType()
		{

			string sql=GetKitGroupTypeSelectClause();
			sql+="from KitGroupType";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitGroupType>(ds, KitGroupTypeFromDataRow);
		}

		public virtual List<KitGroupType> GetPagedKitGroupType(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetKitGroupTypeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [KitGroupTypeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([KitGroupTypeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [KitGroupTypeID] ";
            tempsql += " FROM [KitGroupType] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("KitGroupTypeID"))
					tempsql += " , (AllRecords.[KitGroupTypeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[KitGroupTypeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetKitGroupTypeSelectClause()+@" FROM [KitGroupType], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [KitGroupType].[KitGroupTypeID] = PageIndex.[KitGroupTypeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitGroupType>(ds, KitGroupTypeFromDataRow);
			}else{ return null;}
		}

		private int GetKitGroupTypeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM KitGroupType as AllRecords ";
			else
				sql = "SELECT Count(*) FROM KitGroupType as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(KitGroupType))]
		public virtual KitGroupType InsertKitGroupType(KitGroupType entity)
		{

			KitGroupType other=new KitGroupType();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into KitGroupType ( [KitGroupTypeGUID]
				,[Name]
				,[DisplayOrder]
				,[CreatedOn] )
				Values
				( @KitGroupTypeGUID
				, @Name
				, @DisplayOrder
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitGroupTypeID",entity.KitGroupTypeId)
					, new SqlParameter("@KitGroupTypeGUID",entity.KitGroupTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetKitGroupType(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(KitGroupType))]
		public virtual KitGroupType UpdateKitGroupType(KitGroupType entity)
		{

			if (entity.IsTransient()) return entity;
			KitGroupType other = GetKitGroupType(entity.KitGroupTypeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update KitGroupType set  [KitGroupTypeGUID]=@KitGroupTypeGUID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [CreatedOn]=@CreatedOn 
							 where KitGroupTypeID=@KitGroupTypeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitGroupTypeID",entity.KitGroupTypeId)
					, new SqlParameter("@KitGroupTypeGUID",entity.KitGroupTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetKitGroupType(entity.KitGroupTypeId);
		}

		public virtual bool DeleteKitGroupType(System.Int32 KitGroupTypeId)
		{

			string sql="delete from KitGroupType where KitGroupTypeID=@KitGroupTypeID";
			SqlParameter parameter=new SqlParameter("@KitGroupTypeID",KitGroupTypeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(KitGroupType))]
		public virtual KitGroupType DeleteKitGroupType(KitGroupType entity)
		{
			this.DeleteKitGroupType(entity.KitGroupTypeId);
			return entity;
		}


		public virtual KitGroupType KitGroupTypeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			KitGroupType entity=new KitGroupType();
			entity.KitGroupTypeId = (System.Int32)dr["KitGroupTypeID"];
			entity.KitGroupTypeGuid = (System.Guid)dr["KitGroupTypeGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
