using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingTotalByZoneService
	{
        Dictionary<string, string> GetShippingTotalByZoneBasicSearchColumns();
        
        List<SearchColumn> GetShippingTotalByZoneAdvanceSearchColumns();

		List<ShippingTotalByZone> GetAllShippingTotalByZone();
		ShippingTotalByZone InsertShippingTotalByZone(ShippingTotalByZone entity);

	}
	
	
}
