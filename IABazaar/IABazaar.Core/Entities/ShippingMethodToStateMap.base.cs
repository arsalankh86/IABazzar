using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingMethodToStateMapBase:EntityBase, IEquatable<ShippingMethodToStateMapBase>
	{
			
		public System.Int32 ShippingMethodId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 StateId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingMethodToStateMapBase> Members

        public virtual bool Equals(ShippingMethodToStateMapBase other)
        {
			if(this.ShippingMethodId==other.ShippingMethodId  && this.StoreId==other.StoreId  && this.StateId==other.StateId  && this.CreatedOn==other.CreatedOn )
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
