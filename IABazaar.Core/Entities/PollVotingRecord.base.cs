using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollVotingRecordBase:EntityBase, IEquatable<PollVotingRecordBase>
	{
			
		[PrimaryKey]
		public System.Int32 PollVotingRecordId{ get; set; }

		public System.Guid PollVotingRecordGuid{ get; set; }

		public System.Int32 PollId{ get; set; }

		public System.Int32 PollAnswerId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollVotingRecordBase> Members

        public virtual bool Equals(PollVotingRecordBase other)
        {
			if(this.PollVotingRecordId==other.PollVotingRecordId  && this.PollVotingRecordGuid==other.PollVotingRecordGuid  && this.PollId==other.PollId  && this.PollAnswerId==other.PollAnswerId  && this.CustomerId==other.CustomerId  && this.CreatedOn==other.CreatedOn )
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
