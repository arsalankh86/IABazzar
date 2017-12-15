using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductVectorRepositoryBase
	{
        
        Dictionary<string, string> GetProductVectorBasicSearchColumns();
        List<SearchColumn> GetProductVectorSearchColumns();
        List<SearchColumn> GetProductVectorAdvanceSearchColumns();
        

		ProductVector GetProductVector(System.Int32 ProductId);
		ProductVector UpdateProductVector(ProductVector entity);
		bool DeleteProductVector(System.Int32 ProductId);
		ProductVector DeleteProductVector(ProductVector entity);
		List<ProductVector> GetAllProductVector();
		ProductVector InsertProductVector(ProductVector entity);	}
	
	
}
