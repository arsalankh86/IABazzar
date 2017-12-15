using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomCartRepositoryBase
	{
        
        Dictionary<string, string> GetCustomCartBasicSearchColumns();
        List<SearchColumn> GetCustomCartSearchColumns();
        List<SearchColumn> GetCustomCartAdvanceSearchColumns();
        

		CustomCart GetCustomCart(System.Int32 CustomCartRecId);
		CustomCart UpdateCustomCart(CustomCart entity);
		bool DeleteCustomCart(System.Int32 CustomCartRecId);
		CustomCart DeleteCustomCart(CustomCart entity);
		List<CustomCart> GetAllCustomCart();
		CustomCart InsertCustomCart(CustomCart entity);	}
	
	
}
