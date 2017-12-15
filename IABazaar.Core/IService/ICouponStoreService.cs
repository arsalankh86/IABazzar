using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICouponStoreService
	{
        Dictionary<string, string> GetCouponStoreBasicSearchColumns();
        
        List<SearchColumn> GetCouponStoreAdvanceSearchColumns();

		CouponStore GetCouponStore(System.Int32 CouponId);
		CouponStore UpdateCouponStore(CouponStore entity);
		bool DeleteCouponStore(System.Int32 CouponId);
		List<CouponStore> GetAllCouponStore();
		CouponStore InsertCouponStore(CouponStore entity);

	}
	
	
}
