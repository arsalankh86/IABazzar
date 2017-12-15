using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IOrderOptionService
	{
        Dictionary<string, string> GetOrderOptionBasicSearchColumns();
        
        List<SearchColumn> GetOrderOptionAdvanceSearchColumns();

		OrderOption GetOrderOption(System.Int32 OrderOptionId);
		OrderOption UpdateOrderOption(OrderOption entity);
		bool DeleteOrderOption(System.Int32 OrderOptionId);
		List<OrderOption> GetAllOrderOption();
		OrderOption InsertOrderOption(OrderOption entity);

	}
	
	
}
