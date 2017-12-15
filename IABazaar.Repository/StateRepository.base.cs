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
		
	public abstract partial class StateRepositoryBase : Repository 
	{
        
        public StateRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("StateID",new SearchColumn(){Name="StateID",Title="StateID",SelectClause="StateID",WhereClause="AllRecords.StateID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StateGUID",new SearchColumn(){Name="StateGUID",Title="StateGUID",SelectClause="StateGUID",WhereClause="AllRecords.StateGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Name",new SearchColumn(){Name="Name",Title="Name",SelectClause="Name",WhereClause="AllRecords.Name",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CountryID",new SearchColumn(){Name="CountryID",Title="CountryID",SelectClause="CountryID",WhereClause="AllRecords.CountryID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Abbreviation",new SearchColumn(){Name="Abbreviation",Title="Abbreviation",SelectClause="Abbreviation",WhereClause="AllRecords.Abbreviation",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DisplayOrder",new SearchColumn(){Name="DisplayOrder",Title="DisplayOrder",SelectClause="DisplayOrder",WhereClause="AllRecords.DisplayOrder",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetStateSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetStateBasicSearchColumns()
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

        public virtual List<SearchColumn> GetStateAdvanceSearchColumns()
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
        
        
        public virtual string GetStateSelectClause()
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
                        	selectQuery =  "State."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",State."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual State GetState(System.Int32 StateId)
		{

			string sql=GetStateSelectClause();
			sql+="from State where StateID=@StateID ";
			SqlParameter parameter=new SqlParameter("@StateID",StateId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return StateFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<State> GetAllState()
		{

			string sql=GetStateSelectClause();
			sql+="from State";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<State>(ds, StateFromDataRow);
		}

		public virtual List<State> GetPagedState(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetStateCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [StateID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([StateID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [StateID] ";
            tempsql += " FROM [State] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("StateID"))
					tempsql += " , (AllRecords.[StateID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[StateID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetStateSelectClause()+@" FROM [State], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [State].[StateID] = PageIndex.[StateID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<State>(ds, StateFromDataRow);
			}else{ return null;}
		}

		private int GetStateCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM State as AllRecords ";
			else
				sql = "SELECT Count(*) FROM State as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(State))]
		public virtual State InsertState(State entity)
		{

			State other=new State();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into State ( [StateGUID]
				,[Name]
				,[CountryID]
				,[Abbreviation]
				,[Published]
				,[DisplayOrder]
				,[ExtensionData]
				,[CreatedOn] )
				Values
				( @StateGUID
				, @Name
				, @CountryID
				, @Abbreviation
				, @Published
				, @DisplayOrder
				, @ExtensionData
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StateID",entity.StateId)
					, new SqlParameter("@StateGUID",entity.StateGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CountryID",entity.CountryId ?? (object)DBNull.Value)
					, new SqlParameter("@Abbreviation",entity.Abbreviation)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetState(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(State))]
		public virtual State UpdateState(State entity)
		{

			if (entity.IsTransient()) return entity;
			State other = GetState(entity.StateId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update State set  [StateGUID]=@StateGUID
							, [Name]=@Name
							, [CountryID]=@CountryID
							, [Abbreviation]=@Abbreviation
							, [Published]=@Published
							, [DisplayOrder]=@DisplayOrder
							, [ExtensionData]=@ExtensionData
							, [CreatedOn]=@CreatedOn 
							 where StateID=@StateID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@StateID",entity.StateId)
					, new SqlParameter("@StateGUID",entity.StateGuid)
					, new SqlParameter("@Name",entity.Name)
					, new SqlParameter("@CountryID",entity.CountryId ?? (object)DBNull.Value)
					, new SqlParameter("@Abbreviation",entity.Abbreviation)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@DisplayOrder",entity.DisplayOrder)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetState(entity.StateId);
		}

		public virtual bool DeleteState(System.Int32 StateId)
		{

			string sql="delete from State where StateID=@StateID";
			SqlParameter parameter=new SqlParameter("@StateID",StateId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(State))]
		public virtual State DeleteState(State entity)
		{
			this.DeleteState(entity.StateId);
			return entity;
		}


		public virtual State StateFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			State entity=new State();
			entity.StateId = (System.Int32)dr["StateID"];
			entity.StateGuid = (System.Guid)dr["StateGUID"];
			entity.Name = dr["Name"].ToString();
			entity.CountryId = dr["CountryID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["CountryID"];
			entity.Abbreviation = dr["Abbreviation"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.DisplayOrder = (System.Int32)dr["DisplayOrder"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
