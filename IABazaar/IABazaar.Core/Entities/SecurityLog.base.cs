using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SecurityLogBase:EntityBase, IEquatable<SecurityLogBase>
	{
			
		[PrimaryKey]
		public System.Int64 Logid{ get; set; }

		public System.String SecurityAction{ get; set; }

		public System.String Description{ get; set; }

		public System.DateTime ActionDate{ get; set; }

		public System.Int32 CustomerUpdated{ get; set; }

		public System.Int32 UpdatedBy{ get; set; }

		public System.Int32 CustomerSessionId{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SecurityLogBase> Members

        public virtual bool Equals(SecurityLogBase other)
        {
			if(this.Logid==other.Logid  && this.SecurityAction==other.SecurityAction  && this.Description==other.Description  && this.ActionDate==other.ActionDate  && this.CustomerUpdated==other.CustomerUpdated  && this.UpdatedBy==other.UpdatedBy  && this.CustomerSessionId==other.CustomerSessionId )
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
