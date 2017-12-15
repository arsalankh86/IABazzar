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
		
	public abstract partial class FaqRepositoryBase : Repository 
	{
        
        public FaqRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("FAQID",new SearchColumn(){Name="FAQID",Title="FAQID",SelectClause="FAQID",WhereClause="AllRecords.FAQID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FAQGUID",new SearchColumn(){Name="FAQGUID",Title="FAQGUID",SelectClause="FAQGUID",WhereClause="AllRecords.FAQGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QText",new SearchColumn(){Name="QText",Title="QText",SelectClause="QText",WhereClause="AllRecords.QText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AText",new SearchColumn(){Name="AText",Title="AText",SelectClause="AText",WhereClause="AllRecords.AText",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Published",new SearchColumn(){Name="Published",Title="Published",SelectClause="Published",WhereClause="AllRecords.Published",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Wholesale",new SearchColumn(){Name="Wholesale",Title="Wholesale",SelectClause="Wholesale",WhereClause="AllRecords.Wholesale",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CreatedOn",new SearchColumn(){Name="CreatedOn",Title="CreatedOn",SelectClause="CreatedOn",WhereClause="AllRecords.CreatedOn",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetFaqSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetFaqBasicSearchColumns()
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

        public virtual List<SearchColumn> GetFaqAdvanceSearchColumns()
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
        
        
        public virtual string GetFaqSelectClause()
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
                        	selectQuery =  "FAQ."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",FAQ."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Faq GetFaq(System.Int32 Faqid)
		{

			string sql=GetFaqSelectClause();
			sql+="from FAQ where FAQID=@FAQID ";
			SqlParameter parameter=new SqlParameter("@FAQID",Faqid);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return FaqFromDataRow(ds.Tables[0].Rows[0]);
		}

		public virtual List<Faq> GetAllFaq()
		{

			string sql=GetFaqSelectClause();
			sql+="from FAQ";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Faq>(ds, FaqFromDataRow);
		}

		public virtual List<Faq> GetPagedFaq(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetFaqCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [FAQID] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([FAQID])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [FAQID] ";
            tempsql += " FROM [FAQ] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("FAQID"))
					tempsql += " , (AllRecords.[FAQID])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[FAQID])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetFaqSelectClause()+@" FROM [FAQ], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [FAQ].[FAQID] = PageIndex.[FAQID] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Faq>(ds, FaqFromDataRow);
			}else{ return null;}
		}

		private int GetFaqCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM FAQ as AllRecords ";
			else
				sql = "SELECT Count(*) FROM FAQ as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Faq))]
		public virtual Faq InsertFaq(Faq entity)
		{

			Faq other=new Faq();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into FAQ ( [FAQGUID]
				,[QText]
				,[AText]
				,[Published]
				,[Wholesale]
				,[ExtensionData]
				,[Deleted]
				,[CreatedOn] )
				Values
				( @FAQGUID
				, @QText
				, @AText
				, @Published
				, @Wholesale
				, @ExtensionData
				, @Deleted
				, @CreatedOn );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@FAQID",entity.Faqid)
					, new SqlParameter("@FAQGUID",entity.Faqguid)
					, new SqlParameter("@QText",entity.Qtext ?? (object)DBNull.Value)
					, new SqlParameter("@AText",entity.Atext ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetFaq(Convert.ToInt32(identity));
			}
			return entity;
		}

		[MOLog(AuditOperations.Update,typeof(Faq))]
		public virtual Faq UpdateFaq(Faq entity)
		{

			if (entity.IsTransient()) return entity;
			Faq other = GetFaq(entity.Faqid);
			if (entity.Equals(other)) return entity;
			string sql=@"Update FAQ set  [FAQGUID]=@FAQGUID
							, [QText]=@QText
							, [AText]=@AText
							, [Published]=@Published
							, [Wholesale]=@Wholesale
							, [ExtensionData]=@ExtensionData
							, [Deleted]=@Deleted
							, [CreatedOn]=@CreatedOn 
							 where FAQID=@FAQID";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@FAQID",entity.Faqid)
					, new SqlParameter("@FAQGUID",entity.Faqguid)
					, new SqlParameter("@QText",entity.Qtext ?? (object)DBNull.Value)
					, new SqlParameter("@AText",entity.Atext ?? (object)DBNull.Value)
					, new SqlParameter("@Published",entity.Published)
					, new SqlParameter("@Wholesale",entity.Wholesale)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CreatedOn",entity.CreatedOn)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetFaq(entity.Faqid);
		}

		public virtual bool DeleteFaq(System.Int32 Faqid)
		{

			string sql="delete from FAQ where FAQID=@FAQID";
			SqlParameter parameter=new SqlParameter("@FAQID",Faqid);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Faq))]
		public virtual Faq DeleteFaq(Faq entity)
		{
			this.DeleteFaq(entity.Faqid);
			return entity;
		}


		public virtual Faq FaqFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Faq entity=new Faq();
			entity.Faqid = (System.Int32)dr["FAQID"];
			entity.Faqguid = (System.Guid)dr["FAQGUID"];
			entity.Qtext = dr["QText"].ToString();
			entity.Atext = dr["AText"].ToString();
			entity.Published = (System.Byte)dr["Published"];
			entity.Wholesale = (System.Byte)dr["Wholesale"];
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CreatedOn = (System.DateTime)dr["CreatedOn"];
			return entity;
		}

	}
	
	
}
