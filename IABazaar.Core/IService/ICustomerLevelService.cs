using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomerLevelService
	{
        Dictionary<string, string> GetCustomerLevelBasicSearchColumns();
        
        List<SearchColumn> GetCustomerLevelAdvanceSearchColumns();

		CustomerLevel GetCustomerLevel(System.Int32 CustomerLevelId);
		CustomerLevel UpdateCustomerLevel(CustomerLevel entity);
		bool DeleteCustomerLevel(System.Int32 CustomerLevelId);
		List<CustomerLevel> GetAllCustomerLevel();
		CustomerLevel InsertCustomerLevel(CustomerLevel entity);

	}
	
	
}
