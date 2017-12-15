using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ITopicStoreService
	{
        Dictionary<string, string> GetTopicStoreBasicSearchColumns();
        
        List<SearchColumn> GetTopicStoreAdvanceSearchColumns();

		TopicStore GetTopicStore(System.Int32 TopicId);
		TopicStore UpdateTopicStore(TopicStore entity);
		bool DeleteTopicStore(System.Int32 TopicId);
		List<TopicStore> GetAllTopicStore();
		TopicStore InsertTopicStore(TopicStore entity);

	}
	
	
}
