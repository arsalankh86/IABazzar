using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class TopicMappingService : ITopicMappingService 
	{
		private ITopicMappingRepository _iTopicMappingRepository;
        
		public TopicMappingService(ITopicMappingRepository iTopicMappingRepository)
		{
			this._iTopicMappingRepository = iTopicMappingRepository;
		}
        
        public Dictionary<string, string> GetTopicMappingBasicSearchColumns()
        {
            
            return this._iTopicMappingRepository.GetTopicMappingBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetTopicMappingAdvanceSearchColumns()
        {
            
            return this._iTopicMappingRepository.GetTopicMappingAdvanceSearchColumns();
           
        }


		public List<TopicMapping> GetAllTopicMapping()
		{
			return _iTopicMappingRepository.GetAllTopicMapping();
		}

		public TopicMapping InsertTopicMapping(TopicMapping entity)
		{
			 return _iTopicMappingRepository.InsertTopicMapping(entity);
		}


	}
	
	
}
