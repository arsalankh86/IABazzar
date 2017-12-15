using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingWeightByZoneRepositoryBase
	{
        
        Dictionary<string, string> GetShippingWeightByZoneBasicSearchColumns();
        List<SearchColumn> GetShippingWeightByZoneSearchColumns();
        List<SearchColumn> GetShippingWeightByZoneAdvanceSearchColumns();
        

		List<ShippingWeightByZone> GetAllShippingWeightByZone();
		ShippingWeightByZone InsertShippingWeightByZone(ShippingWeightByZone entity);	}
	
	
}
