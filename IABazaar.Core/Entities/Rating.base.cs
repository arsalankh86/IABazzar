using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class RatingBase:EntityBase, IEquatable<RatingBase>
	{
			
		[PrimaryKey]
		public System.Int32 RatingId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 Rating{ get; set; }

		public System.String Comments{ get; set; }

		public System.Byte HasComment{ get; set; }

		public System.Byte IsFilthy{ get; set; }

		public System.Byte IsRotd{ get; set; }

		public System.Int32 FoundHelpful{ get; set; }

		public System.Int32 FoundNotHelpful{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<RatingBase> Members

        public virtual bool Equals(RatingBase other)
        {
			if(this.RatingId==other.RatingId  && this.StoreId==other.StoreId  && this.ProductId==other.ProductId  && this.CustomerId==other.CustomerId  && this.Rating==other.Rating  && this.Comments==other.Comments  && this.HasComment==other.HasComment  && this.IsFilthy==other.IsFilthy  && this.IsRotd==other.IsRotd  && this.FoundHelpful==other.FoundHelpful  && this.FoundNotHelpful==other.FoundNotHelpful  && this.CreatedOn==other.CreatedOn )
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
