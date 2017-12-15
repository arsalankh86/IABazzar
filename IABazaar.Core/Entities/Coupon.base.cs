using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CouponBase:EntityBase, IEquatable<CouponBase>
	{
			
		[PrimaryKey]
		public System.Int32 CouponId{ get; set; }

		public System.Guid CouponGuid{ get; set; }

		public System.String CouponCode{ get; set; }

		public System.String Description{ get; set; }

		public System.DateTime StartDate{ get; set; }

		public System.DateTime ExpirationDate{ get; set; }

		public System.Decimal DiscountPercent{ get; set; }

		public System.Decimal DiscountAmount{ get; set; }

		public System.Byte DiscountIncludesFreeShipping{ get; set; }

		public System.Byte ExpiresOnFirstUseByAnyCustomer{ get; set; }

		public System.Byte ExpiresAfterOneUsageByEachCustomer{ get; set; }

		public System.Int32? ExpiresAfterNuses{ get; set; }

		public System.Decimal? RequiresMinimumOrderAmount{ get; set; }

		public System.String ValidForCustomers{ get; set; }

		public System.String ValidForProducts{ get; set; }

		public System.String ValidForManufacturers{ get; set; }

		public System.String ValidForCategories{ get; set; }

		public System.String ValidForSections{ get; set; }

		public System.Int32 CouponType{ get; set; }

		public System.Int32 NumUses{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CouponBase> Members

        public virtual bool Equals(CouponBase other)
        {
			if(this.CouponId==other.CouponId  && this.CouponGuid==other.CouponGuid  && this.CouponCode==other.CouponCode  && this.Description==other.Description  && this.StartDate==other.StartDate  && this.ExpirationDate==other.ExpirationDate  && this.DiscountPercent==other.DiscountPercent  && this.DiscountAmount==other.DiscountAmount  && this.DiscountIncludesFreeShipping==other.DiscountIncludesFreeShipping  && this.ExpiresOnFirstUseByAnyCustomer==other.ExpiresOnFirstUseByAnyCustomer  && this.ExpiresAfterOneUsageByEachCustomer==other.ExpiresAfterOneUsageByEachCustomer  && this.ExpiresAfterNuses==other.ExpiresAfterNuses  && this.RequiresMinimumOrderAmount==other.RequiresMinimumOrderAmount  && this.ValidForCustomers==other.ValidForCustomers  && this.ValidForProducts==other.ValidForProducts  && this.ValidForManufacturers==other.ValidForManufacturers  && this.ValidForCategories==other.ValidForCategories  && this.ValidForSections==other.ValidForSections  && this.CouponType==other.CouponType  && this.NumUses==other.NumUses  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
			{
				return true;
			}
			else
			{
				return false;
			}
		
		}

        #endregion
		
		
		
	}
	
	
}
