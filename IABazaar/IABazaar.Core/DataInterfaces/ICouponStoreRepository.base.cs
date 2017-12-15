using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICouponStoreRepositoryBase
	{
        
        Dictionary<string, string> GetCouponStoreBasicSearchColumns();
        List<SearchColumn> GetCouponStoreSearchColumns();
        List<SearchColumn> GetCouponStoreAdvanceSearchColumns();
        

		CouponStore GetCouponStore(System.Int32 CouponId);
		CouponStore UpdateCouponStore(CouponStore entity);
		bool DeleteCouponStore(System.Int32 CouponId);
		CouponStore DeleteCouponStore(CouponStore entity);
		List<CouponStore> GetAllCouponStore();
		CouponStore InsertCouponStore(CouponStore entity);	}
	
	
}
