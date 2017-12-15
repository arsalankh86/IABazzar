using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingMethodToStateMapService
	{
        Dictionary<string, string> GetShippingMethodToStateMapBasicSearchColumns();
        
        List<SearchColumn> GetShippingMethodToStateMapAdvanceSearchColumns();

		ShippingMethodToStateMap GetShippingMethodToStateMap(System.Int32 ShippingMethodId);
		ShippingMethodToStateMap UpdateShippingMethodToStateMap(ShippingMethodToStateMap entity);
		bool DeleteShippingMethodToStateMap(System.Int32 ShippingMethodId);
		List<ShippingMethodToStateMap> GetAllShippingMethodToStateMap();
		ShippingMethodToStateMap InsertShippingMethodToStateMap(ShippingMethodToStateMap entity);

	}
	
	
}
