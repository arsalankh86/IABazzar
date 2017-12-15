using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SearchLogBase:EntityBase, IEquatable<SearchLogBase>
	{
			
		public System.String SearchTerm{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.String LocaleSetting{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SearchLogBase> Members

        public virtual bool Equals(SearchLogBase other)
        {
			if(this.SearchTerm==other.SearchTerm  && this.CustomerId==other.CustomerId  && this.CreatedOn==other.CreatedOn  && this.LocaleSetting==other.LocaleSetting )
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
