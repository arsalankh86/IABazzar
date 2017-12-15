using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ITopicRepositoryBase
	{
        
        Dictionary<string, string> GetTopicBasicSearchColumns();
        List<SearchColumn> GetTopicSearchColumns();
        List<SearchColumn> GetTopicAdvanceSearchColumns();
        

		Topic GetTopic(System.Int32 TopicId);
		Topic UpdateTopic(Topic entity);
		bool DeleteTopic(System.Int32 TopicId);
		Topic DeleteTopic(Topic entity);
		List<Topic> GetAllTopic();
		Topic InsertTopic(Topic entity);	}
	
	
}
