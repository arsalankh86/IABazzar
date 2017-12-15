using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ZipTaxRateBase:EntityBase, IEquatable<ZipTaxRateBase>
	{
			
		[PrimaryKey]
		public System.Int32 ZipTaxId{ get; set; }

		public System.String ZipCode{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Decimal? TaxRate{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 CountryId{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ZipTaxRateBase> Members

        public virtual bool Equals(ZipTaxRateBase other)
        {
			if(this.ZipTaxId==other.ZipTaxId  && this.ZipCode==other.ZipCode  && this.TaxClassId==other.TaxClassId  && this.TaxRate==other.TaxRate  && this.CreatedOn==other.CreatedOn  && this.CountryId==other.CountryId )
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
