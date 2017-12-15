using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductAffiliateService : IProductAffiliateService 
	{
		private IProductAffiliateRepository _iProductAffiliateRepository;
        
		public ProductAffiliateService(IProductAffiliateRepository iProductAffiliateRepository)
		{
			this._iProductAffiliateRepository = iProductAffiliateRepository;
		}
        
        public Dictionary<string, string> GetProductAffiliateBasicSearchColumns()
        {
            
            return this._iProductAffiliateRepository.GetProductAffiliateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductAffiliateAdvanceSearchColumns()
        {
            
            return this._iProductAffiliateRepository.GetProductAffiliateAdvanceSearchColumns();
           
        }


		public ProductAffiliate GetProductAffiliate(System.Int32 ProductId)
		{
			return _iProductAffiliateRepository.GetProductAffiliate(ProductId);
		}

		public ProductAffiliate UpdateProductAffiliate(ProductAffiliate entity)
		{
			return _iProductAffiliateRepository.UpdateProductAffiliate(entity);
		}

		public bool DeleteProductAffiliate(System.Int32 ProductId)
		{
			return _iProductAffiliateRepository.DeleteProductAffiliate(ProductId);
		}

		public List<ProductAffiliate> GetAllProductAffiliate()
		{
			return _iProductAffiliateRepository.GetAllProductAffiliate();
		}

		public ProductAffiliate InsertProductAffiliate(ProductAffiliate entity)
		{
			 return _iProductAffiliateRepository.InsertProductAffiliate(entity);
		}


	}
	
	
}
