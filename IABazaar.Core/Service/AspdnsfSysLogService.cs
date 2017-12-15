using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AspdnsfSysLogService : IAspdnsfSysLogService 
	{
		private IAspdnsfSysLogRepository _iAspdnsfSysLogRepository;
        
		public AspdnsfSysLogService(IAspdnsfSysLogRepository iAspdnsfSysLogRepository)
		{
			this._iAspdnsfSysLogRepository = iAspdnsfSysLogRepository;
		}
        
        public Dictionary<string, string> GetAspdnsfSysLogBasicSearchColumns()
        {
            
            return this._iAspdnsfSysLogRepository.GetAspdnsfSysLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAspdnsfSysLogAdvanceSearchColumns()
        {
            
            return this._iAspdnsfSysLogRepository.GetAspdnsfSysLogAdvanceSearchColumns();
           
        }


		public AspdnsfSysLog GetAspdnsfSysLog(System.Int32 SysLogId)
		{
			return _iAspdnsfSysLogRepository.GetAspdnsfSysLog(SysLogId);
		}

		public AspdnsfSysLog UpdateAspdnsfSysLog(AspdnsfSysLog entity)
		{
			return _iAspdnsfSysLogRepository.UpdateAspdnsfSysLog(entity);
		}

		public bool DeleteAspdnsfSysLog(System.Int32 SysLogId)
		{
			return _iAspdnsfSysLogRepository.DeleteAspdnsfSysLog(SysLogId);
		}

		public List<AspdnsfSysLog> GetAllAspdnsfSysLog()
		{
			return _iAspdnsfSysLogRepository.GetAllAspdnsfSysLog();
		}

		public AspdnsfSysLog InsertAspdnsfSysLog(AspdnsfSysLog entity)
		{
			 return _iAspdnsfSysLogRepository.InsertAspdnsfSysLog(entity);
		}


	}
	
	
}
