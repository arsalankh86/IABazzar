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
		
	public abstract partial class ProductTypeRepositoryBase : Repository 
	{
        
        public ProductTypeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("ProductTypeID",new SearchColumn(){Name="ProductTypeID",Title="ProductTypeID",SelectClause="ProductTypeID",WhereClause="AllRecords.ProductTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ProductTypeGUID",new SearchColumn(){Name="ProductTypeGUID",Title="ProductTypeGUID",SelectClause="ProductTypeGUID",WhereClause="AllRecords.ProductTypeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetProductTypeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetProductTypeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetProductTypeAdvanceSearchColumns()
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
        
        
        public virtual string GetProductTypeSelectClause()
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
                        	selectQuery =  "ProductType."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",ProductType."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual ProductType GetProductType(System.Int32 ProductTypeId)
		{

			string sql=GetProductTypeSelectClause();
			sql+="from ProductType where ProductTypeID=@ProductTypeID ";
			SqlParameter parameter=new SqlParameter("@ProductTypeID",ProductTypeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return ProductTypeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<ProductType> GetAllProductType()
		{

			string sql=GetProductTypeSelectClause();
			sql+="from ProductType";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductType>(ds, ProductTypeFromDataRow);
		}

		public virtual List<ProductType> GetPagedProductType(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetProductTypeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [ProductTypeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([ProductTypeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [ProductTypeID] ";
            tempsql += " FROM [ProductType] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("ProductTypeID"))
					tempsql += " , (AllRecords.[ProductTypeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[ProductTypeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetProductTypeSelectClause()+@" FROM [ProductType], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [ProductType].[ProductTypeID] = PageIndex.[ProductTypeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<ProductType>(ds, ProductTypeFromDataRow);
			}else{ return null;}
		}

		private int GetProductTypeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM ProductType as AllRecords ";
			else
				sql = "SELECT Count(*) FROM ProductType as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(ProductType))]
		public virtual ProductType InsertProductType(ProductType entity)
		{

			ProductType other=new ProductType();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into ProductType ( [ProductTypeGUID]
				,[Name]
				,[DisplayOrder]
				,[TaxClassID]
				,[CreatedOn] )
				Values
				( @ProductTypeGUID
				, @Name
				, @DisplayOrder
				, @TaxClassID
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductTypeID",entity.ProductTypeId)
					, new SqlParameter("@ProductTypeGUID",entity.ProductTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetProductType(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(ProductType))]
		public virtual ProductType UpdateProductType(ProductType entity)
		{

			if (entity.IsTransient()) return entity;
			ProductType other = GetProductType(entity.ProductTypeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update ProductType set  [ProductTypeGUID]=@ProductTypeGUID
							, [Name]=@Name
							, [DisplayOrder]=@DisplayOrder
							, [TaxClassID]=@TaxClassID
							, [CreatedOn]=@CreatedOn 
							 where ProductTypeID=@ProductTypeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@ProductTypeID",entity.ProductTypeId)
					, new SqlParameter("@ProductTypeGUID",entity.ProductTypeGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetProductType(entity.ProductTypeId);
		}

		public virtual bool DeleteProductType(System.Int32 ProductTypeId)
		{

			string sql="delete from ProductType where ProductTypeID=@ProductTypeID";
			SqlParameter parameter=new SqlParameter("@ProductTypeID",ProductTypeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(ProductType))]
		public virtual ProductType DeleteProductType(ProductType entity)
		{
			this.DeleteProductType(entity.ProductTypeId);
			return entity;
		}


		public virtual ProductType ProductTypeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			ProductType entity=new ProductType();
			entity.ProductTypeId = (System.Int32)dr["ProductTypeID"];
			entity.ProductTypeGuid = (System.Guid)dr["ProductTypeGUID"];
			entity.Name = dr["Name"].ToString();
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
