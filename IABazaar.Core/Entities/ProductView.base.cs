using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductViewBase:EntityBase, IEquatable<ProductViewBase>
	{
			
		[PrimaryKey]
		public System.Int32 ViewId{ get; set; }

		public System.String CustomerViewId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.DateTime ViewDate{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductViewBase> Members

        public virtual bool Equals(ProductViewBase other)
        {
			if(this.ViewId==other.ViewId  && this.CustomerViewId==other.CustomerViewId  && this.ProductId==other.ProductId  && this.ViewDate==other.ViewDate )
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
