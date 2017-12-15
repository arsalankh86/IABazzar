using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CouponUsageBase:EntityBase, IEquatable<CouponUsageBase>
	{
			
		[PrimaryKey]
		public System.Int32 CouponUsageId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.String CouponCode{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CouponUsageBase> Members

        public virtual bool Equals(CouponUsageBase other)
        {
			if(this.CouponUsageId==other.CouponUsageId  && this.CustomerId==other.CustomerId  && this.CouponCode==other.CouponCode  && this.CreatedOn==other.CreatedOn )
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
