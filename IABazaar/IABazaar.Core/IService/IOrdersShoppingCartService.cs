using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrdersShoppingCartService
	{
        Dictionary<string, string> GetOrdersShoppingCartBasicSearchColumns();
        
        List<SearchColumn> GetOrdersShoppingCartAdvanceSearchColumns();

		List<OrdersShoppingCart> GetAllOrdersShoppingCart();
		OrdersShoppingCart InsertOrdersShoppingCart(OrdersShoppingCart entity);

	}
	
	
}
