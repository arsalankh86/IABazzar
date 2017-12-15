using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class MobileDeviceBase:EntityBase, IEquatable<MobileDeviceBase>
	{
			
		[PrimaryKey]
		public System.Int32 MobileDeviceId{ get; set; }

		public System.String UserAgent{ get; set; }

		public System.String Name{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<MobileDeviceBase> Members

        public virtual bool Equals(MobileDeviceBase other)
        {
			if(this.MobileDeviceId==other.MobileDeviceId  && this.UserAgent==other.UserAgent  && this.Name==other.Name )
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
