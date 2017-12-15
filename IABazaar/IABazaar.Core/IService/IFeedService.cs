using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IFeedService
	{
        Dictionary<string, string> GetFeedBasicSearchColumns();
        
        List<SearchColumn> GetFeedAdvanceSearchColumns();

		Feed GetFeed(System.Int32 FeedId);
		Feed UpdateFeed(Feed entity);
		bool DeleteFeed(System.Int32 FeedId);
		List<Feed> GetAllFeed();
		Feed InsertFeed(Feed entity);

	}
	
	
}
