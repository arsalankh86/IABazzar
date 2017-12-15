using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductGenreBase:EntityBase, IEquatable<ProductGenreBase>
	{
			
		public System.Int32 ProductId{ get; set; }

		public System.Int32 GenreId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductGenreBase> Members

        public virtual bool Equals(ProductGenreBase other)
        {
			if(this.ProductId==other.ProductId  && this.GenreId==other.GenreId  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
