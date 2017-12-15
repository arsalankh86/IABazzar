using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICouponService
	{
        Dictionary<string, string> GetCouponBasicSearchColumns();
        
        List<SearchColumn> GetCouponAdvanceSearchColumns();

		Coupon GetCoupon(System.Int32 CouponId);
		Coupon UpdateCoupon(Coupon entity);
		bool DeleteCoupon(System.Int32 CouponId);
		List<Coupon> GetAllCoupon();
		Coupon InsertCoupon(Coupon entity);

	}
	
	
}
