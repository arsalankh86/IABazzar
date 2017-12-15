using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IBadWordRepositoryBase
	{
        
        Dictionary<string, string> GetBadWordBasicSearchColumns();
        List<SearchColumn> GetBadWordSearchColumns();
        List<SearchColumn> GetBadWordAdvanceSearchColumns();
        

		BadWord GetBadWord(System.Int32 BadWordId);
		BadWord UpdateBadWord(BadWord entity);
		bool DeleteBadWord(System.Int32 BadWordId);
		BadWord DeleteBadWord(BadWord entity);
		List<BadWord> GetAllBadWord();
		BadWord InsertBadWord(BadWord entity);	}
	
	
}
