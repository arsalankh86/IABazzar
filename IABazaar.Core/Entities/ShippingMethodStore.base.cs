using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingMethodStoreBase:EntityBase, IEquatable<ShippingMethodStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.DateTime? CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingMethodStoreBase> Members

        public virtual bool Equals(ShippingMethodStoreBase other)
        {
			if(this.Id==other.Id  && this.StoreId==other.StoreId  && this.ShippingMethodId==other.ShippingMethodId  && this.CreatedOn==other.CreatedOn )
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
