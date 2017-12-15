using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IErrorLogRepositoryBase
	{
        
        Dictionary<string, string> GetErrorLogBasicSearchColumns();
        List<SearchColumn> GetErrorLogSearchColumns();
        List<SearchColumn> GetErrorLogAdvanceSearchColumns();
        

		ErrorLog GetErrorLog(System.Int32 Logid);
		ErrorLog UpdateErrorLog(ErrorLog entity);
		bool DeleteErrorLog(System.Int32 Logid);
		ErrorLog DeleteErrorLog(ErrorLog entity);
		List<ErrorLog> GetAllErrorLog();
		ErrorLog InsertErrorLog(ErrorLog entity);	}
	
	
}
