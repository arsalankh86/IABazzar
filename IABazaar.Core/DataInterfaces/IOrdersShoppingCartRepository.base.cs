using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrdersShoppingCartRepositoryBase
	{
        
        Dictionary<string, string> GetOrdersShoppingCartBasicSearchColumns();
        List<SearchColumn> GetOrdersShoppingCartSearchColumns();
        List<SearchColumn> GetOrdersShoppingCartAdvanceSearchColumns();
        

		List<OrdersShoppingCart> GetAllOrdersShoppingCart();
		OrdersShoppingCart InsertOrdersShoppingCart(OrdersShoppingCart entity);	}
	
	
}
