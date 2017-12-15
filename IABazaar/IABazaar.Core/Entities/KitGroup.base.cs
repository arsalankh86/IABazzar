using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class KitGroupBase:EntityBase, IEquatable<KitGroupBase>
	{
			
		[PrimaryKey]
		public System.Int32 KitGroupId{ get; set; }

		public System.Guid KitGroupGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String Summary{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Int32 KitGroupTypeId{ get; set; }

		public System.Byte IsRequired{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Byte IsReadOnly{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<KitGroupBase> Members

        public virtual bool Equals(KitGroupBase other)
        {
			if(this.KitGroupId==other.KitGroupId  && this.KitGroupGuid==other.KitGroupGuid  && this.Name==other.Name  && this.Description==other.Description  && this.Summary==other.Summary  && this.ProductId==other.ProductId  && this.DisplayOrder==other.DisplayOrder  && this.KitGroupTypeId==other.KitGroupTypeId  && this.IsRequired==other.IsRequired  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn  && this.IsReadOnly==other.IsReadOnly )
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
