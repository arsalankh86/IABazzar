using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingMethodService : IShippingMethodService 
	{
		private IShippingMethodRepository _iShippingMethodRepository;
        
		public ShippingMethodService(IShippingMethodRepository iShippingMethodRepository)
		{
			this._iShippingMethodRepository = iShippingMethodRepository;
		}
        
        public Dictionary<string, string> GetShippingMethodBasicSearchColumns()
        {
            
            return this._iShippingMethodRepository.GetShippingMethodBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingMethodAdvanceSearchColumns()
        {
            
            return this._iShippingMethodRepository.GetShippingMethodAdvanceSearchColumns();
           
        }


		public ShippingMethod GetShippingMethod(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodRepository.GetShippingMethod(ShippingMethodId);
		}

		public ShippingMethod UpdateShippingMethod(ShippingMethod entity)
		{
			return _iShippingMethodRepository.UpdateShippingMethod(entity);
		}

		public bool DeleteShippingMethod(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodRepository.DeleteShippingMethod(ShippingMethodId);
		}

		public List<ShippingMethod> GetAllShippingMethod()
		{
			return _iShippingMethodRepository.GetAllShippingMethod();
		}

		public ShippingMethod InsertShippingMethod(ShippingMethod entity)
		{
			 return _iShippingMethodRepository.InsertShippingMethod(entity);
		}


	}
	
	
}
