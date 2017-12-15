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
		
	public abstract partial class LayoutRepositoryBase : Repository 
	{
        
        public LayoutRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("LayoutID",new SearchColumn(){Name="LayoutID",Title="LayoutID",SelectClause="LayoutID",WhereClause="AllRecords.LayoutID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LayoutGUID",new SearchColumn(){Name="LayoutGUID",Title="LayoutGUID",SelectClause="LayoutGUID",WhereClause="AllRecords.LayoutGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("HTML",new SearchColumn(){Name="HTML",Title="HTML",SelectClause="HTML",WhereClause="AllRecords.HTML",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Micro",new SearchColumn(){Name="Micro",Title="Micro",SelectClause="Micro",WhereClause="AllRecords.Micro",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Icon",new SearchColumn(){Name="Icon",Title="Icon",SelectClause="Icon",WhereClause="AllRecords.Icon",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Medium",new SearchColumn(){Name="Medium",Title="Medium",SelectClause="Medium",WhereClause="AllRecords.Medium",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Large",new SearchColumn(){Name="Large",Title="Large",SelectClause="Large",WhereClause="AllRecords.Large",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Version",new SearchColumn(){Name="Version",Title="Version",SelectClause="Version",WhereClause="AllRecords.Version",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("UpdatedOn",new SearchColumn(){Name="UpdatedOn",Title="UpdatedOn",SelectClause="UpdatedOn",WhereClause="AllRecords.UpdatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetLayoutSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetLayoutBasicSearchColumns()
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

        public virtual List<SearchColumn> GetLayoutAdvanceSearchColumns()
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
        
        
        public virtual string GetLayoutSelectClause()
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
                        	selectQuery =  "Layout."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Layout."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Layout GetLayout(System.Int32 LayoutId)
		{

			string sql=GetLayoutSelectClause();
			sql+="from Layout where LayoutID=@LayoutID ";
			SqlParameter parameter=new SqlParameter("@LayoutID",LayoutId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return LayoutFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Layout> GetAllLayout()
		{

			string sql=GetLayoutSelectClause();
			sql+="from Layout";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Layout>(ds, LayoutFromDataRow);
		}

		public virtual List<Layout> GetPagedLayout(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetLayoutCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [LayoutID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([LayoutID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [LayoutID] ";
            tempsql += " FROM [Layout] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("LayoutID"))
					tempsql += " , (AllRecords.[LayoutID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[LayoutID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetLayoutSelectClause()+@" FROM [Layout], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Layout].[LayoutID] = PageIndex.[LayoutID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Layout>(ds, LayoutFromDataRow);
			}else{ return null;}
		}

		private int GetLayoutCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Layout as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Layout as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Layout))]
		public virtual Layout InsertLayout(Layout entity)
		{

			Layout other=new Layout();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Layout ( [LayoutGUID]
				,[Name]
				,[Description]
				,[HTML]
				,[Micro]
				,[Icon]
				,[Medium]
				,[Large]
				,[Version]
				,[CreatedOn]
				,[UpdatedOn]
				,[DisplayOrder] )
				Values
				( @LayoutGUID
				, @Name
				, @Description
				, @HTML
				, @Micro
				, @Icon
				, @Medium
				, @Large
				, @Version
				, @CreatedOn
				, @UpdatedOn
				, @DisplayOrder );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@LayoutGUID",entity.LayoutGuid)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@HTML",entity.Html ?? (object)DBNull.Value)
					, new SqlParameter("@Micro",entity.Micro ?? (object)DBNull.Value)
					, new SqlParameter("@Icon",entity.Icon ?? (object)DBNull.Value)
					, new SqlParameter("@Medium",entity.Medium ?? (object)DBNull.Value)
					, new SqlParameter("@Large",entity.Large ?? (object)DBNull.Value)
					, new SqlParameter("@Version",entity.Version)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@UpdatedOn",entity.UpdatedOn)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetLayout(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Layout))]
		public virtual Layout UpdateLayout(Layout entity)
		{

			if (entity.IsTransient()) return entity;
			Layout other = GetLayout(entity.LayoutId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Layout set  [LayoutGUID]=@LayoutGUID
							, [Name]=@Name
							, [Description]=@Description
							, [HTML]=@HTML
							, [Micro]=@Micro
							, [Icon]=@Icon
							, [Medium]=@Medium
							, [Large]=@Large
							, [Version]=@Version
							, [CreatedOn]=@CreatedOn
							, [UpdatedOn]=@UpdatedOn
							, [DisplayOrder]=@DisplayOrder 
							 where LayoutID=@LayoutID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@LayoutID",entity.LayoutId)
					, new SqlParameter("@LayoutGUID",entity.LayoutGuid)
					, new SqlParameter("@Name",entity.Name ?? (object)DBNull.Value)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@HTML",entity.Html ?? (object)DBNull.Value)
					, new SqlParameter("@Micro",entity.Micro ?? (object)DBNull.Value)
					, new SqlParameter("@Icon",entity.Icon ?? (object)DBNull.Value)
					, new SqlParameter("@Medium",entity.Medium ?? (object)DBNull.Value)
					, new SqlParameter("@Large",entity.Large ?? (object)DBNull.Value)
					, new SqlParameter("@Version",entity.Version)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)
					, new SqlParameter("@UpdatedOn",entity.UpdatedOn)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetLayout(entity.LayoutId);
		}

		public virtual bool DeleteLayout(System.Int32 LayoutId)
		{

			string sql="delete from Layout where LayoutID=@LayoutID";
			SqlParameter parameter=new SqlParameter("@LayoutID",LayoutId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Layout))]
		public virtual Layout DeleteLayout(Layout entity)
		{
			this.DeleteLayout(entity.LayoutId);
			return entity;
		}


		public virtual Layout LayoutFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Layout entity=new Layout();
			entity.LayoutId = (System.Int32)dr["LayoutID"];
			entity.LayoutGuid = (System.Guid)dr["LayoutGUID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.Html = dr["HTML"].ToString();
			entity.Micro = dr["Micro"].ToString();
			entity.Icon = dr["Icon"].ToString();
			entity.Medium = dr["Medium"].ToString();
			entity.Large = dr["Large"].ToString();
			entity.Version = (System.Int32)dr["Version"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			entity.UpdatedOn = (System.DateTime)dr["UpdatedOn"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			return entity;
		}

	}
	
	
}
