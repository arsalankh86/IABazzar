using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductGenreService : IProductGenreService 
	{
		private IProductGenreRepository _iProductGenreRepository;
        
		public ProductGenreService(IProductGenreRepository iProductGenreRepository)
		{
			this._iProductGenreRepository = iProductGenreRepository;
		}
        
        public Dictionary<string, string> GetProductGenreBasicSearchColumns()
        {
            
            return this._iProductGenreRepository.GetProductGenreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductGenreAdvanceSearchColumns()
        {
            
            return this._iProductGenreRepository.GetProductGenreAdvanceSearchColumns();
           
        }


		public ProductGenre GetProductGenre(System.Int32 ProductId)
		{
			return _iProductGenreRepository.GetProductGenre(ProductId);
		}

		public ProductGenre UpdateProductGenre(ProductGenre entity)
		{
			return _iProductGenreRepository.UpdateProductGenre(entity);
		}

		public bool DeleteProductGenre(System.Int32 ProductId)
		{
			return _iProductGenreRepository.DeleteProductGenre(ProductId);
		}

		public List<ProductGenre> GetAllProductGenre()
		{
			return _iProductGenreRepository.GetAllProductGenre();
		}

		public ProductGenre InsertProductGenre(ProductGenre entity)
		{
			 return _iProductGenreRepository.InsertProductGenre(entity);
		}


	}
	
	
}
