using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductStoreRepositoryBase
	{
        
        Dictionary<string, string> GetProductStoreBasicSearchColumns();
        List<SearchColumn> GetProductStoreSearchColumns();
        List<SearchColumn> GetProductStoreAdvanceSearchColumns();
        

		ProductStore GetProductStore(System.Int32 ProductId);
		ProductStore UpdateProductStore(ProductStore entity);
		bool DeleteProductStore(System.Int32 ProductId);
		ProductStore DeleteProductStore(ProductStore entity);
		List<ProductStore> GetAllProductStore();
		ProductStore InsertProductStore(ProductStore entity);	}
	
	
}
