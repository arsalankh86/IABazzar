using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ErrorLogBase:EntityBase, IEquatable<ErrorLogBase>
	{
			
		[PrimaryKey]
		public System.Int32 Logid{ get; set; }

		public System.DateTime ErrorDt{ get; set; }

		public System.String Source{ get; set; }

		public System.String Errormsg{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ErrorLogBase> Members

        public virtual bool Equals(ErrorLogBase other)
        {
			if(this.Logid==other.Logid  && this.ErrorDt==other.ErrorDt  && this.Source==other.Source  && this.Errormsg==other.Errormsg )
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
