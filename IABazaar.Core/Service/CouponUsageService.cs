using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CouponUsageService : ICouponUsageService 
	{
		private ICouponUsageRepository _iCouponUsageRepository;
        
		public CouponUsageService(ICouponUsageRepository iCouponUsageRepository)
		{
			this._iCouponUsageRepository = iCouponUsageRepository;
		}
        
        public Dictionary<string, string> GetCouponUsageBasicSearchColumns()
        {
            
            return this._iCouponUsageRepository.GetCouponUsageBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCouponUsageAdvanceSearchColumns()
        {
            
            return this._iCouponUsageRepository.GetCouponUsageAdvanceSearchColumns();
           
        }


		public CouponUsage GetCouponUsage(System.Int32 CouponUsageId)
		{
			return _iCouponUsageRepository.GetCouponUsage(CouponUsageId);
		}

		public CouponUsage UpdateCouponUsage(CouponUsage entity)
		{
			return _iCouponUsageRepository.UpdateCouponUsage(entity);
		}

		public bool DeleteCouponUsage(System.Int32 CouponUsageId)
		{
			return _iCouponUsageRepository.DeleteCouponUsage(CouponUsageId);
		}

		public List<CouponUsage> GetAllCouponUsage()
		{
			return _iCouponUsageRepository.GetAllCouponUsage();
		}

		public CouponUsage InsertCouponUsage(CouponUsage entity)
		{
			 return _iCouponUsageRepository.InsertCouponUsage(entity);
		}


	}
	
	
}
