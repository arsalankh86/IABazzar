using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomerLevelBase:EntityBase, IEquatable<CustomerLevelBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomerLevelId{ get; set; }

		public System.Guid CustomerLevelGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Decimal LevelDiscountPercent{ get; set; }

		public System.Decimal LevelDiscountAmount{ get; set; }

		public System.Byte LevelHasFreeShipping{ get; set; }

		public System.Byte LevelAllowsQuantityDiscounts{ get; set; }

		public System.Byte LevelHasNoTax{ get; set; }

		public System.Byte LevelAllowsCoupons{ get; set; }

		public System.Byte LevelDiscountsApplyToExtendedPrices{ get; set; }

		public System.Byte LevelAllowsPo{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Int32 ParentCustomerLevelId{ get; set; }

		public System.String SeName{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String TemplateName{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomerLevelBase> Members

        public virtual bool Equals(CustomerLevelBase other)
        {
			if(this.CustomerLevelId==other.CustomerLevelId  && this.CustomerLevelGuid==other.CustomerLevelGuid  && this.Name==other.Name  && this.LevelDiscountPercent==other.LevelDiscountPercent  && this.LevelDiscountAmount==other.LevelDiscountAmount  && this.LevelHasFreeShipping==other.LevelHasFreeShipping  && this.LevelAllowsQuantityDiscounts==other.LevelAllowsQuantityDiscounts  && this.LevelHasNoTax==other.LevelHasNoTax  && this.LevelAllowsCoupons==other.LevelAllowsCoupons  && this.LevelDiscountsApplyToExtendedPrices==other.LevelDiscountsApplyToExtendedPrices  && this.LevelAllowsPo==other.LevelAllowsPo  && this.DisplayOrder==other.DisplayOrder  && this.ParentCustomerLevelId==other.ParentCustomerLevelId  && this.SeName==other.SeName  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName )
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
