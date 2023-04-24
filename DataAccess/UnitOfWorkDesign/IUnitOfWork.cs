using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorkDesign
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        void Commit();
        void Rollback();
        bool IsTransactionContinue();
    }
}
