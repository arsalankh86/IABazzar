using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductCategoryRepositoryBase
	{
        
        Dictionary<string, string> GetProductCategoryBasicSearchColumns();
        List<SearchColumn> GetProductCategorySearchColumns();
        List<SearchColumn> GetProductCategoryAdvanceSearchColumns();
        

		ProductCategory GetProductCategory(System.Int32 ProductId);
		ProductCategory UpdateProductCategory(ProductCategory entity);
		bool DeleteProductCategory(System.Int32 ProductId);
		ProductCategory DeleteProductCategory(ProductCategory entity);
		List<ProductCategory> GetAllProductCategory();
		ProductCategory InsertProductCategory(ProductCategory entity);	}
	
	
}
