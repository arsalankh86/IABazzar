using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICustomReportService
	{
        Dictionary<string, string> GetCustomReportBasicSearchColumns();
        
        List<SearchColumn> GetCustomReportAdvanceSearchColumns();

		CustomReport GetCustomReport(System.Int32 CustomReportId);
		CustomReport UpdateCustomReport(CustomReport entity);
		bool DeleteCustomReport(System.Int32 CustomReportId);
		List<CustomReport> GetAllCustomReport();
		CustomReport InsertCustomReport(CustomReport entity);

	}
	
	
}
