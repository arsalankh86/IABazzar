using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class FailedTransactionService : IFailedTransactionService 
	{
		private IFailedTransactionRepository _iFailedTransactionRepository;
        
		public FailedTransactionService(IFailedTransactionRepository iFailedTransactionRepository)
		{
			this._iFailedTransactionRepository = iFailedTransactionRepository;
		}
        
        public Dictionary<string, string> GetFailedTransactionBasicSearchColumns()
        {
            
            return this._iFailedTransactionRepository.GetFailedTransactionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetFailedTransactionAdvanceSearchColumns()
        {
            
            return this._iFailedTransactionRepository.GetFailedTransactionAdvanceSearchColumns();
           
        }


		public FailedTransaction GetFailedTransaction(System.Int32 DbRecNo)
		{
			return _iFailedTransactionRepository.GetFailedTransaction(DbRecNo);
		}

		public FailedTransaction UpdateFailedTransaction(FailedTransaction entity)
		{
			return _iFailedTransactionRepository.UpdateFailedTransaction(entity);
		}

		public bool DeleteFailedTransaction(System.Int32 DbRecNo)
		{
			return _iFailedTransactionRepository.DeleteFailedTransaction(DbRecNo);
		}

		public List<FailedTransaction> GetAllFailedTransaction()
		{
			return _iFailedTransactionRepository.GetAllFailedTransaction();
		}

		public FailedTransaction InsertFailedTransaction(FailedTransaction entity)
		{
			 return _iFailedTransactionRepository.InsertFailedTransaction(entity);
		}


	}
	
	
}
