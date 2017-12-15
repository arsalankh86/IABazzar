using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class TopicStoreService : ITopicStoreService 
	{
		private ITopicStoreRepository _iTopicStoreRepository;
        
		public TopicStoreService(ITopicStoreRepository iTopicStoreRepository)
		{
			this._iTopicStoreRepository = iTopicStoreRepository;
		}
        
        public Dictionary<string, string> GetTopicStoreBasicSearchColumns()
        {
            
            return this._iTopicStoreRepository.GetTopicStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetTopicStoreAdvanceSearchColumns()
        {
            
            return this._iTopicStoreRepository.GetTopicStoreAdvanceSearchColumns();
           
        }


		public TopicStore GetTopicStore(System.Int32 TopicId)
		{
			return _iTopicStoreRepository.GetTopicStore(TopicId);
		}

		public TopicStore UpdateTopicStore(TopicStore entity)
		{
			return _iTopicStoreRepository.UpdateTopicStore(entity);
		}

		public bool DeleteTopicStore(System.Int32 TopicId)
		{
			return _iTopicStoreRepository.DeleteTopicStore(TopicId);
		}

		public List<TopicStore> GetAllTopicStore()
		{
			return _iTopicStoreRepository.GetAllTopicStore();
		}

		public TopicStore InsertTopicStore(TopicStore entity)
		{
			 return _iTopicStoreRepository.InsertTopicStore(entity);
		}


	}
	
	
}
