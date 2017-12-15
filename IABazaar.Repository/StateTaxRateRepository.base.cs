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
		
	public abstract partial class StateTaxRateRepositoryBase : Repository 
	{
        
        public StateTaxRateRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StateTaxID",new SearchColumn(){Name="StateTaxID",Title="StateTaxID",SelectClause="StateTaxID",WhereClause="AllRecords.StateTaxID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StateID",new SearchColumn(){Name="StateID",Title="StateID",SelectClause="StateID",WhereClause="AllRecords.StateID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxClassID",new SearchColumn(){Name="TaxClassID",Title="TaxClassID",SelectClause="TaxClassID",WhereClause="AllRecords.TaxClassID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TaxRate",new SearchColumn(){Name="TaxRate",Title="TaxRate",SelectClause="TaxRate",WhereClause="AllRecords.TaxRate",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetStateTaxRateSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetStateTaxRateBasicSearchColumns()
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

        public virtual List<SearchColumn> GetStateTaxRateAdvanceSearchColumns()
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
        
        
        public virtual string GetStateTaxRateSelectClause()
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
                        	selectQuery =  "StateTaxRate."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",StateTaxRate."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual StateTaxRate GetStateTaxRate(System.Int32 StateTaxId)
		{

			string sql=GetStateTaxRateSelectClause();
			sql+="from StateTaxRate where StateTaxID=@StateTaxID ";
			SqlParameter parameter=new SqlParameter("@StateTaxID",StateTaxId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return StateTaxRateFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<StateTaxRate> GetAllStateTaxRate()
		{

			string sql=GetStateTaxRateSelectClause();
			sql+="from StateTaxRate";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<StateTaxRate>(ds, StateTaxRateFromDataRow);
		}

		public virtual List<StateTaxRate> GetPagedStateTaxRate(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetStateTaxRateCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StateTaxID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StateTaxID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StateTaxID] ";
            tempsql += " FROM [StateTaxRate] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StateTaxID"))
					tempsql += " , (AllRecords.[StateTaxID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StateTaxID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetStateTaxRateSelectClause()+@" FROM [StateTaxRate], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [StateTaxRate].[StateTaxID] = PageIndex.[StateTaxID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<StateTaxRate>(ds, StateTaxRateFromDataRow);
			}else{ return null;}
		}

		private int GetStateTaxRateCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM StateTaxRate as AllRecords ";
			else
				sql = "SELECT Count(*) FROM StateTaxRate as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(StateTaxRate))]
		public virtual StateTaxRate InsertStateTaxRate(StateTaxRate entity)
		{

			StateTaxRate other=new StateTaxRate();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into StateTaxRate ( [StateID]
				,[TaxClassID]
				,[TaxRate]
				,[CreatedOn] )
				Values
				( @StateID
				, @TaxClassID
				, @TaxRate
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StateTaxID",entity.StateTaxId)
					, new SqlParameter("@StateID",entity.StateId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetStateTaxRate(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(StateTaxRate))]
		public virtual StateTaxRate UpdateStateTaxRate(StateTaxRate entity)
		{

			if (entity.IsTransient()) return entity;
			StateTaxRate other = GetStateTaxRate(entity.StateTaxId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update StateTaxRate set  [StateID]=@StateID
							, [TaxClassID]=@TaxClassID
							, [TaxRate]=@TaxRate
							, [CreatedOn]=@CreatedOn 
							 where StateTaxID=@StateTaxID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StateTaxID",entity.StateTaxId)
					, new SqlParameter("@StateID",entity.StateId)
					, new SqlParameter("@TaxClassID",entity.TaxClassId)
					, new SqlParameter("@TaxRate",entity.TaxRate ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetStateTaxRate(entity.StateTaxId);
		}

		public virtual bool DeleteStateTaxRate(System.Int32 StateTaxId)
		{

			string sql="delete from StateTaxRate where StateTaxID=@StateTaxID";
			SqlParameter parameter=new SqlParameter("@StateTaxID",StateTaxId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(StateTaxRate))]
		public virtual StateTaxRate DeleteStateTaxRate(StateTaxRate entity)
		{
			this.DeleteStateTaxRate(entity.StateTaxId);
			return entity;
		}


		public virtual StateTaxRate StateTaxRateFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			StateTaxRate entity=new StateTaxRate();
			entity.StateTaxId = (System.Int32)dr["StateTaxID"];
			entity.StateId = (System.Int32)dr["StateID"];
			entity.TaxClassId = (System.Int32)dr["TaxClassID"];
			entity.TaxRate = dr["TaxRate"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["TaxRate"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
