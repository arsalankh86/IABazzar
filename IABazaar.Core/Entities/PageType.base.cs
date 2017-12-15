using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PageTypeBase:EntityBase, IEquatable<PageTypeBase>
	{
			
		[PrimaryKey]
		public System.Int32 PageTypeId{ get; set; }

		public System.Guid PageTypeGuid{ get; set; }

		public System.String PageTypeName{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PageTypeBase> Members

        public virtual bool Equals(PageTypeBase other)
        {
			if(this.PageTypeId==other.PageTypeId  && this.PageTypeGuid==other.PageTypeGuid  && this.PageTypeName==other.PageTypeName )
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
