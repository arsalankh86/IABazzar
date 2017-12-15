using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SkinPreviewBase:EntityBase, IEquatable<SkinPreviewBase>
	{
			
		[PrimaryKey]
		public System.Int32 SkinPreviewId{ get; set; }

		public System.Guid SkinPreviewGuid{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String Name{ get; set; }

		public System.String GroupName{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SkinPreviewBase> Members

        public virtual bool Equals(SkinPreviewBase other)
        {
			if(this.SkinPreviewId==other.SkinPreviewId  && this.SkinPreviewGuid==other.SkinPreviewGuid  && this.SkinId==other.SkinId  && this.Name==other.Name  && this.GroupName==other.GroupName  && this.CreatedOn==other.CreatedOn )
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
