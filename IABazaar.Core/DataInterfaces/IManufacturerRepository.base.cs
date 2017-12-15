using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IManufacturerRepositoryBase
	{
        
        Dictionary<string, string> GetManufacturerBasicSearchColumns();
        List<SearchColumn> GetManufacturerSearchColumns();
        List<SearchColumn> GetManufacturerAdvanceSearchColumns();
        

		Manufacturer GetManufacturer(System.Int32 ManufacturerId);
		Manufacturer UpdateManufacturer(Manufacturer entity);
		bool DeleteManufacturer(System.Int32 ManufacturerId);
		Manufacturer DeleteManufacturer(Manufacturer entity);
		List<Manufacturer> GetAllManufacturer();
		Manufacturer InsertManufacturer(Manufacturer entity);	}
	
	
}
