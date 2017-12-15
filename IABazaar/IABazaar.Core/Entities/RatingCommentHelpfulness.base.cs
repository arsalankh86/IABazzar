using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class RatingCommentHelpfulnessBase:EntityBase, IEquatable<RatingCommentHelpfulnessBase>
	{
			
		public System.Int32 StoreId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 RatingCustomerId{ get; set; }

		public System.Int32 VotingCustomerId{ get; set; }

		public System.Byte Helpful{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<RatingCommentHelpfulnessBase> Members

        public virtual bool Equals(RatingCommentHelpfulnessBase other)
        {
			if(this.StoreId==other.StoreId  && this.ProductId==other.ProductId  && this.RatingCustomerId==other.RatingCustomerId  && this.VotingCustomerId==other.VotingCustomerId  && this.Helpful==other.Helpful  && this.CreatedOn==other.CreatedOn )
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
