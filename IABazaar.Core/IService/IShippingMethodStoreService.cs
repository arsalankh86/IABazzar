using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingMethodStoreService
	{
        Dictionary<string, string> GetShippingMethodStoreBasicSearchColumns();
        
        List<SearchColumn> GetShippingMethodStoreAdvanceSearchColumns();

		ShippingMethodStore GetShippingMethodStore(System.Int32 StoreId);
		ShippingMethodStore UpdateShippingMethodStore(ShippingMethodStore entity);
		bool DeleteShippingMethodStore(System.Int32 StoreId);
		List<ShippingMethodStore> GetAllShippingMethodStore();
		ShippingMethodStore InsertShippingMethodStore(ShippingMethodStore entity);

	}
	
	
}
