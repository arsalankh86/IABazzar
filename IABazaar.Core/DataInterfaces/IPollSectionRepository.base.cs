using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPollSectionRepositoryBase
	{
        
        Dictionary<string, string> GetPollSectionBasicSearchColumns();
        List<SearchColumn> GetPollSectionSearchColumns();
        List<SearchColumn> GetPollSectionAdvanceSearchColumns();
        

		PollSection GetPollSection(System.Int32 PollId);
		PollSection UpdatePollSection(PollSection entity);
		bool DeletePollSection(System.Int32 PollId);
		PollSection DeletePollSection(PollSection entity);
		List<PollSection> GetAllPollSection();
		PollSection InsertPollSection(PollSection entity);	}
	
	
}
