using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShoppingCartService : IShoppingCartService 
	{
		private IShoppingCartRepository _iShoppingCartRepository;
        
		public ShoppingCartService(IShoppingCartRepository iShoppingCartRepository)
		{
			this._iShoppingCartRepository = iShoppingCartRepository;
		}
        
        public Dictionary<string, string> GetShoppingCartBasicSearchColumns()
        {
            
            return this._iShoppingCartRepository.GetShoppingCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShoppingCartAdvanceSearchColumns()
        {
            
            return this._iShoppingCartRepository.GetShoppingCartAdvanceSearchColumns();
           
        }


		public ShoppingCart GetShoppingCart(System.Int32 ShoppingCartRecId)
		{
			return _iShoppingCartRepository.GetShoppingCart(ShoppingCartRecId);
		}

		public ShoppingCart UpdateShoppingCart(ShoppingCart entity)
		{
			return _iShoppingCartRepository.UpdateShoppingCart(entity);
		}

		public bool DeleteShoppingCart(System.Int32 ShoppingCartRecId)
		{
			return _iShoppingCartRepository.DeleteShoppingCart(ShoppingCartRecId);
		}

		public List<ShoppingCart> GetAllShoppingCart()
		{
			return _iShoppingCartRepository.GetAllShoppingCart();
		}

		public ShoppingCart InsertShoppingCart(ShoppingCart entity)
		{
			 return _iShoppingCartRepository.InsertShoppingCart(entity);
		}


	}
	
	
}
