using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingCalculationStoreBase:EntityBase, IEquatable<ShippingCalculationStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 ShippingCalculationId{ get; set; }

		public System.DateTime? CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingCalculationStoreBase> Members

        public virtual bool Equals(ShippingCalculationStoreBase other)
        {
			if(this.Id==other.Id  && this.StoreId==other.StoreId  && this.ShippingCalculationId==other.ShippingCalculationId  && this.CreatedOn==other.CreatedOn )
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
