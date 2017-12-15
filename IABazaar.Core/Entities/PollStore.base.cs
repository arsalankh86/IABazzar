using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollStoreBase:EntityBase, IEquatable<PollStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 PollId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollStoreBase> Members

        public virtual bool Equals(PollStoreBase other)
        {
			if(this.Id==other.Id  && this.PollId==other.PollId  && this.StoreId==other.StoreId  && this.CreatedOn==other.CreatedOn )
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
