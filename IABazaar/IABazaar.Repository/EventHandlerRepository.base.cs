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
		
	public abstract partial class EventHandlerRepositoryBase : Repository 
	{
        
        public EventHandlerRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("EventID",new SearchColumn(){Name="EventID",Title="EventID",SelectClause="EventID",WhereClause="AllRecords.EventID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EventName",new SearchColumn(){Name="EventName",Title="EventName",SelectClause="EventName",WhereClause="AllRecords.EventName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CalloutURL",new SearchColumn(){Name="CalloutURL",Title="CalloutURL",SelectClause="CalloutURL",WhereClause="AllRecords.CalloutURL",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("XmlPackage",new SearchColumn(){Name="XmlPackage",Title="XmlPackage",SelectClause="XmlPackage",WhereClause="AllRecords.XmlPackage",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Debug",new SearchColumn(){Name="Debug",Title="Debug",SelectClause="Debug",WhereClause="AllRecords.Debug",DataType="System.Boolean",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Active",new SearchColumn(){Name="Active",Title="Active",SelectClause="Active",WhereClause="AllRecords.Active",DataType="System.Boolean",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetEventHandlerSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetEventHandlerBasicSearchColumns()
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

        public virtual List<SearchColumn> GetEventHandlerAdvanceSearchColumns()
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
        
        
        public virtual string GetEventHandlerSelectClause()
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
                        	selectQuery =  "EventHandler."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",EventHandler."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual IABazaar.Core.Entities.EventHandler GetEventHandler(System.Int32 EventId)
		{

			string sql=GetEventHandlerSelectClause();
			sql+="from EventHandler where EventID=@EventID ";
			SqlParameter parameter=new SqlParameter("@EventID",EventId);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return EventHandlerFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<IABazaar.Core.Entities.EventHandler> GetAllEventHandler()
		{

			string sql=GetEventHandlerSelectClause();
			sql+="from EventHandler";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<IABazaar.Core.Entities.EventHandler>(ds, EventHandlerFromDataRow);
		}

		public virtual List<IABazaar.Core.Entities.EventHandler> GetPagedEventHandler(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetEventHandlerCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [EventID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([EventID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [EventID] ";
            tempsql += " FROM [EventHandler] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("EventID"))
					tempsql += " , (AllRecords.[EventID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[EventID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetEventHandlerSelectClause()+@" FROM [EventHandler], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [EventHandler].[EventID] = PageIndex.[EventID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<IABazaar.Core.Entities.EventHandler>(ds, EventHandlerFromDataRow);
			}else{ return null;}
		}

		private int GetEventHandlerCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM EventHandler as AllRecords ";
			else
				sql = "SELECT Count(*) FROM EventHandler as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(IABazaar.Core.Entities.EventHandler))]
		public virtual IABazaar.Core.Entities.EventHandler InsertEventHandler(IABazaar.Core.Entities.EventHandler entity)
		{

			IABazaar.Core.Entities.EventHandler other=new IABazaar.Core.Entities.EventHandler();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into EventHandler ( [EventName]
				,[CalloutURL]
				,[XmlPackage]
				,[Debug]
				,[Active] )
				Values
				( @EventName
				, @CalloutURL
				, @XmlPackage
				, @Debug
				, @Active );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@EventID",entity.EventId)
					, new SqlParameter("@EventName",entity.EventName)
					, new SqlParameter("@CalloutURL",entity.CalloutUrl)
					, new SqlParameter("@XmlPackage",entity.XmlPackage)
					, new SqlParameter("@Debug",entity.Debug)
					, new SqlParameter("@Active",entity.Active)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetEventHandler(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(IABazaar.Core.Entities.EventHandler))]
		public virtual IABazaar.Core.Entities.EventHandler UpdateEventHandler(IABazaar.Core.Entities.EventHandler entity)
		{

			if (entity.IsTransient()) return entity;
			IABazaar.Core.Entities.EventHandler other = GetEventHandler(entity.EventId);
			if (entity.Equals(other)) return entity;
			string sql=@"Update EventHandler set  [EventName]=@EventName
							, [CalloutURL]=@CalloutURL
							, [XmlPackage]=@XmlPackage
							, [Debug]=@Debug
							, [Active]=@Active 
							 where EventID=@EventID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@EventID",entity.EventId)
					, new SqlParameter("@EventName",entity.EventName)
					, new SqlParameter("@CalloutURL",entity.CalloutUrl)
					, new SqlParameter("@XmlPackage",entity.XmlPackage)
					, new SqlParameter("@Debug",entity.Debug)
					, new SqlParameter("@Active",entity.Active)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetEventHandler(entity.EventId);
		}

		public virtual bool DeleteEventHandler(System.Int32 EventId)
		{

			string sql="delete from EventHandler where EventID=@EventID";
			SqlParameter parameter=new SqlParameter("@EventID",EventId);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(IABazaar.Core.Entities.EventHandler))]
		public virtual IABazaar.Core.Entities.EventHandler DeleteEventHandler(IABazaar.Core.Entities.EventHandler entity)
		{
			this.DeleteEventHandler(entity.EventId);
			return entity;
		}


		public virtual IABazaar.Core.Entities.EventHandler EventHandlerFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			IABazaar.Core.Entities.EventHandler entity=new IABazaar.Core.Entities.EventHandler();
			entity.EventId = (System.Int32)dr["EventID"];
			entity.EventName = dr["EventName"].ToString();
			entity.CalloutUrl = dr["CalloutURL"].ToString();
			entity.XmlPackage = dr["XmlPackage"].ToString();
			entity.Debug = (System.Boolean)dr["Debug"];
			entity.Active = (System.Boolean)dr["Active"];
			return entity;
		}

	}
	
	
}
