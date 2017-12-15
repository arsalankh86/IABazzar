using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LayoutBase:EntityBase, IEquatable<LayoutBase>
	{
			
		[PrimaryKey]
		public System.Int32 LayoutId{ get; set; }

		public System.Guid LayoutGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String Html{ get; set; }

		public System.String Micro{ get; set; }

		public System.String Icon{ get; set; }

		public System.String Medium{ get; set; }

		public System.String Large{ get; set; }

		public System.Int32 Version{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.DateTime UpdatedOn{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LayoutBase> Members

        public virtual bool Equals(LayoutBase other)
        {
			if(this.LayoutId==other.LayoutId  && this.LayoutGuid==other.LayoutGuid  && this.Name==other.Name  && this.Description==other.Description  && this.Html==other.Html  && this.Micro==other.Micro  && this.Icon==other.Icon  && this.Medium==other.Medium  && this.Large==other.Large  && this.Version==other.Version  && this.CreatedOn==other.CreatedOn  && this.UpdatedOn==other.UpdatedOn  && this.DisplayOrder==other.DisplayOrder )
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
