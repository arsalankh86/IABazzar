using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LayoutFieldBase:EntityBase, IEquatable<LayoutFieldBase>
	{
			
		[PrimaryKey]
		public System.Int32 LayoutFieldId{ get; set; }

		public System.Guid LayoutFieldGuid{ get; set; }

		public System.Int32? LayoutId{ get; set; }

		public System.Int32? FieldType{ get; set; }

		public System.String FieldId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LayoutFieldBase> Members

        public virtual bool Equals(LayoutFieldBase other)
        {
			if(this.LayoutFieldId==other.LayoutFieldId  && this.LayoutFieldGuid==other.LayoutFieldGuid  && this.LayoutId==other.LayoutId  && this.FieldType==other.FieldType  && this.FieldId==other.FieldId  && this.CreatedOn==other.CreatedOn )
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
