
using System;
using System.Linq;
using FinanceBackEnd.Infrastructure.Repositories;
using FinanceBackEnd.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinanceBackEnd.Infrastructure
{
    public class TryInvestContext : DbContext 
    {
        public TryInvestContext(DbContextOptions<DataContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var updateData = new UpdateData
            {                
                timestamp = DateTime.Now
            };            

            var entries = ChangeTracker
               .Entries()
               .Where(e =>
               {
                   return e.Entity is IEntityAudit &&
                    (
                        e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted
                    );
               });

            foreach (var entityEntry in entries)
            {
                var audit = (IEntityAudit)entityEntry.Entity;                

                if (entityEntry.State == EntityState.Added)
                {
                    if (audit != null)
                    {
                        //audit.created_id = updateData.user.Id;
                        audit.created_at = updateData.timestamp;
                    }
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    if (audit != null)
                    {                        
                        audit.updated_at = updateData.timestamp;
                    }

                    var deletable = (ISoftDeletable)entityEntry.Entity;

                    if (deletable != null && deletable.deleted)
                    {
                        SoftDelete(entityEntry, updateData);
                    }
                }
                else if (entityEntry.State == EntityState.Deleted)
                {
                    SoftDelete(entityEntry, updateData);
                }
            }

            return base.SaveChanges();
        }

        private void SoftDelete(
            EntityEntry entityEntry,
            UpdateData updateData)
        {
            var deletable = (ISoftDeletable)entityEntry.Entity;

            if(deletable != null)
            {
                entityEntry.State = EntityState.Unchanged;
                deletable.deleted = true;

                SoftCascade(entityEntry, updateData);
            }

            var audit = (IEntityAudit)entityEntry.Entity;

            if (audit != null)
            {
                //audit.deleted_id = updateData.user.Id;
                audit.deleted_at = updateData.timestamp;
            }
        }

        private void SoftCascade(
            EntityEntry entityEntry,
            UpdateData updateData)
        {
            // var dependentes = entityEntry.Navigations.Where(navigations =>                 
            // !navigations.Metadata.IsDependentToPrincipal());

            // foreach (var dependente in dependentes)
            // {
            //     if (dependente is CollectionEntry collectionEntry)
            //     {
            //         foreach (var dependentEntry in collectionEntry.CurrentValue)
            //         {
            //             SoftDelete(Entry(dependentEntry), updateData);
            //         }
            //     }
            //     else
            //     {
            //         var dependentEntry = dependente.CurrentValue;
            //         if (dependentEntry != null)
            //         {
            //             SoftDelete(Entry(dependentEntry), updateData);
            //         }
            //     }
            // }
        }

        private struct UpdateData
        {
            public DateTime timestamp;
        }
    }
}