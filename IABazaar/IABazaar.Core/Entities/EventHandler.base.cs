using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class EventHandlerBase:EntityBase, IEquatable<EventHandlerBase>
	{
			
		[PrimaryKey]
		public System.Int32 EventId{ get; set; }

		public System.String EventName{ get; set; }

		public System.String CalloutUrl{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Boolean Debug{ get; set; }

		public System.Boolean Active{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<EventHandlerBase> Members

        public virtual bool Equals(EventHandlerBase other)
        {
			if(this.EventId==other.EventId  && this.EventName==other.EventName  && this.CalloutUrl==other.CalloutUrl  && this.XmlPackage==other.XmlPackage  && this.Debug==other.Debug  && this.Active==other.Active )
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
