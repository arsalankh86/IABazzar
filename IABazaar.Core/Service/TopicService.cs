using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class TopicService : ITopicService 
	{
		private ITopicRepository _iTopicRepository;
        
		public TopicService(ITopicRepository iTopicRepository)
		{
			this._iTopicRepository = iTopicRepository;
		}
        
        public Dictionary<string, string> GetTopicBasicSearchColumns()
        {
            
            return this._iTopicRepository.GetTopicBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetTopicAdvanceSearchColumns()
        {
            
            return this._iTopicRepository.GetTopicAdvanceSearchColumns();
           
        }


		public Topic GetTopic(System.Int32 TopicId)
		{
			return _iTopicRepository.GetTopic(TopicId);
		}

		public Topic UpdateTopic(Topic entity)
		{
			return _iTopicRepository.UpdateTopic(entity);
		}

		public bool DeleteTopic(System.Int32 TopicId)
		{
			return _iTopicRepository.DeleteTopic(TopicId);
		}

		public List<Topic> GetAllTopic()
		{
			return _iTopicRepository.GetAllTopic();
		}

		public Topic InsertTopic(Topic entity)
		{
			 return _iTopicRepository.InsertTopic(entity);
		}


	}
	
	
}
