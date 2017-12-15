using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AffiliateActivityBase:EntityBase, IEquatable<AffiliateActivityBase>
	{
			
		[PrimaryKey]
		public System.Int32 AffiliateActivityId{ get; set; }

		public System.Guid AffiliateActivityGuid{ get; set; }

		public System.Int32 AffiliateId{ get; set; }

		public System.Int32 AffiliateActivityReasonId{ get; set; }

		public System.Decimal? Amount{ get; set; }

		public System.String CardId{ get; set; }

		public System.Int32? OrderNumber{ get; set; }

		public System.String Notes{ get; set; }

		public System.DateTime ActivityDate{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AffiliateActivityBase> Members

        public virtual bool Equals(AffiliateActivityBase other)
        {
			if(this.AffiliateActivityId==other.AffiliateActivityId  && this.AffiliateActivityGuid==other.AffiliateActivityGuid  && this.AffiliateId==other.AffiliateId  && this.AffiliateActivityReasonId==other.AffiliateActivityReasonId  && this.Amount==other.Amount  && this.CardId==other.CardId  && this.OrderNumber==other.OrderNumber  && this.Notes==other.Notes  && this.ActivityDate==other.ActivityDate  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
