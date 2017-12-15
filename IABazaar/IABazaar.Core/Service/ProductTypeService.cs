using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductTypeService : IProductTypeService 
	{
		private IProductTypeRepository _iProductTypeRepository;
        
		public ProductTypeService(IProductTypeRepository iProductTypeRepository)
		{
			this._iProductTypeRepository = iProductTypeRepository;
		}
        
        public Dictionary<string, string> GetProductTypeBasicSearchColumns()
        {
            
            return this._iProductTypeRepository.GetProductTypeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductTypeAdvanceSearchColumns()
        {
            
            return this._iProductTypeRepository.GetProductTypeAdvanceSearchColumns();
           
        }


		public ProductType GetProductType(System.Int32 ProductTypeId)
		{
			return _iProductTypeRepository.GetProductType(ProductTypeId);
		}

		public ProductType UpdateProductType(ProductType entity)
		{
			return _iProductTypeRepository.UpdateProductType(entity);
		}

		public bool DeleteProductType(System.Int32 ProductTypeId)
		{
			return _iProductTypeRepository.DeleteProductType(ProductTypeId);
		}

		public List<ProductType> GetAllProductType()
		{
			return _iProductTypeRepository.GetAllProductType();
		}

		public ProductType InsertProductType(ProductType entity)
		{
			 return _iProductTypeRepository.InsertProductType(entity);
		}


	}
	
	
}
