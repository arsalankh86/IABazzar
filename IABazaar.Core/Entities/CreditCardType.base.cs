using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CreditCardTypeBase:EntityBase, IEquatable<CreditCardTypeBase>
	{
			
		[PrimaryKey]
		public System.Int32 CardTypeId{ get; set; }

		public System.Guid CardTypeGuid{ get; set; }

		public System.String CardType{ get; set; }

		public System.Byte Accepted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CreditCardTypeBase> Members

        public virtual bool Equals(CreditCardTypeBase other)
        {
			if(this.CardTypeId==other.CardTypeId  && this.CardTypeGuid==other.CardTypeGuid  && this.CardType==other.CardType  && this.Accepted==other.Accepted  && this.CreatedOn==other.CreatedOn )
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
