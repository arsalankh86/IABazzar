using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrdersCustomCartBase:EntityBase, IEquatable<OrdersCustomCartBase>
	{
			
		public System.Int32 OrderNumber{ get; set; }

		public System.Int32 CustomCartRecId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32? PackId{ get; set; }

		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.String ProductSku{ get; set; }

		public System.String ProductName{ get; set; }

		public System.String ProductVariantName{ get; set; }

		public System.Decimal? ProductWeight{ get; set; }

		public System.Int32? ProductId{ get; set; }

		public System.Int32? VariantId{ get; set; }

		public System.Int32? Quantity{ get; set; }

		public System.String ChosenColor{ get; set; }

		public System.String ChosenColorSkuModifier{ get; set; }

		public System.String ChosenSize{ get; set; }

		public System.String ChosenSizeSkuModifier{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrdersCustomCartBase> Members

        public virtual bool Equals(OrdersCustomCartBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.CustomCartRecId==other.CustomCartRecId  && this.CustomerId==other.CustomerId  && this.PackId==other.PackId  && this.ShoppingCartRecId==other.ShoppingCartRecId  && this.ProductSku==other.ProductSku  && this.ProductName==other.ProductName  && this.ProductVariantName==other.ProductVariantName  && this.ProductWeight==other.ProductWeight  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.Quantity==other.Quantity  && this.ChosenColor==other.ChosenColor  && this.ChosenColorSkuModifier==other.ChosenColorSkuModifier  && this.ChosenSize==other.ChosenSize  && this.ChosenSizeSkuModifier==other.ChosenSizeSkuModifier  && this.CartType==other.CartType  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
