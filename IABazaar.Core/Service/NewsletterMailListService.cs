using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class NewsletterMailListService : INewsletterMailListService 
	{
		private INewsletterMailListRepository _iNewsletterMailListRepository;
        
		public NewsletterMailListService(INewsletterMailListRepository iNewsletterMailListRepository)
		{
			this._iNewsletterMailListRepository = iNewsletterMailListRepository;
		}
        
        public Dictionary<string, string> GetNewsletterMailListBasicSearchColumns()
        {
            
            return this._iNewsletterMailListRepository.GetNewsletterMailListBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetNewsletterMailListAdvanceSearchColumns()
        {
            
            return this._iNewsletterMailListRepository.GetNewsletterMailListAdvanceSearchColumns();
           
        }


		public List<NewsletterMailList> GetAllNewsletterMailList()
		{
			return _iNewsletterMailListRepository.GetAllNewsletterMailList();
		}

		public NewsletterMailList InsertNewsletterMailList(NewsletterMailList entity)
		{
			 return _iNewsletterMailListRepository.InsertNewsletterMailList(entity);
		}


	}
	
	
}
