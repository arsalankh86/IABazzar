using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISalesPromptRepositoryBase
	{
        
        Dictionary<string, string> GetSalesPromptBasicSearchColumns();
        List<SearchColumn> GetSalesPromptSearchColumns();
        List<SearchColumn> GetSalesPromptAdvanceSearchColumns();
        

		SalesPrompt GetSalesPrompt(System.Int32 SalesPromptId);
		SalesPrompt UpdateSalesPrompt(SalesPrompt entity);
		bool DeleteSalesPrompt(System.Int32 SalesPromptId);
		SalesPrompt DeleteSalesPrompt(SalesPrompt entity);
		List<SalesPrompt> GetAllSalesPrompt();
		SalesPrompt InsertSalesPrompt(SalesPrompt entity);	}
	
	
}
