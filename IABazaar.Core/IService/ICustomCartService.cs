using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomCartService
	{
        Dictionary<string, string> GetCustomCartBasicSearchColumns();
        
        List<SearchColumn> GetCustomCartAdvanceSearchColumns();

		CustomCart GetCustomCart(System.Int32 CustomCartRecId);
		CustomCart UpdateCustomCart(CustomCart entity);
		bool DeleteCustomCart(System.Int32 CustomCartRecId);
		List<CustomCart> GetAllCustomCart();
		CustomCart InsertCustomCart(CustomCart entity);

	}
	
	
}
