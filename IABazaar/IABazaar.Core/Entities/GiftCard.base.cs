using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class GiftCardBase:EntityBase, IEquatable<GiftCardBase>
	{
			
		[PrimaryKey]
		public System.Int32 GiftCardId{ get; set; }

		public System.Guid GiftCardGuid{ get; set; }

		public System.String SerialNumber{ get; set; }

		public System.Int32 PurchasedByCustomerId{ get; set; }

		public System.Int32 OrderNumber{ get; set; }

		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Decimal InitialAmount{ get; set; }

		public System.Decimal Balance{ get; set; }

		public System.DateTime StartDate{ get; set; }

		public System.DateTime ExpirationDate{ get; set; }

		public System.Int32? GiftCardTypeId{ get; set; }

		public System.String EmailName{ get; set; }

		public System.String EmailTo{ get; set; }

		public System.String EmailMessage{ get; set; }

		public System.String ValidForCustomers{ get; set; }

		public System.String ValidForProducts{ get; set; }

		public System.String ValidForManufacturers{ get; set; }

		public System.String ValidForCategories{ get; set; }

		public System.String ValidForSections{ get; set; }

		public System.Byte DisabledByAdministrator{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<GiftCardBase> Members

        public virtual bool Equals(GiftCardBase other)
        {
			if(this.GiftCardId==other.GiftCardId  && this.GiftCardGuid==other.GiftCardGuid  && this.SerialNumber==other.SerialNumber  && this.PurchasedByCustomerId==other.PurchasedByCustomerId  && this.OrderNumber==other.OrderNumber  && this.ShoppingCartRecId==other.ShoppingCartRecId  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.InitialAmount==other.InitialAmount  && this.Balance==other.Balance  && this.StartDate==other.StartDate  && this.ExpirationDate==other.ExpirationDate  && this.GiftCardTypeId==other.GiftCardTypeId  && this.EmailName==other.EmailName  && this.EmailTo==other.EmailTo  && this.EmailMessage==other.EmailMessage  && this.ValidForCustomers==other.ValidForCustomers  && this.ValidForProducts==other.ValidForProducts  && this.ValidForManufacturers==other.ValidForManufacturers  && this.ValidForCategories==other.ValidForCategories  && this.ValidForSections==other.ValidForSections  && this.DisabledByAdministrator==other.DisabledByAdministrator  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
