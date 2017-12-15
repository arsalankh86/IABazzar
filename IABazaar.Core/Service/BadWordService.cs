using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class BadWordService : IBadWordService 
	{
		private IBadWordRepository _iBadWordRepository;
        
		public BadWordService(IBadWordRepository iBadWordRepository)
		{
			this._iBadWordRepository = iBadWordRepository;
		}
        
        public Dictionary<string, string> GetBadWordBasicSearchColumns()
        {
            
            return this._iBadWordRepository.GetBadWordBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetBadWordAdvanceSearchColumns()
        {
            
            return this._iBadWordRepository.GetBadWordAdvanceSearchColumns();
           
        }


		public BadWord GetBadWord(System.Int32 BadWordId)
		{
			return _iBadWordRepository.GetBadWord(BadWordId);
		}

		public BadWord UpdateBadWord(BadWord entity)
		{
			return _iBadWordRepository.UpdateBadWord(entity);
		}

		public bool DeleteBadWord(System.Int32 BadWordId)
		{
			return _iBadWordRepository.DeleteBadWord(BadWordId);
		}

		public List<BadWord> GetAllBadWord()
		{
			return _iBadWordRepository.GetAllBadWord();
		}

		public BadWord InsertBadWord(BadWord entity)
		{
			 return _iBadWordRepository.InsertBadWord(entity);
		}


	}
	
	
}
