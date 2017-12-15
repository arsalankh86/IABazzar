using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ClickTrackBase:EntityBase, IEquatable<ClickTrackBase>
	{
			
		[PrimaryKey]
		public System.Int32 ClickTrackId{ get; set; }

		public System.String Name{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ClickTrackBase> Members

        public virtual bool Equals(ClickTrackBase other)
        {
			if(this.ClickTrackId==other.ClickTrackId  && this.Name==other.Name  && this.CreatedOn==other.CreatedOn )
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
