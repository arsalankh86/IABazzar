using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomCartService : ICustomCartService 
	{
		private ICustomCartRepository _iCustomCartRepository;
        
		public CustomCartService(ICustomCartRepository iCustomCartRepository)
		{
			this._iCustomCartRepository = iCustomCartRepository;
		}
        
        public Dictionary<string, string> GetCustomCartBasicSearchColumns()
        {
            
            return this._iCustomCartRepository.GetCustomCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomCartAdvanceSearchColumns()
        {
            
            return this._iCustomCartRepository.GetCustomCartAdvanceSearchColumns();
           
        }


		public CustomCart GetCustomCart(System.Int32 CustomCartRecId)
		{
			return _iCustomCartRepository.GetCustomCart(CustomCartRecId);
		}

		public CustomCart UpdateCustomCart(CustomCart entity)
		{
			return _iCustomCartRepository.UpdateCustomCart(entity);
		}

		public bool DeleteCustomCart(System.Int32 CustomCartRecId)
		{
			return _iCustomCartRepository.DeleteCustomCart(CustomCartRecId);
		}

		public List<CustomCart> GetAllCustomCart()
		{
			return _iCustomCartRepository.GetAllCustomCart();
		}

		public CustomCart InsertCustomCart(CustomCart entity)
		{
			 return _iCustomCartRepository.InsertCustomCart(entity);
		}


	}
	
	
}
