using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollCategoryService
	{
        Dictionary<string, string> GetPollCategoryBasicSearchColumns();
        
        List<SearchColumn> GetPollCategoryAdvanceSearchColumns();

		PollCategory GetPollCategory(System.Int32 PollId);
		PollCategory UpdatePollCategory(PollCategory entity);
		bool DeletePollCategory(System.Int32 PollId);
		List<PollCategory> GetAllPollCategory();
		PollCategory InsertPollCategory(PollCategory entity);

	}
	
	
}
