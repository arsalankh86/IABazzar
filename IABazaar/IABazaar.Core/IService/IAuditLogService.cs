using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAuditLogService
	{
        Dictionary<string, string> GetAuditLogBasicSearchColumns();
        
        List<SearchColumn> GetAuditLogAdvanceSearchColumns();

		AuditLog GetAuditLog(System.Int64 AuditLogId);
		AuditLog UpdateAuditLog(AuditLog entity);
		bool DeleteAuditLog(System.Int64 AuditLogId);
		List<AuditLog> GetAllAuditLog();
		AuditLog InsertAuditLog(AuditLog entity);

	}
	
	
}
