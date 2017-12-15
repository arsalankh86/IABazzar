using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingMethodBase:EntityBase, IEquatable<ShippingMethodBase>
	{
			
		[PrimaryKey]
		public System.Int32 ShippingMethodId{ get; set; }

		public System.Guid ShippingMethodGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.String Name{ get; set; }

		public System.Decimal? FixedRate{ get; set; }

		public System.Decimal? FixedPercentOfTotal{ get; set; }

		public System.String ShipRushTemplate{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte IsRtShipping{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.String MappedPm{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingMethodBase> Members

        public virtual bool Equals(ShippingMethodBase other)
        {
			if(this.ShippingMethodId==other.ShippingMethodId  && this.ShippingMethodGuid==other.ShippingMethodGuid  && this.StoreId==other.StoreId  && this.Name==other.Name  && this.FixedRate==other.FixedRate  && this.FixedPercentOfTotal==other.FixedPercentOfTotal  && this.ShipRushTemplate==other.ShipRushTemplate  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.IsRtShipping==other.IsRtShipping  && this.CreatedOn==other.CreatedOn  && this.MappedPm==other.MappedPm )
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
