using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class BadWordBase:EntityBase, IEquatable<BadWordBase>
	{
			
		[PrimaryKey]
		public System.Int32 BadWordId{ get; set; }

		public System.String LocaleSetting{ get; set; }

		public System.String Word{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<BadWordBase> Members

        public virtual bool Equals(BadWordBase other)
        {
			if(this.BadWordId==other.BadWordId  && this.LocaleSetting==other.LocaleSetting  && this.Word==other.Word  && this.CreatedOn==other.CreatedOn )
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
