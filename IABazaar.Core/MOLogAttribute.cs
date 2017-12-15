using System;

namespace IABazaar.Core
{

    public enum AuditOperations
    {
        Create,
        Update,
        Delete,
        Get,
        GetAll
    }
    public class MOLogAttribute:Attribute
    {
        public MOLogAttribute(AuditOperations operation,Type entityType)
        {
            this.EntityType = entityType;
            this.Operation = operation;
        }

        public Type EntityType { get; set; }
        public AuditOperations Operation { get; set; }
    }
}

