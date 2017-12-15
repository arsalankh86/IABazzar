using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AffiliateStoreBase:EntityBase, IEquatable<AffiliateStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 AffiliateId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AffiliateStoreBase> Members

        public virtual bool Equals(AffiliateStoreBase other)
        {
			if(this.Id==other.Id  && this.AffiliateId==other.AffiliateId  && this.StoreId==other.StoreId  && this.CreatedOn==other.CreatedOn )
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
