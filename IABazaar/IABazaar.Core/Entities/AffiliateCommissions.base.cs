using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AffiliateCommissionsBase:EntityBase, IEquatable<AffiliateCommissionsBase>
	{
			
		public System.Guid RowGuid{ get; set; }

		public System.Decimal? LowValue{ get; set; }

		public System.Decimal? HighValue{ get; set; }

		public System.Decimal? Commission{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AffiliateCommissionsBase> Members

        public virtual bool Equals(AffiliateCommissionsBase other)
        {
			if(this.RowGuid==other.RowGuid  && this.LowValue==other.LowValue  && this.HighValue==other.HighValue  && this.Commission==other.Commission  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
