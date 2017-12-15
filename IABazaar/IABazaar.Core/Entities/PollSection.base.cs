using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PollSectionBase:EntityBase, IEquatable<PollSectionBase>
	{
			
		public System.Int32 PollId{ get; set; }

		public System.Int32 SectionId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PollSectionBase> Members

        public virtual bool Equals(PollSectionBase other)
        {
			if(this.PollId==other.PollId  && this.SectionId==other.SectionId  && this.CreatedOn==other.CreatedOn )
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
