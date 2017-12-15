using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ErrorLogService : IErrorLogService 
	{
		private IErrorLogRepository _iErrorLogRepository;
        
		public ErrorLogService(IErrorLogRepository iErrorLogRepository)
		{
			this._iErrorLogRepository = iErrorLogRepository;
		}
        
        public Dictionary<string, string> GetErrorLogBasicSearchColumns()
        {
            
            return this._iErrorLogRepository.GetErrorLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetErrorLogAdvanceSearchColumns()
        {
            
            return this._iErrorLogRepository.GetErrorLogAdvanceSearchColumns();
           
        }


		public ErrorLog GetErrorLog(System.Int32 Logid)
		{
			return _iErrorLogRepository.GetErrorLog(Logid);
		}

		public ErrorLog UpdateErrorLog(ErrorLog entity)
		{
			return _iErrorLogRepository.UpdateErrorLog(entity);
		}

		public bool DeleteErrorLog(System.Int32 Logid)
		{
			return _iErrorLogRepository.DeleteErrorLog(Logid);
		}

		public List<ErrorLog> GetAllErrorLog()
		{
			return _iErrorLogRepository.GetAllErrorLog();
		}

		public ErrorLog InsertErrorLog(ErrorLog entity)
		{
			 return _iErrorLogRepository.InsertErrorLog(entity);
		}


	}
	
	
}
