using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductVectorService : IProductVectorService 
	{
		private IProductVectorRepository _iProductVectorRepository;
        
		public ProductVectorService(IProductVectorRepository iProductVectorRepository)
		{
			this._iProductVectorRepository = iProductVectorRepository;
		}
        
        public Dictionary<string, string> GetProductVectorBasicSearchColumns()
        {
            
            return this._iProductVectorRepository.GetProductVectorBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductVectorAdvanceSearchColumns()
        {
            
            return this._iProductVectorRepository.GetProductVectorAdvanceSearchColumns();
           
        }


		public ProductVector GetProductVector(System.Int32 ProductId)
		{
			return _iProductVectorRepository.GetProductVector(ProductId);
		}

		public ProductVector UpdateProductVector(ProductVector entity)
		{
			return _iProductVectorRepository.UpdateProductVector(entity);
		}

		public bool DeleteProductVector(System.Int32 ProductId)
		{
			return _iProductVectorRepository.DeleteProductVector(ProductId);
		}

		public List<ProductVector> GetAllProductVector()
		{
			return _iProductVectorRepository.GetAllProductVector();
		}

		public ProductVector InsertProductVector(ProductVector entity)
		{
			 return _iProductVectorRepository.InsertProductVector(entity);
		}


	}
	
	
}
