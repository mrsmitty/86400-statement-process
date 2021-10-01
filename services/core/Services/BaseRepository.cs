using Services.Core.Interfaces;
using Services.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Core.Services
{
    public abstract class BaseRepository
    {
        internal BankTransactionsContext context;

        public BaseRepository(BankTransactionsContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetItemsAsync<T>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> propertyPath = null) where T : class
        {
            if (propertyPath != null)
            {
                return await context.Set<T>().Where(predicate).Include(propertyPath).ToListAsync();
            }
            else
            {
                return await context.Set<T>().Where(predicate).ToListAsync();
            }
        }

        public async Task AddItemAsync<T>(T item) where T : class
        {
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync<T>(T item) where T : class
        {
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
