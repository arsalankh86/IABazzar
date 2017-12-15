using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class KitGroupTypeBase:EntityBase, IEquatable<KitGroupTypeBase>
	{
			
		[PrimaryKey]
		public System.Int32 KitGroupTypeId{ get; set; }

		public System.Guid KitGroupTypeGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<KitGroupTypeBase> Members

        public virtual bool Equals(KitGroupTypeBase other)
        {
			if(this.KitGroupTypeId==other.KitGroupTypeId  && this.KitGroupTypeGuid==other.KitGroupTypeGuid  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
