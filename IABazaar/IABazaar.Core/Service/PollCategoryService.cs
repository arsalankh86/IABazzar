using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollCategoryService : IPollCategoryService 
	{
		private IPollCategoryRepository _iPollCategoryRepository;
        
		public PollCategoryService(IPollCategoryRepository iPollCategoryRepository)
		{
			this._iPollCategoryRepository = iPollCategoryRepository;
		}
        
        public Dictionary<string, string> GetPollCategoryBasicSearchColumns()
        {
            
            return this._iPollCategoryRepository.GetPollCategoryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollCategoryAdvanceSearchColumns()
        {
            
            return this._iPollCategoryRepository.GetPollCategoryAdvanceSearchColumns();
           
        }


		public PollCategory GetPollCategory(System.Int32 PollId)
		{
			return _iPollCategoryRepository.GetPollCategory(PollId);
		}

		public PollCategory UpdatePollCategory(PollCategory entity)
		{
			return _iPollCategoryRepository.UpdatePollCategory(entity);
		}

		public bool DeletePollCategory(System.Int32 PollId)
		{
			return _iPollCategoryRepository.DeletePollCategory(PollId);
		}

		public List<PollCategory> GetAllPollCategory()
		{
			return _iPollCategoryRepository.GetAllPollCategory();
		}

		public PollCategory InsertPollCategory(PollCategory entity)
		{
			 return _iPollCategoryRepository.InsertPollCategory(entity);
		}


	}
	
	
}
