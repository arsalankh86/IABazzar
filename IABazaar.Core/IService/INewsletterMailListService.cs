using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface INewsletterMailListService
	{
        Dictionary<string, string> GetNewsletterMailListBasicSearchColumns();
        
        List<SearchColumn> GetNewsletterMailListAdvanceSearchColumns();

		List<NewsletterMailList> GetAllNewsletterMailList();
		NewsletterMailList InsertNewsletterMailList(NewsletterMailList entity);

	}
	
	
}
