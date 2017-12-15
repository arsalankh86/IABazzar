using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollAnswerService
	{
        Dictionary<string, string> GetPollAnswerBasicSearchColumns();
        
        List<SearchColumn> GetPollAnswerAdvanceSearchColumns();

		PollAnswer GetPollAnswer(System.Int32 PollAnswerId);
		PollAnswer UpdatePollAnswer(PollAnswer entity);
		bool DeletePollAnswer(System.Int32 PollAnswerId);
		List<PollAnswer> GetAllPollAnswer();
		PollAnswer InsertPollAnswer(PollAnswer entity);

	}
	
	
}
