using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingByProductService : IShippingByProductService 
	{
		private IShippingByProductRepository _iShippingByProductRepository;
        
		public ShippingByProductService(IShippingByProductRepository iShippingByProductRepository)
		{
			this._iShippingByProductRepository = iShippingByProductRepository;
		}
        
        public Dictionary<string, string> GetShippingByProductBasicSearchColumns()
        {
            
            return this._iShippingByProductRepository.GetShippingByProductBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingByProductAdvanceSearchColumns()
        {
            
            return this._iShippingByProductRepository.GetShippingByProductAdvanceSearchColumns();
           
        }


		public ShippingByProduct GetShippingByProduct(System.Int32 ShippingByProductId)
		{
			return _iShippingByProductRepository.GetShippingByProduct(ShippingByProductId);
		}

		public ShippingByProduct UpdateShippingByProduct(ShippingByProduct entity)
		{
			return _iShippingByProductRepository.UpdateShippingByProduct(entity);
		}

		public bool DeleteShippingByProduct(System.Int32 ShippingByProductId)
		{
			return _iShippingByProductRepository.DeleteShippingByProduct(ShippingByProductId);
		}

		public List<ShippingByProduct> GetAllShippingByProduct()
		{
			return _iShippingByProductRepository.GetAllShippingByProduct();
		}

		public ShippingByProduct InsertShippingByProduct(ShippingByProduct entity)
		{
			 return _iShippingByProductRepository.InsertShippingByProduct(entity);
		}


	}
	
	
}
