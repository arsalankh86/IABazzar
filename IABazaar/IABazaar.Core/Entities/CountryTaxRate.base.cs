using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CountryTaxRateBase:EntityBase, IEquatable<CountryTaxRateBase>
	{
			
		[PrimaryKey]
		public System.Int32 CountryTaxId{ get; set; }

		public System.Int32 CountryId{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Decimal? TaxRate{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CountryTaxRateBase> Members

        public virtual bool Equals(CountryTaxRateBase other)
        {
			if(this.CountryTaxId==other.CountryTaxId  && this.CountryId==other.CountryId  && this.TaxClassId==other.TaxClassId  && this.TaxRate==other.TaxRate  && this.CreatedOn==other.CreatedOn )
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
