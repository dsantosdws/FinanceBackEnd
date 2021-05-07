using System;

namespace FinanceBackEnd.Models.Entitys 
{
    public class BaseEntity : IEntityAudit, ISoftDeletable
    {
        public int Id { get; set; }

        // ISoftDeletable

        public bool deleted { get; set; }

        // IEntityAudit

        public int created_id { get; set; }

        public DateTime created_at { get; set; }

        public int? updated_id { get; set; }

        public DateTime? updated_at { get; set; }

        public int? deleted_id { get; set; }

        public DateTime? deleted_at { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseEntity)
            {
                var x = obj as BaseEntity;
                return x.Id.Equals(Id);
            }

            return false;
        }
    }
}