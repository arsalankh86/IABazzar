using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrdersKitCartRepositoryBase
	{
        
        Dictionary<string, string> GetOrdersKitCartBasicSearchColumns();
        List<SearchColumn> GetOrdersKitCartSearchColumns();
        List<SearchColumn> GetOrdersKitCartAdvanceSearchColumns();
        

		List<OrdersKitCart> GetAllOrdersKitCart();
		OrdersKitCart InsertOrdersKitCart(OrdersKitCart entity);	}
	
	
}
