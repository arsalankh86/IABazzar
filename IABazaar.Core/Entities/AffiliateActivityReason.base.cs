using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AffiliateActivityReasonBase:EntityBase, IEquatable<AffiliateActivityReasonBase>
	{
			
		[PrimaryKey]
		public System.Int32 AffiliateActivityReasonId{ get; set; }

		public System.Guid AffiliateActivityReasonGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AffiliateActivityReasonBase> Members

        public virtual bool Equals(AffiliateActivityReasonBase other)
        {
			if(this.AffiliateActivityReasonId==other.AffiliateActivityReasonId  && this.AffiliateActivityReasonGuid==other.AffiliateActivityReasonGuid  && this.Name==other.Name  && this.CreatedOn==other.CreatedOn )
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
