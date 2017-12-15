using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LogEventService : ILogEventService 
	{
		private ILogEventRepository _iLogEventRepository;
        
		public LogEventService(ILogEventRepository iLogEventRepository)
		{
			this._iLogEventRepository = iLogEventRepository;
		}
        
        public Dictionary<string, string> GetLogEventBasicSearchColumns()
        {
            
            return this._iLogEventRepository.GetLogEventBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLogEventAdvanceSearchColumns()
        {
            
            return this._iLogEventRepository.GetLogEventAdvanceSearchColumns();
           
        }


		public LogEvent GetLogEvent(System.Int32 EventId)
		{
			return _iLogEventRepository.GetLogEvent(EventId);
		}

		public LogEvent UpdateLogEvent(LogEvent entity)
		{
			return _iLogEventRepository.UpdateLogEvent(entity);
		}

		public bool DeleteLogEvent(System.Int32 EventId)
		{
			return _iLogEventRepository.DeleteLogEvent(EventId);
		}

		public List<LogEvent> GetAllLogEvent()
		{
			return _iLogEventRepository.GetAllLogEvent();
		}

		public LogEvent InsertLogEvent(LogEvent entity)
		{
			 return _iLogEventRepository.InsertLogEvent(entity);
		}


	}
	
	
}
