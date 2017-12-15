using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingByTotalByPercentBase:EntityBase, IEquatable<ShippingByTotalByPercentBase>
	{
			
		public System.Guid RowGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Decimal LowValue{ get; set; }

		public System.Decimal HighValue{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.Decimal MinimumCharge{ get; set; }

		public System.Decimal SurCharge{ get; set; }

		public System.Decimal PercentOfTotal{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingByTotalByPercentBase> Members

        public virtual bool Equals(ShippingByTotalByPercentBase other)
        {
			if(this.RowGuid==other.RowGuid  && this.StoreId==other.StoreId  && this.LowValue==other.LowValue  && this.HighValue==other.HighValue  && this.ShippingMethodId==other.ShippingMethodId  && this.MinimumCharge==other.MinimumCharge  && this.SurCharge==other.SurCharge  && this.PercentOfTotal==other.PercentOfTotal  && this.CreatedOn==other.CreatedOn )
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
