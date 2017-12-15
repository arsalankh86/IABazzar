using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrdersShoppingCartService : IOrdersShoppingCartService 
	{
		private IOrdersShoppingCartRepository _iOrdersShoppingCartRepository;
        
		public OrdersShoppingCartService(IOrdersShoppingCartRepository iOrdersShoppingCartRepository)
		{
			this._iOrdersShoppingCartRepository = iOrdersShoppingCartRepository;
		}
        
        public Dictionary<string, string> GetOrdersShoppingCartBasicSearchColumns()
        {
            
            return this._iOrdersShoppingCartRepository.GetOrdersShoppingCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrdersShoppingCartAdvanceSearchColumns()
        {
            
            return this._iOrdersShoppingCartRepository.GetOrdersShoppingCartAdvanceSearchColumns();
           
        }


		public List<OrdersShoppingCart> GetAllOrdersShoppingCart()
		{
			return _iOrdersShoppingCartRepository.GetAllOrdersShoppingCart();
		}

		public OrdersShoppingCart InsertOrdersShoppingCart(OrdersShoppingCart entity)
		{
			 return _iOrdersShoppingCartRepository.InsertOrdersShoppingCart(entity);
		}


	}
	
	
}
