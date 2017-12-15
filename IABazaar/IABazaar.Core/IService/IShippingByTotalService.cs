using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingByTotalService
	{
        Dictionary<string, string> GetShippingByTotalBasicSearchColumns();
        
        List<SearchColumn> GetShippingByTotalAdvanceSearchColumns();

		List<ShippingByTotal> GetAllShippingByTotal();
		ShippingByTotal InsertShippingByTotal(ShippingByTotal entity);

	}
	
	
}
