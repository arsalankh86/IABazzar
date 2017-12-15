using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ITopicMappingRepositoryBase
	{
        
        Dictionary<string, string> GetTopicMappingBasicSearchColumns();
        List<SearchColumn> GetTopicMappingSearchColumns();
        List<SearchColumn> GetTopicMappingAdvanceSearchColumns();
        

		List<TopicMapping> GetAllTopicMapping();
		TopicMapping InsertTopicMapping(TopicMapping entity);	}
	
	
}
