using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IFaqService
	{
        Dictionary<string, string> GetFaqBasicSearchColumns();
        
        List<SearchColumn> GetFaqAdvanceSearchColumns();

		Faq GetFaq(System.Int32 Faqid);
		Faq UpdateFaq(Faq entity);
		bool DeleteFaq(System.Int32 Faqid);
		List<Faq> GetAllFaq();
		Faq InsertFaq(Faq entity);

	}
	
	
}
