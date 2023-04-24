using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorkDesign
{
    public class UnitOfWork: IUnitOfWork
    {
        public PersonelTakipSistemiContext Context { get; internal set; }
        private bool isTransaction { get; set; }

        public UnitOfWork(PersonelTakipSistemiContext context)
        {
            Context = context;
        }
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
            isTransaction = true;
        }

        public void Commit()
        {
            Context.Database.CommitTransaction();
            isTransaction = false;
        }

        public void Rollback()
        {
            Context.Database.RollbackTransaction();
            isTransaction = false;
        }

        public bool IsTransactionContinue()
        {
            return isTransaction;
        }
    }
}
