using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingWeightByZoneService
	{
        Dictionary<string, string> GetShippingWeightByZoneBasicSearchColumns();
        
        List<SearchColumn> GetShippingWeightByZoneAdvanceSearchColumns();

		List<ShippingWeightByZone> GetAllShippingWeightByZone();
		ShippingWeightByZone InsertShippingWeightByZone(ShippingWeightByZone entity);

	}
	
	
}
