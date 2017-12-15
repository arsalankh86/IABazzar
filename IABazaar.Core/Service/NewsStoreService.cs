using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class NewsStoreService : INewsStoreService 
	{
		private INewsStoreRepository _iNewsStoreRepository;
        
		public NewsStoreService(INewsStoreRepository iNewsStoreRepository)
		{
			this._iNewsStoreRepository = iNewsStoreRepository;
		}
        
        public Dictionary<string, string> GetNewsStoreBasicSearchColumns()
        {
            
            return this._iNewsStoreRepository.GetNewsStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetNewsStoreAdvanceSearchColumns()
        {
            
            return this._iNewsStoreRepository.GetNewsStoreAdvanceSearchColumns();
           
        }


		public NewsStore GetNewsStore(System.Int32 NewsId)
		{
			return _iNewsStoreRepository.GetNewsStore(NewsId);
		}

		public NewsStore UpdateNewsStore(NewsStore entity)
		{
			return _iNewsStoreRepository.UpdateNewsStore(entity);
		}

		public bool DeleteNewsStore(System.Int32 NewsId)
		{
			return _iNewsStoreRepository.DeleteNewsStore(NewsId);
		}

		public List<NewsStore> GetAllNewsStore()
		{
			return _iNewsStoreRepository.GetAllNewsStore();
		}

		public NewsStore InsertNewsStore(NewsStore entity)
		{
			 return _iNewsStoreRepository.InsertNewsStore(entity);
		}


	}
	
	
}
