using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductSectionBase:EntityBase, IEquatable<ProductSectionBase>
	{
			
		public System.Int32 ProductId{ get; set; }

		public System.Int32 SectionId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductSectionBase> Members

        public virtual bool Equals(ProductSectionBase other)
        {
			if(this.ProductId==other.ProductId  && this.SectionId==other.SectionId  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
