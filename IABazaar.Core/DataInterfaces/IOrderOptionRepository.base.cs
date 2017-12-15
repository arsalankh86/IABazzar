using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IOrderOptionRepositoryBase
	{
        
        Dictionary<string, string> GetOrderOptionBasicSearchColumns();
        List<SearchColumn> GetOrderOptionSearchColumns();
        List<SearchColumn> GetOrderOptionAdvanceSearchColumns();
        

		OrderOption GetOrderOption(System.Int32 OrderOptionId);
		OrderOption UpdateOrderOption(OrderOption entity);
		bool DeleteOrderOption(System.Int32 OrderOptionId);
		OrderOption DeleteOrderOption(OrderOption entity);
		List<OrderOption> GetAllOrderOption();
		OrderOption InsertOrderOption(OrderOption entity);	}
	
	
}
