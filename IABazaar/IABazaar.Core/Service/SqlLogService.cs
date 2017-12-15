using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SqlLogService : ISqlLogService 
	{
		private ISqlLogRepository _iSqlLogRepository;
        
		public SqlLogService(ISqlLogRepository iSqlLogRepository)
		{
			this._iSqlLogRepository = iSqlLogRepository;
		}
        
        public Dictionary<string, string> GetSqlLogBasicSearchColumns()
        {
            
            return this._iSqlLogRepository.GetSqlLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSqlLogAdvanceSearchColumns()
        {
            
            return this._iSqlLogRepository.GetSqlLogAdvanceSearchColumns();
           
        }


		public SqlLog GetSqlLog(System.Int32 SqlLogId)
		{
			return _iSqlLogRepository.GetSqlLog(SqlLogId);
		}

		public SqlLog UpdateSqlLog(SqlLog entity)
		{
			return _iSqlLogRepository.UpdateSqlLog(entity);
		}

		public bool DeleteSqlLog(System.Int32 SqlLogId)
		{
			return _iSqlLogRepository.DeleteSqlLog(SqlLogId);
		}

		public List<SqlLog> GetAllSqlLog()
		{
			return _iSqlLogRepository.GetAllSqlLog();
		}

		public SqlLog InsertSqlLog(SqlLog entity)
		{
			 return _iSqlLogRepository.InsertSqlLog(entity);
		}


	}
	
	
}
