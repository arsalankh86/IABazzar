using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductDistributorService : IProductDistributorService 
	{
		private IProductDistributorRepository _iProductDistributorRepository;
        
		public ProductDistributorService(IProductDistributorRepository iProductDistributorRepository)
		{
			this._iProductDistributorRepository = iProductDistributorRepository;
		}
        
        public Dictionary<string, string> GetProductDistributorBasicSearchColumns()
        {
            
            return this._iProductDistributorRepository.GetProductDistributorBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductDistributorAdvanceSearchColumns()
        {
            
            return this._iProductDistributorRepository.GetProductDistributorAdvanceSearchColumns();
           
        }


		public ProductDistributor GetProductDistributor(System.Int32 ProductId)
		{
			return _iProductDistributorRepository.GetProductDistributor(ProductId);
		}

		public ProductDistributor UpdateProductDistributor(ProductDistributor entity)
		{
			return _iProductDistributorRepository.UpdateProductDistributor(entity);
		}

		public bool DeleteProductDistributor(System.Int32 ProductId)
		{
			return _iProductDistributorRepository.DeleteProductDistributor(ProductId);
		}

		public List<ProductDistributor> GetAllProductDistributor()
		{
			return _iProductDistributorRepository.GetAllProductDistributor();
		}

		public ProductDistributor InsertProductDistributor(ProductDistributor entity)
		{
			 return _iProductDistributorRepository.InsertProductDistributor(entity);
		}


	}
	
	
}
