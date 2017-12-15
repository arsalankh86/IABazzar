using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrderOptionStoreService : IOrderOptionStoreService 
	{
		private IOrderOptionStoreRepository _iOrderOptionStoreRepository;
        
		public OrderOptionStoreService(IOrderOptionStoreRepository iOrderOptionStoreRepository)
		{
			this._iOrderOptionStoreRepository = iOrderOptionStoreRepository;
		}
        
        public Dictionary<string, string> GetOrderOptionStoreBasicSearchColumns()
        {
            
            return this._iOrderOptionStoreRepository.GetOrderOptionStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrderOptionStoreAdvanceSearchColumns()
        {
            
            return this._iOrderOptionStoreRepository.GetOrderOptionStoreAdvanceSearchColumns();
           
        }


		public OrderOptionStore GetOrderOptionStore(System.Int32 OrderOptionId)
		{
			return _iOrderOptionStoreRepository.GetOrderOptionStore(OrderOptionId);
		}

		public OrderOptionStore UpdateOrderOptionStore(OrderOptionStore entity)
		{
			return _iOrderOptionStoreRepository.UpdateOrderOptionStore(entity);
		}

		public bool DeleteOrderOptionStore(System.Int32 OrderOptionId)
		{
			return _iOrderOptionStoreRepository.DeleteOrderOptionStore(OrderOptionId);
		}

		public List<OrderOptionStore> GetAllOrderOptionStore()
		{
			return _iOrderOptionStoreRepository.GetAllOrderOptionStore();
		}

		public OrderOptionStore InsertOrderOptionStore(OrderOptionStore entity)
		{
			 return _iOrderOptionStoreRepository.InsertOrderOptionStore(entity);
		}


	}
	
	
}
