using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class GalleryBase:EntityBase, IEquatable<GalleryBase>
	{
			
		[PrimaryKey]
		public System.Int32 GalleryId{ get; set; }

		public System.Guid GalleryGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String DirName{ get; set; }

		public System.String Description{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<GalleryBase> Members

        public virtual bool Equals(GalleryBase other)
        {
			if(this.GalleryId==other.GalleryId  && this.GalleryGuid==other.GalleryGuid  && this.Name==other.Name  && this.DirName==other.DirName  && this.Description==other.Description  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
