using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PasswordLogBase:EntityBase, IEquatable<PasswordLogBase>
	{
			
		public System.Int32 CustomerId{ get; set; }

		public System.DateTime ChangeDt{ get; set; }

		public System.String OldPwd{ get; set; }

		public System.Int32 SaltKey{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PasswordLogBase> Members

        public virtual bool Equals(PasswordLogBase other)
        {
			if(this.CustomerId==other.CustomerId  && this.ChangeDt==other.ChangeDt  && this.OldPwd==other.OldPwd  && this.SaltKey==other.SaltKey )
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
