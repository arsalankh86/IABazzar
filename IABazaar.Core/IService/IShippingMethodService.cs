using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingMethodService
	{
        Dictionary<string, string> GetShippingMethodBasicSearchColumns();
        
        List<SearchColumn> GetShippingMethodAdvanceSearchColumns();

		ShippingMethod GetShippingMethod(System.Int32 ShippingMethodId);
		ShippingMethod UpdateShippingMethod(ShippingMethod entity);
		bool DeleteShippingMethod(System.Int32 ShippingMethodId);
		List<ShippingMethod> GetAllShippingMethod();
		ShippingMethod InsertShippingMethod(ShippingMethod entity);

	}
	
	
}
