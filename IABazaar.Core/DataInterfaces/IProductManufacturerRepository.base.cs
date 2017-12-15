using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductManufacturerRepositoryBase
	{
        
        Dictionary<string, string> GetProductManufacturerBasicSearchColumns();
        List<SearchColumn> GetProductManufacturerSearchColumns();
        List<SearchColumn> GetProductManufacturerAdvanceSearchColumns();
        

		ProductManufacturer GetProductManufacturer(System.Int32 ProductId);
		ProductManufacturer UpdateProductManufacturer(ProductManufacturer entity);
		bool DeleteProductManufacturer(System.Int32 ProductId);
		ProductManufacturer DeleteProductManufacturer(ProductManufacturer entity);
		List<ProductManufacturer> GetAllProductManufacturer();
		ProductManufacturer InsertProductManufacturer(ProductManufacturer entity);	}
	
	
}
