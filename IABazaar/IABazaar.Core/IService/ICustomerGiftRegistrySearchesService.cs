using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomerGiftRegistrySearchesService
	{
        Dictionary<string, string> GetCustomerGiftRegistrySearchesBasicSearchColumns();
        
        List<SearchColumn> GetCustomerGiftRegistrySearchesAdvanceSearchColumns();

		CustomerGiftRegistrySearches GetCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId);
		CustomerGiftRegistrySearches UpdateCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity);
		bool DeleteCustomerGiftRegistrySearches(System.Int32 CustomerGiftRegistrySearchesId);
		List<CustomerGiftRegistrySearches> GetAllCustomerGiftRegistrySearches();
		CustomerGiftRegistrySearches InsertCustomerGiftRegistrySearches(CustomerGiftRegistrySearches entity);

	}
	
	
}
