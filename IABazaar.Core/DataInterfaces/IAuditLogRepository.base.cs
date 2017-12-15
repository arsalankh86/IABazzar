using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAuditLogRepositoryBase
	{
        
        Dictionary<string, string> GetAuditLogBasicSearchColumns();
        List<SearchColumn> GetAuditLogSearchColumns();
        List<SearchColumn> GetAuditLogAdvanceSearchColumns();
        

		AuditLog GetAuditLog(System.Int64 AuditLogId);
		AuditLog UpdateAuditLog(AuditLog entity);
		bool DeleteAuditLog(System.Int64 AuditLogId);
		AuditLog DeleteAuditLog(AuditLog entity);
		List<AuditLog> GetAllAuditLog();
		AuditLog InsertAuditLog(AuditLog entity);	}
	
	
}
