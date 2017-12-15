using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomerGiftRegistrySearchesBase:EntityBase, IEquatable<CustomerGiftRegistrySearchesBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomerGiftRegistrySearchesId{ get; set; }

		public System.Guid CustomerGiftRegistrySearchesGuid{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Guid GiftRegistryGuid{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomerGiftRegistrySearchesBase> Members

        public virtual bool Equals(CustomerGiftRegistrySearchesBase other)
        {
			if(this.CustomerGiftRegistrySearchesId==other.CustomerGiftRegistrySearchesId  && this.CustomerGiftRegistrySearchesGuid==other.CustomerGiftRegistrySearchesGuid  && this.CustomerId==other.CustomerId  && this.GiftRegistryGuid==other.GiftRegistryGuid  && this.CreatedOn==other.CreatedOn )
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
