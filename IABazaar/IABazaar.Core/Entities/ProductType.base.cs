using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductTypeBase:EntityBase, IEquatable<ProductTypeBase>
	{
			
		[PrimaryKey]
		public System.Int32 ProductTypeId{ get; set; }

		public System.Guid ProductTypeGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductTypeBase> Members

        public virtual bool Equals(ProductTypeBase other)
        {
			if(this.ProductTypeId==other.ProductTypeId  && this.ProductTypeGuid==other.ProductTypeGuid  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.TaxClassId==other.TaxClassId  && this.CreatedOn==other.CreatedOn )
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
