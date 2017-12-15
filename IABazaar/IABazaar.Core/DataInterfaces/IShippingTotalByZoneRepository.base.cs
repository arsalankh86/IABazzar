using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingTotalByZoneRepositoryBase
	{
        
        Dictionary<string, string> GetShippingTotalByZoneBasicSearchColumns();
        List<SearchColumn> GetShippingTotalByZoneSearchColumns();
        List<SearchColumn> GetShippingTotalByZoneAdvanceSearchColumns();
        

		List<ShippingTotalByZone> GetAllShippingTotalByZone();
		ShippingTotalByZone InsertShippingTotalByZone(ShippingTotalByZone entity);	}
	
	
}
