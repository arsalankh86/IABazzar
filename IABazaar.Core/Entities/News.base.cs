using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class NewsBase:EntityBase, IEquatable<NewsBase>
	{
			
		[PrimaryKey]
		public System.Int32 NewsId{ get; set; }

		public System.Guid NewsGuid{ get; set; }

		public System.String Headline{ get; set; }

		public System.String NewsCopy{ get; set; }

		public System.DateTime ExpiresOn{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<NewsBase> Members

        public virtual bool Equals(NewsBase other)
        {
			if(this.NewsId==other.NewsId  && this.NewsGuid==other.NewsGuid  && this.Headline==other.Headline  && this.NewsCopy==other.NewsCopy  && this.ExpiresOn==other.ExpiresOn  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
