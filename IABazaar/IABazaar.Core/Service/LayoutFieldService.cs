using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LayoutFieldService : ILayoutFieldService 
	{
		private ILayoutFieldRepository _iLayoutFieldRepository;
        
		public LayoutFieldService(ILayoutFieldRepository iLayoutFieldRepository)
		{
			this._iLayoutFieldRepository = iLayoutFieldRepository;
		}
        
        public Dictionary<string, string> GetLayoutFieldBasicSearchColumns()
        {
            
            return this._iLayoutFieldRepository.GetLayoutFieldBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLayoutFieldAdvanceSearchColumns()
        {
            
            return this._iLayoutFieldRepository.GetLayoutFieldAdvanceSearchColumns();
           
        }


		public LayoutField GetLayoutField(System.Int32 LayoutFieldId)
		{
			return _iLayoutFieldRepository.GetLayoutField(LayoutFieldId);
		}

		public LayoutField UpdateLayoutField(LayoutField entity)
		{
			return _iLayoutFieldRepository.UpdateLayoutField(entity);
		}

		public bool DeleteLayoutField(System.Int32 LayoutFieldId)
		{
			return _iLayoutFieldRepository.DeleteLayoutField(LayoutFieldId);
		}

		public List<LayoutField> GetAllLayoutField()
		{
			return _iLayoutFieldRepository.GetAllLayoutField();
		}

		public LayoutField InsertLayoutField(LayoutField entity)
		{
			 return _iLayoutFieldRepository.InsertLayoutField(entity);
		}


	}
	
	
}
