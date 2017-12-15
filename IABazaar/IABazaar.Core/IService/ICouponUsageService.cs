using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICouponUsageService
	{
        Dictionary<string, string> GetCouponUsageBasicSearchColumns();
        
        List<SearchColumn> GetCouponUsageAdvanceSearchColumns();

		CouponUsage GetCouponUsage(System.Int32 CouponUsageId);
		CouponUsage UpdateCouponUsage(CouponUsage entity);
		bool DeleteCouponUsage(System.Int32 CouponUsageId);
		List<CouponUsage> GetAllCouponUsage();
		CouponUsage InsertCouponUsage(CouponUsage entity);

	}
	
	
}
