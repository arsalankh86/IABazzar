using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ITopicStoreRepositoryBase
	{
        
        Dictionary<string, string> GetTopicStoreBasicSearchColumns();
        List<SearchColumn> GetTopicStoreSearchColumns();
        List<SearchColumn> GetTopicStoreAdvanceSearchColumns();
        

		TopicStore GetTopicStore(System.Int32 TopicId);
		TopicStore UpdateTopicStore(TopicStore entity);
		bool DeleteTopicStore(System.Int32 TopicId);
		TopicStore DeleteTopicStore(TopicStore entity);
		List<TopicStore> GetAllTopicStore();
		TopicStore InsertTopicStore(TopicStore entity);	}
	
	
}
