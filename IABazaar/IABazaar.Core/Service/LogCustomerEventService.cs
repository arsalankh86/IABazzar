using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LogCustomerEventService : ILogCustomerEventService 
	{
		private ILogCustomerEventRepository _iLogCustomerEventRepository;
        
		public LogCustomerEventService(ILogCustomerEventRepository iLogCustomerEventRepository)
		{
			this._iLogCustomerEventRepository = iLogCustomerEventRepository;
		}
        
        public Dictionary<string, string> GetLogCustomerEventBasicSearchColumns()
        {
            
            return this._iLogCustomerEventRepository.GetLogCustomerEventBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLogCustomerEventAdvanceSearchColumns()
        {
            
            return this._iLogCustomerEventRepository.GetLogCustomerEventAdvanceSearchColumns();
           
        }


		public LogCustomerEvent GetLogCustomerEvent(System.Int32 DbRecNo)
		{
			return _iLogCustomerEventRepository.GetLogCustomerEvent(DbRecNo);
		}

		public LogCustomerEvent UpdateLogCustomerEvent(LogCustomerEvent entity)
		{
			return _iLogCustomerEventRepository.UpdateLogCustomerEvent(entity);
		}

		public bool DeleteLogCustomerEvent(System.Int32 DbRecNo)
		{
			return _iLogCustomerEventRepository.DeleteLogCustomerEvent(DbRecNo);
		}

		public List<LogCustomerEvent> GetAllLogCustomerEvent()
		{
			return _iLogCustomerEventRepository.GetAllLogCustomerEvent();
		}

		public LogCustomerEvent InsertLogCustomerEvent(LogCustomerEvent entity)
		{
			 return _iLogCustomerEventRepository.InsertLogCustomerEvent(entity);
		}


	}
	
	
}
