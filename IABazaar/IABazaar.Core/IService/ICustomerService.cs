using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomerService
	{
        Dictionary<string, string> GetCustomerBasicSearchColumns();
        
        List<SearchColumn> GetCustomerAdvanceSearchColumns();

		Customer GetCustomer(System.Int32 CustomerId);
		Customer UpdateCustomer(Customer entity);
		bool DeleteCustomer(System.Int32 CustomerId);
		List<Customer> GetAllCustomer();
		Customer InsertCustomer(Customer entity);

	}
	
	
}
