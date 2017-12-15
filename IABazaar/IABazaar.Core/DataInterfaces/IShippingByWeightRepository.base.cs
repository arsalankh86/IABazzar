using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingByWeightRepositoryBase
	{
        
        Dictionary<string, string> GetShippingByWeightBasicSearchColumns();
        List<SearchColumn> GetShippingByWeightSearchColumns();
        List<SearchColumn> GetShippingByWeightAdvanceSearchColumns();
        

		List<ShippingByWeight> GetAllShippingByWeight();
		ShippingByWeight InsertShippingByWeight(ShippingByWeight entity);	}
	
	
}
