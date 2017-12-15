using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollBase:EntityBase, IEquatable<PollBase>
	{
			
		[PrimaryKey]
		public System.Int32 PollId{ get; set; }

		public System.Guid PollGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 PollSortOrderId{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.Byte AnonsCanVote{ get; set; }

		public System.DateTime ExpiresOn{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollBase> Members

        public virtual bool Equals(PollBase other)
        {
			if(this.PollId==other.PollId  && this.PollGuid==other.PollGuid  && this.Name==other.Name  && this.PollSortOrderId==other.PollSortOrderId  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.DisplayOrder==other.DisplayOrder  && this.Deleted==other.Deleted  && this.AnonsCanVote==other.AnonsCanVote  && this.ExpiresOn==other.ExpiresOn  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
