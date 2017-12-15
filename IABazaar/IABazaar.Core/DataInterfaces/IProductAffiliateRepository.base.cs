using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductAffiliateRepositoryBase
	{
        
        Dictionary<string, string> GetProductAffiliateBasicSearchColumns();
        List<SearchColumn> GetProductAffiliateSearchColumns();
        List<SearchColumn> GetProductAffiliateAdvanceSearchColumns();
        

		ProductAffiliate GetProductAffiliate(System.Int32 ProductId);
		ProductAffiliate UpdateProductAffiliate(ProductAffiliate entity);
		bool DeleteProductAffiliate(System.Int32 ProductId);
		ProductAffiliate DeleteProductAffiliate(ProductAffiliate entity);
		List<ProductAffiliate> GetAllProductAffiliate();
		ProductAffiliate InsertProductAffiliate(ProductAffiliate entity);	}
	
	
}
