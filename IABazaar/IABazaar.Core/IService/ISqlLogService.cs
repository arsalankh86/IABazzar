using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ISqlLogService
	{
        Dictionary<string, string> GetSqlLogBasicSearchColumns();
        
        List<SearchColumn> GetSqlLogAdvanceSearchColumns();

		SqlLog GetSqlLog(System.Int32 SqlLogId);
		SqlLog UpdateSqlLog(SqlLog entity);
		bool DeleteSqlLog(System.Int32 SqlLogId);
		List<SqlLog> GetAllSqlLog();
		SqlLog InsertSqlLog(SqlLog entity);

	}
	
	
}
