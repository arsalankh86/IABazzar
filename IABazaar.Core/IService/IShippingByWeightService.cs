using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingByWeightService
	{
        Dictionary<string, string> GetShippingByWeightBasicSearchColumns();
        
        List<SearchColumn> GetShippingByWeightAdvanceSearchColumns();

		List<ShippingByWeight> GetAllShippingByWeight();
		ShippingByWeight InsertShippingByWeight(ShippingByWeight entity);

	}
	
	
}
