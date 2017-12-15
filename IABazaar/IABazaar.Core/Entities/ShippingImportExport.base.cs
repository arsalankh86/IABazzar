using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingImportExportBase:EntityBase, IEquatable<ShippingImportExportBase>
	{
			
		public System.Int32 OrderNumber{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.String CompanyName{ get; set; }

		public System.String CustomerLastName{ get; set; }

		public System.String CustomerFirstName{ get; set; }

		public System.String CustomerPhone{ get; set; }

		public System.String CustomerEmail{ get; set; }

		public System.String Address1{ get; set; }

		public System.String Address2{ get; set; }

		public System.String Suite{ get; set; }

		public System.String City{ get; set; }

		public System.String State{ get; set; }

		public System.String Zip{ get; set; }

		public System.String Country{ get; set; }

		public System.String ServiceCarrierCode{ get; set; }

		public System.String TrackingNumber{ get; set; }

		public System.Decimal? Cost{ get; set; }

		public System.Decimal? Weight{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingImportExportBase> Members

        public virtual bool Equals(ShippingImportExportBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.CustomerId==other.CustomerId  && this.StoreId==other.StoreId  && this.CompanyName==other.CompanyName  && this.CustomerLastName==other.CustomerLastName  && this.CustomerFirstName==other.CustomerFirstName  && this.CustomerPhone==other.CustomerPhone  && this.CustomerEmail==other.CustomerEmail  && this.Address1==other.Address1  && this.Address2==other.Address2  && this.Suite==other.Suite  && this.City==other.City  && this.State==other.State  && this.Zip==other.Zip  && this.Country==other.Country  && this.ServiceCarrierCode==other.ServiceCarrierCode  && this.TrackingNumber==other.TrackingNumber  && this.Cost==other.Cost  && this.Weight==other.Weight )
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
