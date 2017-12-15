using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class QuantityDiscountTableBase:EntityBase, IEquatable<QuantityDiscountTableBase>
	{
			
		[PrimaryKey]
		public System.Int32 QuantityDiscountTableId{ get; set; }

		public System.Guid? QuantityDiscountTableGuid{ get; set; }

		public System.Int32? QuantityDiscountId{ get; set; }

		public System.Int32 LowQuantity{ get; set; }

		public System.Int32 HighQuantity{ get; set; }

		public System.Decimal DiscountPercent{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<QuantityDiscountTableBase> Members

        public virtual bool Equals(QuantityDiscountTableBase other)
        {
			if(this.QuantityDiscountTableId==other.QuantityDiscountTableId  && this.QuantityDiscountTableGuid==other.QuantityDiscountTableGuid  && this.QuantityDiscountId==other.QuantityDiscountId  && this.LowQuantity==other.LowQuantity  && this.HighQuantity==other.HighQuantity  && this.DiscountPercent==other.DiscountPercent  && this.CreatedOn==other.CreatedOn )
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
