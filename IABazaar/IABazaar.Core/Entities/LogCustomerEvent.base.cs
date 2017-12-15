using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LogCustomerEventBase:EntityBase, IEquatable<LogCustomerEventBase>
	{
			
		[PrimaryKey]
		public System.Int32 DbRecNo{ get; set; }

		public System.Int32? CustomerId{ get; set; }

		public System.Int32? EventId{ get; set; }

		public System.DateTime? Timestamp{ get; set; }

		public System.String Data{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LogCustomerEventBase> Members

        public virtual bool Equals(LogCustomerEventBase other)
        {
			if(this.DbRecNo==other.DbRecNo  && this.CustomerId==other.CustomerId  && this.EventId==other.EventId  && this.Timestamp==other.Timestamp  && this.Data==other.Data )
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
