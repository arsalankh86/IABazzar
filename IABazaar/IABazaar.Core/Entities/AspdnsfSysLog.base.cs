using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AspdnsfSysLogBase:EntityBase, IEquatable<AspdnsfSysLogBase>
	{
			
		[PrimaryKey]
		public System.Int32 SysLogId{ get; set; }

		public System.Guid SysLogGuid{ get; set; }

		public System.String Message{ get; set; }

		public System.String Details{ get; set; }

		public System.String Type{ get; set; }

		public System.String Severity{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AspdnsfSysLogBase> Members

        public virtual bool Equals(AspdnsfSysLogBase other)
        {
			if(this.SysLogId==other.SysLogId  && this.SysLogGuid==other.SysLogGuid  && this.Message==other.Message  && this.Details==other.Details  && this.Type==other.Type  && this.Severity==other.Severity  && this.CreatedOn==other.CreatedOn )
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
