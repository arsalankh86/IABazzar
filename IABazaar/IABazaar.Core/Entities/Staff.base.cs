using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class StaffBase:EntityBase, IEquatable<StaffBase>
	{
			
		[PrimaryKey]
		public System.Int32 StaffId{ get; set; }

		public System.Guid StaffGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Title{ get; set; }

		public System.String Bio{ get; set; }

		public System.String Phone{ get; set; }

		public System.String Fax{ get; set; }

		public System.String Email{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<StaffBase> Members

        public virtual bool Equals(StaffBase other)
        {
			if(this.StaffId==other.StaffId  && this.StaffGuid==other.StaffGuid  && this.Name==other.Name  && this.Title==other.Title  && this.Bio==other.Bio  && this.Phone==other.Phone  && this.Fax==other.Fax  && this.Email==other.Email  && this.DisplayOrder==other.DisplayOrder  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
