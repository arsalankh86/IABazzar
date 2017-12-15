using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrdersService : IOrdersService 
	{
		private IOrdersRepository _iOrdersRepository;
        
		public OrdersService(IOrdersRepository iOrdersRepository)
		{
			this._iOrdersRepository = iOrdersRepository;
		}
        
        public Dictionary<string, string> GetOrdersBasicSearchColumns()
        {
            
            return this._iOrdersRepository.GetOrdersBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrdersAdvanceSearchColumns()
        {
            
            return this._iOrdersRepository.GetOrdersAdvanceSearchColumns();
           
        }


		public Orders GetOrders(System.Int32 OrderNumber)
		{
			return _iOrdersRepository.GetOrders(OrderNumber);
		}

		public Orders UpdateOrders(Orders entity)
		{
			return _iOrdersRepository.UpdateOrders(entity);
		}

		public bool DeleteOrders(System.Int32 OrderNumber)
		{
			return _iOrdersRepository.DeleteOrders(OrderNumber);
		}

		public List<Orders> GetAllOrders()
		{
			return _iOrdersRepository.GetAllOrders();
		}

		public Orders InsertOrders(Orders entity)
		{
			 return _iOrdersRepository.InsertOrders(entity);
		}


	}
	
	
}
