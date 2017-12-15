using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CountryBase:EntityBase, IEquatable<CountryBase>
	{
			
		[PrimaryKey]
		public System.Int32 CountryId{ get; set; }

		public System.Guid CountryGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String TwoLetterIsoCode{ get; set; }

		public System.String ThreeLetterIsoCode{ get; set; }

		public System.String NumericIsoCode{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Byte PostalCodeRequired{ get; set; }

		public System.String PostalCodeRegex{ get; set; }

		public System.String PostalCodeExample{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CountryBase> Members

        public virtual bool Equals(CountryBase other)
        {
			if(this.CountryId==other.CountryId  && this.CountryGuid==other.CountryGuid  && this.Name==other.Name  && this.TwoLetterIsoCode==other.TwoLetterIsoCode  && this.ThreeLetterIsoCode==other.ThreeLetterIsoCode  && this.NumericIsoCode==other.NumericIsoCode  && this.Published==other.Published  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn  && this.PostalCodeRequired==other.PostalCodeRequired  && this.PostalCodeRegex==other.PostalCodeRegex  && this.PostalCodeExample==other.PostalCodeExample )
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
