using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductTypeRepositoryBase
	{
        
        Dictionary<string, string> GetProductTypeBasicSearchColumns();
        List<SearchColumn> GetProductTypeSearchColumns();
        List<SearchColumn> GetProductTypeAdvanceSearchColumns();
        

		ProductType GetProductType(System.Int32 ProductTypeId);
		ProductType UpdateProductType(ProductType entity);
		bool DeleteProductType(System.Int32 ProductTypeId);
		ProductType DeleteProductType(ProductType entity);
		List<ProductType> GetAllProductType();
		ProductType InsertProductType(ProductType entity);	}
	
	
}
