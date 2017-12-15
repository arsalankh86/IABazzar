using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IErrorLogService
	{
        Dictionary<string, string> GetErrorLogBasicSearchColumns();
        
        List<SearchColumn> GetErrorLogAdvanceSearchColumns();

		ErrorLog GetErrorLog(System.Int32 Logid);
		ErrorLog UpdateErrorLog(ErrorLog entity);
		bool DeleteErrorLog(System.Int32 Logid);
		List<ErrorLog> GetAllErrorLog();
		ErrorLog InsertErrorLog(ErrorLog entity);

	}
	
	
}
