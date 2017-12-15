using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IMailingMgrLogService
	{
        Dictionary<string, string> GetMailingMgrLogBasicSearchColumns();
        
        List<SearchColumn> GetMailingMgrLogAdvanceSearchColumns();

		MailingMgrLog GetMailingMgrLog(System.Int32 MailingMgrLogId);
		MailingMgrLog UpdateMailingMgrLog(MailingMgrLog entity);
		bool DeleteMailingMgrLog(System.Int32 MailingMgrLogId);
		List<MailingMgrLog> GetAllMailingMgrLog();
		MailingMgrLog InsertMailingMgrLog(MailingMgrLog entity);

	}
	
	
}
