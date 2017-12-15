using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IFailedTransactionService
	{
        Dictionary<string, string> GetFailedTransactionBasicSearchColumns();
        
        List<SearchColumn> GetFailedTransactionAdvanceSearchColumns();

		FailedTransaction GetFailedTransaction(System.Int32 DbRecNo);
		FailedTransaction UpdateFailedTransaction(FailedTransaction entity);
		bool DeleteFailedTransaction(System.Int32 DbRecNo);
		List<FailedTransaction> GetAllFailedTransaction();
		FailedTransaction InsertFailedTransaction(FailedTransaction entity);

	}
	
	
}
