using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollSectionService
	{
        Dictionary<string, string> GetPollSectionBasicSearchColumns();
        
        List<SearchColumn> GetPollSectionAdvanceSearchColumns();

		PollSection GetPollSection(System.Int32 PollId);
		PollSection UpdatePollSection(PollSection entity);
		bool DeletePollSection(System.Int32 PollId);
		List<PollSection> GetAllPollSection();
		PollSection InsertPollSection(PollSection entity);

	}
	
	
}
