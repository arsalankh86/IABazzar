using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductDistributorService
	{
        Dictionary<string, string> GetProductDistributorBasicSearchColumns();
        
        List<SearchColumn> GetProductDistributorAdvanceSearchColumns();

		ProductDistributor GetProductDistributor(System.Int32 ProductId);
		ProductDistributor UpdateProductDistributor(ProductDistributor entity);
		bool DeleteProductDistributor(System.Int32 ProductId);
		List<ProductDistributor> GetAllProductDistributor();
		ProductDistributor InsertProductDistributor(ProductDistributor entity);

	}
	
	
}
