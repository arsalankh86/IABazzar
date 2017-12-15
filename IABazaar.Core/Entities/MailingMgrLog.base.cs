using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class MailingMgrLogBase:EntityBase, IEquatable<MailingMgrLogBase>
	{
			
		[PrimaryKey]
		public System.Int32 MailingMgrLogId{ get; set; }

		public System.Guid MailingMgrLogGuid{ get; set; }

		public System.DateTime SentOn{ get; set; }

		public System.String ToEmail{ get; set; }

		public System.String FromEmail{ get; set; }

		public System.String Subject{ get; set; }

		public System.String Body{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<MailingMgrLogBase> Members

        public virtual bool Equals(MailingMgrLogBase other)
        {
			if(this.MailingMgrLogId==other.MailingMgrLogId  && this.MailingMgrLogGuid==other.MailingMgrLogGuid  && this.SentOn==other.SentOn  && this.ToEmail==other.ToEmail  && this.FromEmail==other.FromEmail  && this.Subject==other.Subject  && this.Body==other.Body )
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
