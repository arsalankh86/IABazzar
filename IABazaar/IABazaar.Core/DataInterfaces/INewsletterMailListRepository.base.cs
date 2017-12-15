using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface INewsletterMailListRepositoryBase
	{
        
        Dictionary<string, string> GetNewsletterMailListBasicSearchColumns();
        List<SearchColumn> GetNewsletterMailListSearchColumns();
        List<SearchColumn> GetNewsletterMailListAdvanceSearchColumns();
        

		List<NewsletterMailList> GetAllNewsletterMailList();
		NewsletterMailList InsertNewsletterMailList(NewsletterMailList entity);	}
	
	
}
