using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollAnswerService : IPollAnswerService 
	{
		private IPollAnswerRepository _iPollAnswerRepository;
        
		public PollAnswerService(IPollAnswerRepository iPollAnswerRepository)
		{
			this._iPollAnswerRepository = iPollAnswerRepository;
		}
        
        public Dictionary<string, string> GetPollAnswerBasicSearchColumns()
        {
            
            return this._iPollAnswerRepository.GetPollAnswerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollAnswerAdvanceSearchColumns()
        {
            
            return this._iPollAnswerRepository.GetPollAnswerAdvanceSearchColumns();
           
        }


		public PollAnswer GetPollAnswer(System.Int32 PollAnswerId)
		{
			return _iPollAnswerRepository.GetPollAnswer(PollAnswerId);
		}

		public PollAnswer UpdatePollAnswer(PollAnswer entity)
		{
			return _iPollAnswerRepository.UpdatePollAnswer(entity);
		}

		public bool DeletePollAnswer(System.Int32 PollAnswerId)
		{
			return _iPollAnswerRepository.DeletePollAnswer(PollAnswerId);
		}

		public List<PollAnswer> GetAllPollAnswer()
		{
			return _iPollAnswerRepository.GetAllPollAnswer();
		}

		public PollAnswer InsertPollAnswer(PollAnswer entity)
		{
			 return _iPollAnswerRepository.InsertPollAnswer(entity);
		}


	}
	
	
}
