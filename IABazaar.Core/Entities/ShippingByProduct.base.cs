using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingByProductBase:EntityBase, IEquatable<ShippingByProductBase>
	{
			
		[PrimaryKey]
		public System.Int32 ShippingByProductId{ get; set; }

		public System.Guid ShippingByProductGuid{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.Decimal ShippingCost{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingByProductBase> Members

        public virtual bool Equals(ShippingByProductBase other)
        {
			if(this.ShippingByProductId==other.ShippingByProductId  && this.ShippingByProductGuid==other.ShippingByProductGuid  && this.VariantId==other.VariantId  && this.ShippingMethodId==other.ShippingMethodId  && this.ShippingCost==other.ShippingCost  && this.CreatedOn==other.CreatedOn )
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
