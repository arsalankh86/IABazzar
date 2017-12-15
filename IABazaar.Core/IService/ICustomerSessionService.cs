using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomerSessionService
	{
        Dictionary<string, string> GetCustomerSessionBasicSearchColumns();
        
        List<SearchColumn> GetCustomerSessionAdvanceSearchColumns();

		CustomerSession GetCustomerSession(System.Int32 CustomerSessionId);
		CustomerSession UpdateCustomerSession(CustomerSession entity);
		bool DeleteCustomerSession(System.Int32 CustomerSessionId);
		List<CustomerSession> GetAllCustomerSession();
		CustomerSession InsertCustomerSession(CustomerSession entity);

	}
	
	
}
