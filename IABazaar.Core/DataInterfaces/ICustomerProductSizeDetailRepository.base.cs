using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomerProductSizeDetailRepositoryBase
	{
        
        Dictionary<string, string> GetCustomerProductSizeDetailBasicSearchColumns();
        List<SearchColumn> GetCustomerProductSizeDetailSearchColumns();
        List<SearchColumn> GetCustomerProductSizeDetailAdvanceSearchColumns();
        

		CustomerProductSizeDetail GetCustomerProductSizeDetail(System.Int32 CustomerProductSize);
		CustomerProductSizeDetail UpdateCustomerProductSizeDetail(CustomerProductSizeDetail entity);
		bool DeleteCustomerProductSizeDetail(System.Int32 CustomerProductSize);
		CustomerProductSizeDetail DeleteCustomerProductSizeDetail(CustomerProductSizeDetail entity);
		List<CustomerProductSizeDetail> GetAllCustomerProductSizeDetail();
		CustomerProductSizeDetail InsertCustomerProductSizeDetail(CustomerProductSizeDetail entity);	}
	
	
}
