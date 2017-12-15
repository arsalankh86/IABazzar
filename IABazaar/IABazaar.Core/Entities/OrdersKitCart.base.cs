using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrdersKitCartBase:EntityBase, IEquatable<OrdersKitCartBase>
	{
			
		public System.Int32 OrderNumber{ get; set; }

		public System.Int32 KitCartRecId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.Int32? ProductId{ get; set; }

		public System.Int32? VariantId{ get; set; }

		public System.String ProductName{ get; set; }

		public System.String ProductVariantName{ get; set; }

		public System.Int32? KitGroupId{ get; set; }

		public System.String KitGroupName{ get; set; }

		public System.Byte? KitGroupIsRequired{ get; set; }

		public System.Int32? KitItemId{ get; set; }

		public System.String KitItemName{ get; set; }

		public System.Decimal? KitItemPriceDelta{ get; set; }

		public System.Int32? Quantity{ get; set; }

		public System.Decimal KitItemWeightDelta{ get; set; }

		public System.String TextOption{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Int32 KitGroupTypeId{ get; set; }

		public System.Int32? InventoryVariantId{ get; set; }

		public System.String InventoryVariantColor{ get; set; }

		public System.String InventoryVariantSize{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.Byte KitGroupIsReadOnly{ get; set; }

		public System.Int32 KitItemInventoryQuantityDelta{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrdersKitCartBase> Members

        public virtual bool Equals(OrdersKitCartBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.KitCartRecId==other.KitCartRecId  && this.CustomerId==other.CustomerId  && this.ShoppingCartRecId==other.ShoppingCartRecId  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.ProductName==other.ProductName  && this.ProductVariantName==other.ProductVariantName  && this.KitGroupId==other.KitGroupId  && this.KitGroupName==other.KitGroupName  && this.KitGroupIsRequired==other.KitGroupIsRequired  && this.KitItemId==other.KitItemId  && this.KitItemName==other.KitItemName  && this.KitItemPriceDelta==other.KitItemPriceDelta  && this.Quantity==other.Quantity  && this.KitItemWeightDelta==other.KitItemWeightDelta  && this.TextOption==other.TextOption  && this.ExtensionData==other.ExtensionData  && this.KitGroupTypeId==other.KitGroupTypeId  && this.InventoryVariantId==other.InventoryVariantId  && this.InventoryVariantColor==other.InventoryVariantColor  && this.InventoryVariantSize==other.InventoryVariantSize  && this.CreatedOn==other.CreatedOn  && this.CartType==other.CartType  && this.KitGroupIsReadOnly==other.KitGroupIsReadOnly  && this.KitItemInventoryQuantityDelta==other.KitItemInventoryQuantityDelta )
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
