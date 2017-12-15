using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAspdnsfSysLogRepositoryBase
	{
        
        Dictionary<string, string> GetAspdnsfSysLogBasicSearchColumns();
        List<SearchColumn> GetAspdnsfSysLogSearchColumns();
        List<SearchColumn> GetAspdnsfSysLogAdvanceSearchColumns();
        

		AspdnsfSysLog GetAspdnsfSysLog(System.Int32 SysLogId);
		AspdnsfSysLog UpdateAspdnsfSysLog(AspdnsfSysLog entity);
		bool DeleteAspdnsfSysLog(System.Int32 SysLogId);
		AspdnsfSysLog DeleteAspdnsfSysLog(AspdnsfSysLog entity);
		List<AspdnsfSysLog> GetAllAspdnsfSysLog();
		AspdnsfSysLog InsertAspdnsfSysLog(AspdnsfSysLog entity);	}
	
	
}
