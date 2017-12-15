using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SecurityLogService : ISecurityLogService 
	{
		private ISecurityLogRepository _iSecurityLogRepository;
        
		public SecurityLogService(ISecurityLogRepository iSecurityLogRepository)
		{
			this._iSecurityLogRepository = iSecurityLogRepository;
		}
        
        public Dictionary<string, string> GetSecurityLogBasicSearchColumns()
        {
            
            return this._iSecurityLogRepository.GetSecurityLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSecurityLogAdvanceSearchColumns()
        {
            
            return this._iSecurityLogRepository.GetSecurityLogAdvanceSearchColumns();
           
        }


		public SecurityLog GetSecurityLog(System.Int64 Logid)
		{
			return _iSecurityLogRepository.GetSecurityLog(Logid);
		}

		public SecurityLog UpdateSecurityLog(SecurityLog entity)
		{
			return _iSecurityLogRepository.UpdateSecurityLog(entity);
		}

		public bool DeleteSecurityLog(System.Int64 Logid)
		{
			return _iSecurityLogRepository.DeleteSecurityLog(Logid);
		}

		public List<SecurityLog> GetAllSecurityLog()
		{
			return _iSecurityLogRepository.GetAllSecurityLog();
		}

		public SecurityLog InsertSecurityLog(SecurityLog entity)
		{
			 return _iSecurityLogRepository.InsertSecurityLog(entity);
		}


	}
	
	
}
