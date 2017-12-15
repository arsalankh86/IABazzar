using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductRepositoryBase
	{
        
        Dictionary<string, string> GetProductBasicSearchColumns();
        List<SearchColumn> GetProductSearchColumns();
        List<SearchColumn> GetProductAdvanceSearchColumns();
        

		Product GetProduct(System.Int32 ProductId);
		Product UpdateProduct(Product entity);
		bool DeleteProduct(System.Int32 ProductId);
		Product DeleteProduct(Product entity);
		List<Product> GetAllProduct();
		Product InsertProduct(Product entity);	}
	
	
}
