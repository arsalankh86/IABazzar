using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class OrderNumbersService : IOrderNumbersService 
	{
		private IOrderNumbersRepository _iOrderNumbersRepository;
        
		public OrderNumbersService(IOrderNumbersRepository iOrderNumbersRepository)
		{
			this._iOrderNumbersRepository = iOrderNumbersRepository;
		}
        
        public Dictionary<string, string> GetOrderNumbersBasicSearchColumns()
        {
            
            return this._iOrderNumbersRepository.GetOrderNumbersBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetOrderNumbersAdvanceSearchColumns()
        {
            
            return this._iOrderNumbersRepository.GetOrderNumbersAdvanceSearchColumns();
           
        }


		public OrderNumbers GetOrderNumbers(System.Int32 OrderNumber)
		{
			return _iOrderNumbersRepository.GetOrderNumbers(OrderNumber);
		}

		public OrderNumbers UpdateOrderNumbers(OrderNumbers entity)
		{
			return _iOrderNumbersRepository.UpdateOrderNumbers(entity);
		}

		public bool DeleteOrderNumbers(System.Int32 OrderNumber)
		{
			return _iOrderNumbersRepository.DeleteOrderNumbers(OrderNumber);
		}

		public List<OrderNumbers> GetAllOrderNumbers()
		{
			return _iOrderNumbersRepository.GetAllOrderNumbers();
		}

		public OrderNumbers InsertOrderNumbers(OrderNumbers entity)
		{
			 return _iOrderNumbersRepository.InsertOrderNumbers(entity);
		}


	}
	
	
}
