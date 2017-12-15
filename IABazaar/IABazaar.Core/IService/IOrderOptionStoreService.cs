using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrderOptionStoreService
	{
        Dictionary<string, string> GetOrderOptionStoreBasicSearchColumns();
        
        List<SearchColumn> GetOrderOptionStoreAdvanceSearchColumns();

		OrderOptionStore GetOrderOptionStore(System.Int32 OrderOptionId);
		OrderOptionStore UpdateOrderOptionStore(OrderOptionStore entity);
		bool DeleteOrderOptionStore(System.Int32 OrderOptionId);
		List<OrderOptionStore> GetAllOrderOptionStore();
		OrderOptionStore InsertOrderOptionStore(OrderOptionStore entity);

	}
	
	
}
