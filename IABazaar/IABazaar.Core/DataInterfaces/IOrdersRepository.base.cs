using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrdersRepositoryBase
	{
        
        Dictionary<string, string> GetOrdersBasicSearchColumns();
        List<SearchColumn> GetOrdersSearchColumns();
        List<SearchColumn> GetOrdersAdvanceSearchColumns();
        

		Orders GetOrders(System.Int32 OrderNumber);
		Orders UpdateOrders(Orders entity);
		bool DeleteOrders(System.Int32 OrderNumber);
		Orders DeleteOrders(Orders entity);
		List<Orders> GetAllOrders();
		Orders InsertOrders(Orders entity);	}
	
	
}
