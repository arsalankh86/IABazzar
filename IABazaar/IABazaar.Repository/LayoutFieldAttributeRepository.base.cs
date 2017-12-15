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
		
	public abstract partial class LayoutFieldAttributeRepositoryBase : Repository 
	{
        
        public LayoutFieldAttributeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LayoutFieldAttributeID",new SearchColumn(){Name="LayoutFieldAttributeID",Title="LayoutFieldAttributeID",SelectClause="LayoutFieldAttributeID",WhereClause="AllRecords.LayoutFieldAttributeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutFieldAttributeGUID",new SearchColumn(){Name="LayoutFieldAttributeGUID",Title="LayoutFieldAttributeGUID",SelectClause="LayoutFieldAttributeGUID",WhereClause="AllRecords.LayoutFieldAttributeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutID",new SearchColumn(){Name="LayoutID",Title="LayoutID",SelectClause="LayoutID",WhereClause="AllRecords.LayoutID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutFieldID",new SearchColumn(){Name="LayoutFieldID",Title="LayoutFieldID",SelectClause="LayoutFieldID",WhereClause="AllRecords.LayoutFieldID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Value",new SearchColumn(){Name="Value",Title="Value",SelectClause="Value",WhereClause="AllRecords.Value",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLayoutFieldAttributeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLayoutFieldAttributeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLayoutFieldAttributeAdvanceSearchColumns()
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
        
        
        public virtual string GetLayoutFieldAttributeSelectClause()
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
                        	selectQuery =  "LayoutFieldAttribute."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",LayoutFieldAttribute."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual LayoutFieldAttribute GetLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId)
		{

			string sql=GetLayoutFieldAttributeSelectClause();
			sql+="from LayoutFieldAttribute where LayoutFieldAttributeID=@LayoutFieldAttributeID ";
			SqlParameter parameter=new SqlParameter("@LayoutFieldAttributeID",LayoutFieldAttributeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LayoutFieldAttributeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<LayoutFieldAttribute> GetAllLayoutFieldAttribute()
		{

			string sql=GetLayoutFieldAttributeSelectClause();
			sql+="from LayoutFieldAttribute";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutFieldAttribute>(ds, LayoutFieldAttributeFromDataRow);
		}

		public virtual List<LayoutFieldAttribute> GetPagedLayoutFieldAttribute(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLayoutFieldAttributeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LayoutFieldAttributeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LayoutFieldAttributeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LayoutFieldAttributeID] ";
            tempsql += " FROM [LayoutFieldAttribute] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LayoutFieldAttributeID"))
					tempsql += " , (AllRecords.[LayoutFieldAttributeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LayoutFieldAttributeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLayoutFieldAttributeSelectClause()+@" FROM [LayoutFieldAttribute], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [LayoutFieldAttribute].[LayoutFieldAttributeID] = PageIndex.[LayoutFieldAttributeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<LayoutFieldAttribute>(ds, LayoutFieldAttributeFromDataRow);
			}else{ return null;}
		}

		private int GetLayoutFieldAttributeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM LayoutFieldAttribute as AllRecords ";
			else
				sql = "SELECT Count(*) FROM LayoutFieldAttribute as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(LayoutFieldAttribute))]
		public virtual LayoutFieldAttribute InsertLayoutFieldAttribute(LayoutFieldAttribute entity)
		{

			LayoutFieldAttribute other=new LayoutFieldAttribute();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into LayoutFieldAttribute ( [LayoutFieldAttributeGUID]
				,[LayoutID]
				,[LayoutFieldID]
				,[Name]
				,[Value] )
				Values
				( @LayoutFieldAttributeGUID
				, @LayoutID
				, @LayoutFieldID
				, @Name
				, @Value );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutFieldAttributeID",entity.LayoutFieldAttributeId)
					, new SqlParameter("@LayoutFieldAttributeGUID",entity.LayoutFieldAttributeGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@LayoutFieldID",entity.LayoutFieldId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Value",entity.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLayoutFieldAttribute(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(LayoutFieldAttribute))]
		public virtual LayoutFieldAttribute UpdateLayoutFieldAttribute(LayoutFieldAttribute entity)
		{

			if (entity.IsTransient()) return entity;
			LayoutFieldAttribute other = GetLayoutFieldAttribute(entity.LayoutFieldAttributeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update LayoutFieldAttribute set  [LayoutFieldAttributeGUID]=@LayoutFieldAttributeGUID
							, [LayoutID]=@LayoutID
							, [LayoutFieldID]=@LayoutFieldID
							, [Name]=@Name
							, [Value]=@Value 
							 where LayoutFieldAttributeID=@LayoutFieldAttributeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutFieldAttributeID",entity.LayoutFieldAttributeId)
					, new SqlParameter("@LayoutFieldAttributeGUID",entity.LayoutFieldAttributeGuid)
					, new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@LayoutFieldID",entity.LayoutFieldId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Value",entity.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLayoutFieldAttribute(entity.LayoutFieldAttributeId);
		}

		public virtual bool DeleteLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId)
		{

			string sql="delete from LayoutFieldAttribute where LayoutFieldAttributeID=@LayoutFieldAttributeID";
			SqlParameter parameter=new SqlParameter("@LayoutFieldAttributeID",LayoutFieldAttributeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(LayoutFieldAttribute))]
		public virtual LayoutFieldAttribute DeleteLayoutFieldAttribute(LayoutFieldAttribute entity)
		{
			this.DeleteLayoutFieldAttribute(entity.LayoutFieldAttributeId);
			return entity;
		}


		public virtual LayoutFieldAttribute LayoutFieldAttributeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			LayoutFieldAttribute entity=new LayoutFieldAttribute();
			entity.LayoutFieldAttributeId = (System.Int32)dr["LayoutFieldAttributeID"];
			entity.LayoutFieldAttributeGuid = (System.Guid)dr["LayoutFieldAttributeGUID"];
			entity.LayoutId = (System.Int32)dr["LayoutID"];
			entity.LayoutFieldId = (System.Int32)dr["LayoutFieldID"];
			entity.Name = dr["Name"].ToString();
			entity.Value = dr["Value"].ToString();
			return entity;
		}

	}
	
	
}
