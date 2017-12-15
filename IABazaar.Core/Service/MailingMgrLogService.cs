using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class MailingMgrLogService : IMailingMgrLogService 
	{
		private IMailingMgrLogRepository _iMailingMgrLogRepository;
        
		public MailingMgrLogService(IMailingMgrLogRepository iMailingMgrLogRepository)
		{
			this._iMailingMgrLogRepository = iMailingMgrLogRepository;
		}
        
        public Dictionary<string, string> GetMailingMgrLogBasicSearchColumns()
        {
            
            return this._iMailingMgrLogRepository.GetMailingMgrLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetMailingMgrLogAdvanceSearchColumns()
        {
            
            return this._iMailingMgrLogRepository.GetMailingMgrLogAdvanceSearchColumns();
           
        }


		public MailingMgrLog GetMailingMgrLog(System.Int32 MailingMgrLogId)
		{
			return _iMailingMgrLogRepository.GetMailingMgrLog(MailingMgrLogId);
		}

		public MailingMgrLog UpdateMailingMgrLog(MailingMgrLog entity)
		{
			return _iMailingMgrLogRepository.UpdateMailingMgrLog(entity);
		}

		public bool DeleteMailingMgrLog(System.Int32 MailingMgrLogId)
		{
			return _iMailingMgrLogRepository.DeleteMailingMgrLog(MailingMgrLogId);
		}

		public List<MailingMgrLog> GetAllMailingMgrLog()
		{
			return _iMailingMgrLogRepository.GetAllMailingMgrLog();
		}

		public MailingMgrLog InsertMailingMgrLog(MailingMgrLog entity)
		{
			 return _iMailingMgrLogRepository.InsertMailingMgrLog(entity);
		}


	}
	
	
}
