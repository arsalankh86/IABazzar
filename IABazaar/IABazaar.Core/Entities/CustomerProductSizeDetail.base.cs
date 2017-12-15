using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomerProductSizeDetailBase:EntityBase, IEquatable<CustomerProductSizeDetailBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomerProductSize{ get; set; }

		public System.Int32? CustomerId{ get; set; }

		public System.Int32? ProductId{ get; set; }

		public System.String Email{ get; set; }

		public System.String Bustchest{ get; set; }

		public System.String Waist{ get; set; }

		public System.String Shoulder{ get; set; }

		public System.String Hip{ get; set; }

		public System.String Neckwidth{ get; set; }

		public System.String Sleevesstyle{ get; set; }

		public System.String Trouserstyle{ get; set; }

		public System.String Shirtstyle{ get; set; }

		public System.String Heightfeet{ get; set; }

		public System.String Stichinginstructions{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomerProductSizeDetailBase> Members

        public virtual bool Equals(CustomerProductSizeDetailBase other)
        {
			if(this.CustomerProductSize==other.CustomerProductSize  && this.CustomerId==other.CustomerId  && this.ProductId==other.ProductId  && this.Email==other.Email  && this.Bustchest==other.Bustchest  && this.Waist==other.Waist  && this.Shoulder==other.Shoulder  && this.Hip==other.Hip  && this.Neckwidth==other.Neckwidth  && this.Sleevesstyle==other.Sleevesstyle  && this.Trouserstyle==other.Trouserstyle  && this.Shirtstyle==other.Shirtstyle  && this.Heightfeet==other.Heightfeet  && this.Stichinginstructions==other.Stichinginstructions )
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
