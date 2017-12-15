using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductDistributorRepositoryBase
	{
        
        Dictionary<string, string> GetProductDistributorBasicSearchColumns();
        List<SearchColumn> GetProductDistributorSearchColumns();
        List<SearchColumn> GetProductDistributorAdvanceSearchColumns();
        

		ProductDistributor GetProductDistributor(System.Int32 ProductId);
		ProductDistributor UpdateProductDistributor(ProductDistributor entity);
		bool DeleteProductDistributor(System.Int32 ProductId);
		ProductDistributor DeleteProductDistributor(ProductDistributor entity);
		List<ProductDistributor> GetAllProductDistributor();
		ProductDistributor InsertProductDistributor(ProductDistributor entity);	}
	
	
}
