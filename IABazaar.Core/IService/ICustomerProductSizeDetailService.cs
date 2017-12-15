using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomerProductSizeDetailService
	{
        Dictionary<string, string> GetCustomerProductSizeDetailBasicSearchColumns();
        
        List<SearchColumn> GetCustomerProductSizeDetailAdvanceSearchColumns();

		CustomerProductSizeDetail GetCustomerProductSizeDetail(System.Int32 CustomerProductSize);
		CustomerProductSizeDetail UpdateCustomerProductSizeDetail(CustomerProductSizeDetail entity);
		bool DeleteCustomerProductSizeDetail(System.Int32 CustomerProductSize);
		List<CustomerProductSizeDetail> GetAllCustomerProductSizeDetail();
		CustomerProductSizeDetail InsertCustomerProductSizeDetail(CustomerProductSizeDetail entity);

	}
	
	
}
