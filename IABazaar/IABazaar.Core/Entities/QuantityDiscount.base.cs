using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class QuantityDiscountBase:EntityBase, IEquatable<QuantityDiscountBase>
	{
			
		[PrimaryKey]
		public System.Int32 QuantityDiscountId{ get; set; }

		public System.Guid QuantityDiscountGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte DiscountType{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<QuantityDiscountBase> Members

        public virtual bool Equals(QuantityDiscountBase other)
        {
			if(this.QuantityDiscountId==other.QuantityDiscountId  && this.QuantityDiscountGuid==other.QuantityDiscountGuid  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.DiscountType==other.DiscountType  && this.CreatedOn==other.CreatedOn )
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
