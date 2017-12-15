using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CurrencyBase:EntityBase, IEquatable<CurrencyBase>
	{
			
		[PrimaryKey]
		public System.Int32 CurrencyId{ get; set; }

		public System.Guid CurrencyGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String CurrencyCode{ get; set; }

		public System.Decimal? ExchangeRate{ get; set; }

		public System.Byte WasLiveRate{ get; set; }

		public System.String DisplayLocaleFormat{ get; set; }

		public System.String Symbol{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String DisplaySpec{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.DateTime LastUpdated{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CurrencyBase> Members

        public virtual bool Equals(CurrencyBase other)
        {
			if(this.CurrencyId==other.CurrencyId  && this.CurrencyGuid==other.CurrencyGuid  && this.Name==other.Name  && this.CurrencyCode==other.CurrencyCode  && this.ExchangeRate==other.ExchangeRate  && this.WasLiveRate==other.WasLiveRate  && this.DisplayLocaleFormat==other.DisplayLocaleFormat  && this.Symbol==other.Symbol  && this.ExtensionData==other.ExtensionData  && this.Published==other.Published  && this.DisplayOrder==other.DisplayOrder  && this.DisplaySpec==other.DisplaySpec  && this.CreatedOn==other.CreatedOn  && this.LastUpdated==other.LastUpdated )
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
