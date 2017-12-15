using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductViewService
	{
        Dictionary<string, string> GetProductViewBasicSearchColumns();
        
        List<SearchColumn> GetProductViewAdvanceSearchColumns();

		ProductView GetProductView(System.Int32 ViewId);
		ProductView UpdateProductView(ProductView entity);
		bool DeleteProductView(System.Int32 ViewId);
		List<ProductView> GetAllProductView();
		ProductView InsertProductView(ProductView entity);

	}
	
	
}
