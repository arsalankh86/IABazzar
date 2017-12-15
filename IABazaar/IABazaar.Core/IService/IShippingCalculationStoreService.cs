using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingCalculationStoreService
	{
        Dictionary<string, string> GetShippingCalculationStoreBasicSearchColumns();
        
        List<SearchColumn> GetShippingCalculationStoreAdvanceSearchColumns();

		ShippingCalculationStore GetShippingCalculationStore(System.Int32 StoreId);
		ShippingCalculationStore UpdateShippingCalculationStore(ShippingCalculationStore entity);
		bool DeleteShippingCalculationStore(System.Int32 StoreId);
		List<ShippingCalculationStore> GetAllShippingCalculationStore();
		ShippingCalculationStore InsertShippingCalculationStore(ShippingCalculationStore entity);

	}
	
	
}
