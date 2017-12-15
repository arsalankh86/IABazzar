using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class GiftCardUsageBase:EntityBase, IEquatable<GiftCardUsageBase>
	{
			
		[PrimaryKey]
		public System.Int32 GiftCardUsageId{ get; set; }

		public System.Guid GiftCardUsageGuid{ get; set; }

		public System.Int32 GiftCardId{ get; set; }

		public System.Int32 UsageTypeId{ get; set; }

		public System.Int32 UsedByCustomerId{ get; set; }

		public System.Int32 OrderNumber{ get; set; }

		public System.Decimal Amount{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<GiftCardUsageBase> Members

        public virtual bool Equals(GiftCardUsageBase other)
        {
			if(this.GiftCardUsageId==other.GiftCardUsageId  && this.GiftCardUsageGuid==other.GiftCardUsageGuid  && this.GiftCardId==other.GiftCardId  && this.UsageTypeId==other.UsageTypeId  && this.UsedByCustomerId==other.UsedByCustomerId  && this.OrderNumber==other.OrderNumber  && this.Amount==other.Amount  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
