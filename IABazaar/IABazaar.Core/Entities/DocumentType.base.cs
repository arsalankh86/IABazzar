using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class DocumentTypeBase:EntityBase, IEquatable<DocumentTypeBase>
	{
			
		[PrimaryKey]
		public System.Int32 DocumentTypeId{ get; set; }

		public System.Guid DocumentTypeGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<DocumentTypeBase> Members

        public virtual bool Equals(DocumentTypeBase other)
        {
			if(this.DocumentTypeId==other.DocumentTypeId  && this.DocumentTypeGuid==other.DocumentTypeGuid  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
