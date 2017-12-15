using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollSortOrderBase:EntityBase, IEquatable<PollSortOrderBase>
	{
			
		[PrimaryKey]
		public System.Int32 PollSortOrderId{ get; set; }

		public System.Guid PollSortOrderGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollSortOrderBase> Members

        public virtual bool Equals(PollSortOrderBase other)
        {
			if(this.PollSortOrderId==other.PollSortOrderId  && this.PollSortOrderGuid==other.PollSortOrderGuid  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
