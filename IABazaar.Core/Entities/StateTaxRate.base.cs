using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class StateTaxRateBase:EntityBase, IEquatable<StateTaxRateBase>
	{
			
		[PrimaryKey]
		public System.Int32 StateTaxId{ get; set; }

		public System.Int32 StateId{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Decimal? TaxRate{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<StateTaxRateBase> Members

        public virtual bool Equals(StateTaxRateBase other)
        {
			if(this.StateTaxId==other.StateTaxId  && this.StateId==other.StateId  && this.TaxClassId==other.TaxClassId  && this.TaxRate==other.TaxRate  && this.CreatedOn==other.CreatedOn )
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
