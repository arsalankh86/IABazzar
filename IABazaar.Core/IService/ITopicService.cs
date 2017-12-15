using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ITopicService
	{
        Dictionary<string, string> GetTopicBasicSearchColumns();
        
        List<SearchColumn> GetTopicAdvanceSearchColumns();

		Topic GetTopic(System.Int32 TopicId);
		Topic UpdateTopic(Topic entity);
		bool DeleteTopic(System.Int32 TopicId);
		List<Topic> GetAllTopic();
		Topic InsertTopic(Topic entity);

	}
	
	
}
