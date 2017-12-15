using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductVariantRepositoryBase
	{
        
        Dictionary<string, string> GetProductVariantBasicSearchColumns();
        List<SearchColumn> GetProductVariantSearchColumns();
        List<SearchColumn> GetProductVariantAdvanceSearchColumns();
        

		ProductVariant GetProductVariant(System.Int32 VariantId);
		ProductVariant UpdateProductVariant(ProductVariant entity);
		bool DeleteProductVariant(System.Int32 VariantId);
		ProductVariant DeleteProductVariant(ProductVariant entity);
		List<ProductVariant> GetAllProductVariant();
		ProductVariant InsertProductVariant(ProductVariant entity);	}
	
	
}
