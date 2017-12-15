using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingMethodRepositoryBase
	{
        
        Dictionary<string, string> GetShippingMethodBasicSearchColumns();
        List<SearchColumn> GetShippingMethodSearchColumns();
        List<SearchColumn> GetShippingMethodAdvanceSearchColumns();
        

		ShippingMethod GetShippingMethod(System.Int32 ShippingMethodId);
		ShippingMethod UpdateShippingMethod(ShippingMethod entity);
		bool DeleteShippingMethod(System.Int32 ShippingMethodId);
		ShippingMethod DeleteShippingMethod(ShippingMethod entity);
		List<ShippingMethod> GetAllShippingMethod();
		ShippingMethod InsertShippingMethod(ShippingMethod entity);	}
	
	
}
