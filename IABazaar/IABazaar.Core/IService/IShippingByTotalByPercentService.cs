using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingByTotalByPercentService
	{
        Dictionary<string, string> GetShippingByTotalByPercentBasicSearchColumns();
        
        List<SearchColumn> GetShippingByTotalByPercentAdvanceSearchColumns();

		List<ShippingByTotalByPercent> GetAllShippingByTotalByPercent();
		ShippingByTotalByPercent InsertShippingByTotalByPercent(ShippingByTotalByPercent entity);

	}
	
	
}
