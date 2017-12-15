using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IFailedTransactionRepositoryBase
	{
        
        Dictionary<string, string> GetFailedTransactionBasicSearchColumns();
        List<SearchColumn> GetFailedTransactionSearchColumns();
        List<SearchColumn> GetFailedTransactionAdvanceSearchColumns();
        

		FailedTransaction GetFailedTransaction(System.Int32 DbRecNo);
		FailedTransaction UpdateFailedTransaction(FailedTransaction entity);
		bool DeleteFailedTransaction(System.Int32 DbRecNo);
		FailedTransaction DeleteFailedTransaction(FailedTransaction entity);
		List<FailedTransaction> GetAllFailedTransaction();
		FailedTransaction InsertFailedTransaction(FailedTransaction entity);	}
	
	
}
