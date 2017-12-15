using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomerSessionService : ICustomerSessionService 
	{
		private ICustomerSessionRepository _iCustomerSessionRepository;
        
		public CustomerSessionService(ICustomerSessionRepository iCustomerSessionRepository)
		{
			this._iCustomerSessionRepository = iCustomerSessionRepository;
		}
        
        public Dictionary<string, string> GetCustomerSessionBasicSearchColumns()
        {
            
            return this._iCustomerSessionRepository.GetCustomerSessionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomerSessionAdvanceSearchColumns()
        {
            
            return this._iCustomerSessionRepository.GetCustomerSessionAdvanceSearchColumns();
           
        }


		public CustomerSession GetCustomerSession(System.Int32 CustomerSessionId)
		{
			return _iCustomerSessionRepository.GetCustomerSession(CustomerSessionId);
		}

		public CustomerSession UpdateCustomerSession(CustomerSession entity)
		{
			return _iCustomerSessionRepository.UpdateCustomerSession(entity);
		}

		public bool DeleteCustomerSession(System.Int32 CustomerSessionId)
		{
			return _iCustomerSessionRepository.DeleteCustomerSession(CustomerSessionId);
		}

		public List<CustomerSession> GetAllCustomerSession()
		{
			return _iCustomerSessionRepository.GetAllCustomerSession();
		}

		public CustomerSession InsertCustomerSession(CustomerSession entity)
		{
			 return _iCustomerSessionRepository.InsertCustomerSession(entity);
		}


	}
	
	
}
