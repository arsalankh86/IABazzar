using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrdersKitCartService : IOrdersKitCartService 
	{
		private IOrdersKitCartRepository _iOrdersKitCartRepository;
        
		public OrdersKitCartService(IOrdersKitCartRepository iOrdersKitCartRepository)
		{
			this._iOrdersKitCartRepository = iOrdersKitCartRepository;
		}
        
        public Dictionary<string, string> GetOrdersKitCartBasicSearchColumns()
        {
            
            return this._iOrdersKitCartRepository.GetOrdersKitCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrdersKitCartAdvanceSearchColumns()
        {
            
            return this._iOrdersKitCartRepository.GetOrdersKitCartAdvanceSearchColumns();
           
        }


		public List<OrdersKitCart> GetAllOrdersKitCart()
		{
			return _iOrdersKitCartRepository.GetAllOrdersKitCart();
		}

		public OrdersKitCart InsertOrdersKitCart(OrdersKitCart entity)
		{
			 return _iOrdersKitCartRepository.InsertOrdersKitCart(entity);
		}


	}
	
	
}
