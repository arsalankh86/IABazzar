using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollSectionService : IPollSectionService 
	{
		private IPollSectionRepository _iPollSectionRepository;
        
		public PollSectionService(IPollSectionRepository iPollSectionRepository)
		{
			this._iPollSectionRepository = iPollSectionRepository;
		}
        
        public Dictionary<string, string> GetPollSectionBasicSearchColumns()
        {
            
            return this._iPollSectionRepository.GetPollSectionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollSectionAdvanceSearchColumns()
        {
            
            return this._iPollSectionRepository.GetPollSectionAdvanceSearchColumns();
           
        }


		public PollSection GetPollSection(System.Int32 PollId)
		{
			return _iPollSectionRepository.GetPollSection(PollId);
		}

		public PollSection UpdatePollSection(PollSection entity)
		{
			return _iPollSectionRepository.UpdatePollSection(entity);
		}

		public bool DeletePollSection(System.Int32 PollId)
		{
			return _iPollSectionRepository.DeletePollSection(PollId);
		}

		public List<PollSection> GetAllPollSection()
		{
			return _iPollSectionRepository.GetAllPollSection();
		}

		public PollSection InsertPollSection(PollSection entity)
		{
			 return _iPollSectionRepository.InsertPollSection(entity);
		}


	}
	
	
}
