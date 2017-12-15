using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingByTotalBase:EntityBase, IEquatable<ShippingByTotalBase>
	{
			
		public System.Guid RowGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Decimal LowValue{ get; set; }

		public System.Decimal HighValue{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.Decimal ShippingCharge{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingByTotalBase> Members

        public virtual bool Equals(ShippingByTotalBase other)
        {
			if(this.RowGuid==other.RowGuid  && this.StoreId==other.StoreId  && this.LowValue==other.LowValue  && this.HighValue==other.HighValue  && this.ShippingMethodId==other.ShippingMethodId  && this.ShippingCharge==other.ShippingCharge  && this.CreatedOn==other.CreatedOn )
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
