using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingCalculationBase:EntityBase, IEquatable<ShippingCalculationBase>
	{
			
		[PrimaryKey]
		public System.Int32 ShippingCalculationId{ get; set; }

		public System.Guid ShippingCalculationGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Byte Selected{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingCalculationBase> Members

        public virtual bool Equals(ShippingCalculationBase other)
        {
			if(this.ShippingCalculationId==other.ShippingCalculationId  && this.ShippingCalculationGuid==other.ShippingCalculationGuid  && this.Name==other.Name  && this.Selected==other.Selected  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
