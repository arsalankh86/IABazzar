using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingTotalByZoneBase:EntityBase, IEquatable<ShippingTotalByZoneBase>
	{
			
		public System.Guid RowGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.Decimal LowValue{ get; set; }

		public System.Decimal HighValue{ get; set; }

		public System.Int32 ShippingZoneId{ get; set; }

		public System.Decimal ShippingCharge{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingTotalByZoneBase> Members

        public virtual bool Equals(ShippingTotalByZoneBase other)
        {
			if(this.RowGuid==other.RowGuid  && this.StoreId==other.StoreId  && this.ShippingMethodId==other.ShippingMethodId  && this.LowValue==other.LowValue  && this.HighValue==other.HighValue  && this.ShippingZoneId==other.ShippingZoneId  && this.ShippingCharge==other.ShippingCharge  && this.CreatedOn==other.CreatedOn )
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
