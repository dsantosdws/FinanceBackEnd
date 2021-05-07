using System;

namespace FinanceBackEnd.Models.Entitys 
{
    public interface IEntityAudit 
    {
        int created_id { get; set; }

        DateTime created_at { get; set; }

        int? updated_id { get; set; }

        DateTime? updated_at { get; set; }

        int? deleted_id { get; set; }

        DateTime? deleted_at { get; set; }
    }
}