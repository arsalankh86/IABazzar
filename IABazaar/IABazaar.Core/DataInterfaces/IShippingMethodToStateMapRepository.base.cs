using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingMethodToStateMapRepositoryBase
	{
        
        Dictionary<string, string> GetShippingMethodToStateMapBasicSearchColumns();
        List<SearchColumn> GetShippingMethodToStateMapSearchColumns();
        List<SearchColumn> GetShippingMethodToStateMapAdvanceSearchColumns();
        

		ShippingMethodToStateMap GetShippingMethodToStateMap(System.Int32 ShippingMethodId);
		ShippingMethodToStateMap UpdateShippingMethodToStateMap(ShippingMethodToStateMap entity);
		bool DeleteShippingMethodToStateMap(System.Int32 ShippingMethodId);
		ShippingMethodToStateMap DeleteShippingMethodToStateMap(ShippingMethodToStateMap entity);
		List<ShippingMethodToStateMap> GetAllShippingMethodToStateMap();
		ShippingMethodToStateMap InsertShippingMethodToStateMap(ShippingMethodToStateMap entity);	}
	
	
}
