using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAspdnsfSysLogService
	{
        Dictionary<string, string> GetAspdnsfSysLogBasicSearchColumns();
        
        List<SearchColumn> GetAspdnsfSysLogAdvanceSearchColumns();

		AspdnsfSysLog GetAspdnsfSysLog(System.Int32 SysLogId);
		AspdnsfSysLog UpdateAspdnsfSysLog(AspdnsfSysLog entity);
		bool DeleteAspdnsfSysLog(System.Int32 SysLogId);
		List<AspdnsfSysLog> GetAllAspdnsfSysLog();
		AspdnsfSysLog InsertAspdnsfSysLog(AspdnsfSysLog entity);

	}
	
	
}
