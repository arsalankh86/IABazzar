using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrderOptionService : IOrderOptionService 
	{
		private IOrderOptionRepository _iOrderOptionRepository;
        
		public OrderOptionService(IOrderOptionRepository iOrderOptionRepository)
		{
			this._iOrderOptionRepository = iOrderOptionRepository;
		}
        
        public Dictionary<string, string> GetOrderOptionBasicSearchColumns()
        {
            
            return this._iOrderOptionRepository.GetOrderOptionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrderOptionAdvanceSearchColumns()
        {
            
            return this._iOrderOptionRepository.GetOrderOptionAdvanceSearchColumns();
           
        }


		public OrderOption GetOrderOption(System.Int32 OrderOptionId)
		{
			return _iOrderOptionRepository.GetOrderOption(OrderOptionId);
		}

		public OrderOption UpdateOrderOption(OrderOption entity)
		{
			return _iOrderOptionRepository.UpdateOrderOption(entity);
		}

		public bool DeleteOrderOption(System.Int32 OrderOptionId)
		{
			return _iOrderOptionRepository.DeleteOrderOption(OrderOptionId);
		}

		public List<OrderOption> GetAllOrderOption()
		{
			return _iOrderOptionRepository.GetAllOrderOption();
		}

		public OrderOption InsertOrderOption(OrderOption entity)
		{
			 return _iOrderOptionRepository.InsertOrderOption(entity);
		}


	}
	
	
}
