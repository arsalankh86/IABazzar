using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPollCategoryRepositoryBase
	{
        
        Dictionary<string, string> GetPollCategoryBasicSearchColumns();
        List<SearchColumn> GetPollCategorySearchColumns();
        List<SearchColumn> GetPollCategoryAdvanceSearchColumns();
        

		PollCategory GetPollCategory(System.Int32 PollId);
		PollCategory UpdatePollCategory(PollCategory entity);
		bool DeletePollCategory(System.Int32 PollId);
		PollCategory DeletePollCategory(PollCategory entity);
		List<PollCategory> GetAllPollCategory();
		PollCategory InsertPollCategory(PollCategory entity);	}
	
	
}
