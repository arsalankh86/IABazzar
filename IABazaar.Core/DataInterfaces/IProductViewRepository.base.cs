using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductViewRepositoryBase
	{
        
        Dictionary<string, string> GetProductViewBasicSearchColumns();
        List<SearchColumn> GetProductViewSearchColumns();
        List<SearchColumn> GetProductViewAdvanceSearchColumns();
        

		ProductView GetProductView(System.Int32 ViewId);
		ProductView UpdateProductView(ProductView entity);
		bool DeleteProductView(System.Int32 ViewId);
		ProductView DeleteProductView(ProductView entity);
		List<ProductView> GetAllProductView();
		ProductView InsertProductView(ProductView entity);	}
	
	
}
