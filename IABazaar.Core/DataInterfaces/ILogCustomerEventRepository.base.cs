using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILogCustomerEventRepositoryBase
	{
        
        Dictionary<string, string> GetLogCustomerEventBasicSearchColumns();
        List<SearchColumn> GetLogCustomerEventSearchColumns();
        List<SearchColumn> GetLogCustomerEventAdvanceSearchColumns();
        

		LogCustomerEvent GetLogCustomerEvent(System.Int32 DbRecNo);
		LogCustomerEvent UpdateLogCustomerEvent(LogCustomerEvent entity);
		bool DeleteLogCustomerEvent(System.Int32 DbRecNo);
		LogCustomerEvent DeleteLogCustomerEvent(LogCustomerEvent entity);
		List<LogCustomerEvent> GetAllLogCustomerEvent();
		LogCustomerEvent InsertLogCustomerEvent(LogCustomerEvent entity);	}
	
	
}
