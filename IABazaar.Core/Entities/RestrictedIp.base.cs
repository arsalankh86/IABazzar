using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class RestrictedIpBase:EntityBase, IEquatable<RestrictedIpBase>
	{
			
		public System.Int32 DbRecNo{ get; set; }

		public System.String IpAddress{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<RestrictedIpBase> Members

        public virtual bool Equals(RestrictedIpBase other)
        {
			if(this.DbRecNo==other.DbRecNo  && this.IpAddress==other.IpAddress  && this.CreatedOn==other.CreatedOn )
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
