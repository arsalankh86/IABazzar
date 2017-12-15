using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICustomReportRepositoryBase
	{
        
        Dictionary<string, string> GetCustomReportBasicSearchColumns();
        List<SearchColumn> GetCustomReportSearchColumns();
        List<SearchColumn> GetCustomReportAdvanceSearchColumns();
        

		CustomReport GetCustomReport(System.Int32 CustomReportId);
		CustomReport UpdateCustomReport(CustomReport entity);
		bool DeleteCustomReport(System.Int32 CustomReportId);
		CustomReport DeleteCustomReport(CustomReport entity);
		List<CustomReport> GetAllCustomReport();
		CustomReport InsertCustomReport(CustomReport entity);	}
	
	
}
