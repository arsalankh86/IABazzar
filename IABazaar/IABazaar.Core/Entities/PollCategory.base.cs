using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollCategoryBase:EntityBase, IEquatable<PollCategoryBase>
	{
			
		public System.Int32 PollId{ get; set; }

		public System.Int32 CategoryId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollCategoryBase> Members

        public virtual bool Equals(PollCategoryBase other)
        {
			if(this.PollId==other.PollId  && this.CategoryId==other.CategoryId  && this.CreatedOn==other.CreatedOn )
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
