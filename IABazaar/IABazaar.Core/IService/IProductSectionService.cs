using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductSectionService
	{
        Dictionary<string, string> GetProductSectionBasicSearchColumns();
        
        List<SearchColumn> GetProductSectionAdvanceSearchColumns();

		ProductSection GetProductSection(System.Int32 ProductId);
		ProductSection UpdateProductSection(ProductSection entity);
		bool DeleteProductSection(System.Int32 ProductId);
		List<ProductSection> GetAllProductSection();
		ProductSection InsertProductSection(ProductSection entity);

	}
	
	
}
