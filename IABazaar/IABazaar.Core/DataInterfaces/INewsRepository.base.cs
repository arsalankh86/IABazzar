using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface INewsRepositoryBase
	{
        
        Dictionary<string, string> GetNewsBasicSearchColumns();
        List<SearchColumn> GetNewsSearchColumns();
        List<SearchColumn> GetNewsAdvanceSearchColumns();
        

		News GetNews(System.Int32 NewsId);
		News UpdateNews(News entity);
		bool DeleteNews(System.Int32 NewsId);
		News DeleteNews(News entity);
		List<News> GetAllNews();
		News InsertNews(News entity);	}
	
	
}
