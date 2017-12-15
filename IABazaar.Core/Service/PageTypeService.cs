using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PageTypeService : IPageTypeService 
	{
		private IPageTypeRepository _iPageTypeRepository;
        
		public PageTypeService(IPageTypeRepository iPageTypeRepository)
		{
			this._iPageTypeRepository = iPageTypeRepository;
		}
        
        public Dictionary<string, string> GetPageTypeBasicSearchColumns()
        {
            
            return this._iPageTypeRepository.GetPageTypeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPageTypeAdvanceSearchColumns()
        {
            
            return this._iPageTypeRepository.GetPageTypeAdvanceSearchColumns();
           
        }


		public PageType GetPageType(System.Int32 PageTypeId)
		{
			return _iPageTypeRepository.GetPageType(PageTypeId);
		}

		public PageType UpdatePageType(PageType entity)
		{
			return _iPageTypeRepository.UpdatePageType(entity);
		}

		public bool DeletePageType(System.Int32 PageTypeId)
		{
			return _iPageTypeRepository.DeletePageType(PageTypeId);
		}

		public List<PageType> GetAllPageType()
		{
			return _iPageTypeRepository.GetAllPageType();
		}

		public PageType InsertPageType(PageType entity)
		{
			 return _iPageTypeRepository.InsertPageType(entity);
		}


	}
	
	
}
