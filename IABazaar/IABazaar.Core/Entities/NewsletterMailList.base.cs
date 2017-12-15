using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class NewsletterMailListBase:EntityBase, IEquatable<NewsletterMailListBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Guid? Guid{ get; set; }

		public System.String EmailAddress{ get; set; }

		public System.String FirstName{ get; set; }

		public System.String LastName{ get; set; }

		public System.Boolean? SubscriptionConfirmed{ get; set; }

		public System.DateTime? AddedOn{ get; set; }

		public System.DateTime? SubscribedOn{ get; set; }

		public System.DateTime? UnsubscribedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<NewsletterMailListBase> Members

        public virtual bool Equals(NewsletterMailListBase other)
        {
			if(this.Id==other.Id  && this.Guid==other.Guid  && this.EmailAddress==other.EmailAddress  && this.FirstName==other.FirstName  && this.LastName==other.LastName  && this.SubscriptionConfirmed==other.SubscriptionConfirmed  && this.AddedOn==other.AddedOn  && this.SubscribedOn==other.SubscribedOn  && this.UnsubscribedOn==other.UnsubscribedOn )
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
