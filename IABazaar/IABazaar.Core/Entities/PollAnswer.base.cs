using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollAnswerBase:EntityBase, IEquatable<PollAnswerBase>
	{
			
		[PrimaryKey]
		public System.Int32 PollAnswerId{ get; set; }

		public System.Guid PollAnswerGuid{ get; set; }

		public System.Int32 PollId{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollAnswerBase> Members

        public virtual bool Equals(PollAnswerBase other)
        {
			if(this.PollAnswerId==other.PollAnswerId  && this.PollAnswerGuid==other.PollAnswerGuid  && this.PollId==other.PollId  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
