using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductVariantService
	{
        Dictionary<string, string> GetProductVariantBasicSearchColumns();
        
        List<SearchColumn> GetProductVariantAdvanceSearchColumns();

		ProductVariant GetProductVariant(System.Int32 VariantId);
		ProductVariant UpdateProductVariant(ProductVariant entity);
		bool DeleteProductVariant(System.Int32 VariantId);
		List<ProductVariant> GetAllProductVariant();
		ProductVariant InsertProductVariant(ProductVariant entity);

	}
	
	
}
