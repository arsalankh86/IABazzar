using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class KitCartBase:EntityBase, IEquatable<KitCartBase>
	{
			
		[PrimaryKey]
		public System.Int32 KitCartRecId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Int32 KitGroupId{ get; set; }

		public System.Int32 KitGroupTypeId{ get; set; }

		public System.Int32 KitItemId{ get; set; }

		public System.Int32 Quantity{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.Int32? OriginalRecurringOrderNumber{ get; set; }

		public System.String TextOption{ get; set; }

		public System.Int32? InventoryVariantId{ get; set; }

		public System.String InventoryVariantColor{ get; set; }

		public System.String InventoryVariantSize{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<KitCartBase> Members

        public virtual bool Equals(KitCartBase other)
        {
			if(this.KitCartRecId==other.KitCartRecId  && this.CustomerId==other.CustomerId  && this.ShoppingCartRecId==other.ShoppingCartRecId  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.KitGroupId==other.KitGroupId  && this.KitGroupTypeId==other.KitGroupTypeId  && this.KitItemId==other.KitItemId  && this.Quantity==other.Quantity  && this.CartType==other.CartType  && this.OriginalRecurringOrderNumber==other.OriginalRecurringOrderNumber  && this.TextOption==other.TextOption  && this.InventoryVariantId==other.InventoryVariantId  && this.InventoryVariantColor==other.InventoryVariantColor  && this.InventoryVariantSize==other.InventoryVariantSize  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
