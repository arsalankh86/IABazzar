using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ISecurityLogService
	{
        Dictionary<string, string> GetSecurityLogBasicSearchColumns();
        
        List<SearchColumn> GetSecurityLogAdvanceSearchColumns();

		SecurityLog GetSecurityLog(System.Int64 Logid);
		SecurityLog UpdateSecurityLog(SecurityLog entity);
		bool DeleteSecurityLog(System.Int64 Logid);
		List<SecurityLog> GetAllSecurityLog();
		SecurityLog InsertSecurityLog(SecurityLog entity);

	}
	
	
}
