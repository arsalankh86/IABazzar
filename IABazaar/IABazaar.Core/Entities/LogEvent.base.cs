using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LogEventBase:EntityBase, IEquatable<LogEventBase>
	{
			
		[PrimaryKey]
		public System.Int32 EventId{ get; set; }

		public System.String Name{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LogEventBase> Members

        public virtual bool Equals(LogEventBase other)
        {
			if(this.EventId==other.EventId  && this.Name==other.Name  && this.CreatedOn==other.CreatedOn )
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
