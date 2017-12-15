using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrderNumbersRepositoryBase
	{
        
        Dictionary<string, string> GetOrderNumbersBasicSearchColumns();
        List<SearchColumn> GetOrderNumbersSearchColumns();
        List<SearchColumn> GetOrderNumbersAdvanceSearchColumns();
        

		OrderNumbers GetOrderNumbers(System.Int32 OrderNumber);
		OrderNumbers UpdateOrderNumbers(OrderNumbers entity);
		bool DeleteOrderNumbers(System.Int32 OrderNumber);
		OrderNumbers DeleteOrderNumbers(OrderNumbers entity);
		List<OrderNumbers> GetAllOrderNumbers();
		OrderNumbers InsertOrderNumbers(OrderNumbers entity);	}
	
	
}
