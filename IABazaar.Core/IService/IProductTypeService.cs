using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductTypeService
	{
        Dictionary<string, string> GetProductTypeBasicSearchColumns();
        
        List<SearchColumn> GetProductTypeAdvanceSearchColumns();

		ProductType GetProductType(System.Int32 ProductTypeId);
		ProductType UpdateProductType(ProductType entity);
		bool DeleteProductType(System.Int32 ProductTypeId);
		List<ProductType> GetAllProductType();
		ProductType InsertProductType(ProductType entity);

	}
	
	
}
