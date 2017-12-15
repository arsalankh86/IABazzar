using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface INewsService
	{
        Dictionary<string, string> GetNewsBasicSearchColumns();
        
        List<SearchColumn> GetNewsAdvanceSearchColumns();

		News GetNews(System.Int32 NewsId);
		News UpdateNews(News entity);
		bool DeleteNews(System.Int32 NewsId);
		List<News> GetAllNews();
		News InsertNews(News entity);

	}
	
	
}
