using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingMethodToCountryMapService
	{
        Dictionary<string, string> GetShippingMethodToCountryMapBasicSearchColumns();
        
        List<SearchColumn> GetShippingMethodToCountryMapAdvanceSearchColumns();

		ShippingMethodToCountryMap GetShippingMethodToCountryMap(System.Int32 ShippingMethodId);
		ShippingMethodToCountryMap UpdateShippingMethodToCountryMap(ShippingMethodToCountryMap entity);
		bool DeleteShippingMethodToCountryMap(System.Int32 ShippingMethodId);
		List<ShippingMethodToCountryMap> GetAllShippingMethodToCountryMap();
		ShippingMethodToCountryMap InsertShippingMethodToCountryMap(ShippingMethodToCountryMap entity);

	}
	
	
}
