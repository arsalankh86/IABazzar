using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class KitGroupTypeService : IKitGroupTypeService 
	{
		private IKitGroupTypeRepository _iKitGroupTypeRepository;
        
		public KitGroupTypeService(IKitGroupTypeRepository iKitGroupTypeRepository)
		{
			this._iKitGroupTypeRepository = iKitGroupTypeRepository;
		}
        
        public Dictionary<string, string> GetKitGroupTypeBasicSearchColumns()
        {
            
            return this._iKitGroupTypeRepository.GetKitGroupTypeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetKitGroupTypeAdvanceSearchColumns()
        {
            
            return this._iKitGroupTypeRepository.GetKitGroupTypeAdvanceSearchColumns();
           
        }


		public KitGroupType GetKitGroupType(System.Int32 KitGroupTypeId)
		{
			return _iKitGroupTypeRepository.GetKitGroupType(KitGroupTypeId);
		}

		public KitGroupType UpdateKitGroupType(KitGroupType entity)
		{
			return _iKitGroupTypeRepository.UpdateKitGroupType(entity);
		}

		public bool DeleteKitGroupType(System.Int32 KitGroupTypeId)
		{
			return _iKitGroupTypeRepository.DeleteKitGroupType(KitGroupTypeId);
		}

		public List<KitGroupType> GetAllKitGroupType()
		{
			return _iKitGroupTypeRepository.GetAllKitGroupType();
		}

		public KitGroupType InsertKitGroupType(KitGroupType entity)
		{
			 return _iKitGroupTypeRepository.InsertKitGroupType(entity);
		}


	}
	
	
}
