using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingByProductService
	{
        Dictionary<string, string> GetShippingByProductBasicSearchColumns();
        
        List<SearchColumn> GetShippingByProductAdvanceSearchColumns();

		ShippingByProduct GetShippingByProduct(System.Int32 ShippingByProductId);
		ShippingByProduct UpdateShippingByProduct(ShippingByProduct entity);
		bool DeleteShippingByProduct(System.Int32 ShippingByProductId);
		List<ShippingByProduct> GetAllShippingByProduct();
		ShippingByProduct InsertShippingByProduct(ShippingByProduct entity);

	}
	
	
}
