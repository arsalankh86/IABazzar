using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductGenreService
	{
        Dictionary<string, string> GetProductGenreBasicSearchColumns();
        
        List<SearchColumn> GetProductGenreAdvanceSearchColumns();

		ProductGenre GetProductGenre(System.Int32 ProductId);
		ProductGenre UpdateProductGenre(ProductGenre entity);
		bool DeleteProductGenre(System.Int32 ProductId);
		List<ProductGenre> GetAllProductGenre();
		ProductGenre InsertProductGenre(ProductGenre entity);

	}
	
	
}
