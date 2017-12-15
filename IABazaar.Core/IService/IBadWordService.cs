using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IBadWordService
	{
        Dictionary<string, string> GetBadWordBasicSearchColumns();
        
        List<SearchColumn> GetBadWordAdvanceSearchColumns();

		BadWord GetBadWord(System.Int32 BadWordId);
		BadWord UpdateBadWord(BadWord entity);
		bool DeleteBadWord(System.Int32 BadWordId);
		List<BadWord> GetAllBadWord();
		BadWord InsertBadWord(BadWord entity);

	}
	
	
}
