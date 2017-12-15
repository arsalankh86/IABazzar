using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CouponStoreService : ICouponStoreService 
	{
		private ICouponStoreRepository _iCouponStoreRepository;
        
		public CouponStoreService(ICouponStoreRepository iCouponStoreRepository)
		{
			this._iCouponStoreRepository = iCouponStoreRepository;
		}
        
        public Dictionary<string, string> GetCouponStoreBasicSearchColumns()
        {
            
            return this._iCouponStoreRepository.GetCouponStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCouponStoreAdvanceSearchColumns()
        {
            
            return this._iCouponStoreRepository.GetCouponStoreAdvanceSearchColumns();
           
        }


		public CouponStore GetCouponStore(System.Int32 CouponId)
		{
			return _iCouponStoreRepository.GetCouponStore(CouponId);
		}

		public CouponStore UpdateCouponStore(CouponStore entity)
		{
			return _iCouponStoreRepository.UpdateCouponStore(entity);
		}

		public bool DeleteCouponStore(System.Int32 CouponId)
		{
			return _iCouponStoreRepository.DeleteCouponStore(CouponId);
		}

		public List<CouponStore> GetAllCouponStore()
		{
			return _iCouponStoreRepository.GetAllCouponStore();
		}

		public CouponStore InsertCouponStore(CouponStore entity)
		{
			 return _iCouponStoreRepository.InsertCouponStore(entity);
		}


	}
	
	
}
