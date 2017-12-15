using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SalesPromptService : ISalesPromptService 
	{
		private ISalesPromptRepository _iSalesPromptRepository;
        
		public SalesPromptService(ISalesPromptRepository iSalesPromptRepository)
		{
			this._iSalesPromptRepository = iSalesPromptRepository;
		}
        
        public Dictionary<string, string> GetSalesPromptBasicSearchColumns()
        {
            
            return this._iSalesPromptRepository.GetSalesPromptBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSalesPromptAdvanceSearchColumns()
        {
            
            return this._iSalesPromptRepository.GetSalesPromptAdvanceSearchColumns();
           
        }


		public SalesPrompt GetSalesPrompt(System.Int32 SalesPromptId)
		{
			return _iSalesPromptRepository.GetSalesPrompt(SalesPromptId);
		}

		public SalesPrompt UpdateSalesPrompt(SalesPrompt entity)
		{
			return _iSalesPromptRepository.UpdateSalesPrompt(entity);
		}

		public bool DeleteSalesPrompt(System.Int32 SalesPromptId)
		{
			return _iSalesPromptRepository.DeleteSalesPrompt(SalesPromptId);
		}

		public List<SalesPrompt> GetAllSalesPrompt()
		{
			return _iSalesPromptRepository.GetAllSalesPrompt();
		}

		public SalesPrompt InsertSalesPrompt(SalesPrompt entity)
		{
			 return _iSalesPromptRepository.InsertSalesPrompt(entity);
		}


	}
	
	
}
