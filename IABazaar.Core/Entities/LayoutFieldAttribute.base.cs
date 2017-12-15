using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LayoutFieldAttributeBase:EntityBase, IEquatable<LayoutFieldAttributeBase>
	{
			
		[PrimaryKey]
		public System.Int32 LayoutFieldAttributeId{ get; set; }

		public System.Guid LayoutFieldAttributeGuid{ get; set; }

		public System.Int32 LayoutId{ get; set; }

		public System.Int32 LayoutFieldId{ get; set; }

		public System.String Name{ get; set; }

		public System.String Value{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LayoutFieldAttributeBase> Members

        public virtual bool Equals(LayoutFieldAttributeBase other)
        {
			if(this.LayoutFieldAttributeId==other.LayoutFieldAttributeId  && this.LayoutFieldAttributeGuid==other.LayoutFieldAttributeGuid  && this.LayoutId==other.LayoutId  && this.LayoutFieldId==other.LayoutFieldId  && this.Name==other.Name  && this.Value==other.Value )
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
