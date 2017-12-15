using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface INewsStoreRepositoryBase
	{
        
        Dictionary<string, string> GetNewsStoreBasicSearchColumns();
        List<SearchColumn> GetNewsStoreSearchColumns();
        List<SearchColumn> GetNewsStoreAdvanceSearchColumns();
        

		NewsStore GetNewsStore(System.Int32 NewsId);
		NewsStore UpdateNewsStore(NewsStore entity);
		bool DeleteNewsStore(System.Int32 NewsId);
		NewsStore DeleteNewsStore(NewsStore entity);
		List<NewsStore> GetAllNewsStore();
		NewsStore InsertNewsStore(NewsStore entity);	}
	
	
}
