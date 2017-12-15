using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICouponUsageRepositoryBase
	{
        
        Dictionary<string, string> GetCouponUsageBasicSearchColumns();
        List<SearchColumn> GetCouponUsageSearchColumns();
        List<SearchColumn> GetCouponUsageAdvanceSearchColumns();
        

		CouponUsage GetCouponUsage(System.Int32 CouponUsageId);
		CouponUsage UpdateCouponUsage(CouponUsage entity);
		bool DeleteCouponUsage(System.Int32 CouponUsageId);
		CouponUsage DeleteCouponUsage(CouponUsage entity);
		List<CouponUsage> GetAllCouponUsage();
		CouponUsage InsertCouponUsage(CouponUsage entity);	}
	
	
}
