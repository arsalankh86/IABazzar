using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IZipTaxRateRepositoryBase
	{
        
        Dictionary<string, string> GetZipTaxRateBasicSearchColumns();
        List<SearchColumn> GetZipTaxRateSearchColumns();
        List<SearchColumn> GetZipTaxRateAdvanceSearchColumns();
        

		ZipTaxRate GetZipTaxRate(System.Int32 ZipTaxId);
		ZipTaxRate UpdateZipTaxRate(ZipTaxRate entity);
		bool DeleteZipTaxRate(System.Int32 ZipTaxId);
		ZipTaxRate DeleteZipTaxRate(ZipTaxRate entity);
		List<ZipTaxRate> GetAllZipTaxRate();
		ZipTaxRate InsertZipTaxRate(ZipTaxRate entity);	}
	
	
}
