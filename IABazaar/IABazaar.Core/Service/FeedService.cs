using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class FeedService : IFeedService 
	{
		private IFeedRepository _iFeedRepository;
        
		public FeedService(IFeedRepository iFeedRepository)
		{
			this._iFeedRepository = iFeedRepository;
		}
        
        public Dictionary<string, string> GetFeedBasicSearchColumns()
        {
            
            return this._iFeedRepository.GetFeedBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetFeedAdvanceSearchColumns()
        {
            
            return this._iFeedRepository.GetFeedAdvanceSearchColumns();
           
        }


		public Feed GetFeed(System.Int32 FeedId)
		{
			return _iFeedRepository.GetFeed(FeedId);
		}

		public Feed UpdateFeed(Feed entity)
		{
			return _iFeedRepository.UpdateFeed(entity);
		}

		public bool DeleteFeed(System.Int32 FeedId)
		{
			return _iFeedRepository.DeleteFeed(FeedId);
		}

		public List<Feed> GetAllFeed()
		{
			return _iFeedRepository.GetAllFeed();
		}

		public Feed InsertFeed(Feed entity)
		{
			 return _iFeedRepository.InsertFeed(entity);
		}


	}
	
	
}
