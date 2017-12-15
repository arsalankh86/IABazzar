using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductService
	{
        Dictionary<string, string> GetProductBasicSearchColumns();
        
        List<SearchColumn> GetProductAdvanceSearchColumns();

		Product GetProduct(System.Int32 ProductId);
		Product UpdateProduct(Product entity);
		bool DeleteProduct(System.Int32 ProductId);
		List<Product> GetAllProduct();
		Product InsertProduct(Product entity);

	}
	
	
}
