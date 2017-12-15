using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PasswordLogService : IPasswordLogService 
	{
		private IPasswordLogRepository _iPasswordLogRepository;
        
		public PasswordLogService(IPasswordLogRepository iPasswordLogRepository)
		{
			this._iPasswordLogRepository = iPasswordLogRepository;
		}
        
        public Dictionary<string, string> GetPasswordLogBasicSearchColumns()
        {
            
            return this._iPasswordLogRepository.GetPasswordLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPasswordLogAdvanceSearchColumns()
        {
            
            return this._iPasswordLogRepository.GetPasswordLogAdvanceSearchColumns();
           
        }


		public List<PasswordLog> GetAllPasswordLog()
		{
			return _iPasswordLogRepository.GetAllPasswordLog();
		}

		public PasswordLog InsertPasswordLog(PasswordLog entity)
		{
			 return _iPasswordLogRepository.InsertPasswordLog(entity);
		}


	}
	
	
}
