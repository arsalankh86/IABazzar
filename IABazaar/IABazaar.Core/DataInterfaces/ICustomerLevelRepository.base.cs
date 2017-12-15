using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomerLevelRepositoryBase
	{
        
        Dictionary<string, string> GetCustomerLevelBasicSearchColumns();
        List<SearchColumn> GetCustomerLevelSearchColumns();
        List<SearchColumn> GetCustomerLevelAdvanceSearchColumns();
        

		CustomerLevel GetCustomerLevel(System.Int32 CustomerLevelId);
		CustomerLevel UpdateCustomerLevel(CustomerLevel entity);
		bool DeleteCustomerLevel(System.Int32 CustomerLevelId);
		CustomerLevel DeleteCustomerLevel(CustomerLevel entity);
		List<CustomerLevel> GetAllCustomerLevel();
		CustomerLevel InsertCustomerLevel(CustomerLevel entity);	}
	
	
}
