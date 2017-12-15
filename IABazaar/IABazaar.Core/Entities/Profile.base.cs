using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProfileBase:EntityBase, IEquatable<ProfileBase>
	{
			
		public System.Int32? StoreId{ get; set; }

		[PrimaryKey]
		public System.Int32 ProfileId{ get; set; }

		public System.Int32? CustomerId{ get; set; }

		public System.String PropertyName{ get; set; }

		public System.Guid? CustomerGuid{ get; set; }

		public System.String PropertyValueString{ get; set; }

		public System.DateTime? UpdatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProfileBase> Members

        public virtual bool Equals(ProfileBase other)
        {
			if(this.StoreId==other.StoreId  && this.ProfileId==other.ProfileId  && this.CustomerId==other.CustomerId  && this.PropertyName==other.PropertyName  && this.CustomerGuid==other.CustomerGuid  && this.PropertyValueString==other.PropertyValueString  && this.UpdatedOn==other.UpdatedOn )
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
