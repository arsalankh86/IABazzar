using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class FaqService : IFaqService 
	{
		private IFaqRepository _iFaqRepository;
        
		public FaqService(IFaqRepository iFaqRepository)
		{
			this._iFaqRepository = iFaqRepository;
		}
        
        public Dictionary<string, string> GetFaqBasicSearchColumns()
        {
            
            return this._iFaqRepository.GetFaqBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetFaqAdvanceSearchColumns()
        {
            
            return this._iFaqRepository.GetFaqAdvanceSearchColumns();
           
        }


		public Faq GetFaq(System.Int32 Faqid)
		{
			return _iFaqRepository.GetFaq(Faqid);
		}

		public Faq UpdateFaq(Faq entity)
		{
			return _iFaqRepository.UpdateFaq(entity);
		}

		public bool DeleteFaq(System.Int32 Faqid)
		{
			return _iFaqRepository.DeleteFaq(Faqid);
		}

		public List<Faq> GetAllFaq()
		{
			return _iFaqRepository.GetAllFaq();
		}

		public Faq InsertFaq(Faq entity)
		{
			 return _iFaqRepository.InsertFaq(entity);
		}


	}
	
	
}
