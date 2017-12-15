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
		
	public abstract partial class CreditCardTypeRepositoryBase : Repository 
	{
        
        public CreditCardTypeRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("CardTypeID",new SearchColumn(){Name="CardTypeID",Title="CardTypeID",SelectClause="CardTypeID",WhereClause="AllRecords.CardTypeID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardTypeGUID",new SearchColumn(){Name="CardTypeGUID",Title="CardTypeGUID",SelectClause="CardTypeGUID",WhereClause="AllRecords.CardTypeGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardType",new SearchColumn(){Name="CardType",Title="CardType",SelectClause="CardType",WhereClause="AllRecords.CardType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Accepted",new SearchColumn(){Name="Accepted",Title="Accepted",SelectClause="Accepted",WhereClause="AllRecords.Accepted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetCreditCardTypeSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetCreditCardTypeBasicSearchColumns()
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

        public virtual List<SearchColumn> GetCreditCardTypeAdvanceSearchColumns()
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
        
        
        public virtual string GetCreditCardTypeSelectClause()
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
                        	selectQuery =  "CreditCardType."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",CreditCardType."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual CreditCardType GetCreditCardType(System.Int32 CardTypeId)
		{

			string sql=GetCreditCardTypeSelectClause();
			sql+="from CreditCardType where CardTypeID=@CardTypeID ";
			SqlParameter parameter=new SqlParameter("@CardTypeID",CardTypeId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return CreditCardTypeFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<CreditCardType> GetAllCreditCardType()
		{

			string sql=GetCreditCardTypeSelectClause();
			sql+="from CreditCardType";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CreditCardType>(ds, CreditCardTypeFromDataRow);
		}

		public virtual List<CreditCardType> GetPagedCreditCardType(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetCreditCardTypeCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [CardTypeID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([CardTypeID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [CardTypeID] ";
            tempsql += " FROM [CreditCardType] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("CardTypeID"))
					tempsql += " , (AllRecords.[CardTypeID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[CardTypeID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetCreditCardTypeSelectClause()+@" FROM [CreditCardType], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [CreditCardType].[CardTypeID] = PageIndex.[CardTypeID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<CreditCardType>(ds, CreditCardTypeFromDataRow);
			}else{ return null;}
		}

		private int GetCreditCardTypeCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM CreditCardType as AllRecords ";
			else
				sql = "SELECT Count(*) FROM CreditCardType as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(CreditCardType))]
		public virtual CreditCardType InsertCreditCardType(CreditCardType entity)
		{

			CreditCardType other=new CreditCardType();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into CreditCardType ( [CardTypeGUID]
				,[CardType]
				,[Accepted]
				,[CreatedOn] )
				Values
				( @CardTypeGUID
				, @CardType
				, @Accepted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CardTypeID",entity.CardTypeId)
					, new SqlParameter("@CardTypeGUID",entity.CardTypeGuid)
					, new SqlParameter("@CardType",entity.CardType)
					, new SqlParameter("@Accepted",entity.Accepted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetCreditCardType(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(CreditCardType))]
		public virtual CreditCardType UpdateCreditCardType(CreditCardType entity)
		{

			if (entity.IsTransient()) return entity;
			CreditCardType other = GetCreditCardType(entity.CardTypeId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update CreditCardType set  [CardTypeGUID]=@CardTypeGUID
							, [CardType]=@CardType
							, [Accepted]=@Accepted
							, [CreatedOn]=@CreatedOn 
							 where CardTypeID=@CardTypeID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@CardTypeID",entity.CardTypeId)
					, new SqlParameter("@CardTypeGUID",entity.CardTypeGuid)
					, new SqlParameter("@CardType",entity.CardType)
					, new SqlParameter("@Accepted",entity.Accepted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetCreditCardType(entity.CardTypeId);
		}

		public virtual bool DeleteCreditCardType(System.Int32 CardTypeId)
		{

			string sql="delete from CreditCardType where CardTypeID=@CardTypeID";
			SqlParameter parameter=new SqlParameter("@CardTypeID",CardTypeId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(CreditCardType))]
		public virtual CreditCardType DeleteCreditCardType(CreditCardType entity)
		{
			this.DeleteCreditCardType(entity.CardTypeId);
			return entity;
		}


		public virtual CreditCardType CreditCardTypeFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			CreditCardType entity=new CreditCardType();
			entity.CardTypeId = (System.Int32)dr["CardTypeID"];
			entity.CardTypeGuid = (System.Guid)dr["CardTypeGUID"];
			entity.CardType = dr["CardType"].ToString();
			entity.Accepted = (System.Byte)dr["Accepted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
