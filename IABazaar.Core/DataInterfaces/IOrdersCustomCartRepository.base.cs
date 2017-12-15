using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrdersCustomCartRepositoryBase
	{
        
        Dictionary<string, string> GetOrdersCustomCartBasicSearchColumns();
        List<SearchColumn> GetOrdersCustomCartSearchColumns();
        List<SearchColumn> GetOrdersCustomCartAdvanceSearchColumns();
        

		List<OrdersCustomCart> GetAllOrdersCustomCart();
		OrdersCustomCart InsertOrdersCustomCart(OrdersCustomCart entity);	}
	
	
}
