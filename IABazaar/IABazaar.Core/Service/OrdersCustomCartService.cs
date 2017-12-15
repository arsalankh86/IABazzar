using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrdersCustomCartService : IOrdersCustomCartService 
	{
		private IOrdersCustomCartRepository _iOrdersCustomCartRepository;
        
		public OrdersCustomCartService(IOrdersCustomCartRepository iOrdersCustomCartRepository)
		{
			this._iOrdersCustomCartRepository = iOrdersCustomCartRepository;
		}
        
        public Dictionary<string, string> GetOrdersCustomCartBasicSearchColumns()
        {
            
            return this._iOrdersCustomCartRepository.GetOrdersCustomCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrdersCustomCartAdvanceSearchColumns()
        {
            
            return this._iOrdersCustomCartRepository.GetOrdersCustomCartAdvanceSearchColumns();
           
        }


		public List<OrdersCustomCart> GetAllOrdersCustomCart()
		{
			return _iOrdersCustomCartRepository.GetAllOrdersCustomCart();
		}

		public OrdersCustomCart InsertOrdersCustomCart(OrdersCustomCart entity)
		{
			 return _iOrdersCustomCartRepository.InsertOrdersCustomCart(entity);
		}


	}
	
	
}
