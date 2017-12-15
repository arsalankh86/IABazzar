using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrderOptionStoreRepositoryBase
	{
        
        Dictionary<string, string> GetOrderOptionStoreBasicSearchColumns();
        List<SearchColumn> GetOrderOptionStoreSearchColumns();
        List<SearchColumn> GetOrderOptionStoreAdvanceSearchColumns();
        

		OrderOptionStore GetOrderOptionStore(System.Int32 OrderOptionId);
		OrderOptionStore UpdateOrderOptionStore(OrderOptionStore entity);
		bool DeleteOrderOptionStore(System.Int32 OrderOptionId);
		OrderOptionStore DeleteOrderOptionStore(OrderOptionStore entity);
		List<OrderOptionStore> GetAllOrderOptionStore();
		OrderOptionStore InsertOrderOptionStore(OrderOptionStore entity);	}
	
	
}
