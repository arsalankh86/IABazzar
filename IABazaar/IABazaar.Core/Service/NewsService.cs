using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class NewsService : INewsService 
	{
		private INewsRepository _iNewsRepository;
        
		public NewsService(INewsRepository iNewsRepository)
		{
			this._iNewsRepository = iNewsRepository;
		}
        
        public Dictionary<string, string> GetNewsBasicSearchColumns()
        {
            
            return this._iNewsRepository.GetNewsBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetNewsAdvanceSearchColumns()
        {
            
            return this._iNewsRepository.GetNewsAdvanceSearchColumns();
           
        }


		public News GetNews(System.Int32 NewsId)
		{
			return _iNewsRepository.GetNews(NewsId);
		}

		public News UpdateNews(News entity)
		{
			return _iNewsRepository.UpdateNews(entity);
		}

		public bool DeleteNews(System.Int32 NewsId)
		{
			return _iNewsRepository.DeleteNews(NewsId);
		}

		public List<News> GetAllNews()
		{
			return _iNewsRepository.GetAllNews();
		}

		public News InsertNews(News entity)
		{
			 return _iNewsRepository.InsertNews(entity);
		}


	}
	
	
}
