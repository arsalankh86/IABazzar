using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductViewService : IProductViewService 
	{
		private IProductViewRepository _iProductViewRepository;
        
		public ProductViewService(IProductViewRepository iProductViewRepository)
		{
			this._iProductViewRepository = iProductViewRepository;
		}
        
        public Dictionary<string, string> GetProductViewBasicSearchColumns()
        {
            
            return this._iProductViewRepository.GetProductViewBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductViewAdvanceSearchColumns()
        {
            
            return this._iProductViewRepository.GetProductViewAdvanceSearchColumns();
           
        }


		public ProductView GetProductView(System.Int32 ViewId)
		{
			return _iProductViewRepository.GetProductView(ViewId);
		}

		public ProductView UpdateProductView(ProductView entity)
		{
			return _iProductViewRepository.UpdateProductView(entity);
		}

		public bool DeleteProductView(System.Int32 ViewId)
		{
			return _iProductViewRepository.DeleteProductView(ViewId);
		}

		public List<ProductView> GetAllProductView()
		{
			return _iProductViewRepository.GetAllProductView();
		}

		public ProductView InsertProductView(ProductView entity)
		{
			 return _iProductViewRepository.InsertProductView(entity);
		}


	}
	
	
}
