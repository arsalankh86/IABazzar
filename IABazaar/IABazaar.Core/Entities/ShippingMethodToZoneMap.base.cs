using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingMethodToZoneMapBase:EntityBase, IEquatable<ShippingMethodToZoneMapBase>
	{
			
		public System.Int32 ShippingMethodId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 ShippingZoneId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingMethodToZoneMapBase> Members

        public virtual bool Equals(ShippingMethodToZoneMapBase other)
        {
			if(this.ShippingMethodId==other.ShippingMethodId  && this.StoreId==other.StoreId  && this.ShippingZoneId==other.ShippingZoneId  && this.CreatedOn==other.CreatedOn )
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
