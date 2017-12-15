using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingZoneService
	{
        Dictionary<string, string> GetShippingZoneBasicSearchColumns();
        
        List<SearchColumn> GetShippingZoneAdvanceSearchColumns();

		ShippingZone GetShippingZone(System.Int32 ShippingZoneId);
		ShippingZone UpdateShippingZone(ShippingZone entity);
		bool DeleteShippingZone(System.Int32 ShippingZoneId);
		List<ShippingZone> GetAllShippingZone();
		ShippingZone InsertShippingZone(ShippingZone entity);

	}
	
	
}
