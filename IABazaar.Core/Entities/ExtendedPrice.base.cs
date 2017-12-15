using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ExtendedPriceBase:EntityBase, IEquatable<ExtendedPriceBase>
	{
			
		[PrimaryKey]
		public System.Int32 ExtendedPriceId{ get; set; }

		public System.Guid ExtendedPriceGuid{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Int32 CustomerLevelId{ get; set; }

		public System.Decimal Price{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ExtendedPriceBase> Members

        public virtual bool Equals(ExtendedPriceBase other)
        {
			if(this.ExtendedPriceId==other.ExtendedPriceId  && this.ExtendedPriceGuid==other.ExtendedPriceGuid  && this.VariantId==other.VariantId  && this.CustomerLevelId==other.CustomerLevelId  && this.Price==other.Price  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
