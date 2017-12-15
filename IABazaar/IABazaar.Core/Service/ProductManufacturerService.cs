using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductManufacturerService : IProductManufacturerService 
	{
		private IProductManufacturerRepository _iProductManufacturerRepository;
        
		public ProductManufacturerService(IProductManufacturerRepository iProductManufacturerRepository)
		{
			this._iProductManufacturerRepository = iProductManufacturerRepository;
		}
        
        public Dictionary<string, string> GetProductManufacturerBasicSearchColumns()
        {
            
            return this._iProductManufacturerRepository.GetProductManufacturerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductManufacturerAdvanceSearchColumns()
        {
            
            return this._iProductManufacturerRepository.GetProductManufacturerAdvanceSearchColumns();
           
        }


		public ProductManufacturer GetProductManufacturer(System.Int32 ProductId)
		{
			return _iProductManufacturerRepository.GetProductManufacturer(ProductId);
		}

		public ProductManufacturer UpdateProductManufacturer(ProductManufacturer entity)
		{
			return _iProductManufacturerRepository.UpdateProductManufacturer(entity);
		}

		public bool DeleteProductManufacturer(System.Int32 ProductId)
		{
			return _iProductManufacturerRepository.DeleteProductManufacturer(ProductId);
		}

		public List<ProductManufacturer> GetAllProductManufacturer()
		{
			return _iProductManufacturerRepository.GetAllProductManufacturer();
		}

		public ProductManufacturer InsertProductManufacturer(ProductManufacturer entity)
		{
			 return _iProductManufacturerRepository.InsertProductManufacturer(entity);
		}


	}
	
	
}
