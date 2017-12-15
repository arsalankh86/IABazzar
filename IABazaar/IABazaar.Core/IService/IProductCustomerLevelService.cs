using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductCustomerLevelService
	{
        Dictionary<string, string> GetProductCustomerLevelBasicSearchColumns();
        
        List<SearchColumn> GetProductCustomerLevelAdvanceSearchColumns();

		ProductCustomerLevel GetProductCustomerLevel(System.Int32 ProductId);
		ProductCustomerLevel UpdateProductCustomerLevel(ProductCustomerLevel entity);
		bool DeleteProductCustomerLevel(System.Int32 ProductId);
		List<ProductCustomerLevel> GetAllProductCustomerLevel();
		ProductCustomerLevel InsertProductCustomerLevel(ProductCustomerLevel entity);

	}
	
	
}
