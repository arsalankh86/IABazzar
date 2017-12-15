using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IMailingMgrLogRepositoryBase
	{
        
        Dictionary<string, string> GetMailingMgrLogBasicSearchColumns();
        List<SearchColumn> GetMailingMgrLogSearchColumns();
        List<SearchColumn> GetMailingMgrLogAdvanceSearchColumns();
        

		MailingMgrLog GetMailingMgrLog(System.Int32 MailingMgrLogId);
		MailingMgrLog UpdateMailingMgrLog(MailingMgrLog entity);
		bool DeleteMailingMgrLog(System.Int32 MailingMgrLogId);
		MailingMgrLog DeleteMailingMgrLog(MailingMgrLog entity);
		List<MailingMgrLog> GetAllMailingMgrLog();
		MailingMgrLog InsertMailingMgrLog(MailingMgrLog entity);	}
	
	
}
