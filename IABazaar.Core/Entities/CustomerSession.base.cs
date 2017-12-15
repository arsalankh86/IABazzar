using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomerSessionBase:EntityBase, IEquatable<CustomerSessionBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomerSessionId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.String SessionName{ get; set; }

		public System.String SessionValue{ get; set; }

		public System.String Ipaddr{ get; set; }

		public System.DateTime LastActivity{ get; set; }

		public System.DateTime? LoggedOut{ get; set; }

		public System.Guid CustomerSessionGuid{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.DateTime ExpiresOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomerSessionBase> Members

        public virtual bool Equals(CustomerSessionBase other)
        {
			if(this.CustomerSessionId==other.CustomerSessionId  && this.CustomerId==other.CustomerId  && this.SessionName==other.SessionName  && this.SessionValue==other.SessionValue  && this.Ipaddr==other.Ipaddr  && this.LastActivity==other.LastActivity  && this.LoggedOut==other.LoggedOut  && this.CustomerSessionGuid==other.CustomerSessionGuid  && this.CreatedOn==other.CreatedOn  && this.ExpiresOn==other.ExpiresOn )
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
