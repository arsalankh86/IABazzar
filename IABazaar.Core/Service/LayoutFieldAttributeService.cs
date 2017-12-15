using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LayoutFieldAttributeService : ILayoutFieldAttributeService 
	{
		private ILayoutFieldAttributeRepository _iLayoutFieldAttributeRepository;
        
		public LayoutFieldAttributeService(ILayoutFieldAttributeRepository iLayoutFieldAttributeRepository)
		{
			this._iLayoutFieldAttributeRepository = iLayoutFieldAttributeRepository;
		}
        
        public Dictionary<string, string> GetLayoutFieldAttributeBasicSearchColumns()
        {
            
            return this._iLayoutFieldAttributeRepository.GetLayoutFieldAttributeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLayoutFieldAttributeAdvanceSearchColumns()
        {
            
            return this._iLayoutFieldAttributeRepository.GetLayoutFieldAttributeAdvanceSearchColumns();
           
        }


		public LayoutFieldAttribute GetLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId)
		{
			return _iLayoutFieldAttributeRepository.GetLayoutFieldAttribute(LayoutFieldAttributeId);
		}

		public LayoutFieldAttribute UpdateLayoutFieldAttribute(LayoutFieldAttribute entity)
		{
			return _iLayoutFieldAttributeRepository.UpdateLayoutFieldAttribute(entity);
		}

		public bool DeleteLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId)
		{
			return _iLayoutFieldAttributeRepository.DeleteLayoutFieldAttribute(LayoutFieldAttributeId);
		}

		public List<LayoutFieldAttribute> GetAllLayoutFieldAttribute()
		{
			return _iLayoutFieldAttributeRepository.GetAllLayoutFieldAttribute();
		}

		public LayoutFieldAttribute InsertLayoutFieldAttribute(LayoutFieldAttribute entity)
		{
			 return _iLayoutFieldAttributeRepository.InsertLayoutFieldAttribute(entity);
		}


	}
	
	
}
