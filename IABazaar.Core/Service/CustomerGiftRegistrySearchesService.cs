using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomerGiftRegistrySearchesService : ICustomerGiftRegistrySearchesService 
	{
		private ICustomerGiftRegistrySearchesRepository _iCustomerGiftRegistrySearchesRepository;
        
		public CustomerGiftRegistrySearchesService(ICustomerGiftRegistrySearchesRepository iCustomerGiftRegistrySearchesRepository)
		{
			this._iCustomerGiftRegistrySearchesRepository = iCustomerGiftRegistrySearchesRepository;
		}
        
        public Dictionary<string, string> GetCustomerGiftRegistrySearchesBasicSearchColumns()
        {
            
            return this._iCustomerGiftRegistrySearchesRepository.GetCustomerGiftRegistrySearchesBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomerGiftRegistrySearchesAdvanceSearchColumns()
        {
            
            return this._iCustomerGiftRegistrySearchesRepository.GetCustomerGiftRegistrySearchesAdvanceSearchColumns();
           
        }


		public CustomerGiftRegistrySearches GetCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId)
		{
			return _iCustomerGiftRegistrySearchesRepository.GetCustomerGiftRegistrySearches(CustomerGiftRegistrySearchesId);
		}

		public CustomerGiftRegistrySearches UpdateCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity)
		{
			return _iCustomerGiftRegistrySearchesRepository.UpdateCustomerGiftRegistrySearches(entity);
		}

		public bool DeleteCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId)
		{
			return _iCustomerGiftRegistrySearchesRepository.DeleteCustomerGiftRegistrySearches(CustomerGiftRegistrySearchesId);
		}

		public List<CustomerGiftRegistrySearches> GetAllCustomerGiftRegistrySearches()
		{
			return _iCustomerGiftRegistrySearchesRepository.GetAllCustomerGiftRegistrySearches();
		}

		public CustomerGiftRegistrySearches InsertCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity)
		{
			 return _iCustomerGiftRegistrySearchesRepository.InsertCustomerGiftRegistrySearches(entity);
		}


	}
	
	
}
