using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICouponRepositoryBase
	{
        
        Dictionary<string, string> GetCouponBasicSearchColumns();
        List<SearchColumn> GetCouponSearchColumns();
        List<SearchColumn> GetCouponAdvanceSearchColumns();
        

		Coupon GetCoupon(System.Int32 CouponId);
		Coupon UpdateCoupon(Coupon entity);
		bool DeleteCoupon(System.Int32 CouponId);
		Coupon DeleteCoupon(Coupon entity);
		List<Coupon> GetAllCoupon();
		Coupon InsertCoupon(Coupon entity);	}
	
	
}
