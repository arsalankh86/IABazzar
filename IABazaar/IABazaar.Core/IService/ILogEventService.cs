using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILogEventService
	{
        Dictionary<string, string> GetLogEventBasicSearchColumns();
        
        List<SearchColumn> GetLogEventAdvanceSearchColumns();

		LogEvent GetLogEvent(System.Int32 EventId);
		LogEvent UpdateLogEvent(LogEvent entity);
		bool DeleteLogEvent(System.Int32 EventId);
		List<LogEvent> GetAllLogEvent();
		LogEvent InsertLogEvent(LogEvent entity);

	}
	
	
}
