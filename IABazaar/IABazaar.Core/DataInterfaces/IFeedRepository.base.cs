using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IFeedRepositoryBase
	{
        
        Dictionary<string, string> GetFeedBasicSearchColumns();
        List<SearchColumn> GetFeedSearchColumns();
        List<SearchColumn> GetFeedAdvanceSearchColumns();
        

		Feed GetFeed(System.Int32 FeedId);
		Feed UpdateFeed(Feed entity);
		bool DeleteFeed(System.Int32 FeedId);
		Feed DeleteFeed(Feed entity);
		List<Feed> GetAllFeed();
		Feed InsertFeed(Feed entity);	}
	
	
}
