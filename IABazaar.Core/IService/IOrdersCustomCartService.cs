using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrdersCustomCartService
	{
        Dictionary<string, string> GetOrdersCustomCartBasicSearchColumns();
        
        List<SearchColumn> GetOrdersCustomCartAdvanceSearchColumns();

		List<OrdersCustomCart> GetAllOrdersCustomCart();
		OrdersCustomCart InsertOrdersCustomCart(OrdersCustomCart entity);

	}
	
	
}
