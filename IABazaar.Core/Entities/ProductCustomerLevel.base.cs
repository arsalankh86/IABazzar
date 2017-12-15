using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductCustomerLevelBase:EntityBase, IEquatable<ProductCustomerLevelBase>
	{
			
		public System.Int32 ProductId{ get; set; }

		public System.Int32 CustomerLevelId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductCustomerLevelBase> Members

        public virtual bool Equals(ProductCustomerLevelBase other)
        {
			if(this.ProductId==other.ProductId  && this.CustomerLevelId==other.CustomerLevelId  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
