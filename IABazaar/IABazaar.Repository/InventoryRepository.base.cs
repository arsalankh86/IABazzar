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
		
	public abstract partial class InventoryRepositoryBase : Repository 
	{
        
        public InventoryRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("InventoryID",new SearchColumn(){Name="InventoryID",Title="InventoryID",SelectClause="InventoryID",WhereClause="AllRecords.InventoryID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryGUID",new SearchColumn(){Name="InventoryGUID",Title="InventoryGUID",SelectClause="InventoryGUID",WhereClause="AllRecords.InventoryGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VariantID",new SearchColumn(){Name="VariantID",Title="VariantID",SelectClause="VariantID",WhereClause="AllRecords.VariantID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Color",new SearchColumn(){Name="Color",Title="Color",SelectClause="Color",WhereClause="AllRecords.Color",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Size",new SearchColumn(){Name="Size",Title="Size",SelectClause="Size",WhereClause="AllRecords.Size",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Quan",new SearchColumn(){Name="Quan",Title="Quan",SelectClause="Quan",WhereClause="AllRecords.Quan",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VendorFullSKU",new SearchColumn(){Name="VendorFullSKU",Title="VendorFullSKU",SelectClause="VendorFullSKU",WhereClause="AllRecords.VendorFullSKU",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("WarehouseLocation",new SearchColumn(){Name="WarehouseLocation",Title="WarehouseLocation",SelectClause="WarehouseLocation",WhereClause="AllRecords.WarehouseLocation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("WeightDelta",new SearchColumn(){Name="WeightDelta",Title="WeightDelta",SelectClause="WeightDelta",WhereClause="AllRecords.WeightDelta",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VendorID",new SearchColumn(){Name="VendorID",Title="VendorID",SelectClause="VendorID",WhereClause="AllRecords.VendorID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetInventorySearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetInventoryBasicSearchColumns()
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

        public virtual List<SearchColumn> GetInventoryAdvanceSearchColumns()
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
        
        
        public virtual string GetInventorySelectClause()
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
                        	selectQuery =  "Inventory."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Inventory."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Inventory GetInventory(System.Int32 InventoryId)
		{

			string sql=GetInventorySelectClause();
			sql+="from Inventory where InventoryID=@InventoryID ";
			SqlParameter parameter=new SqlParameter("@InventoryID",InventoryId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return InventoryFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Inventory> GetAllInventory()
		{

			string sql=GetInventorySelectClause();
			sql+="from Inventory";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Inventory>(ds, InventoryFromDataRow);
		}

		public virtual List<Inventory> GetPagedInventory(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetInventoryCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [InventoryID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([InventoryID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [InventoryID] ";
            tempsql += " FROM [Inventory] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("InventoryID"))
					tempsql += " , (AllRecords.[InventoryID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[InventoryID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetInventorySelectClause()+@" FROM [Inventory], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Inventory].[InventoryID] = PageIndex.[InventoryID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Inventory>(ds, InventoryFromDataRow);
			}else{ return null;}
		}

		private int GetInventoryCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Inventory as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Inventory as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Inventory))]
		public virtual Inventory InsertInventory(Inventory entity)
		{

			Inventory other=new Inventory();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Inventory ( [InventoryGUID]
				,[VariantID]
				,[Color]
				,[Size]
				,[Quan]
				,[VendorFullSKU]
				,[WarehouseLocation]
				,[WeightDelta]
				,[VendorID]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @InventoryGUID
				, @VariantID
				, @Color
				, @Size
				, @Quan
				, @VendorFullSKU
				, @WarehouseLocation
				, @WeightDelta
				, @VendorID
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@InventoryID",entity.InventoryId)
					, new SqlParameter("@InventoryGUID",entity.InventoryGuid)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Color",entity.Color ?? (object)DBNull.Value)
					, new SqlParameter("@Size",entity.Size ?? (object)DBNull.Value)
					, new SqlParameter("@Quan",entity.Quan)
					, new SqlParameter("@VendorFullSKU",entity.VendorFullSku ?? (object)DBNull.Value)
					, new SqlParameter("@WarehouseLocation",entity.WarehouseLocation ?? (object)DBNull.Value)
					, new SqlParameter("@WeightDelta",entity.WeightDelta)
					, new SqlParameter("@VendorID",entity.VendorId ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetInventory(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Inventory))]
		public virtual Inventory UpdateInventory(Inventory entity)
		{

			if (entity.IsTransient()) return entity;
			Inventory other = GetInventory(entity.InventoryId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Inventory set  [InventoryGUID]=@InventoryGUID
							, [VariantID]=@VariantID
							, [Color]=@Color
							, [Size]=@Size
							, [Quan]=@Quan
							, [VendorFullSKU]=@VendorFullSKU
							, [WarehouseLocation]=@WarehouseLocation
							, [WeightDelta]=@WeightDelta
							, [VendorID]=@VendorID
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where InventoryID=@InventoryID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@InventoryID",entity.InventoryId)
					, new SqlParameter("@InventoryGUID",entity.InventoryGuid)
					, new SqlParameter("@VariantID",entity.VariantId)
					, new SqlParameter("@Color",entity.Color ?? (object)DBNull.Value)
					, new SqlParameter("@Size",entity.Size ?? (object)DBNull.Value)
					, new SqlParameter("@Quan",entity.Quan)
					, new SqlParameter("@VendorFullSKU",entity.VendorFullSku ?? (object)DBNull.Value)
					, new SqlParameter("@WarehouseLocation",entity.WarehouseLocation ?? (object)DBNull.Value)
					, new SqlParameter("@WeightDelta",entity.WeightDelta)
					, new SqlParameter("@VendorID",entity.VendorId ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetInventory(entity.InventoryId);
		}

		public virtual bool DeleteInventory(System.Int32 InventoryId)
		{

			string sql="delete from Inventory where InventoryID=@InventoryID";
			SqlParameter parameter=new SqlParameter("@InventoryID",InventoryId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Inventory))]
		public virtual Inventory DeleteInventory(Inventory entity)
		{
			this.DeleteInventory(entity.InventoryId);
			return entity;
		}


		public virtual Inventory InventoryFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Inventory entity=new Inventory();
			entity.InventoryId = (System.Int32)dr["InventoryID"];
			entity.InventoryGuid = (System.Guid)dr["InventoryGUID"];
			entity.VariantId = (System.Int32)dr["VariantID"];
			entity.Color = dr["Color"].ToString();
			entity.Size = dr["Size"].ToString();
			entity.Quan = (System.Int32)dr["Quan"];
			entity.VendorFullSku = dr["VendorFullSKU"].ToString();
			entity.WarehouseLocation = dr["WarehouseLocation"].ToString();
			entity.WeightDelta = (System.Decimal)dr["WeightDelta"];
			entity.VendorId = dr["VendorID"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
