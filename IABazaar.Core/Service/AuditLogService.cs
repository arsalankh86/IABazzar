using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AuditLogService : IAuditLogService 
	{
		private IAuditLogRepository _iAuditLogRepository;
        
		public AuditLogService(IAuditLogRepository iAuditLogRepository)
		{
			this._iAuditLogRepository = iAuditLogRepository;
		}
        
        public Dictionary<string, string> GetAuditLogBasicSearchColumns()
        {
            
            return this._iAuditLogRepository.GetAuditLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAuditLogAdvanceSearchColumns()
        {
            
            return this._iAuditLogRepository.GetAuditLogAdvanceSearchColumns();
           
        }


		public AuditLog GetAuditLog(System.Int64 AuditLogId)
		{
			return _iAuditLogRepository.GetAuditLog(AuditLogId);
		}

		public AuditLog UpdateAuditLog(AuditLog entity)
		{
			return _iAuditLogRepository.UpdateAuditLog(entity);
		}

		public bool DeleteAuditLog(System.Int64 AuditLogId)
		{
			return _iAuditLogRepository.DeleteAuditLog(AuditLogId);
		}

		public List<AuditLog> GetAllAuditLog()
		{
			return _iAuditLogRepository.GetAllAuditLog();
		}

		public AuditLog InsertAuditLog(AuditLog entity)
		{
			 return _iAuditLogRepository.InsertAuditLog(entity);
		}


	}
	
	
}
