using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LayoutMapBase:EntityBase, IEquatable<LayoutMapBase>
	{
			
		[PrimaryKey]
		public System.Int32 LayoutMapId{ get; set; }

		public System.Guid LayoutMapGuid{ get; set; }

		public System.Int32 LayoutId{ get; set; }

		public System.Int32 PageTypeId{ get; set; }

		public System.Int32 PageId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LayoutMapBase> Members

        public virtual bool Equals(LayoutMapBase other)
        {
			if(this.LayoutMapId==other.LayoutMapId  && this.LayoutMapGuid==other.LayoutMapGuid  && this.LayoutId==other.LayoutId  && this.PageTypeId==other.PageTypeId  && this.PageId==other.PageId  && this.CreatedOn==other.CreatedOn )
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
