using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISqlLogRepositoryBase
	{
        
        Dictionary<string, string> GetSqlLogBasicSearchColumns();
        List<SearchColumn> GetSqlLogSearchColumns();
        List<SearchColumn> GetSqlLogAdvanceSearchColumns();
        

		SqlLog GetSqlLog(System.Int32 SqlLogId);
		SqlLog UpdateSqlLog(SqlLog entity);
		bool DeleteSqlLog(System.Int32 SqlLogId);
		SqlLog DeleteSqlLog(SqlLog entity);
		List<SqlLog> GetAllSqlLog();
		SqlLog InsertSqlLog(SqlLog entity);	}
	
	
}
