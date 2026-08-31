using Microsoft.EntityFrameworkCore.Storage;
using MySchool.Application.Interface;
using MySchool.Infrastructure.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Infrastructure.Presistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySchoolContext _context;
        private IDbContextTransaction? _transaction;


        public UnitOfWork(MySchoolContext context)
        {
            _context = context;
        }


        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }


        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }


        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if( _transaction != null)
            {
                await _transaction.CommitAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction= null;
            }
        }
    }
}
