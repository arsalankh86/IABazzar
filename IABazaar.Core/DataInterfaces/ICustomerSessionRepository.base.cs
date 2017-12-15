using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomerSessionRepositoryBase
	{
        
        Dictionary<string, string> GetCustomerSessionBasicSearchColumns();
        List<SearchColumn> GetCustomerSessionSearchColumns();
        List<SearchColumn> GetCustomerSessionAdvanceSearchColumns();
        

		CustomerSession GetCustomerSession(System.Int32 CustomerSessionId);
		CustomerSession UpdateCustomerSession(CustomerSession entity);
		bool DeleteCustomerSession(System.Int32 CustomerSessionId);
		CustomerSession DeleteCustomerSession(CustomerSession entity);
		List<CustomerSession> GetAllCustomerSession();
		CustomerSession InsertCustomerSession(CustomerSession entity);	}
	
	
}
