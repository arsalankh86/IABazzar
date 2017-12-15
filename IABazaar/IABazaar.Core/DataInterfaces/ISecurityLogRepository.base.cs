using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISecurityLogRepositoryBase
	{
        
        Dictionary<string, string> GetSecurityLogBasicSearchColumns();
        List<SearchColumn> GetSecurityLogSearchColumns();
        List<SearchColumn> GetSecurityLogAdvanceSearchColumns();
        

		SecurityLog GetSecurityLog(System.Int64 Logid);
		SecurityLog UpdateSecurityLog(SecurityLog entity);
		bool DeleteSecurityLog(System.Int64 Logid);
		SecurityLog DeleteSecurityLog(SecurityLog entity);
		List<SecurityLog> GetAllSecurityLog();
		SecurityLog InsertSecurityLog(SecurityLog entity);	}
	
	
}
