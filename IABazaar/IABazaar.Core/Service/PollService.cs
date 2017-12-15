using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollService : IPollService 
	{
		private IPollRepository _iPollRepository;
        
		public PollService(IPollRepository iPollRepository)
		{
			this._iPollRepository = iPollRepository;
		}
        
        public Dictionary<string, string> GetPollBasicSearchColumns()
        {
            
            return this._iPollRepository.GetPollBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollAdvanceSearchColumns()
        {
            
            return this._iPollRepository.GetPollAdvanceSearchColumns();
           
        }


		public Poll GetPoll(System.Int32 PollId)
		{
			return _iPollRepository.GetPoll(PollId);
		}

		public Poll UpdatePoll(Poll entity)
		{
			return _iPollRepository.UpdatePoll(entity);
		}

		public bool DeletePoll(System.Int32 PollId)
		{
			return _iPollRepository.DeletePoll(PollId);
		}

		public List<Poll> GetAllPoll()
		{
			return _iPollRepository.GetAllPoll();
		}

		public Poll InsertPoll(Poll entity)
		{
			 return _iPollRepository.InsertPoll(entity);
		}


	}
	
	
}
