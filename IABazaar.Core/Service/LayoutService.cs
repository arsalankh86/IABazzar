using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LayoutService : ILayoutService 
	{
		private ILayoutRepository _iLayoutRepository;
        
		public LayoutService(ILayoutRepository iLayoutRepository)
		{
			this._iLayoutRepository = iLayoutRepository;
		}
        
        public Dictionary<string, string> GetLayoutBasicSearchColumns()
        {
            
            return this._iLayoutRepository.GetLayoutBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLayoutAdvanceSearchColumns()
        {
            
            return this._iLayoutRepository.GetLayoutAdvanceSearchColumns();
           
        }


		public Layout GetLayout(System.Int32 LayoutId)
		{
			return _iLayoutRepository.GetLayout(LayoutId);
		}

		public Layout UpdateLayout(Layout entity)
		{
			return _iLayoutRepository.UpdateLayout(entity);
		}

		public bool DeleteLayout(System.Int32 LayoutId)
		{
			return _iLayoutRepository.DeleteLayout(LayoutId);
		}

		public List<Layout> GetAllLayout()
		{
			return _iLayoutRepository.GetAllLayout();
		}

		public Layout InsertLayout(Layout entity)
		{
			 return _iLayoutRepository.InsertLayout(entity);
		}


	}
	
	
}
