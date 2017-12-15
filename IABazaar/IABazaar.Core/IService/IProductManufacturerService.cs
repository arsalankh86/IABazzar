using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductManufacturerService
	{
        Dictionary<string, string> GetProductManufacturerBasicSearchColumns();
        
        List<SearchColumn> GetProductManufacturerAdvanceSearchColumns();

		ProductManufacturer GetProductManufacturer(System.Int32 ProductId);
		ProductManufacturer UpdateProductManufacturer(ProductManufacturer entity);
		bool DeleteProductManufacturer(System.Int32 ProductId);
		List<ProductManufacturer> GetAllProductManufacturer();
		ProductManufacturer InsertProductManufacturer(ProductManufacturer entity);

	}
	
	
}
