using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SectionService : ISectionService 
	{
		private ISectionRepository _iSectionRepository;
        
		public SectionService(ISectionRepository iSectionRepository)
		{
			this._iSectionRepository = iSectionRepository;
		}
        
        public Dictionary<string, string> GetSectionBasicSearchColumns()
        {
            
            return this._iSectionRepository.GetSectionBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSectionAdvanceSearchColumns()
        {
            
            return this._iSectionRepository.GetSectionAdvanceSearchColumns();
           
        }


		public Section GetSection(System.Int32 SectionId)
		{
			return _iSectionRepository.GetSection(SectionId);
		}

		public Section UpdateSection(Section entity)
		{
			return _iSectionRepository.UpdateSection(entity);
		}

		public bool DeleteSection(System.Int32 SectionId)
		{
			return _iSectionRepository.DeleteSection(SectionId);
		}

		public List<Section> GetAllSection()
		{
			return _iSectionRepository.GetAllSection();
		}

		public Section InsertSection(Section entity)
		{
			 return _iSectionRepository.InsertSection(entity);
		}


	}
	
	
}
