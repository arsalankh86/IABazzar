using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingImportExportRepositoryBase
	{
        
        Dictionary<string, string> GetShippingImportExportBasicSearchColumns();
        List<SearchColumn> GetShippingImportExportSearchColumns();
        List<SearchColumn> GetShippingImportExportAdvanceSearchColumns();
        

		ShippingImportExport GetShippingImportExport(System.Int32 OrderNumber);
		ShippingImportExport UpdateShippingImportExport(ShippingImportExport entity);
		bool DeleteShippingImportExport(System.Int32 OrderNumber);
		ShippingImportExport DeleteShippingImportExport(ShippingImportExport entity);
		List<ShippingImportExport> GetAllShippingImportExport();
		ShippingImportExport InsertShippingImportExport(ShippingImportExport entity);	}
	
	
}
