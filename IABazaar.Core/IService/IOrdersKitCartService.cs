using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrdersKitCartService
	{
        Dictionary<string, string> GetOrdersKitCartBasicSearchColumns();
        
        List<SearchColumn> GetOrdersKitCartAdvanceSearchColumns();

		List<OrdersKitCart> GetAllOrdersKitCart();
		OrdersKitCart InsertOrdersKitCart(OrdersKitCart entity);

	}
	
	
}
