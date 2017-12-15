using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductSectionService : IProductSectionService 
	{
		private IProductSectionRepository _iProductSectionRepository;
        
		public ProductSectionService(IProductSectionRepository iProductSectionRepository)
		{
			this._iProductSectionRepository = iProductSectionRepository;
		}
        
        public Dictionary<string, string> GetProductSectionBasicSearchColumns()
        {
            
            return this._iProductSectionRepository.GetProductSectionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductSectionAdvanceSearchColumns()
        {
            
            return this._iProductSectionRepository.GetProductSectionAdvanceSearchColumns();
           
        }


		public ProductSection GetProductSection(System.Int32 ProductId)
		{
			return _iProductSectionRepository.GetProductSection(ProductId);
		}

		public ProductSection UpdateProductSection(ProductSection entity)
		{
			return _iProductSectionRepository.UpdateProductSection(entity);
		}

		public bool DeleteProductSection(System.Int32 ProductId)
		{
			return _iProductSectionRepository.DeleteProductSection(ProductId);
		}

		public List<ProductSection> GetAllProductSection()
		{
			return _iProductSectionRepository.GetAllProductSection();
		}

		public ProductSection InsertProductSection(ProductSection entity)
		{
			 return _iProductSectionRepository.InsertProductSection(entity);
		}


	}
	
	
}
