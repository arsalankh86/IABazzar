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
		
	public abstract partial class KitItemRepositoryBase : Repository 
	{
        
        public KitItemRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("KitItemID",new SearchColumn(){Name="KitItemID",Title="KitItemID",SelectClause="KitItemID",WhereClause="AllRecords.KitItemID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitItemGUID",new SearchColumn(){Name="KitItemGUID",Title="KitItemGUID",SelectClause="KitItemGUID",WhereClause="AllRecords.KitItemGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("KitGroupID",new SearchColumn(){Name="KitGroupID",Title="KitGroupID",SelectClause="KitGroupID",WhereClause="AllRecords.KitGroupID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Description",new SearchColumn(){Name="Description",Title="Description",SelectClause="Description",WhereClause="AllRecords.Description",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PriceDelta",new SearchColumn(){Name="PriceDelta",Title="PriceDelta",SelectClause="PriceDelta",WhereClause="AllRecords.PriceDelta",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("WeightDelta",new SearchColumn(){Name="WeightDelta",Title="WeightDelta",SelectClause="WeightDelta",WhereClause="AllRecords.WeightDelta",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsDefault",new SearchColumn(){Name="IsDefault",Title="IsDefault",SelectClause="IsDefault",WhereClause="AllRecords.IsDefault",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionMaxLength",new SearchColumn(){Name="TextOptionMaxLength",Title="TextOptionMaxLength",SelectClause="TextOptionMaxLength",WhereClause="AllRecords.TextOptionMaxLength",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionWidth",new SearchColumn(){Name="TextOptionWidth",Title="TextOptionWidth",SelectClause="TextOptionWidth",WhereClause="AllRecords.TextOptionWidth",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TextOptionHeight",new SearchColumn(){Name="TextOptionHeight",Title="TextOptionHeight",SelectClause="TextOptionHeight",WhereClause="AllRecords.TextOptionHeight",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantID",new SearchColumn(){Name="InventoryVariantID",Title="InventoryVariantID",SelectClause="InventoryVariantID",WhereClause="AllRecords.InventoryVariantID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryQuantityDelta",new SearchColumn(){Name="InventoryQuantityDelta",Title="InventoryQuantityDelta",SelectClause="InventoryQuantityDelta",WhereClause="AllRecords.InventoryQuantityDelta",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantColor",new SearchColumn(){Name="InventoryVariantColor",Title="InventoryVariantColor",SelectClause="InventoryVariantColor",WhereClause="AllRecords.InventoryVariantColor",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryVariantSize",new SearchColumn(){Name="InventoryVariantSize",Title="InventoryVariantSize",SelectClause="InventoryVariantSize",WhereClause="AllRecords.InventoryVariantSize",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetKitItemSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetKitItemBasicSearchColumns()
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

        public virtual List<SearchColumn> GetKitItemAdvanceSearchColumns()
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
        
        
        public virtual string GetKitItemSelectClause()
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
                        	selectQuery =  "KitItem."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",KitItem."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual KitItem GetKitItem(System.Int32 KitItemId)
		{

			string sql=GetKitItemSelectClause();
			sql+="from KitItem where KitItemID=@KitItemID ";
			SqlParameter parameter=new SqlParameter("@KitItemID",KitItemId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return KitItemFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<KitItem> GetAllKitItem()
		{

			string sql=GetKitItemSelectClause();
			sql+="from KitItem";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitItem>(ds, KitItemFromDataRow);
		}

		public virtual List<KitItem> GetPagedKitItem(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetKitItemCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [KitItemID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([KitItemID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [KitItemID] ";
            tempsql += " FROM [KitItem] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("KitItemID"))
					tempsql += " , (AllRecords.[KitItemID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[KitItemID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetKitItemSelectClause()+@" FROM [KitItem], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [KitItem].[KitItemID] = PageIndex.[KitItemID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<KitItem>(ds, KitItemFromDataRow);
			}else{ return null;}
		}

		private int GetKitItemCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM KitItem as AllRecords ";
			else
				sql = "SELECT Count(*) FROM KitItem as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(KitItem))]
		public virtual KitItem InsertKitItem(KitItem entity)
		{

			KitItem other=new KitItem();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into KitItem ( [KitItemGUID]
				,[KitGroupID]
				,[Name]
				,[Description]
				,[PriceDelta]
				,[WeightDelta]
				,[IsDefault]
				,[DisplayOrder]
				,[ExtensionData]
				,[TextOptionMaxLength]
				,[TextOptionWidth]
				,[TextOptionHeight]
				,[InventoryVariantID]
				,[InventoryQuantityDelta]
				,[InventoryVariantColor]
				,[InventoryVariantSize]
				,[CreatedOn] )
				Values
				( @KitItemGUID
				, @KitGroupID
				, @Name
				, @Description
				, @PriceDelta
				, @WeightDelta
				, @IsDefault
				, @DisplayOrder
				, @ExtensionData
				, @TextOptionMaxLength
				, @TextOptionWidth
				, @TextOptionHeight
				, @InventoryVariantID
				, @InventoryQuantityDelta
				, @InventoryVariantColor
				, @InventoryVariantSize
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitItemID",entity.KitItemId)
					, new SqlParameter("@KitItemGUID",entity.KitItemGuid)
					, new SqlParameter("@KitGroupID",entity.KitGroupId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@PriceDelta",entity.PriceDelta)
					, new SqlParameter("@WeightDelta",entity.WeightDelta)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionMaxLength",entity.TextOptionMaxLength ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionWidth",entity.TextOptionWidth ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionHeight",entity.TextOptionHeight ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantID",entity.InventoryVariantId ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryQuantityDelta",entity.InventoryQuantityDelta)
					, new SqlParameter("@InventoryVariantColor",entity.InventoryVariantColor ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantSize",entity.InventoryVariantSize ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetKitItem(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(KitItem))]
		public virtual KitItem UpdateKitItem(KitItem entity)
		{

			if (entity.IsTransient()) return entity;
			KitItem other = GetKitItem(entity.KitItemId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update KitItem set  [KitItemGUID]=@KitItemGUID
							, [KitGroupID]=@KitGroupID
							, [Name]=@Name
							, [Description]=@Description
							, [PriceDelta]=@PriceDelta
							, [WeightDelta]=@WeightDelta
							, [IsDefault]=@IsDefault
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [TextOptionMaxLength]=@TextOptionMaxLength
							, [TextOptionWidth]=@TextOptionWidth
							, [TextOptionHeight]=@TextOptionHeight
							, [InventoryVariantID]=@InventoryVariantID
							, [InventoryQuantityDelta]=@InventoryQuantityDelta
							, [InventoryVariantColor]=@InventoryVariantColor
							, [InventoryVariantSize]=@InventoryVariantSize
							, [CreatedOn]=@CreatedOn 
							 where KitItemID=@KitItemID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@KitItemID",entity.KitItemId)
					, new SqlParameter("@KitItemGUID",entity.KitItemGuid)
					, new SqlParameter("@KitGroupID",entity.KitGroupId)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@Description",entity.Description ?? (object)DBNull.Value)
					, new SqlParameter("@PriceDelta",entity.PriceDelta)
					, new SqlParameter("@WeightDelta",entity.WeightDelta)
					, new SqlParameter("@IsDefault",entity.IsDefault)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionMaxLength",entity.TextOptionMaxLength ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionWidth",entity.TextOptionWidth ?? (object)DBNull.Value)
					, new SqlParameter("@TextOptionHeight",entity.TextOptionHeight ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantID",entity.InventoryVariantId ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryQuantityDelta",entity.InventoryQuantityDelta)
					, new SqlParameter("@InventoryVariantColor",entity.InventoryVariantColor ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryVariantSize",entity.InventoryVariantSize ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetKitItem(entity.KitItemId);
		}

		public virtual bool DeleteKitItem(System.Int32 KitItemId)
		{

			string sql="delete from KitItem where KitItemID=@KitItemID";
			SqlParameter parameter=new SqlParameter("@KitItemID",KitItemId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(KitItem))]
		public virtual KitItem DeleteKitItem(KitItem entity)
		{
			this.DeleteKitItem(entity.KitItemId);
			return entity;
		}


		public virtual KitItem KitItemFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			KitItem entity=new KitItem();
			entity.KitItemId = (System.Int32)dr["KitItemID"];
			entity.KitItemGuid = (System.Guid)dr["KitItemGUID"];
			entity.KitGroupId = (System.Int32)dr["KitGroupID"];
			entity.Name = dr["Name"].ToString();
			entity.Description = dr["Description"].ToString();
			entity.PriceDelta = (System.Decimal)dr["PriceDelta"];
			entity.WeightDelta = (System.Decimal)dr["WeightDelta"];
			entity.IsDefault = (System.Byte)dr["IsDefault"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.TextOptionMaxLength = dr["TextOptionMaxLength"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["TextOptionMaxLength"];
			entity.TextOptionWidth = dr["TextOptionWidth"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["TextOptionWidth"];
			entity.TextOptionHeight = dr["TextOptionHeight"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["TextOptionHeight"];
			entity.InventoryVariantId = dr["InventoryVariantID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["InventoryVariantID"];
			entity.InventoryQuantityDelta = (System.Int32)dr["InventoryQuantityDelta"];
			entity.InventoryVariantColor = dr["InventoryVariantColor"].ToString();
			entity.InventoryVariantSize = dr["InventoryVariantSize"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
