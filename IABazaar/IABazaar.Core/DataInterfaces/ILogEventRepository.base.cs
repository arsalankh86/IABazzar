using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILogEventRepositoryBase
	{
        
        Dictionary<string, string> GetLogEventBasicSearchColumns();
        List<SearchColumn> GetLogEventSearchColumns();
        List<SearchColumn> GetLogEventAdvanceSearchColumns();
        

		LogEvent GetLogEvent(System.Int32 EventId);
		LogEvent UpdateLogEvent(LogEvent entity);
		bool DeleteLogEvent(System.Int32 EventId);
		LogEvent DeleteLogEvent(LogEvent entity);
		List<LogEvent> GetAllLogEvent();
		LogEvent InsertLogEvent(LogEvent entity);	}
	
	
}
