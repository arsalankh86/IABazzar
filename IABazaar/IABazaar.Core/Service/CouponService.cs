using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CouponService : ICouponService 
	{
		private ICouponRepository _iCouponRepository;
        
		public CouponService(ICouponRepository iCouponRepository)
		{
			this._iCouponRepository = iCouponRepository;
		}
        
        public Dictionary<string, string> GetCouponBasicSearchColumns()
        {
            
            return this._iCouponRepository.GetCouponBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCouponAdvanceSearchColumns()
        {
            
            return this._iCouponRepository.GetCouponAdvanceSearchColumns();
           
        }


		public Coupon GetCoupon(System.Int32 CouponId)
		{
			return _iCouponRepository.GetCoupon(CouponId);
		}

		public Coupon UpdateCoupon(Coupon entity)
		{
			return _iCouponRepository.UpdateCoupon(entity);
		}

		public bool DeleteCoupon(System.Int32 CouponId)
		{
			return _iCouponRepository.DeleteCoupon(CouponId);
		}

		public List<Coupon> GetAllCoupon()
		{
			return _iCouponRepository.GetAllCoupon();
		}

		public Coupon InsertCoupon(Coupon entity)
		{
			 return _iCouponRepository.InsertCoupon(entity);
		}


	}
	
	
}
