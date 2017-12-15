using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IFaqRepositoryBase
	{
        
        Dictionary<string, string> GetFaqBasicSearchColumns();
        List<SearchColumn> GetFaqSearchColumns();
        List<SearchColumn> GetFaqAdvanceSearchColumns();
        

		Faq GetFaq(System.Int32 Faqid);
		Faq UpdateFaq(Faq entity);
		bool DeleteFaq(System.Int32 Faqid);
		Faq DeleteFaq(Faq entity);
		List<Faq> GetAllFaq();
		Faq InsertFaq(Faq entity);	}
	
	
}
