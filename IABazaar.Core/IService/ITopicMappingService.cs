using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ITopicMappingService
	{
        Dictionary<string, string> GetTopicMappingBasicSearchColumns();
        
        List<SearchColumn> GetTopicMappingAdvanceSearchColumns();

		List<TopicMapping> GetAllTopicMapping();
		TopicMapping InsertTopicMapping(TopicMapping entity);

	}
	
	
}
