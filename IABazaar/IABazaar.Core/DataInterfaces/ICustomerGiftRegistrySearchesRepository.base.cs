using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomerGiftRegistrySearchesRepositoryBase
	{
        
        Dictionary<string, string> GetCustomerGiftRegistrySearchesBasicSearchColumns();
        List<SearchColumn> GetCustomerGiftRegistrySearchesSearchColumns();
        List<SearchColumn> GetCustomerGiftRegistrySearchesAdvanceSearchColumns();
        

		CustomerGiftRegistrySearches GetCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId);
		CustomerGiftRegistrySearches UpdateCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity);
		bool DeleteCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId);
		CustomerGiftRegistrySearches DeleteCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity);
		List<CustomerGiftRegistrySearches> GetAllCustomerGiftRegistrySearches();
		CustomerGiftRegistrySearches InsertCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity);	}
	
	
}
