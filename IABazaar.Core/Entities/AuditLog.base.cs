using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AuditLogBase:EntityBase, IEquatable<AuditLogBase>
	{
			
		[PrimaryKey]
		public System.Int64 AuditLogId{ get; set; }

		public System.DateTime ActionDate{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 UpdatedCustomerId{ get; set; }

		public System.Int32 OrderNumber{ get; set; }

		public System.String Description{ get; set; }

		public System.String Details{ get; set; }

		public System.String PagePath{ get; set; }

		public System.String AuditGroup{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AuditLogBase> Members

        public virtual bool Equals(AuditLogBase other)
        {
			if(this.AuditLogId==other.AuditLogId  && this.ActionDate==other.ActionDate  && this.CustomerId==other.CustomerId  && this.UpdatedCustomerId==other.UpdatedCustomerId  && this.OrderNumber==other.OrderNumber  && this.Description==other.Description  && this.Details==other.Details  && this.PagePath==other.PagePath  && this.AuditGroup==other.AuditGroup )
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
