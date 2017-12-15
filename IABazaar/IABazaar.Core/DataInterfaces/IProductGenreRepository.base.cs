using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductGenreRepositoryBase
	{
        
        Dictionary<string, string> GetProductGenreBasicSearchColumns();
        List<SearchColumn> GetProductGenreSearchColumns();
        List<SearchColumn> GetProductGenreAdvanceSearchColumns();
        

		ProductGenre GetProductGenre(System.Int32 ProductId);
		ProductGenre UpdateProductGenre(ProductGenre entity);
		bool DeleteProductGenre(System.Int32 ProductId);
		ProductGenre DeleteProductGenre(ProductGenre entity);
		List<ProductGenre> GetAllProductGenre();
		ProductGenre InsertProductGenre(ProductGenre entity);	}
	
	
}
