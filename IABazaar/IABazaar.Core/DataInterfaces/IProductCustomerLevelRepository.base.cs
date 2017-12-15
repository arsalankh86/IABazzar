using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductCustomerLevelRepositoryBase
	{
        
        Dictionary<string, string> GetProductCustomerLevelBasicSearchColumns();
        List<SearchColumn> GetProductCustomerLevelSearchColumns();
        List<SearchColumn> GetProductCustomerLevelAdvanceSearchColumns();
        

		ProductCustomerLevel GetProductCustomerLevel(System.Int32 ProductId);
		ProductCustomerLevel UpdateProductCustomerLevel(ProductCustomerLevel entity);
		bool DeleteProductCustomerLevel(System.Int32 ProductId);
		ProductCustomerLevel DeleteProductCustomerLevel(ProductCustomerLevel entity);
		List<ProductCustomerLevel> GetAllProductCustomerLevel();
		ProductCustomerLevel InsertProductCustomerLevel(ProductCustomerLevel entity);	}
	
	
}
