using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductVariantService : IProductVariantService 
	{
		private IProductVariantRepository _iProductVariantRepository;
        
		public ProductVariantService(IProductVariantRepository iProductVariantRepository)
		{
			this._iProductVariantRepository = iProductVariantRepository;
		}
        
        public Dictionary<string, string> GetProductVariantBasicSearchColumns()
        {
            
            return this._iProductVariantRepository.GetProductVariantBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductVariantAdvanceSearchColumns()
        {
            
            return this._iProductVariantRepository.GetProductVariantAdvanceSearchColumns();
           
        }


		public ProductVariant GetProductVariant(System.Int32 VariantId)
		{
			return _iProductVariantRepository.GetProductVariant(VariantId);
		}

		public ProductVariant UpdateProductVariant(ProductVariant entity)
		{
			return _iProductVariantRepository.UpdateProductVariant(entity);
		}

		public bool DeleteProductVariant(System.Int32 VariantId)
		{
			return _iProductVariantRepository.DeleteProductVariant(VariantId);
		}

		public List<ProductVariant> GetAllProductVariant()
		{
			return _iProductVariantRepository.GetAllProductVariant();
		}

		public ProductVariant InsertProductVariant(ProductVariant entity)
		{
			 return _iProductVariantRepository.InsertProductVariant(entity);
		}


	}
	
	
}
