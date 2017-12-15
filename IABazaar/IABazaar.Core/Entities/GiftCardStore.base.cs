using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class GiftCardStoreBase:EntityBase, IEquatable<GiftCardStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 GiftCardId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<GiftCardStoreBase> Members

        public virtual bool Equals(GiftCardStoreBase other)
        {
			if(this.Id==other.Id  && this.GiftCardId==other.GiftCardId  && this.StoreId==other.StoreId  && this.CreatedOn==other.CreatedOn )
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
