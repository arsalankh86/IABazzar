using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IManufacturerService
	{
        Dictionary<string, string> GetManufacturerBasicSearchColumns();
        
        List<SearchColumn> GetManufacturerAdvanceSearchColumns();

		Manufacturer GetManufacturer(System.Int32 ManufacturerId);
		Manufacturer UpdateManufacturer(Manufacturer entity);
		bool DeleteManufacturer(System.Int32 ManufacturerId);
		List<Manufacturer> GetAllManufacturer();
		Manufacturer InsertManufacturer(Manufacturer entity);

	}
	
	
}
