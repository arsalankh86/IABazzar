using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingZoneRepositoryBase
	{
        
        Dictionary<string, string> GetShippingZoneBasicSearchColumns();
        List<SearchColumn> GetShippingZoneSearchColumns();
        List<SearchColumn> GetShippingZoneAdvanceSearchColumns();
        

		ShippingZone GetShippingZone(System.Int32 ShippingZoneId);
		ShippingZone UpdateShippingZone(ShippingZone entity);
		bool DeleteShippingZone(System.Int32 ShippingZoneId);
		ShippingZone DeleteShippingZone(ShippingZone entity);
		List<ShippingZone> GetAllShippingZone();
		ShippingZone InsertShippingZone(ShippingZone entity);	}
	
	
}
