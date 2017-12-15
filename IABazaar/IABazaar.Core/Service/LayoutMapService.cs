using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LayoutMapService : ILayoutMapService 
	{
		private ILayoutMapRepository _iLayoutMapRepository;
        
		public LayoutMapService(ILayoutMapRepository iLayoutMapRepository)
		{
			this._iLayoutMapRepository = iLayoutMapRepository;
		}
        
        public Dictionary<string, string> GetLayoutMapBasicSearchColumns()
        {
            
            return this._iLayoutMapRepository.GetLayoutMapBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLayoutMapAdvanceSearchColumns()
        {
            
            return this._iLayoutMapRepository.GetLayoutMapAdvanceSearchColumns();
           
        }


		public LayoutMap GetLayoutMap(System.Int32 LayoutMapId)
		{
			return _iLayoutMapRepository.GetLayoutMap(LayoutMapId);
		}

		public LayoutMap UpdateLayoutMap(LayoutMap entity)
		{
			return _iLayoutMapRepository.UpdateLayoutMap(entity);
		}

		public bool DeleteLayoutMap(System.Int32 LayoutMapId)
		{
			return _iLayoutMapRepository.DeleteLayoutMap(LayoutMapId);
		}

		public List<LayoutMap> GetAllLayoutMap()
		{
			return _iLayoutMapRepository.GetAllLayoutMap();
		}

		public LayoutMap InsertLayoutMap(LayoutMap entity)
		{
			 return _iLayoutMapRepository.InsertLayoutMap(entity);
		}


	}
	
	
}
