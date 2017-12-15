using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SearchLogService : ISearchLogService 
	{
		private ISearchLogRepository _iSearchLogRepository;
        
		public SearchLogService(ISearchLogRepository iSearchLogRepository)
		{
			this._iSearchLogRepository = iSearchLogRepository;
		}
        
        public Dictionary<string, string> GetSearchLogBasicSearchColumns()
        {
            
            return this._iSearchLogRepository.GetSearchLogBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSearchLogAdvanceSearchColumns()
        {
            
            return this._iSearchLogRepository.GetSearchLogAdvanceSearchColumns();
           
        }


		public List<SearchLog> GetAllSearchLog()
		{
			return _iSearchLogRepository.GetAllSearchLog();
		}

		public SearchLog InsertSearchLog(SearchLog entity)
		{
			 return _iSearchLogRepository.InsertSearchLog(entity);
		}


	}
	
	
}
