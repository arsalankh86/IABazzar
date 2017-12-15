using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingMethodToZoneMapService
	{
        Dictionary<string, string> GetShippingMethodToZoneMapBasicSearchColumns();
        
        List<SearchColumn> GetShippingMethodToZoneMapAdvanceSearchColumns();

		ShippingMethodToZoneMap GetShippingMethodToZoneMap(System.Int32 ShippingMethodId);
		ShippingMethodToZoneMap UpdateShippingMethodToZoneMap(ShippingMethodToZoneMap entity);
		bool DeleteShippingMethodToZoneMap(System.Int32 ShippingMethodId);
		List<ShippingMethodToZoneMap> GetAllShippingMethodToZoneMap();
		ShippingMethodToZoneMap InsertShippingMethodToZoneMap(ShippingMethodToZoneMap entity);

	}
	
	
}
