using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShippingImportExportService
	{
        Dictionary<string, string> GetShippingImportExportBasicSearchColumns();
        
        List<SearchColumn> GetShippingImportExportAdvanceSearchColumns();

		ShippingImportExport GetShippingImportExport(System.Int32 OrderNumber);
		ShippingImportExport UpdateShippingImportExport(ShippingImportExport entity);
		bool DeleteShippingImportExport(System.Int32 OrderNumber);
		List<ShippingImportExport> GetAllShippingImportExport();
		ShippingImportExport InsertShippingImportExport(ShippingImportExport entity);

	}
	
	
}
