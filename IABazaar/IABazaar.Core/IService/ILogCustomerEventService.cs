using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILogCustomerEventService
	{
        Dictionary<string, string> GetLogCustomerEventBasicSearchColumns();
        
        List<SearchColumn> GetLogCustomerEventAdvanceSearchColumns();

		LogCustomerEvent GetLogCustomerEvent(System.Int32 DbRecNo);
		LogCustomerEvent UpdateLogCustomerEvent(LogCustomerEvent entity);
		bool DeleteLogCustomerEvent(System.Int32 DbRecNo);
		List<LogCustomerEvent> GetAllLogCustomerEvent();
		LogCustomerEvent InsertLogCustomerEvent(LogCustomerEvent entity);

	}
	
	
}
