using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class KitGroupService : IKitGroupService 
	{
		private IKitGroupRepository _iKitGroupRepository;
        
		public KitGroupService(IKitGroupRepository iKitGroupRepository)
		{
			this._iKitGroupRepository = iKitGroupRepository;
		}
        
        public Dictionary<string, string> GetKitGroupBasicSearchColumns()
        {
            
            return this._iKitGroupRepository.GetKitGroupBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetKitGroupAdvanceSearchColumns()
        {
            
            return this._iKitGroupRepository.GetKitGroupAdvanceSearchColumns();
           
        }


		public KitGroup GetKitGroup(System.Int32 KitGroupId)
		{
			return _iKitGroupRepository.GetKitGroup(KitGroupId);
		}

		public KitGroup UpdateKitGroup(KitGroup entity)
		{
			return _iKitGroupRepository.UpdateKitGroup(entity);
		}

		public bool DeleteKitGroup(System.Int32 KitGroupId)
		{
			return _iKitGroupRepository.DeleteKitGroup(KitGroupId);
		}

		public List<KitGroup> GetAllKitGroup()
		{
			return _iKitGroupRepository.GetAllKitGroup();
		}

		public KitGroup InsertKitGroup(KitGroup entity)
		{
			 return _iKitGroupRepository.InsertKitGroup(entity);
		}


	}
	
	
}
