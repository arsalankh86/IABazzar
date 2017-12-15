using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductLocaleSettingService : IProductLocaleSettingService 
	{
		private IProductLocaleSettingRepository _iProductLocaleSettingRepository;
        
		public ProductLocaleSettingService(IProductLocaleSettingRepository iProductLocaleSettingRepository)
		{
			this._iProductLocaleSettingRepository = iProductLocaleSettingRepository;
		}
        
        public Dictionary<string, string> GetProductLocaleSettingBasicSearchColumns()
        {
            
            return this._iProductLocaleSettingRepository.GetProductLocaleSettingBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductLocaleSettingAdvanceSearchColumns()
        {
            
            return this._iProductLocaleSettingRepository.GetProductLocaleSettingAdvanceSearchColumns();
           
        }


		public ProductLocaleSetting GetProductLocaleSetting(System.Int32 ProductId)
		{
			return _iProductLocaleSettingRepository.GetProductLocaleSetting(ProductId);
		}

		public ProductLocaleSetting UpdateProductLocaleSetting(ProductLocaleSetting entity)
		{
			return _iProductLocaleSettingRepository.UpdateProductLocaleSetting(entity);
		}

		public bool DeleteProductLocaleSetting(System.Int32 ProductId)
		{
			return _iProductLocaleSettingRepository.DeleteProductLocaleSetting(ProductId);
		}

		public List<ProductLocaleSetting> GetAllProductLocaleSetting()
		{
			return _iProductLocaleSettingRepository.GetAllProductLocaleSetting();
		}

		public ProductLocaleSetting InsertProductLocaleSetting(ProductLocaleSetting entity)
		{
			 return _iProductLocaleSettingRepository.InsertProductLocaleSetting(entity);
		}


	}
	
	
}
