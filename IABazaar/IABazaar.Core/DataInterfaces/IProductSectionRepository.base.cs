using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductSectionRepositoryBase
	{
        
        Dictionary<string, string> GetProductSectionBasicSearchColumns();
        List<SearchColumn> GetProductSectionSearchColumns();
        List<SearchColumn> GetProductSectionAdvanceSearchColumns();
        

		ProductSection GetProductSection(System.Int32 ProductId);
		ProductSection UpdateProductSection(ProductSection entity);
		bool DeleteProductSection(System.Int32 ProductId);
		ProductSection DeleteProductSection(ProductSection entity);
		List<ProductSection> GetAllProductSection();
		ProductSection InsertProductSection(ProductSection entity);	}
	
	
}
