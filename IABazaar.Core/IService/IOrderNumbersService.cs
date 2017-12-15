using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrderNumbersService
	{
        Dictionary<string, string> GetOrderNumbersBasicSearchColumns();
        
        List<SearchColumn> GetOrderNumbersAdvanceSearchColumns();

		OrderNumbers GetOrderNumbers(System.Int32 OrderNumber);
		OrderNumbers UpdateOrderNumbers(OrderNumbers entity);
		bool DeleteOrderNumbers(System.Int32 OrderNumber);
		List<OrderNumbers> GetAllOrderNumbers();
		OrderNumbers InsertOrderNumbers(OrderNumbers entity);

	}
	
	
}
