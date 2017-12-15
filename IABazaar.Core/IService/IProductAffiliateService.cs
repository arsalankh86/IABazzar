using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductAffiliateService
	{
        Dictionary<string, string> GetProductAffiliateBasicSearchColumns();
        
        List<SearchColumn> GetProductAffiliateAdvanceSearchColumns();

		ProductAffiliate GetProductAffiliate(System.Int32 ProductId);
		ProductAffiliate UpdateProductAffiliate(ProductAffiliate entity);
		bool DeleteProductAffiliate(System.Int32 ProductId);
		List<ProductAffiliate> GetAllProductAffiliate();
		ProductAffiliate InsertProductAffiliate(ProductAffiliate entity);

	}
	
	
}
