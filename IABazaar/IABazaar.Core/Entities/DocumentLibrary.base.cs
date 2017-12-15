using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class DocumentLibraryBase:EntityBase, IEquatable<DocumentLibraryBase>
	{
			
		public System.Int32 DocumentId{ get; set; }

		public System.Int32 LibraryId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<DocumentLibraryBase> Members

        public virtual bool Equals(DocumentLibraryBase other)
        {
			if(this.DocumentId==other.DocumentId  && this.LibraryId==other.LibraryId  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
